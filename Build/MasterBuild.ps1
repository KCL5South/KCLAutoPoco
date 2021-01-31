Include .\UpdateAssemblyInfo.ps1

Properties {
	if(-Not (Test-Path Variable:\UpdateBuildNumber))
	{
		New-Item Variable:\UpdateBuildNumber -Value $false | out-null
	}
	if(-Not (Test-Path Variable:\DoxygenOutput))
	{
		New-Item Variable:\DoxygenOutput -Value "..\Documentation" | out-null
	}
	if(-Not (Test-Path Variable:\BuildNumber))
	{
		New-Item Variable:\BuildNumber -Value 0 | out-null
	}
	if(-Not (Test-Path Variable:\BuildDescription))
	{
		New-Item Variable:\BuildDescription -Value "Test Build Description" | out-null
	}
	if(-Not (Test-Path Variable:\NuGetApiKey))
	{
		New-Item Variable:\NuGetApiKey -Value "Not the API Key" | out-null
	}

	Assert($UpdateBuildNumber -is [System.Boolean]) "The property UpdateBuildNumber must be a boolean value."
	Assert($DoxygenOutput -is [System.String]) "The property DoxygenOutput must be a string value."
	Assert($BuildNumber -is [System.Int32]) "The property BuildNumber must be an Int32 value."
	Assert($BuildDescription -is [System.String]) "The property BuildDescription must be a string value."
	Assert($NuGetApiKey -is [System.String]) "The property NuGetApiKey must be a string value."
}

Task default -Depends Debug

Task Debug -Depends	Task_RunPesterTests, Task-ResolveDependencies, Task-UpdateAssemblyInfo, Debug_Build, Debug_RunNUnitTests
Task Release -Depends Task_RunPesterTests, Task-ResolveDependencies, Task-UpdateAssemblyInfo, Release_Build, Release_RunNUnitTests
Task Full -Depends	Release, `
					Task-BuildDocumentation

#-------------------------------
#	Run Pester Tests
#-------------------------------
Task Task_RunPesterTests {
	Invoke-Pester -Output Detailed -CI
	$testResults = [xml](get-content testResults.xml)
	
	if(Test-Path testResults.xml)
	{
		Remove-Item testResults.xml
	}
	
	if(@($testResults | select-xml "//*/test-suite[descendant::failure]").Length -gt 0)
	{
		throw "Pester Tests Failed"
	}
}

#-------------------------------
#	Resolve Dependencies	
#-------------------------------
Task Task-ResolveDependencies {
	Exec {
		nuget install 	packages.config `
						-OutputDirectory ..\packages `
						-NoCache `
						-NonInteractive `
						-Verbosity detailed
	}
}

#-------------------------------
#	Assembly Info Update.
#-------------------------------
Task Task-UpdateAssemblyInfo {
	Assert(Test-Path Variable:\BuildDescription) "You must define the build Description before executing this task."
	Assert(Test-Path Variable:\BuildNumber) "You must define the build number before executing this task."
	
	Set-AssemblyAttributes (resolve-path "..\AutoPoco\Properties\AssemblyInfo.cs") $buildDescription $buildNumber
	Set-AssemblyAttributes (resolve-path "..\AutoPoco.KCL\Properties\AssemblyInfo.cs") $buildDescription $buildNumber
} -PreCondition {
	$UpdateBuildNumber -eq $true
}

#-------------------------------
#	Build
#-------------------------------
Task Debug_Build {
	Exec {
		msbuild ..\AutoPoco.sln /P:Configuration=DEBUG /P:VisualStudioVersion=12.0
	}
}
Task Release_Build {
	Exec {
		msbuild ..\AutoPoco.sln /P:Configuration=RELEASE /P:VisualStudioVersion=12.0
	}
}

#-------------------------------
#	Run Tests
#-------------------------------
Task Debug_RunNUnitTests {
	Exec {
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.Tests.Integration\bin\debug\AutoPoco.Tests.Integration.dll /xml=AutoPoco.Tests.Integration.TestResults.xml /nologo
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.Tests.Unit\bin\debug\AutoPoco.Tests.Unit.dll /xml=AutoPoco.Tests.Unit.TestResults.xml /nologo
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.KCL.Tests.Unit\bin\debug\AutoPoco.KCL.Tests.Unit.dll /xml=AutoPoco.Tests.Unit.TestResults.xml /nologo
	}
}
Task Release_RunNUnitTests {
	Exec {
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.Tests.Integration\bin\release\AutoPoco.Tests.Integration.dll /xml=AutoPoco.Tests.Integration.TestResults.xml /nologo
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.Tests.Unit\bin\release\AutoPoco.Tests.Unit.dll /xml=AutoPoco.Tests.Unit.TestResults.xml /nologo
		..\packages\NUnit.Runners.2.6.2\tools\Nunit-console.exe ..\AutoPoco.KCL.Tests.Unit\bin\release\AutoPoco.KCL.Tests.Unit.dll /xml=AutoPoco.Tests.Unit.TestResults.xml /nologo
	}
}

#-------------------------------
#	Build Documentation
#-------------------------------
Task Task-BuildDocumentation {
	Assert(Test-Path Variable:\DoxygenOutput) "You must define 'DoxygenOutput' in order to run this task."
	Assert(Test-Path Variable:\BuildNumber) "You must define 'BuildNumber' in order to run this task."
	$doxyFile = @((gc master.doxyfile), "OUTPUT_DIRECTORY = ""$DoxygenOutput""", "PROJECT_NUMBER = $BuildNumber", "HTML_OUTPUT = ""$DoxygenOutput""")

	Exec { 
		$doxyFile | Doxygen -
	}
}

#-------------------------------
#	NuGetPackage
#-------------------------------
Task Task-BuildNuGetPackage {
	$version = [Reflection.Assembly]::LoadFile((Resolve-Path ..\AutoPoco\Bin\Release\AutoPoco.dll)).GetName().version
	nuget pack .\KCLAutoPoco.nuspec -Version $version.ToString()
}
Task Task-DeployNuGetPackage {
	Assert(Test-Path Variable:\NuGetApiKey) "The Variable `$NuGetApiKey must be defined"
	get-childItem *.nupkg | foreach { nuget push $_.FullName -s http://www.ikclife.com/KCLNuGetFeed/ $NuGetApiKey }
}
Task Task-CleanUpNuGetPackages {
	del *.nupkg
}
Task Task-NuGetPackage -depends Task_RunPesterTests, Task-BuildNuGetPackage, Task-DeployNuGetPackage, Task-CleanUpNuGetPackages
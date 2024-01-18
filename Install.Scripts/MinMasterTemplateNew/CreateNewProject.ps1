# Initialize variables
$RepoDir = Resolve-Path "..\.."
$TemplateDir = Resolve-Path ".\Templates"
$SourceDir = Resolve-Path "$RepoDir\Source"

# Create new Alternet UI project
# ask for project name
$projectName = Read-Host -Prompt 'Enter project name '
$projectName = $projectName.Trim()

# ask path for new project
$projectPath = Read-Host -Prompt 'Enter project path '
$projectPath = $projectPath.Trim()
$projectPath = "$projectPath\$projectName"

# ask .NET8.0 or Framework 4.8
$netVersion = Read-Host -Prompt 'Enter .NET version (net8.0 or net48) '
$netVersion = $netVersion.Trim()

# copy Nuget.config.txt to new project path
# create $projectPath if not exit
if(!(Test-Path -Path $projectPath)) {
	New-Item -ItemType directory -Path $projectPath
}

Write-Host " "
Write-Host "################################################################################"
Write-Host "          Creation of Nuget packages in progress. Please wait...."
Write-Host "################################################################################"
Write-Host " "

# Clean Template folder
Write-Host " "
Write-Host "Clean Template folder"
Write-Host " "
Get-ChildItem -Path "$TemplateDir\LocalPackages" -Recurse | Remove-Item -Force -Recurse

# Copy script to build Windows nuget packages
Write-Host " "
Write-Host "Copy script to build Windows nuget packages"
Write-Host " "
Copy-Item -Path "$TemplateDir\NugetBuild\*.*" -Destination "$SourceDir\Build\Alternet.UI.Pal\"

#Build Nuget packages 
Write-Host " "
Write-Host "Build nuget packages"
Write-Host " "
cd "$SourceDir\Alternet.UI"
dotnet msbuild -t:pack
dotnet msbuild /t:Nuget "$RepoDir\Install.Scripts\.\..\Source\Build\Alternet.UI.Pal\Alternet.UI.Pal.Partial.proj"

# Remove script to build Windows nuget packages
Remove-Item "$SourceDir\Build\Alternet.UI.Pal\Alternet.UI.Pal.NuGet.Partial.targets"
Remove-Item "$SourceDir\Build\Alternet.UI.Pal\Alternet.UI.Pal.Partial.proj"

# Start build Local Nuget Packages
cd $TemplateDir
cd ..

if(!(Test-Path -Path $TemplateDir\LocalPackages)) {
    New-Item -ItemType directory -Path $TemplateDir\LocalPackages
}

Copy-Item -Path "$SourceDir\Build\Alternet.UI.Pal\NuGet\*.nupkg" -Destination "$TemplateDir\LocalPackages"
Copy-Item -Path "$SourceDir\Alternet.UI\bin\Debug\*.nupkg" -Destination "$TemplateDir\LocalPackages"


$anuiVersion = ""
$files = Get-ChildItem -Path $TemplateDir\LocalPackages
foreach ($file in $files) {
    if ($file.Name -like "Alternet.UI.Pal.*") {
        $anuiVersion=$file.Name -replace "Alternet.UI.Pal.", ""
		# 
		# $creationTime = $file.CreationTime
		# $horoDate = $creationTime.ToString("_yyyyMMdd_HHmmss")
		# $anuiVersion=$anuiVersion -replace ".nupkg", $horoDate
		$anuiVersion=$anuiVersion -replace ".nupkg", ""
	}
}
Write-Host "ANUI Version : $anuiVersion"

# foreach ($file in $files) {
	# $newName=$file -replace ".nupkg", "$anuiVersion.nupkg"
	# Move-Item "$TemplateDir\LocalPackages\$file" "$TemplateDir\LocalPackages\$newName"
# }


# Get all zip files in the directory
$nugFiles = Get-ChildItem -Path "$TemplateDir\LocalPackages" -Filter *.nupkg

# Decompress each zip file
foreach ($nugFile in $nugFiles) {
	# Get Nuget file info
	$fileInfo = Get-Item "$TemplateDir\LocalPackages\$nugFile"	

	# Check if file name contains ".PAL"
	if ($fileInfo -notmatch ".PAL") {
	# Rename nupkg file to zip file
	$newFilePath = $fileInfo.DirectoryName + "\" + $fileInfo.BaseName + ".zip"
	Move-Item -Path $fileInfo -Destination $newFilePath
	  
	# Unzip the file 
	$zipDestDir = [IO.Path]::GetFileNameWithoutExtension($newFilePath)
	Expand-Archive -Path $newFilePath -DestinationPath "$TemplateDir\LocalPackages\$zipDestDir"
	
	
		Remove-Item "$TemplateDir\LocalPackages\$zipDestDir.zip"
		# Copy tools to folders
		New-Item -ItemType directory -Path "$TemplateDir\LocalPackages\$zipDestDir\tools\netstandard2.0"
		Copy-Item -Path "$SourceDir\Alternet.UI.Build.Tasks\bin\Debug\netstandard2.0\Alternet.UI.Build.Tasks.dll" -Destination "$TemplateDir\LocalPackages\$zipDestDir\tools\netstandard2.0\"
		
		# Get the items in the source folder
		$items = Get-ChildItem -Path "$TemplateDir\LocalPackages\$zipDestDir"

		Start-Sleep -Seconds 3
		# Compress the items into the zip file without keeping the source folder name
		Compress-Archive -Force -Path $items.FullName -DestinationPath "$TemplateDir\LocalPackages\$zipDestDir.zip"
		Move-Item -Path "$TemplateDir\LocalPackages\$zipDestDir.zip" -Destination "$TemplateDir\LocalPackages\$zipDestDir.nupkg"
		Remove-Item -LiteralPath "$TemplateDir\LocalPackages\$zipDestDir" -Force -Recurse 
	}
	
}


Copy-Item -Path "$templateDir\Nuget.config.txt" -Destination "$projectPath\Nuget.config"
Copy-Item -Path "$templateDir\Sample.csproj.txt" -Destination "$projectPath\$projectName.csproj"

# copy $SourceDir/Integration/Templates/CSharp/Application/MainWindow.uixml to new project path
Copy-Item -Path "$SourceDir\Integration\Templates\CSharp\Application\program.cs" -Destination "$projectPath\program.cs"
Copy-Item -Path "$SourceDir\Integration\Templates\CSharp\Application\MainWindow.uixml" -Destination "$projectPath\MainWindow.uixml"
Copy-Item -Path "$SourceDir\Integration\Templates\CSharp\Application\MainWindow.uixml.cs" -Destination "$projectPath\MainWindow.uixml.cs"

# copy content of $TemplateDir\LocalPackages to new project path
if(!(Test-Path -Path "$projectPath\LocalPackages")) {
    New-Item -ItemType directory -Path "$projectPath\LocalPackages"
}
Copy-Item -Path "$templateDir\LocalPackages\*" -Destination "$projectPath\LocalPackages\" -Recurse


# In $projectName.csproj and program.cs and MainWindow.uixml and MainWindow.uixml.cs replace "Alternet.UI.Templates.Application.CSharp" by "$projectName"
(Get-Content "$projectPath\$projectName.csproj") | Foreach-Object {$_ -replace "Alternet.UI.Templates.Application.CSharp", "$projectName"} | Set-Content "$projectPath\$projectName.csproj"
(Get-Content "$projectPath\program.cs") | Foreach-Object {$_ -replace "Alternet.UI.Templates.Application.CSharp", $projectName} | Set-Content "$projectPath\program.cs"
(Get-Content "$projectPath\MainWindow.uixml") | Foreach-Object {$_ -replace "Alternet.UI.Templates.Application.CSharp", $projectName} | Set-Content "$projectPath\MainWindow.uixml"
(Get-Content "$projectPath\MainWindow.uixml.cs") | Foreach-Object {$_ -replace "Alternet.UI.Templates.Application.CSharp", $projectName} | Set-Content "$projectPath\MainWindow.uixml.cs"



# In "$projectPath\$projectName.csproj" replace "net6.0" by "net8.0"
(Get-Content "$projectPath\$projectName.csproj") | Foreach-Object {$_ -replace "net8.0;net48", $netVersion} | Set-Content "$projectPath\$projectName.csproj"

# In "$projectPath\$projectName.csproj" replace "X.X.X" by $anuiVersion
(Get-Content "$projectPath\$projectName.csproj") | Foreach-Object {$_ -replace "X.X.X", $anuiVersion} | Set-Content "$projectPath\$projectName.csproj"

Write-Host " "
Write-Host " "
Write-Host "################################################################################"
Write-Host " Project successfull created here : $projectPath"
Write-Host "################################################################################"

# Initialize variables
$RepoDir = Resolve-Path "..\.."
$TemplateDir = Resolve-Path ".\Templates"
$SourceDir = Resolve-Path "$RepoDir\Source"

# ask path for new project
$projectPath = Read-Host -Prompt 'Enter project path '
$projectPath = $projectPath.Trim()

if (!(Test-Path $projectPath)) {
	Write-Host "Error : folder $projectPath not exist !"
	return
}


$projectName=Get-ChildItem -Path $projectPath -Filter *.csproj 

Remove-Item "$projectPath\LocalPackages\Alternet.UI.*.nupkg"

Remove-Item "$SourceDir\Alternet.UI\bin\Debug\*.nupkg"
Remove-Item "$SourceDir\Build\Alternet.UI.Pal\NuGet\*.nupkg"

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
		$anuiVersion=$anuiVersion -replace ".nupkg", ""
	}
}
Write-Host "ANUI Version : $anuiVersion"

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

# copy content of $TemplateDir\LocalPackages to new project path
if(!(Test-Path -Path "$projectPath\LocalPackages")) {
    New-Item -ItemType directory -Path "$projectPath\LocalPackages"
}
Copy-Item -Path "$templateDir\LocalPackages\*" -Destination "$projectPath\LocalPackages\" -Recurse

# In .csproj file replace old version by new $anuiVersion
#$pattern = '`" Version="[^"]*"'
$pattern = '" Version="[^"]*"'
#(Get-Content "$projectPath\$projectName") | Foreach-Object {$_ -replace $pattern,"`" Version=`"$anuiVersion`""} | Set-Content "$projectPath\$projectName"
(Get-Content "$projectPath\$projectName") | Foreach-Object {
    if ($_ -match "Alternet") {
        $_ -replace $pattern,"`" Version=`"$anuiVersion`""
    } else {
        $_
    }
} | Set-Content "$projectPath\$projectName"

Write-Host " "
Write-Host " "
Write-Host "################################################################################"
Write-Host " Project successfull updated here : $projectPath"
Write-Host "################################################################################"

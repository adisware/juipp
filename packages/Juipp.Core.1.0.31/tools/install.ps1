param($installPath, $toolsPath, $package, $project)

$path10 = "`$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\TextTemplating\v10.0\Microsoft.TextTemplating.targets"
$path11 = "`$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\TextTemplating\v11.0\Microsoft.TextTemplating.targets"


$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
$importElement = $msbuild.Xml.AddImport($path10)
$importElement.Condition = "Exists('" + $path10 + "')"
$importElement = $msbuild.Xml.AddImport($path11)
$importElement.Condition = "Exists('" + $path11 + "')"

$propertyGroup = $msbuild.Xml.AddPropertyGroup()
$propertyGroup.Label = 'AdiswareJuippT4Properties'

$propertyGroup.AddProperty('TransformOnBuild', 'true')
$propertyGroup.AddProperty('OverwriteReadOnlyOuputFiles', 'true')
$propertyGroup.AddProperty('TransformOutOfDateOnly', 'false')

$project.Save()

Write-Host "Added Imports for T4"
Write-Host "Added Property Group > AdiswareJuippT4Properties"
Write-Host "Added Property > 'TransformOnBuild', 'true'"
Write-Host "Added Property > 'OverwriteReadOnlyOuputFiles', 'true'"
Write-Host "Added Property > 'TransformOutOfDateOnly', 'TransformOutOfDateOnly'"


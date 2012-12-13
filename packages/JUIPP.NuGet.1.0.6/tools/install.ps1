param($installPath, $toolsPath, $package, $project)

$path = "`$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\TextTemplating\v10.0\Microsoft.TextTemplating.targets"



$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
$msbuild.Xml.AddImport($path)

$propertyGroup = $msbuild.Xml.AddPropertyGroup()
$propertyGroup.Label = 'AdiswareJuippT4Properties'

$propertyGroup.AddProperty('TransformOnBuild', 'true')
$propertyGroup.AddProperty('OverwriteReadOnlyOuputFiles', 'true')
$propertyGroup.AddProperty('TransformOutOfDateOnly', 'false')

$project.Save()

Write-Host "AddImport(`$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\TextTemplating\v10.0\Microsoft.TextTemplating.targets)"
Write-Host "AddPropertyGroup() Label = AdiswareJuippT4Properties"
Write-Host "AddProperty('TransformOnBuild', 'true')"
Write-Host "AddProperty('OverwriteReadOnlyOuputFiles', 'true')"
Write-Host "AddProperty('TransformOutOfDateOnly', 'TransformOutOfDateOnly')"
Write-Host "project Save()"

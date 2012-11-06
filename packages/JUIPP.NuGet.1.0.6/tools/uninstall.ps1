param($installPath, $toolsPath, $package, $project)

$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

$importToRemove = $msbuild.Xml.Imports | Where-Object { $_.Project.Endswith('Microsoft.TextTemplating.targets') }
$msbuild.Xml.RemoveChild($importToRemove) | out-null

$propertyGroupToRemove = $msbuild.Xml.PropertyGroups | Where-Object { $_.Label -eq 'AdiswareJuippT4Properties' } | Select-Object -First 1
$msbuild.Xml.RemoveChild($propertyGroupToRemove) | out-null

$project.Save()


Write-Host "Remove Import - (`$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\TextTemplating\v10.0\Microsoft.TextTemplating.targets)"
Write-Host "Remove Property Group - Label = AdiswareJuippT4Properties"
Write-Host "project Save()"




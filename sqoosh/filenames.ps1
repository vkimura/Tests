$arrPhotoNamesInDir = Get-ChildItem -Path . -Recurse -Include *jpg,*png,*svg -Name
foreach ($fileName in $arrPhotoNamesInDir)
{
	Write-Host $fileName
}
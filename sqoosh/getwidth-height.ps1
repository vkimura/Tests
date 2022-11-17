[void][System.Reflection.Assembly]::LoadWithPartialName("System.Drawing")

Get-ChildItem -Recurse . $originalPath -Include @("*.png", "*.jpg", "*.svg") | % {
	$image = [System.Drawing.Image]::FromFile($_.FullName)
	Write-Host $_.Name
	Write-Host $image.width
	Write-Host $image.height
	$resize50 = ($image.width*.50)
	Write-Host $resize50
	#squoosh-cli --webp "{'quality':75, 'target_size': 250}" --resize "{'width':500}" -d outputDir ./work-at-vcd-image.png
	#[System.IO.Path]::GetFileNameWithoutExtension('D:\LogTest\Newline-FileTest.txt') 
	$fileNoExt = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
	& squoosh-cli --webp "{'quality':75, 'target_size': 250}" --resize "{'width':$resize50}" -d outputDir ./$fileNoExt.png
}
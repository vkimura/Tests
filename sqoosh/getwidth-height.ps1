[void][System.Reflection.Assembly]::LoadWithPartialName("System.Drawing")

#$global:outputDir = $null
$global:outputDir = "outputDir"
$global:curWidth = $null

#return last file in folder
function lastFile() {
	 $lastFile = gci $outputDir | sort LastWriteTime | select -last 1
	 return $lastFile
}

function renameFile($_lastFile,$_lastFileNoExt,$_intWidth,$_lastFileWithExt) {
	Rename-Item -Path $outputDir\$_lastFile -NewName $_lastFileNoExt-$_intWidth$_lastFileWithExt
	#Rename-Item -Path $outputDir\$_lastFile -NewName "test.webp"
}	

$arrWidths = 400,800,1024,1200
#Get-ChildItem -Recurse . $originalPath -Include @("*.png", "*.jpg", "*.svg") | % {
Get-ChildItem -Recurse . $originalPath -Include @("*.jpg") | % {
	
	foreach ($intWidth in $arrWidths) {
		
		#$width = 400
		$image = [System.Drawing.Image]::FromFile($_.FullName)
		Write-Host $_.Name
		Write-Host $image.width
		Write-Host $image.height
		$resize50 = ($image.width*$width)
		Write-Host $resize50
		#squoosh-cli --webp "{'quality':75, 'target_size': 250}" --resize "{'width':500}" -d outputDir ./work-at-vcd-image.png
		#[System.IO.Path]::GetFileNameWithoutExtension('D:\LogTest\Newline-FileTest.txt') 
		$fileNoExt = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
		$fileExt = [System.IO.Path]::GetExtension($_.Name)
		
		#Check if width of photo is greater than the current intWidth to avoid creating an image that is bigger than the original
		if ($image.width -gt $intWidth) {
			& squoosh-cli --webp "{'quality':75, 'target_size': 250}" --resize "{'width':$intWidth}" -d $outputDir ./$fileNoExt$fileExt
		} else {
			break
		}
		
		#Return last file
		$lastFile = lastFile
		$lastFileNoExt = [System.IO.Path]::GetFileNameWithoutExtension($lastFile)
		$lastFileWithExt = [System.IO.Path]::GetExtension($lastFile)
		
		Write-Host "Last file (no ext): " $lastFileNoExt
		
		Start-Sleep -Milliseconds 7000
		
		renameFile $lastFile $lastFileNoExt $intWidth $lastFileWithExt
	}	
}


Function LoopThroughFolder {
    param(
        [string]$FolderPath
    )
    $Folder = Get-ChildItem -Path $FolderPath -Recurse -File
    $Folder | ForEach-Object {
        $File = $_
        $File.FullName
    }
}
Function LoopFileContents {
    Get-Content C:\Users\vkimura\Downloads\6794_SampleCode-Data\FileList.txt | ForEach-Object {
        $file = $_
        # $file
        # $file | Get-Content
        CheckIfFileExists -file $file
        # Write-Output $file
    }
}

Function FileExistenceList{
    param(
        # [Parameter(Mandatory=$true)]
        $fileOutput,
        $file,
        $fileExists
    )
    # $file
    # $file | Get-Content
    $appendedLine = $file,$fileExists
    Add-Content $fileOutput ($appendedLine -join ",")
}

Function CheckIfFileExists {
    Param(
        [Parameter(Mandatory=$true)]
        [string]$file
    )
    # Full path of the file
    # $file = 'c:\temp\important_file.txt'
    # $file = 'C:\Users\vkimura\source\repos\DEFAULT\VCCollege\Files\pages\001-vacc-icon-accreditation-001.png'
    
    $prependFile = "C:\Users\vkimura\source\repos\DEFAULT\VCCollege"
    $fileURL = $prependFile + $file

    #If the file does not exist
    if (-not(Test-Path -Path $fileURL -PathType Leaf)) {
        try {
            # $null = New-Item -ItemType File -Path $fileURL -Force -ErrorAction Stop
            $fileExists = 0
            $fileOutput = "C:\Users\vkimura\Downloads\6794_SampleCode-Data\FileListOutput.txt"
            FileExistenceList $fileOutput $file $fileExists #append to file list - file exists for current file path
            Write-Host "The file [$fileURL] has been created."
        }
        catch {
            throw $_.Exception.Message
        }
    }
    # If the file already exists
    else {
        $fileExists = 1
        $fileOutput = "C:\Users\vkimura\Downloads\6794_SampleCode-Data\FileListOutput.txt"
        FileExistenceList $fileOutput $file $fileExists #append to file list - file does NOT exist for current file path
        #$null = Remove-Item -ItemType File -Path $fileURL -Force -ErrorAction Stop #delete file if it exists
        Write-Host "Cannot create [$fileURL] because a file with that name already exists."
    }
}

LoopFileContents
# CheckIfFileExists -file 'C:\Users\vkimura\source\repos\DEFAULT\VCCollege\Files\pages\001-vacc-icon-accreditation-001.png'


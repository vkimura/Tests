Function Get-BatAvg{
    Param ($Name, $Runs, $Outs)
    $Avg = [int]($Runs / $Outs*100)/100
    Write-Output "$Name's Average = $Avg, $Runs, $Outs"
    }

    Get-BatAvg Bradman 6996 70
    Get-BatAvg Lara 4000 50
    
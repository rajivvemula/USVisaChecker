$reportFile = "report.html"
$jsonFile = "ratingoutput.json"
$outputFile = "report.test.html"

# Read report.html contents
$reportContent = Get-Content -Path $reportFile -Raw

# Read ratingoutput.json contents
$jsonContent = Get-Content -Path $jsonFile -Raw

# Replace the specified string in the report content
$modifiedContent = $reportContent -replace "@RATING_OUTPUT_RAW_ESCAPED_JSON", $jsonContent

# Save the modified content to report.test.html
$modifiedContent | Set-Content -Path $outputFile

Write-Host "Modified report saved as report.test.html."

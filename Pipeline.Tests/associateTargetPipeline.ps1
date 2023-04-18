$runId = $Env:TestRunId
$AccessToken= $Env:ACCESS_TOKEN
$pipelineId= $Env:TARGET_ENV_PIPELINE_ID

write "RunId: ${runId}"
write "pipelineId: ${pipelineId}"
#write "AccessToken: ${AccessToken}"


$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Authorization", "Basic ${AccessToken}")
$response = Invoke-RestMethod "https://dev.azure.com/biberk/biberk/_apis/build/latest/${pipelineId}?api-version=7.0-preview.1" -Method 'GET' -Headers $headers
$buildNumber = $response.buildNumber
$buildId = $response.id

echo "BuildNumber: $buildNumber"


$body = @"
{
    "build":{
        "id": $buildId,
        "name": $buildNumber,
        "url": "https://dev.azure.com/biberk/_apis/build/Builds/${buildId}"
    }
}
"@
echo "request body:"
echo $body
$headers.Add("Content-Type", "application/json")
$response = Invoke-RestMethod "https://dev.azure.com/biberk/biberk/_apis/test/runs/${runId}?api-version=7.0" -Method 'PATCH' -Headers $headers -Body $body
$runName = $response.name
echo "successfully updated ${runName} build reference to ${buildNumber}"
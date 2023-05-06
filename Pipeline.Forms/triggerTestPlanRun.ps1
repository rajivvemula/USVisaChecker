#
# Pre-requisites
# 
# Environment Variables:
# PlanId
# TargetEnvironment (must match release pipeline's stage name & parent suite name on step 1 below)
# TargetReleaseId (release pipeline Id)
# ACCESS_TOKEN (a PAT, pipelines have this already by default)
# ADO_ORG
# ADO_PROJ
#
# 1.) there must be a static suite with the TargetEnvironment name
# 2.) there must exist a children of <TargetEnvironment> suite representing an area (naming doesn't matter)
# 3.) there must exist exist a suite under the suite on step 2 with the actual tests
# 4.) Update release
#  
#


if (-not $Env:PlanId) {
    Write-Error "PlanId environment variable is not set. [Required]"
    exit
}
  
if (-not $Env:TargetEnvironment) {
    Write-Error "TargetEnvironment environment variable is not set. [Required]"
    exit
}

if (-not $Env:TargetReleaseId) {
    Write-Error "TargetReleaseId environment variable is not set. [Required]"
    exit
}
  
if (-not $Env:BEARER_TOKEN -and -not $Env:PAT_TOKEN) {
    Write-Error "BEARER_TOKEN or PAT_TOKEN environment variables not set. [Required]"
    exit
}

if (-not $Env:ADO_ORG) {
    Write-Error "ADO_ORG environment variable is not set. [Required]"
    exit
}

if (-not $Env:ADO_PROJ) {
    Write-Error "ADO_PROJ environment variable is not set. [Required]"
    exit
}


  
# All required environment variables exist, continue with script

  

$planId = $Env:PlanId
$envName = $Env:TargetEnvironment
$BearerToken= $Env:BEARER_TOKEN
$PATToken = $Env:PAT_TOKEN
$definitionId = $Env:TargetReleaseId
$org = $Env:ADO_ORG
$proj = $Env:ADO_PROJ
echo "PlanId: $planId"
echo "EnvName: $envName" 
echo "releaseId: $definitionId" 
echo "org: $org"
echo "proj: $proj" 
#echo "BearerToken: ${BearerToken}"



#
# Retrieving target test points
#
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
if($BearerToken){
    echo "Loaded bearer token"
    $headers.Add("Authorization", "Bearer ${BearerToken}")
}
else {
    echo "Loaded basic token"
    $B64Pat = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes("`:$PATToken"))
    $headers.Add("Authorization", "Basic ${B64Pat}")
}
$headers.Add("Content-Type", "application/json")


$suitesURL = "https://dev.azure.com/$org/$proj/_apis/test/Plans/${planId}/suites?api-version=5.0"
$suitesRes = Invoke-RestMethod $suitesURL -Method 'GET' -Headers $headers
$environmentSuite = $suitesRes.value | Where-Object { $_.name -ieq $envName }

# $testpointIds = @()

$testPointsUrl = "https://dev.azure.com/$org/$proj/_apis/testplan/Plans/${planId}/Suites/$($environmentSuite.id)/TestPoint?api-version=7.0&continuationToken=0%3B1000&isRecursive=true"
$pointsRes = Invoke-RestMethod $testPointsUrl -Method 'GET' -Headers $headers 

$configurationGroups = $pointsRes.value | Group-Object -Property {$_.configuration.id}



# foreach ($point in $pointsRes.value) {
#     $testpointIds += $point.id
# }

echo "configuration groups count: $($configurationGroups.count)"
echo "retrieved target testpoints"

#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------


foreach($configurationGroup in $configurationGroups)
{
$testpointIds =@()

foreach ($point in $configurationGroup.Group) {
    $testpointIds += $point.id
}
echo "testpoint count: $($testpointIds.count)"


#
# Create Test Run
#
$currentDate = Get-Date -Format "M/d/yyyy, h:mm:ss tt"
$createTestRunJson = @"
{
    "name":"SchedulesTestRun $currentDate",
    "automated":true,
    "pointIds": [ $($testpointIds -join ',') ],
    "state":"NotStarted",
    "dtlTestEnvironment":{
        "id":"vstfs://dummy"
    },
    "plan":{
        "id":"$planId"
    },
    "filter":{
        "sourceFilter":"*.dll",
        "testCaseFilter":""
    }
}
"@
$createTestRunObj = ConvertFrom-Json $createTestRunJson

$createTestRunUrl = "https://dev.azure.com/$org/$proj/_apis/test/Runs?api-version=7.0"
$createTestRunRes = Invoke-RestMethod $createTestRunUrl -Method 'POST' -Headers $headers -Body $createTestRunJson
$runId = $createTestRunRes.id

echo "created test run"

#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------


#
# Send release trigger
#
$definitionUrl = "https://vsrm.dev.azure.com/$org/$proj/_apis/release/definitions/${definitionId}?api-version=7.0"
$definitionRes = Invoke-RestMethod $definitionUrl -Method 'GET' -Headers $headers

$buildDefinitionId = $definitionRes.artifacts[0].definitionReference.definition.id
$latestBuild = Invoke-RestMethod "https://dev.azure.com/$org/$proj/_apis/build/latest/${buildDefinitionId}?api-version=7.0-preview.1" -Method 'GET' -Headers $headers

$releaseJson = @"
{
    "artifacts": [
        {
            "alias": "$($definitionRes.artifacts[0].alias)",
            "instanceReference": {
                "name": "$($latestBuild.buildNumber)",
                "id": "$($latestBuild.id)",
                "sourceBranch": "$($latestBuild.sourceBranch)",
                "sourceRepositoryId": "$($latestBuild.repository.id)",
                "sourceRepositoryType": "TfsGit",
                "sourceVersion": "$($latestBuild.sourceVersion)",
                "sourcePullRequestVersion": null,
                "commitMessage": null
            }
        }
    ],
    "definitionId": $definitionId,
    "description": "",
    "isDraft": false,
    "manualEnvironments": [
        "QA",
        "QA2",
        "QAint",
        "Dev1",
        "Dev2",
        "Dev3",
        "Dev4"
    ],
    "environmentsMetadata": [],
    "variables": {},
    "properties": {},
    "reason": 1
}
"@


$releaseObj = ConvertFrom-Json $releaseJson
$releaseRes = Invoke-RestMethod "https://vsrm.dev.azure.com/$org/$proj/_apis/Release/releases?api-version=7.0" -Method 'POST' -Headers $headers -Body $releaseJson
$releaseId = $releaseRes.id
$envObj = $releaseRes.environments | Where-Object { $_.name -ieq $envName }
$environmentId = $envObj.id

echo "sent release trigger" 


#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------

#
# Update test run with release data
#

$updateTestRunJson = @"
{
    "build": {
      "id": "$($latestBuild.id)"
    },
    "releaseEnvironmentUri": "vstfs:///ReleaseManagement/Environment/$environmentId",
    "releaseUri": "vstfs:///ReleaseManagement/Release/$releaseId"
}

"@

$updateTestRunRes = Invoke-RestMethod "https://dev.azure.com/$org/$proj/_apis/test/runs/${runId}?api-version=7.0" -Method 'PATCH' -Headers $headers -Body $updateTestRunJson

#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------

#
# Update release to activate
#
$releaseRes.environments | foreach { $_.deployPhasesSnapshot[0].phaseType = 1 }

# $releaseRes.environments | foreach { $_.variables.'test.RunId'.value = $runId }
# $releaseRes.environments | foreach { $_.variables.'test.RunId'.isSecret = "false" }

$releaseRes.environments | foreach {
    $_.variables | Add-Member -MemberType NoteProperty -Name "test.RunId" -Value (New-Object -TypeName PSObject)
    $_.variables.'test.RunId' | Add-Member -MemberType NoteProperty -Name "value" -Value $runId -Force
    $_.variables.'test.RunId' | Add-Member -MemberType NoteProperty -Name "isSecret" -Value $false -Force
}

echo "RunId: "
echo $($releaseRes.environments[0].variables)
$releaseRes = $releaseRes | ConvertTo-Json -Depth 10
$updatedReleaseRes = Invoke-RestMethod "https://vsrm.dev.azure.com/$org/$proj/_apis/release/releases/${releaseId}?api-version=7.0" -Method 'PUT' -Headers $headers -Body $releaseRes



#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------

#
# Update environment to activate
#
$envUpdateJson = @"
{
    status: 2
}
"@
$environmentUpdateRes = Invoke-RestMethod "https://vsrm.dev.azure.com/$org/$proj/_apis/release/releases/${releaseId}/environments/${environmentId}?api-version=7.0" -Method 'PATCH' -Headers $headers -Body $envUpdateJson

}
#--------------------------------------------------------------------------------------------------------------------------------------
#--------------------------------------------------------------------------------------------------------------------------------------

# Debug
#
# $suitesRes | ConvertTo-Json | Set-Content -Path  "test/01_allSuites.json"
# $envSuite | ConvertTo-Json | Set-Content -Path  "test/02_envSuites.json"
# $suites | ConvertTo-Json | Set-Content -Path    "test/03_targetSuites.json"
# $testpointIds | ConvertTo-Json | Set-Content -Path  "test/04_testPoints.json"
# $releaseJson | ConvertTo-Json | Set-Content -Path  "test/05_Release.json"
# $createTestRunObj | ConvertTo-Json | Set-Content -Path  "test/06_createTestRun.json"
# $latestBuild | ConvertTo-Json | Set-Content -Path  "test/07_latestbuild.json"
# $releaseRes | ConvertTo-Json | Set-Content -Path  "test/08_releaseRes.json"


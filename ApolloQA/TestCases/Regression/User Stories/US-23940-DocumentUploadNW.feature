Feature: US-23940-DocumentUploadNW
User able to upload document and verify document
	

@mytag
Scenario Outline: 01_User navigate Policy deatils page
Given user landed biBerk home page
When user clicks on Policy CTA then user landed Policy grid page
And user clicks on Existing "<Policy Number>" then landed policy details page

Examples: 
| Policy Number |
| 10086         |

Scenario: 02_User upload documents
And user clicks on Documents CTA then user landed documents page
And user clicks on New File CTA then user landed upload page
And user clicks on Browse Your Computer CTA and user upload file
Then user verify document uploaded successfully 
And user logout of biBerk page 

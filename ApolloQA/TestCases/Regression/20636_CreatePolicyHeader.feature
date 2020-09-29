Feature: 20636_CreatePolicyHeader
	Verify Policy header details with expanded mode and collapsed mode

@mytag
Scenario Outline: TC_01 Verify Policy Headers details 
Given user landed biBerk homepage
When user click on Policy CTA then user landed Policy grid page
And user clicks on existing "<Policy Number>" then user landed Policy details page
Then user verify "<Policy Number>", "<Business Name>", "<Status>", "<Effective Date>", "<Expiration Date>", "<Line of Business>", "<Carrier>", "<Agency>", "<Underwriter>","<Products>" and "<Alerts>"


Examples: 
| Policy Number| Business Name | Status         | Effective Date | Expiration Date | Line of Business| Carrier                                     | Agency                | Underwriter        | Products | Alerts |
| 10086        | ACME          | Pre-Submission | 07/13/2020     | 07/13/2021      | Commercial Auto | Berkshire Hathaway Direct Insurance Company | A Master Organization | Unassigned         | N/A      | 0      |
#| 10090       | ACME          | Pre-Submission | 07/13/2020     | 07/13/2021      | Commercial Auto | Berkshire Hathaway Direct Insurance Company | A Master Organization | Unassigned         | N/A      | 0      |
#| 19948       | Hertz         | Bound          | 09/24/2020     | 09/24/2021      | Commercial Auto | Berkshire Hathaway Direct Insurance Company | biBERK                | ApolloTestUserG301 | N/A      | 0      |


Scenario Outline: TC_02 Verify Policy headers details with collapsed view
When user clicks on Chevron CTA then Policy Header should be displayed as collpased view
Then user verify collapsed view "<Policy Number>", "<Business Name>", "<Status>", "<Effective Date>", "<Expiration Date>" and "<Alerts>"

Examples: 
| Policy Number | Business Name | Status         | Effective Date | Expiration Date | Alerts |
| 10086         | ACME          | Pre-Submission | 07/13/2020     | 07/13/2021      | 0      |

Scenario Outline: TC_03 Verify when user navigates any others page Policy haeders should be dsiplayed as collpased view
When user clicks on page then user landed realted page
Then user verify collapsed view "<Policy Number>", "<Business Name>", "<Status>", "<Effective Date>", "<Expiration Date>" and "<Alerts>"

Examples: 
| Policy Number | Business Name | Status         | Effective Date | Expiration Date | Alerts |
| 10086         | ACME          | Pre-Submission | 07/13/2020     | 07/13/2021      | 0      |

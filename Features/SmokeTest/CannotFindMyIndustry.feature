Feature: CannotFindMyIndustry

Verify functionality for when industry is not found

Updated May 2023: US 102054
Updated to include two other scenarios:
- completely deleted their first query and tried another search
- from the first character typed it has been at least 10 seconds

@Unit @Smoke @Regression 
Scenario: Can not Find My Industry Leads to Referral
	Given user starts a quote with:
	| Other Industry 2 | Description | Employees | Location                              | Own or Lease | ZIP Code |
	|    Gold              | Sliver      | 2         | I Run My Business From Property I Own |              | 62704    |
	Then user verifies the appearance of the Refer page due to no LOB
	| Business Name | First Name | Last Name | Email             | Phone      | Website      |
	| mybusiness    | Kirst      | Nast      | knast@yopmail.com | 9194842211 | football.com |

@Unit @Smoke @Regression 
Scenario Outline: Finding Industry by Description Leads to BOP PP
	Given user starts a quote with:
	| Other Industry | Description | Employees | Location                             | Own or Lease | ZIP Code | LOB |
	| Can't find     | <descr>     | 5         |I Run My Business From Property I Own |              | 90012    | BP  |

Examples: 
  | descr       |
  | Handyman    |
  | Restaurant  |
  | Photography |
  | Painting    |
  | Remodel     |

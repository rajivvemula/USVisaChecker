Feature: WC_AutoRecycling_R
Ineligible Quote for Keyword: Auto Recycling
Description: Refer, need to add uninsured subcontractor/1099 pay under towing class code. 
Policy premium exceeds max allowable value for sales/online..
Number of employees : 8
ZIP Code: 70518
Business Operation: I Lease a Space From Others
Included Officer: 1
Business started year: Started 6 years ago
Business Structured: Corporation

@WC @Regression @Referred @LA @Auto
Scenario: WC Auto Recycling gets referred
	Given user starts a quote with:
		| Industry       | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Recycling | 8         | I Lease a Space From Others |              | 70518    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                  |
		| When do you want your policy to start?                                                 |                         |
		| When did you start your business?                                                      | Started 6 years ago     |
		| How is your business structured?                                                       | Corporation             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                   |
		| Do any staff work only in sales?                                                       | no                      |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                      |
		| Business                                                                               | Test Auto XMOD          |
		| Address                                                                                | 220 W 14th St;Broussard |
		| Contact First Name                                                                     | TestF                   |
		| Contact Last Name                                                                      | TestL                   |
		| Email                                                                                  | Test@Test123.com        |
		| Phone                                                                                  | 1231231321              |
		| Business website                                                                       | test.com                |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty         |
		| OneF       | OneL      | Physical Laborer |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                       | Answer                                      |
		| Do you provide towing or roadside assistance?                                                  | Yes - 3rd party or 1099 workers may provide |
		| Do you require all 3rd parties/1099 workers working for you to have certificates of insurance? | No we don't require them to have insurance  |
		| What is the annual pay to 3rd parties or 1099 workers for towing/roadside assistance?          | 40000                                       |
		| Do you engage in the repossession of vehicles?                                                 | no                                          |
		| In the past 3 years how many Workers' Compensation claims were reported?                       | None                                        |
		| Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?       | no                                          |
		| Do you currently have a Workers' Compensation insurance policy in effect?                      | yes                                         |
		| Do you have multiple locations in more than one state?                                         | no                                          |
		| Federal Employer Identification Number (FEIN)                                                  | 63-1212123                                  |
	Then user begins the WC AI page having the FEIN with value 63-1212123
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Auto XMOD          |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
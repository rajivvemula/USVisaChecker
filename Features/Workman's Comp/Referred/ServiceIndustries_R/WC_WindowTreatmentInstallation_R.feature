Feature: WC_WindowTreatmentInstallation_R
Keyword: Window Treatment Installation
Ineligible quote - Credit Rating: Rating is outside allowable range.
Zip Code: 89121
City: Las Vegas
Employee option: 8
Business Operation: I Lease a Space From Others
Payroll: 0
Entity type: Corporation
SSN: 832803691 

@Service @WC @Referred @FL @Regression
Scenario: WC Window Treatment Installation referred due to low credit score linked to SSN
	Given user starts a quote with:
		| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Window Treatment Installation | 8         | I Lease a Space From Others |              | 32091    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                           |
		| When do you want your policy to start?                                                 |                                  |
		| When did you start your business?                                                      | Started 10 years or more ago     |
		| How is your business structured?                                                       | Corporation                      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                            |
		| Are there any employees that never travel to job sites or do any construction work?    | no                               |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                               |
		| Business                                                                               | Credit score linked to SSN refer |
		| Address                                                                                | 701 SE 71st St;Starke            |
		| Contact First Name                                                                     | TestF                            |
		| Contact Last Name                                                                      | TestL                            |
		| Email                                                                                  | Test@Test123.com                 |
		| Phone                                                                                  | 1231233212                       |
		| Business website                                                                       | test.com                         |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| FName      | LName     | yes        | 40000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer    |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None      |
		| Do you perform any work over 30 feet above ground level?                  | no        |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes       |
		| Do you have multiple locations in more than one state?                    | no        |
		| Social Security Number (SSN)                                              | 832803691 |
	Then user begins the WC AI page having the SSN with value 832803691
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                            |
		| Business name      | Credit score linked to SSN refer |
		| Contact first name | TestF                            |
		| Contact last name  | TestL                            |
		| Email              | Test@Test123.com                 |
		| Phone              | 1231233212                       |
		| Business website   | www.TestPartnerCert.com          |
	Then user verifies the refer thank you page appears
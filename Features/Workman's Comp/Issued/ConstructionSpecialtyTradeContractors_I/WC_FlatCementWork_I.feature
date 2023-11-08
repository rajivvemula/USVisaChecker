﻿Feature: WC_FlatCementWork_I

Get quote details, payment and issued policy.
Keyword: Flat Cement Work
Employee option: 3
ZIP code: 70006
Business Structured: LLC
Business Operation: I Lease a Space From Others
Business started year : Started 9 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 

@WC @Issued @Construction @LA @Regression @YourServices
Scenario: WC Flat Cement Work: No Self-Bearing Work policy issued in Louisiana
	Given user starts a quote with:
		| Industry                               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Flat Cement Work: No Self-Bearing Work | 3         | I Lease a Space From Others |              | 70006    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 9 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                       |
		| Are there any employees that never travel to job sites or do any construction work?    | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Celestial Echos             |
		| Address                                                                                | 4901 SAINT MARY ST;Metairie |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name | 
		| Vera       | Angel     | 
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer                   |
		| Do you build any load-bearing concrete walls?                                                                    | no                       |
		| Do you do any masonry work such as manual brick or stone laying?                                                 | no                       |
		| Do you do residential foundation work?                                                                           | no                       |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None                     |
		| Do you perform any work over 30 feet above ground level?                                                         | no                       |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                    | no                       |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no                       |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no                       |
		| Do you do any construction work in New York?                                                                     | no                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | no                       |
		| When was your last policy in effect?                                                                             | Never no prior insurance |
		| Do you have multiple locations in more than one state?                                                           | no                       |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 06-2671064
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| Payment Option      | One Pay Plan           |
		| CC Name             | Celestial Echos        |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | No                     |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
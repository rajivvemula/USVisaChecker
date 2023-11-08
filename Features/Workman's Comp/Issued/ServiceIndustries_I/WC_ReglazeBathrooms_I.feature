﻿Feature: WC_ReglazeBathrooms_I

Issuing a WC Reglaze Bathrooms Issued Policy

@Service @WC @Issued @PA @Regression @YourServices
Scenario: WC Reglaze Bathrooms policy issued for PA
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Reglaze Bathrooms | 3         | I Lease a Space From Others |              | 16213    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                       |
		| Are there any employees that never travel to job sites or do any construction work?    | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Reglaze Bathrooms LLC;CE    |
		| Address                                                                                | 450A Main St;Callensburg    |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                                                                   | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                                                             | no         |
		| Do you do any framing work?                                                                                                                                | no         |
		| Do you do roofing work?                                                                                                                                    | no         |
		| What percentage of work done is drywall or sheetrock installation or repair?                                                                               | 1-25%      |
		| In the past 3 years how many Workers' Compensation claims were reported?                                                                                   | None       |
		| Do you perform any work over 30 feet above ground level?                                                                                                   | no         |
		| Do you do any water damage, fire damage, or mold restoration?                                                                                              | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                                                                         | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business?                                           | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                                                                  | yes        |
		| Do you do any construction work in New York?                                                                                                               | no         |
		| Do you agree to submit proof of insurance claims history, also called loss runs, for the prior 3 years within 30 days of the effective date of the policy? | yes        |
		| Do you have multiple locations in more than one state?                                                                                                     | no         |
		| Federal Employer Identification Number (FEIN)                                                                                                              | 23-1326965 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	Then wc user handles 1 excluded oo with these values:
		| Set Name   |
		| Vera Angel |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Young Mens Christian Association  |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: GL
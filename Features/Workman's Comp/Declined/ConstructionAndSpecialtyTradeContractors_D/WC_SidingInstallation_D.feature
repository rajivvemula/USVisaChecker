Feature: WC_SidingInstallation_D
Ineligible quote - response to carrier question;
Decline Reason: Policy premium exceeds max allowable value for sales/online..
Keyword: Siding Installation
Yes I have Employee
Number of employee : 5
Business Operation: I Lease a Space From Others
Included Officer: 0
Business started year : Started 4 years ago
Business Structured: LLC
The second test on this page declines due to "Payroll is less than Guard Minimum threshold for Bad state."

@Construction @WC @Declined @NC @Regression
Scenario: WC Siding Installation gets declined due premium exceeding max allowable value for sales/online
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Siding Installation | 5         | I Lease a Space From Others |              | 27007    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                |
		| When do you want your policy to start?                                                 |                                       |
		| When did you start your business?                                                      | Started 4 years ago                   |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 45000                                 |
		| Are there employees that do not do any actual physical work but travel to job sites?   | no                                    |
		| Do any employees only do general office work and rarely travel?                        | no                                    |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                    |
		| Business                                                                               | Siding Installation                   |
		| Address                                                                                | 1421 Little Mountain Church Rd;Ararat |
		| Contact First Name                                                                     | TestF                                 |
		| Contact Last Name                                                                      | TestL                                 |
		| Email                                                                                  | Test@Test123.com                      |
		| Phone                                                                                  | 1231231321                            |
		| Business website                                                                       | test.com                              |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| OneF       | OneL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                                                                   | Answer |
		| What percentage of work done is framing (rough carpentry)?                                                                                                 | 60     |
		| Do you ever transport six or more workers in the same vehicle?                                                                                             | no     |
		| Do you do roofing work?                                                                                                                                    | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?                                                                                   | None   |
		| Do you perform any work over 30 feet above ground level?                                                                                                   | yes    |
		| What is the max height, in feet, you work above ground level?                                                                                              | 45     |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                                                              | yes    |
		| What is the max depth, in feet, you work underground?                                                                                                      | 25     |
		| Do you do any water damage, fire damage, or mold restoration?                                                                                              | no     |
		| Do you do any demolition or wrecking of entire buildings or homes?                                                                                         | no     |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business?                                           | no     |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                                                                  | yes    |
		| Do you agree to submit proof of insurance claims history, also called loss runs, for the prior 3 years within 30 days of the effective date of the policy? | yes    |
		| Do you do any construction work in New York?                                                                                                               | yes    |
		| Do you have multiple locations in more than one state?                                                                                                     | no     |
		| Does your business have a state-issued experience modification factor (XMOD)?                                                                              | no     |
	Then user verifies the WC decline page appearance

@Construction @WC @Declined @WI @Regression
Scenario: WC Siding Installation gets declined in WI due to Pay roll under 15K
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Siding Installation | 15        | I Lease a Space From Others |              | 53093    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                           |
		| When do you want your policy to start?                                                 |                                  |
		| When did you start your business?                                                      | Started 2 years ago              |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 12000                            |
		| Are there employees that do not do any actual physical work but travel to job sites?   | no                               |
		| Do any employees only do general office work and rarely travel?                        | no                               |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                               |
		| Business                                                                               | Wisconsin Siding Installations   |
		| Contact First Name                                                                     | TestF                            |
		| Contact Last Name                                                                      | TestL                            |
		| Address                                                                                | Gulfport W5062 County Rd F;Waldo |
		| Email                                                                                  | sidinginstall@gmail.com          |
		| Phone                                                                                  | 9194844411                       |
	And user verifies the Wage Calculator page
	Then user fills out the Payroll Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 7.25                  | 5                   | 5              |
	Then user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| OneF       | OneL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer                   |
		| What percentage of work done is framing (rough carpentry)?                                                       | 60                       |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no                       |
		| Do you do roofing work?                                                                                          | no                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None                     |
		| Do you perform any work over 30 feet above ground level?                                                         | no                       |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                    | no                       |
		| Do you do any water damage, fire damage, or mold restoration?                                                    | no                       |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no                       |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | no                       |
		| When was your last policy in effect?                                                                             | Never no prior insurance |
		| Do you have multiple locations in more than one state?                                                           | no                       |
		| Do you do any construction work in New York?                                                                     | no                       |
	Then user verifies the WC decline page appearance
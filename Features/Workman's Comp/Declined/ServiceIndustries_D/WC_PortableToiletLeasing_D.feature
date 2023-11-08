Feature: WC_PortableToiletLeasing_D
Decline - DeclineReason::Unacceptable severity from depth exposure via collapse, decline.
Yes I have Employee
Number of employee : 3
ZIP Code: 21001
Business Operation: I Lease a Space From Others
Included Officer: 3
Business started year : Started 8 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments

@Service @WC @Regression @Declined @NY
Scenario: WC Portable Toilet Leasing gets declined because work lower than 10 feet below ground
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Portable Toilet Leasing | 3         | I Lease a Space From Others |              | 21001    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 8 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 1,240,000                   |
		| Are there any employees that do not do any cleaning or maintenance work?               | no                          |
		| Business                                                                               | Portable Toilet Leasing     |
		| Address                                                                                | 529 Edmund St;Aberdeen      |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                | Answer |
		| How many owners/officers does your business have?                                       | 3      |
		| How many owners/officers do you want to cover with this policy?                         | 3      |
		| Are there any included owners/officers that do not do any cleaning or maintenance work? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer     |
		| Do you do any work lower than 10 feet below ground?                       | yes        |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None       |
		| What is the max depth in feet you work underground?                       | 100        |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes        |
		| Do you have multiple locations in more than one state?                    | no         |
		| Federal Employer Identification Number (FEIN)                             | 23-5619498 |
	Then user verifies the WC decline page appearance
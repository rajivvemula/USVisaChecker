Feature: WC_MasonryContractorClassCode_D
Ineligible quote: Decline, group transportation is a severe CAT claim exposure and unacceptable.

Keyword: Masonry Contractor - ineligible class code
Employee option: Various employees - 2
ZIPCode: 90036
Employee Payroll: 100,000
Entity type: Limited Liability Co. (LLC)
Years in business: 7
Included owner officers: No
Excluded owner officer: 1

@Construction @WC @Declined @CA
Scenario: WC Masonry Contractor gets declined due to group transportation
	Given user starts a quote with:
		| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Masonry Contractor | 2         | I Lease a Space From Others |              | 90036    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                         |
		| When do you want your policy to start?                                                 |                                |
		| When did you start your business?                                                      | Started 7 years ago            |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)    |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000                         |
		| Do any employee contractors make at least $32/hr?                                      | no                             |
		| Are there any employees that never travel to job sites or do any construction work?    | no                             |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                             |
		| Business                                                                               | CA Masons;CAM                  |
		| Address                                                                                | 5905 Wilshire Blvd;Los Angeles |
		| Fill Contact                                                                           |                                |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                                                                   | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                                                             | yes        |
		| In the past 3 years how many Workers' Compensation claims were reported?                                                                                   | None       |
		| Do you perform any work over 30 feet above ground level?                                                                                                   | no         |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                                                              | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                                                                         | no         |
		| Are you engaged in any chimney work?                                                                                                                       | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business?                                           | no         |
		| Do you do any construction work in New York?                                                                                                               | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                                                                  | yes        |
		| Do you agree to submit proof of insurance claims history, also called loss runs, for the prior 3 years within 30 days of the effective date of the policy? | yes        |
		| Do you have multiple locations in more than one state?                                                                                                     | no         |
		| Federal Employer Identification Number (FEIN)                                                                                                              | 06-2671064 |
	Then user verifies the WC decline page appearance
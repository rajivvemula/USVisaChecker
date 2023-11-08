Feature: WC_AdultLivingFacility_WithMedicalCare_D
Ineligible quote: If user select Yes option Do you provide emergency response workers to areas 
with disease outbreaks, catastrophes, or disasters
Keyword: Adult Living Facility: With Medical Care
Employee option: Various employees - 20
ZIPCode: 30305
Employee Payroll: 1,240,000
Entity type: LLC
Years in business: Started 7 years ago
Included owner officers: Yes 2
Excluded owner officer: 2

@Health @WC @Declined @GA @Regression
Scenario: WC AdultLivingFacility: WithMedicalCare gets declined because providing emergency response workers to areas with disease outbreaks, catastrophes, or disasters
	Given user starts a quote with:
		| Industry                                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Adult Living Facility: With Medical Care | 20        | I Lease a Space From Others |              | 30305    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                          |
		| When do you want your policy to start?                                                          |                                 |
		| When did you start your business?                                                               | Started 7 years ago             |
		| How is your business structured?                                                                | Limited Liability Co. (LLC)     |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 1,240,000                       |
		| Are there any licensed employee physicians, RNs, practical nurses, directors or administrators? | no                              |
		| Do any employees only do general office work and rarely travel?                                 | no                              |
		| Business                                                                                        | Adult Living Facility           |
		| Address                                                                                         | 3363 Grant Valley Rd NW;Atlanta |
		| Contact First Name                                                                              | TestF                           |
		| Contact Last Name                                                                               | TestL                           |
		| Email                                                                                           | Test@Test123.com                |
		| Phone                                                                                           | 1231231321                      |
		| Business website                                                                                | test.com                        |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                   | Answer |
		| How many owners/officers does your business have?                                          | 4      |
		| How many owners/officers do you want to cover with this policy?                            | 2      |
		| Are any included owners/officers licensed physicians, nurses, directors or administrators? | No     |
		| Do any included owners/officers only do general office work and rarely travel?             | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer     |
		| Do you accept clients that have been diagnosed with a form of dementia?                                | No         |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | yes        |
		| What percentage of residents or clients are ambulatory?                                                | 0          |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes        |
		| Do you use any volunteers or donated labor?                                                            | no         |
		| Do you have multiple locations in more than one state?                                                 | no         |
		| Federal Employer Identification Number (FEIN)                                                          | 23-1326965 |
	Then user verifies the WC decline page appearance
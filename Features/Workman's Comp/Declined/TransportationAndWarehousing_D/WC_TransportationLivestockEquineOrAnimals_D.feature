Feature: WC_TransportationLivestockEquineOrAnimals_D
Ineligible Quote for the 
Keyword: Transportation: Livestock, Equine, or Animals
Decline Reason: due to poor management safety oversight from out of service HazMat violations.
Employees option: 2
ZIP code: 01105
Business Structured: Corporation
Business Operation: I Work at a Job Site  
Business started year : Started 8 years ago

@Transportation @WC @Declined @MA @Regression
Scenario: WC Transportation: Livestock Animals gets declined because cited for HAZMAT violations
	Given user starts a quote with:
		| Industry                                      | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Transportation: Livestock, Equine, or Animals | 2         | I Work at a Job Site |              | 01105    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                              |
		| When do you want your policy to start?                                                 |                                     |
		| When did you start your business?                                                      | Started 8 years ago                 |
		| How is your business structured?                                                       | Corporation                         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                              |
		| Are there any employees that do not drive and do not load/unload goods?                | no                                  |
		| Are there any drivers that drive trucks you own or lease but pay via 1099?             | no                                  |
		| Do any owner operators or sub-haulers transport goods on your behalf?                  | no                                  |
		| Business                                                                               | HazmatFree                          |
		| Address                                                                                | 3363 Grant Valley Rd NW;Springfield |
		| Contact First Name                                                                     | TestF                               |
		| Contact Last Name                                                                      | TestL                               |
		| Email                                                                                  | automationtest@biberk.com           |
		| Phone                                                                                  | 1231231321                          |
		| Business website                                                                       | test.com                            |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 25000          |
		| TwoF       | TwoL      | yes        | 25000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                               |
		| Does your business have a USDOT Number?                                                                            | no                                   |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                        | 51 - 100 miles                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                                 |
		| Do you review MVRs for all employees with a driving exposure?                                                      | Yes at the time of hire and annually |
		| Do you transport any hazardous materials?                                                                          | yes                                  |
		| Do you do manual tarping?                                                                                          | yes                                  |
		| In the past 3 years has the DOT cited you for any out of service HazMat violations?                                | yes                                  |
		| Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7, or 8)?                           | no                                   |
		| Do your drivers do any manual loading/unloading of materials?                                                      | yes                                  |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes                                  |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                                   |
		| Do you have multiple locations in more than one state?                                                             | no                                   |
		| Federal Employer Identification Number (FEIN)                                                                      | 23-5619498                           |
	Then user verifies the WC decline page appearance

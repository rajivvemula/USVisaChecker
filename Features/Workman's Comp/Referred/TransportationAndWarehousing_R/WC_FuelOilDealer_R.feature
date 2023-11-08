Feature: WC_FuelOilDealer_R
Ineligible quote for Keyword: Fuel Oil Dealer
Referral reason: Policy premium exceeds max allowable value for sales/online
Yes I have Employee
Number of employee : 1
ZIP Code: 04401
Business Operation: I Lease a Space From Others
Included Officer: 1
Business started year : Started 7 years ago
Business Structured: LLC 

@Referred @Regression @ME @WC @YourServices @Transportation
Scenario: WC Fuel Oil Dealer creates referred policy because policy premium exceeds max allowable value
	Given user starts a quote with:
	| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Fuel Oil Dealer | 1         | I Lease a Space From Others |              | 04401    | WC  |
	Then user fills out the WC About You page with these values:
	| Question                                                                               | Answer                      |
	| When do you want your policy to start?                                                 |                             |
	| When did you start your business?                                                      | Started 7 years ago         |
	| How is your business structured?                                                       | Limited Liability Co. (LLC) |
	| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 880880                      |
	| Do any employees only do general office work and rarely travel?                        | No                          |
	| Are there any drivers that drive trucks you own or lease but pay via 1099?             | No                          |
	| Do any owner operators or sub-haulers transport goods on your behalf?                  | No                          |
	| Business                                                                               |                             |
	| Address                                                                                | 287 Godfrey Blvd;Bangor     |
	| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
	| Question                                                                       | Answer |
	| How many owners/officers does your business have?                              | 1      |
	| How many owners/officers do you want to cover with this policy?                | 1      |
	| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
	| Question                                                                                 | Answer     |
	| Do you do any exploration, extraction, or refining of oil or oil related products?       | no         |
	| How many miles at most do drivers go from their base location?                           | 50         |
	| In the past 3 years how many Workers' Compensation claims were reported?                 | None       |
	| In the past 3 years has the DOT cited you for any out of service HazMat violations?      | no         |
	| Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7, or 8)? | no         |
	| Do you have multiple locations in more than one state?                                   | no         |
	Then user verifies the appearance of the WC Additional Information page
	Then user begins the WC AI page setting the FEIN with value 123123414
	Then wc user handles 1 covered oo
	And user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
	| Field                        | Value          |
	| Business name                | TestBiz        |
	| Doing Business as (optional) | DBA            |
	| Contact first name           | Ken            |
	| Contact last name            | Masters        |
	| Contact email                | test@yahoo.com |
	| Contact phone                | 3789129831     |
	| Business website (optional)  | test.com       |
	Then user verifies the refer thank you page appears
	
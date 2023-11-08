Feature: WC_FuelOilDealer_D
Ineligible quote
Keyword: Fuel Oil Dealer
DECLINED - DeclineReason::Unacceptable hazard we only have appetite for transportation
Number of employees : 3
ZIP Code: 10001
Business Operation: I Lease a Space From Others
Included Officer: 3
Business started year : Started 7 years ago
Business Structured: LLC

@Oil @WC @Declined @NY @Regression
Scenario: WC Fuel Oil Dealer gets declined because unacceptable hazard activities other than transportation
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Fuel Oil Dealer | 3         | I Lease a Space From Others |              | 10001    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 70000                       |
		| Do any employees only do general office work and rarely travel?                        | no                          |
		| Are there any drivers that drive trucks you own or lease but pay via 1099?             | no                          |
		| Do any owner operators or sub-haulers transport goods on your behalf?                  | no                          |
		| Business                                                                               | Fluffy Maui LLC             |
		| Address                                                                                | 550 W 25th St;Manhattan     |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | automationtest@biberk.com   |
		| Phone                                                                                  | 1231231321                  |
	Then user verifies the appearance of the WC Owners and Officers Page
	And user handles the WC OO kickoff questions with these values:
		| Question                                                                                       | Answer  |
		| How many owners/officers does your business have?                                              | 1       |
		| How many owners/officers do you want to cover with this policy?                                | 1       |
	And user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| FirstOne   | LastOne   | yes        | 20000          |
	Then user continues on from the WC OO page
	And user fills out the WC Your Services page
		| Question                                                                                 | Answer    |
		| Do you do any exploration, extraction, or refining of oil or oil related products?       | no        |
		| How many miles at most do drivers go from their base location?                           | 50        |
		| In the past 3 years how many Workers' Compensation claims were reported?                 | None      |
		| In the past 3 years has the DOT cited you for any out of service HazMat violations?      | no        |
		| Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7, or 8)? | yes       |
		| Do you have multiple locations in more than one state?                                   | no        |
	Then user verifies the WC decline page appearance
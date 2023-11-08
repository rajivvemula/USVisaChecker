Feature: WC_AftermarketAutoPartsWholesalers_I

Issuing an Aftermarket Auto Parts Wholesalers policy

@Auto @WC @CT @Regression @YourServices
Scenario: WC Aftermarket AutoParts Wholesalers policy issued for Connecticut
	Given user starts a quote with:
		| Industry                           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Aftermarket Auto Parts Wholesalers | 11        | I Lease a Space From Others |              | 06457    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Partnership                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 53000                        |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                           |
		| Business                                                                               | Lord & Co. Engines;          |
		| Address                                                                                | 46 Grandview Dr;Middletown   |
		| Fill Contact                                                                           |                              |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| first name | last name | job duty                      |
		| Heat       | Driver 7  | General Office Worker         |
		| Heat       | Driver 6  | Mechanic or Estimates repairs |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                            | Answer                                      |
		| Do you have any staff that travel to deliver parts to customers or transfer them between locations? | no                                          |
		| Do you provide towing or roadside assistance?                                                       | Yes - 3rd party or 1099 workers may provide |
		| Do you require all 3rd parties/1099 workers working for you to have certificates of insurance?      | Yes we require them to have insurance       |
		| In the past 3 years how many Workers' Compensation claims were reported?                            | None                                        |
		| Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?            | yes                                         |
		| Do employees ever test drive large commercial vehicles, motorcycles, or recreational vehicles?      | no                                          |
		| Do you currently have a Workers' Compensation insurance policy in effect?                           | yes                                         |
		| Do you have multiple locations in more than one state?                                              | no                                          |
		| Federal Employer Identification Number (FEIN)                                                       | 23-1626549                                  |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1626549
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Lord & Co. Engines                |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: BOP
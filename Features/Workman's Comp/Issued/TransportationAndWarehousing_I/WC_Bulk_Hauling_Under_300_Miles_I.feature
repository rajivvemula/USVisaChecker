Feature: WC_Bulk_Hauling_Under_300_Miles_I
Testing the Your Services questions for the keyword
Issuing Bulk Hauling: under 300 miles policy

@Transportation @WC @Issued @FL @Regression @YourServices
Scenario: WC Bulk Hauling Under 300 Miles creates an issued policy in Florida
	Given user starts a quote with:
		| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Bulk Hauling: under 300 miles | 4         | I Lease a Space From Others |              | 33609    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                 |
		| When do you want your policy to start?                                                 |                        |
		| When did you start your business?                                                      | Started 5 years ago    |
		| How is your business structured?                                                       | Corporation            |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 505000                 |
		| Are there any employees that do not drive and do not load/unload goods?                | no                     |
		| Are there any drivers that drive trucks you own or lease but pay via 1099?             | no                     |
		| Do any owner operators or sub-haulers transport goods on your behalf?                  | no                     |
		| Business                                                                               | Super Sentai           |
		| Address                                                                                | 306 N Habana Ave;Tampa |
		| Fill Contact                                                                           |                        |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Tommy      | Oliver    |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                               |
		| Does your business have a USDOT Number?                                                                            | yes                                  |
		| Enter the USDOT number:                                                                                            | 23223                                |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                        | 101 - 200 miles                      |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                                 |
		| Do you review MVRs for all employees with a driving exposure?                                                      | Yes at the time of hire and annually |
		| Do you do manual tarping?                                                                                          | no                                   |
		| Do you transport any hazardous materials?                                                                          | yes                                  |
		| In the past 3 years has the DOT cited you for any out of service HazMat violations?                                | no                                   |
		| Do you haul any explosives, radioactives, or corrosives (DOT Hazard Classes 1, 7, or 8)?                           | no                                   |
		| Do your drivers do any manual loading/unloading of materials?                                                      | no                                   |
		| Do drivers use chains to secure equipment, logs, or other large loads for transport?                               | no                                   |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes                                  |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                                   |
		| Do you have multiple locations in more than one state?                                                             | no                                   |
		| Federal Employer Identification Number (FEIN)                                                                      | 23-7177659                           |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-7177659
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field                       | Value                             |
		| Payment Option              | 25% Down + 9 Monthly Installments |
		| CC Name                     | Super Sentai                      |
		| CC Number                   | 4111111111111111                  |
		| CC Expiration Month         | 11                                |
		| CC Expiration Year          | 25                                |
		| Autopay                     | No                                |
		| First Name                  | TestF                             |
		| Last Name                   | TestL                             |
		| Email                       | TestFTestL@Test123.com            |
		| Phone                       | 7777777777                        |
		| Same Billing Info?          | Yes                               |
		| Read Florida Applications?  | Yes                               |
		| Read Foregoing Application? | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: CA
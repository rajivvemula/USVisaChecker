Feature: WC_AutoBodyRepairShop_I
Issued Policy for the Keyword: Auto Body Repair Shop
Employee option: 11
ZIP code: 32091
Business Structured: Corporation
Business Operation: I Run My Business From Property I Own  
Business started year: Started 8 years ago
Payroll: 500,000 
Included owners/officers: 1
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 25% Down + 9 Monthly Installments

@Auto @WC @FL @Regression @YourServices @Issued
 Scenario: WC Auto Repair: No Body Work policy issued for Florida.
	Given user starts a quote with:
		| Industry                  | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Auto Repair: No Body Work | 11        | I Run My Business From Property I Own |              | 32091    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                  |
		| When do you want your policy to start?                                                 |                         |
		| When did you start your business?                                                      | Started 9 years ago     |
		| How is your business structured?                                                       | Corporation             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                  |
		| Do you have any auto salespersons on staff?                                            | yes;7000                |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                      |
		| Business                                                                               | Florida Auto Repair;FAR |
		| Address                                                                                | 643 W Pratt St;Starke   |
		| Fill Contact                                                                           |                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty                      |
		| Billy      | Bob       | yes        | 52000          | Mechanic or Estimates repairs |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                        | Answer     |
		| Do you provide towing or roadside assistance?                                                   | No         |
		| Do you engage in the repossession of vehicles?                                                  | no         |
		| What % of revenue is from sales or service of Truck Tractors/Trailers or Recreational Vehicles? | 0          |
		| In the past 3 years how many Workers' Compensation claims were reported?                        | None       |
		| Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?        | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                       | yes        |
		| Do you have multiple locations in more than one state?                                          | no         |
		| Federal Employer Identification Number (FEIN)                                                   | 23-1234567 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	Then user verifies that the Florida Premium Estimate Disclosure table contains these values:
		| Class Code | Class Code Description             | Estimated Annual Remuneration | Manual Rate |
		| 8380       | AUTO SERVICE OR REPAIR CTR. & DRVS | $550,200.00                   | 2.05        |
		| 8748       | AUTOMOBILE SALESPERSONS            | $7,000.00                     | 0.53        |
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1626549
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field                       | Value                             |
		| Payment Option              | 25% Down + 9 Monthly Installments |
		| CC Name                     | Florida Auto Repair               |
		| CC Number                   | 4111111111111111                  |
		| CC Expiration Month         | 11                                |
		| CC Expiration Year          | 25                                |
		| Autopay                     | No                                |
		| First Name                  | Florida                           |
		| Last Name                   | Auto Repair                       |
		| Email                       | FloridaAutoReapir@Automotive.com  |
		| Phone                       | 7777777777                        |
		| Same Billing Info?          | Yes                               |
		| Read Florida Applications?  | Yes                               |
		| Read Foregoing Application? | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: BOP
	
@Auto @WC @Issued @ME @Regression @YourServices
Scenario: WC Auto Body Repair Shop issued for Maine
	Given user starts a quote with:
		| Industry              | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Auto Body Repair Shop | 3         | I Run My Business From Property I Own |              | 04330    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                        |
		| When do you want your policy to start?                                                 |                               |
		| When did you start your business?                                                      | Started 9 years ago           |
		| How is your business structured?                                                       | Corporation                   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                        |
		| Do any employees do any roadside assistance or towing?                                 | no                            |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                            |
		| Business                                                                               | AutoBody Repair Shop          |
		| Address                                                                                | 2 State House Station;Augusta |
		| Fill Contact                                                                           |                               |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                       | Answer |
		| How many owners/officers does your business have?                                              | 1      |
		| How many owners/officers do you want to cover with this policy?                                | 1      |
		| Do any included owners/officers only do general office work never writing up repair estimates? | No     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                        | Answer                   |
		| Do you provide towing or roadside assistance?                                                   | No                       |
		| Do you dismantle, salvage, or junk vehicles?                                                    | no                       |
		| Do you engage in the repossession of vehicles?                                                  | yes                      |
		| What % of revenue is from sales or service of Truck Tractors/Trailers or Recreational Vehicles? | 20                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                        | None                     |
		| Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles?        | no                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                       | no                       |
		| When was your last policy in effect?                                                            | Never no prior insurance |
		| Do you have multiple locations in more than one state?                                          | no                       |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 10% Down + 10 Monthly Installments |
		| CC Name             | MAG Auto Garage                    |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | TestF                              |
		| Last Name           | TestL                              |
		| Email               | TestFTestL@Test123.com             |
		| Phone               | 7777777777                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
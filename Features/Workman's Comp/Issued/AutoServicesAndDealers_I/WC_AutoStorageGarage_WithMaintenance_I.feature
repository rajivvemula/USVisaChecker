Feature: WC_AutoStorageGarage_WithMaintenance_I

Issued Policy for the Keyword: Auto Storage Garage with Maintenance
ZIP code:21014

@Auto @WC @Issued @MD @Regression @YourServices
Scenario: WC Auto Storage Garage: With Maintenance policy issued for Maryland
	Given user starts a quote with:
		| Industry                              | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Auto Storage Garage: With Maintenance | 3         | I Run My Business From Property I Own |              | 21014    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                   |
		| When do you want your policy to start?                                                 |                          |
		| When did you start your business?                                                      | Started 9 years ago      |
		| How is your business structured?                                                       | Corporation              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                   |
		| Do you have any auto salespersons on staff?                                            | yes;7000                 |
		| Do any employees do any roadside assistance or towing?                                 | no                       |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                       |
		| Business                                                                               | MD Auto Garage;MAG       |
		| Address                                                                                | 500 N Hickory Ave;Bel Air|
		| Fill Contact                                                                           |                          |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                            | Answer |
		| How many owners/officers does your business have?                                                   | 1      |
		| How many owners/officers do you want to cover with this policy?                                     | 1      |	
		| Do any included owners/officers only do general office work never writing up repair estimates?      | No     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
	    | Question                                                                                        | Answer                   |
	    | Do you provide towing or roadside assistance?                                                   | No                       |
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
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | MAG Auto Garage                   |
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
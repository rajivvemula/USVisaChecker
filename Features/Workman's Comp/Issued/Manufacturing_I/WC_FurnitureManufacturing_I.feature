Feature: WC_FurnitureManufacturing_I

Issued Policy for Keyword: WC Furniture Manufacturing

@WC @Manufacturing @Regression @Issued @NE @YourServices
Scenario: WC Furniture Manufacturing Issued in Nebraska
	Given user starts a quote with:
		| Industry                | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Furniture Manufacturing | 2         | I Own a Property & Lease to Others |              | 68467    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                         | Answer              |
		| When did you start your business?                                                                                | Started 8 years ago |
		| How is your business structured?                                                                                 | Partnership         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                           | 500000              |
		| Do any employees only do general office work and rarely travel?                                                  | no                  |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process?                  | no                  |
		| Business                                                                                                         |                     |
		| Address                                                                                                          | 1618 Rd N,York      |
		| Fill Contact                                                                                                     |                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                          | Answer |
		| How many owners/officers does your business have?                 | 5+     |
		| How many owners/officers do you want to cover with this policy?   | 3      |
		| How many owners/officers do you want to exclude from this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty     |
		| FirstOne   | LastOne   | Manufacturer |
		| FirstTwo   | LastTwo   | Manufacturer |
		| FirstThree | LastThree | Manufacturer |
	Then user handles the WC Excluded OO with these values:
		| Name |
		|      |
		|      |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Do you operate a sawmill?                                                 | no                                            |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page setting the FEIN with value 12-3123124
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Boiler Inspector Guys             |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
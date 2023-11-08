Feature: WC_ManufacturingHamburger_I

105408 WC | Update regression test to align with OO rules - AZ, this feature is helping to test (US89102)
Scenario 1: AZ (LLC) - 1 Owner Officer Total

@WC @Manufacturing @Regression @Issued @AZ @OwnerOfficer
Scenario: WC Manufacturing Hamburger Issued In Arizona LLC 1 Total OO
	Given user starts a quote with:
		| Industry                 | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Manufacturing: Hamburger | 8         | I Own a Property & Lease to Others |              | 85004    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                         | Answer                      |
		| When did you start your business?                                                                                | Started 8 years ago         |
		| How is your business structured?                                                                                 | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                           | 500000                      |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process?                  | no                          |
		| Are there any administrative or back office employees that are not involved at all in the manufacturing process? | no                          |
		| Business                                                                                                         |                             |
		| Address                                                                                                          | 2301 N Central Ave;Phoenix  |
		| Fill Contact                                                                                                     |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 1      |
		| How many owners/officers do you want to cover with this policy?                        | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| FirstOne   | LastOne   | yes        | 40000          | Manufacturer |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                       |
		| Is there any butchering or handling of livestock?                         | yes                          |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                           |
		| Do your employees deliver any of your finished product?                   | Sometimes (<50% of the time) |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                         |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                           |
		| Do you currently have a Workers' Compensation insurance policy in effect? | no                           |
		| When was your last policy in effect?                                      | Never no prior insurance     |
		| Do you have multiple locations in more than one state?                    | no                           |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 06-2671064
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| Payment Option      | One Pay Plan           |
		| CC Name             | Celestial Echos        |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | No                     |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
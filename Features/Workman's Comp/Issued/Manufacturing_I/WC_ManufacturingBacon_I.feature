Feature: WC_ManufacturingBacon_I

105408 WC | Update regression test to align with OO rules - AZ, this feature tests (US89102)
WC Manufacturing Bacon Issued In Arizona Corporation 1 Covered OO And 1 Excluded OO

@WC @Manufacturing @Issued @Regression @AZ @YourServices @OwnerOfficer
Scenario: WC Manufacturing Bacon Issued In Arizona Corporation 1 Covered OO And 1 Excluded OO
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Manufacturing: Bacon | 13        | I Lease a Space From Others |              | 85004    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                         | Answer                     |
		| When do you want your policy to start?                                                                           |                            |
		| When did you start your business?                                                                                | Started 8 years ago        |
		| How is your business structured?                                                                                 | Corporation                |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                           | 440440                     |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process?                  | no                         |
		| Are there any administrative or back office employees that are not involved at all in the manufacturing process? | no                         |
		| Business                                                                                                         | Blast Away;BOOM            |
		| Business                                                                                                         | Test Actor AK              |
		| Address                                                                                                          | 2301 N Central Ave;Phoenix |
		| Contact First Name                                                                                               | TestF                      |
		| Contact Last Name                                                                                                | TestL                      |
		| Email                                                                                                            | Test@Test123.com           |
		| Phone                                                                                                            | 1231231321                 |
		| Business website                                                                                                 | test.com                   |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 2      |
		| How many owners have less than 50% ownership? State law requires that they be covered. | 1      |
		| How many owners/officers do you want to cover with this policy?                        | 1      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name | Checkbox |
		| Vera       | Angel     | Yes      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | % Ownership | W2 payroll | Annual Payroll | Job Duty     |
		| FirstOne   | LastOne   | Yes         | yes        | 40000          | Manufacturer |
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
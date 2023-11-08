Feature: WC_AmusementParkOrExhibitionOperation_I
Issuing policy for Amusement Park or Exhibition Operation
zipcode:35226

@Hospitality @WC @Issued @AL @Regression @YourServices
Scenario: WC Amusement Park Or Exhibition Operation policy issued in Alabama
	Given user starts a quote with:
		| Industry                                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Amusement Park or Exhibition Operation    | 5         | I Lease a Space From Others |              | 35226    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 5 years ago          |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 80000                        |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Business                                                                               | Alabama Amusement Park       |
		| Address                                                                                | 1575 Patton Chapel Rd;Hoover |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 1      |
		| How many owners/officers do you want to cover with this policy?                        | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| TestF      | TestL     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                 | Answer                                               |
		| Do you travel to set up any temporary exhibits?                                          | No all our exhibits are at permanent fixed locations |
		| Do you do any work higher than 30 feet above ground?                                     | no                                                   |
		| Do you do any erection of new rides or setting up new exhibits requiring carpentry work? | no                                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?                 | None                                                 |
		| Do you do any caving, rock climbing, or white water rafting?                             | no                                                   |
		| Do you do fishing or hunting activities?                                                 | no                                                   |
		| Do you currently have a Workers' Compensation insurance policy in effect?                | yes                                                  |
		| Do you use any volunteers or donated labor?                                              | no                                                   |
		| Do you have multiple locations in more than one state?                                   | no                                                   |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
    When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-0271074
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|		    |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
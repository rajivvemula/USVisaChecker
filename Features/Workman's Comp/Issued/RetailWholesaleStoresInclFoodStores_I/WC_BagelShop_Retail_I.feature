Feature: WC_BagelShop_Retail_I

Issuing Bagel Shop Retail policy in New York.

@Retail @WC @Issued @NY @Regression @YourServices
Scenario: WC Bagel Shop Retail issued policy in NY
	Given user starts a quote with:
		| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Bagel Shop: Retail | 5         | I Lease a Space From Others |              | 12207    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                |
		| When do you want your policy to start?                                                 |                       |
		| When did you start your business?                                                      | Started 2 years ago   |
		| How is your business structured?                                                       | Corporation           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 80000                 |
		| Do any employees only do general office work and do not work a cash register?          | no                    |
		| Business                                                                               | Ye Olde Bagel Shoppe  |
		| Address                                                                                | 1004 6th Ave W;Albany |
		| Contact First Name                                                                     | TestF                 |
		| Contact Last Name                                                                      | TestL                 |
		| Email                                                                                  | Test@Test123.com      |
		| Phone                                                                                  | 1231231321            |
		| Business website                                                                       | test.com              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| TestFN     | TestLN    |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 10     |
		| Do you deliver any food or goods by bicycle?                              | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a Standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization | Value |
		| N/A           | N/A   |
	Then user begins the WC AI page setting the FEIN with value 23-7277824
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value               |
		| Payment Option      | One Pay Plan        |
		| CC Name             | Test                |
		| CC Number           | 4111111111111111    |
		| CC Expiration Month | 11                  |
		| CC Expiration Year  | 25                  |
		| Autopay             | Yes                 |
		| First Name          | TestF               |
		| Last Name           | TestL               |
		| Email               | TestFTestL@Test.com |
		| Phone               | 7777777777          |
		| Same Billing Info?  | Yes                 |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
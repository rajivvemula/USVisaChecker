Feature: WC_JewelryRepair_I

Verifying that the Jewelry Repair keyword can be issued when officers have 50% and 10% ownership of the business.

@Retail @WC @Issued @AZ @Regression @OwnerOfficer
Scenario: Jewelry Repair _ 2 Officers With 10% Ownership
	Given user starts a quote with:
		| Industry       | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Jewelry Repair |           | I Work at a Job Site |              | 69120    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                               | Answer                   |
		| When do you want your policy to start? |                          |
		| When did you start your business?      | Started 2 years ago      |
		| How is your business structured?       | Corporation              |
		| Business                               | Jewelry Repair           |
		| Address                                | 119 E Jackson Ave;Arnold |
		| Contact First Name                     | TestF                    |
		| Contact Last Name                      | TestL                    |
		| Email                                  | Test@Test123.com         |
		| Phone                                  | 1231231321               |
		| Business website                       | test.com                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 2      |
	Then user handles the WC Covered OO with these values:
		| first name | last name |
		| OneF       | OneL      |
		| TwoF       | TwoL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| Do you use armed security officers?                                       | yes    |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 25% Down + 6 Monthly Installments |
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
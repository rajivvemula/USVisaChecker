Feature: WC_ContractorEquipment_I

Issuing a policy for Contractor Equipment: Rental, Sales, or Service - IN

@Retail @WC @Issued @IN @Regression
Scenario: WC Contractor Equipment: Rental Sales or Service policy issued in Indiana
	Given user starts a quote with:
		| Industry                                         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Contractor Equipment: Rental, Sales, or Service  | 3         | I Lease a Space From Others |              | 47201    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer               |
		| When do you want your policy to start?                                                 |                      |
		| When did you start your business?                                                      | Started 2 years ago  |
		| How is your business structured?                                                       | Corporation          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000               |
		| Business                                                                               | Equipment store      |
		| Address                                                                                | 15 Brown St;Columbus |
		| Contact First Name                                                                     | TestF                |
		| Contact Last Name                                                                      | TestL                |
		| Email                                                                                  | Test@Test123.com     |
		| Phone                                                                                  | 1231231321           |
		| Business website                                                                       | test.com             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 1      |		
		| How many owners/officers do you want to cover with this policy?                        | 1      |	
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                         | Answer |
		| Will the business owner(s) or employees be operating any of the equipment at customer locations? | no     |
		| What is the max depth in feet below ground you do work at?                                       | 0      |
		| What percentage of your overall sales involve delivery?                                          | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?                         | None   |
		| What is the max height in feet you work above ground level?                                      | 0      |
		| Do you currently have a Workers' Compensation insurance policy in effect?                        | yes    |
		| Do you have multiple locations in more than one state?                                           | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 12-1234567
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

Feature: WC_RadiationSafetyServices_I
Issuing a Radiation Safety Services policy
ZIP Code: 02907 (RI)

@Service @WC @Issued @RI @Regression @YourServices
Scenario: WC Radiation Safety Services creates issued policy for Rhode Island	
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Radiation Safety Services | 10        | I Lease a Space From Others |              | 02907    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                    |
		| When do you want your policy to start?                                                 |                           |
		| When did you start your business?                                                      | Started 9 years ago       |
		| How is your business structured?                                                       | Partnership               |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                    |
		| Business                                                                               | Radiation Safety Services |
		| Address                                                                                | 343 Broad St;Providence   |
		| Fill Contact                                                                           |                           |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                        | Answer |
		| How many owners/officers does your business have?                                                               | 5+     |
		| How many owners/officers do you want to exclude from this policy? State law requires that they all be excluded. | 5      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                     | Answer |
		| Do you do land or site surveying?                                            | no     |
		| Do you do direct physical work such as construction, landscaping or farming? | no     |
		| Do you do any work higher than 30 feet above ground?                         | no     |
		| Do you do any work lower than 10 feet below ground?                          | no     |
		| Do you ever act as a general contractor or foreman on construction projects? | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?     | None   |
		| Do you handle, store, or transport any hazardous corrosive substances?       | no     |
		| Do you handle, store, or transport any explosives or blasting agents?        | no     |
		| Do you have multiple locations in more than one state?                       | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the SSN with value 231-11-1111
	Then wc user handles 5 excluded oo with these values:
		| Set Name       |
		| Kirk Hammett   |
		| James Hetfield |
		| Lars Ulrich    |
		| Rob Trujillo   |
		| Jason Newsted  |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Radiatoin Safety Services         |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | Funky                             |
		| Last Name           | Kong                              |
		| Email               | FunkyKong@Cheese.com              |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL
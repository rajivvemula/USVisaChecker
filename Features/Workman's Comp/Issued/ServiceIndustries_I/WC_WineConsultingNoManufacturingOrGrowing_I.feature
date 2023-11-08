Feature: WC_WineConsultingNoManufacturingOrGrowing_I

Issuing a Wine Consulting: No manufacturing or growing policy

@Service @WC @Issued @DC @Regression @YourServices
Scenario: WC Wine Consulting No Manufacturing Or Growing policy issued for DC
	Given user starts a quote with:
		| Industry                                     | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Wine Consulting: No manufacturing or growing | 7         | I Own a Property & Lease to Others |              | 20036    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                            | Answer                       |
		| When do you want your policy to start?                                                              |                              |
		| When did you start your business?                                                                   | Started 7 years ago          |
		| How is your business structured?                                                                    | Limited Liability Co. (LLC)  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)              | 57000                        |
		| Do you pay any subcontractors/1099 workers to do installation of machines/equipment on your behalf? | no                           |
		| Business                                                                                            | Probable Fermintation LLC;PF |
		| Address                                                                                             | 1771 Church St NW;Washington |
		| Fill Contact                                                                                        |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                               | Answer |
		| Do you do any fabrication or machining?                                                | no     |
		| Do you do any installation or repair of equipment or machines at customer locations?   | no     |
		| Do you do any heating, ventilation, or air conditioning (HVAC) installation or repair? | no     |
		| Do you do any work higher than 30 feet above ground?                                   | no     |
		| Do you do any work lower than 10 feet below ground?                                    | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?               | None   |
		| Do you handle, store, or transport any hazardous corrosive substances?                 | no     |
		| Do you handle, store, or transport any explosives or blasting agents?                  | no     |
		| Do you have multiple locations in more than one state?                                 | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the SSN with value 325-64-7484
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                     |
		| Payment Option      | One Pay Plan              |
		| CC Name             | Probable Fermintation LLC |
		| CC Number           | 4111111111111111          |
		| CC Expiration Month | 11                        |
		| CC Expiration Year  | 25                        |
		| Autopay             | No                        |
		| First Name          | TestF                     |
		| Last Name           | TestL                     |
		| Email               | TestFTestL@Test123.com    |
		| Phone               | 7777777777                |
		| Same Billing Info?  | Yes                       |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL
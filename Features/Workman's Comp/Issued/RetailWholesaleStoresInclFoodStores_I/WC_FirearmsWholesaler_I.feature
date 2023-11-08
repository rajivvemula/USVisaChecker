Feature: WC_FirearmsWholesaler_I
Issuing a Firearms Wholesaler - New Mexico Issued Policy 
 
@Service @WC @Issued @NM @Regression @YourServices
Scenario: WC Firearms Wholesaler issued in New Mexico
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Firearms Wholesaler | 3         | I Lease a Space From Others |              | 87501    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 9 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                       |
		| Business                                                                               | Boomsticks LLC              |
		| Address                                                                                | 128 Steese Hwy;Santa Fe     |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 10     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you operate a shooting or firing range where live ammunition is used?  | yes    |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1326965
	Then wc user handles 1 excluded oo with these values:
		| Set Name      |
		| Selina Joseph |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                            |
		| Payment Option      | One Pay Plan                     |
		| CC Name             | Young Mens Christian Association |
		| CC Number           | 4111111111111111                 |
		| CC Expiration Month | 11                               |
		| CC Expiration Year  | 25                               |
		| Autopay             | N/A                              |
		| First Name          | TestF                            |
		| Last Name           | TestL                            |
		| Email               | TestFTestL@Test123.com           |
		| Phone               | 7777777777                       |
		| Same Billing Info?  | Yes                              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
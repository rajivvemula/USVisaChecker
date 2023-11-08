Feature: MotionPictureProduction_I

Issuing a Motion Picture Production policy in OK

@Hospitality @WC @Issued @OK @Regression @YourServices
Scenario: WC MotionPicture Production creates issued policy in Oklahoma
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Motion Picture Production | 3         | I work at a job site |              | 74820    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                 |
		| When do you want your policy to start?                                                 |                        |
		| When did you start your business?                                                      | Started this year      |
		| How is your business structured?                                                       | Corporation            |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                  |
		| Do you make any payments to workers using IRS Form 1099?                               | no                     |
		| Business                                                                               | New Hollywood in OK    |
		| Address                                                                                | 200 S Broadway Ave;Ada |
		| Contact First Name                                                                     | TestF                  |
		| Contact Last Name                                                                      | TestL                  |
		| Email                                                                                  | Test@Test123.com       |
		| Phone                                                                                  | 1231231321             |
		| Business website                                                                       |                        |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 2      |
		| How many owners/officers do you want to cover with this policy?                        | 1      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                          | Answer |
		| Do you use pyrotechnics?                                                          | no     |
		| Do you film choreographed fight scenes?                                           | no     |
		| Do you perform acts with knives, other sharp objects, fire, or live ammunition?   | no     |
		| Do you film car, motorcycle, or ATV stunts or chase scenes?                       | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?          | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect?         | yes    |
		| Do you use any volunteers or donated labor?                                       | no     |
		| Do you have multiple locations in more than one state?                            | no     |
    Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
    Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 2 excluded oo with these values:
		| Set Name  |
		| Aaaa Bbbb |
		| Cccc Dddd |    
    Then user continues on from the WC Additional Information page		
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | One Pay Plan                      |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | Yes                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL
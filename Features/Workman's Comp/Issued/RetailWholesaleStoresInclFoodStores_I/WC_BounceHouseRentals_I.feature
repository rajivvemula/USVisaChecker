Feature: WC_BounceHouseRentals_I

Issued WC Policy For Bounce House Rentals In Illinois

@Regression @WC @Retail @Issued @IL 
Scenario: WC Bounce House Rentals Issued Policy
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Bounce House Rentals | 1         | I Lease a Space From Others |              | 60073    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                  | Answer                         |
		| When do you want your policy to start?                                                    |                                |
		| When did you start your business?                                                         | Started 2 years ago            |
		| How is your business structured?                                                          | Corporation                    |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)    | 40000                          |
		| Do any employees only do general office work and rarely travel?                           | no                             |
		| Do any employees help set up/install items such as furniture, lighting, stages, or tents? | no                             |
		| Do any employees deliver goods but wouldn't help set up or install anything?              | yes                            |
		| Business                                                                                  | Test NH Corp;Test DBA          |
		| Address                                                                                   | 24881 W CLINTON AVE;Round Lake |
		| Contact First Name                                                                        | TestF                          |
		| Contact Last Name                                                                         | TestL                          |
		| Email                                                                                     | Test@Test123.com               |
		| Phone                                                                                     | 1231231321                     |
		| Business website                                                                          | test.com                       |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 2      |
		| How many owners/officers do you want to cover with this policy?                | 1      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                     |
		| Do your employees deliver any of your goods or merchandise?               | Often (50-99% of the time) |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                       |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                        |
		| Do you have multiple locations in more than one state?                    | no                         |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Set Name  | 
		| OneF OneL | 
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
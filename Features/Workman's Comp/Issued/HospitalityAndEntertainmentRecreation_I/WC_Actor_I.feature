Feature: WC_Actor_I

Issuing policy for Actor

@Hospitality @WC @Issued @AK @Regression @YourServices 
Scenario: WC Actor creates issued policy in Alaska
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actor    | 2         | I Lease a Space From Others |              | 99780    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer              |
		| When do you want your policy to start?                                                 |                     |
		| When did you start your business?                                                      | Started 5 years ago |
		| How is your business structured?                                                       | Corporation         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000               |
		| Are there any actors, entertainers, or musicians on staff?                             | no                  |
		| Do you make any payments to workers using IRS Form 1099?                               | no                  |
		| Business                                                                               | Test Actor AK       |
		| Address                                                                                | 1314 Alaska Hwy;Tok |
		| Contact First Name                                                                     | TestF               |
		| Contact Last Name                                                                      | TestL               |
		| Email                                                                                  | Test@Test123.com    |
		| Phone                                                                                  | 1231231321          |
		| Business website                                                                       | test.com            |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 0      |		
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                          | Answer |
		| Do you use pyrotechnics?                                                          | no     |
		| Do you perform acts with knives, other sharp objects, fire, or live ammunition?   | no     |
		| Do you do any work higher than 30 feet above ground?                              | no     |
		| Do you help set up furniture or install any sound/lighting at events?             | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?          | None   |
		| Do you work with lions, tigers, leopards, bears, elephants, or venomous reptiles? | no     |
		| Do you currently have a Workers' Compensation insurance policy in effect?         | yes    |
		| Do you use any volunteers or donated labor?                                       | no     |
		| Do you have multiple locations in more than one state?                            | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 2 excluded oo with these values:
		| Have Name |
		|           |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 25% Down + 6 Monthly Installments |
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
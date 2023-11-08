Feature: WC_SnowRemoval_I
Issuing a Workers Comp Snow Removal policy in Idaho

@Service @WC @Issued @ID @Regression @YourServices
Scenario: WC Snow Removal policy issued in ID
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Snow Removal | 15        | I Lease a Space From Others |              | 83702    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 9 years ago         |
		| How is your business structured?                                                       | Partnership                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                      |
		| Do any employees only do general office work and rarely travel?                        | no                          |
		| Business                                                                               | Idaho Snow Removal Services |
		| Address                                                                                | 780 S 14th St;Boise         |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 2      |
		| How many owners/officers do you want to cover with this policy?                | 2      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                               |
		| Do you remove snow from roofs?                                            | no                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                 |
		| Is work exclusively performed on parking lots and driveways?              | no                                   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | no                                   |
		| When was your last policy in effect?                                      | Never no prior insurance             |
		| Do you have multiple locations in more than one state?                    | no                                   |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 231-11-1110
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Test                              |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@gmail.com              |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
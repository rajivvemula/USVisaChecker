Feature: WC_BoysAndGirlsClub_I
ZIP Code: 02907 (RI)
Additional Info page - Setting the Excluded OO

@OwnerOfficer @WC @Issued @Education @Regression @RI
Scenario: WC Boys And Girls Club creates issued policy in Rhode Island
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Boys and Girls Club | 10        | I Lease a Space From Others |              | 02907    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                              |
		| When do you want your policy to start?                                                 |                                     |
		| When did you start your business?                                                      | Started 9 years ago                 |
		| How is your business structured?                                                       | Partnership                         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                              |
		| Business                                                                               | Boys and Girls Club of America;BGCA |
		| Address                                                                                | 343 Broad St;Providence             |
		| Fill Contact                                                                           |                                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                        | Answer |
		| How many owners/officers does your business have?                                                               | 5+     |
		| How many owners/officers do you want to exclude from this policy? State law requires that they all be excluded. | 5      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None        |
		| Are any children or students younger than five years old?                 | No          |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes         |
		| Do you use any volunteers or donated labor?                               | no          |
		| Do you have multiple locations in more than one state?                    | no          |
		| Social Security Number (SSN)                                              | 231-11-1111 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the SSN with value 231-11-1111
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
		| CC Name             | Funky Chicken-cheese              |
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
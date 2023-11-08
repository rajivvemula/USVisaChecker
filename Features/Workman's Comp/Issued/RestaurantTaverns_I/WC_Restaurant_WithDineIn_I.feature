Feature: WC_Restaurant_WithDineIn_I

WC issued policy for Restaurant: With Dine In

@WC @Issued @Restaurant @GA @Regression @YourServices
Scenario: WC Restaurant With Dine In issued policy for GA
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Restaurant: With Dine In | 4         | I Lease a Space From Others |              | 30033    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                     |
		| When do you want your policy to start?                                                 |                            |
		| When did you start your business?                                                      | Started 3 years ago        |
		| How is your business structured?                                                       | Individual/Sole Proprietor |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                     |
		| Are there any delivery drivers on staff (includes bicycles)?                           | no                         |
		| Insured First Name                                                                     | Madden                     |
		| Insured Last Name                                                                      | Ali                        |
		| Address                                                                                | 1750 Decatur Hwy;Decatur   |
		| Email                                                                                  | Madden@gmail.com           |
		| Phone                                                                                  | 8329890445                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                           | Answer                   |
		| What percentage of your overall sales involve alcohol?                                             | 10                       |
		| What percentage of your overall sales involve off-premises catering, lunch wagons, or food trucks? | 10                       |
		| What percentage of your overall sales involve delivery?                                            | 10                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                           | None                     |
		| Do you use bouncers or security guards?                                                            | Yes - via our employees  |
		| Do you provide any private adult entertainment including escorts and/or strippers?                 | no                       |
		| Are you open after 2 A.M.?                                                                         | no                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                          | no                       |
		| When was your last policy in effect?                                                               | Never no prior insurance |
		| Do you have multiple locations in more than one state?                                             | no                       |
		| Do you deliver any food or goods by bicycle?                                                       | no                       |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
    Then user verifies the appearance of the WC Additional Information page
	Then user begins the WC AI page setting the FEIN with value 06-2671064
	And user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 15% Down + 9 Monthly Installments  |
		| CC Name             | Test Pay                           |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | FN                                 |
		| Last Name           | LN                                 |
		| Email               | FNLN@gmail.com                     |
		| Phone               | 7777777777                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
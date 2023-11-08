Feature: WC_SubstanceAbuseHalfwayHouse_I

Issuing a Substance Abuse Halfway House policy in NY

@Staging @Regression @WC @Issued @Health @NY
Scenario: WC Substance Abuse Halfway House policy issued in NY
	Given user starts a quote with:
		| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Substance Abuse Halfway House | 5         | I Lease a Space From Others |              | 11550    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                  |
		| When do you want your policy to start?                                                 |                         |
		| When did you start your business?                                                      | Started 4 years ago     |
		| How is your business structured?                                                       | Partnership             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 90000                   |
		| Business                                                                               | NY Halfway house        |
		| Address                                                                                | 46 Gladys Ave;Hempstead |
		| Contact First Name                                                                     | TestF                   |
		| Contact Last Name                                                                      | TestL                   |
		| Email                                                                                  | Test@Test123.com        |
		| Phone                                                                                  | 1231231321              |
		| Business website                                                                       |                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| John       | Smith     | yes        | 40000          |
		| Mary       | Right     | yes        | 50000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer |
		| Do you accept clients who are currently on probation?                                                  | no     |
		| Do you operate as a halfway house, accepting residents directly from jail or prison?                   | no     |
		| Do you accept clients who have felony convictions other than drug-related charges?                     | no     |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes    |
		| Do you use any volunteers or donated labor?                                                            | no     |
		| Do you have multiple locations in more than one state?                                                 | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Multi-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 2 excluded oo with these values:
		| Have Name |
		|           |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | No               |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 3211234567       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	

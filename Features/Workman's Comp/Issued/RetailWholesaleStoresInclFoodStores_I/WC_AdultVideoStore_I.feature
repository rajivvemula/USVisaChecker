Feature: WC_AdultVideoStore_I

Issuing a policy for keyword Adult Video Store with annual payroll more than 90% industry min, but less than 100%
Logic described in Task 118658 Description

@Staging @Regression @WC @Retail @Issued @AL
Scenario: WC Adult Video Store policy issued in Alabama
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Adult Video Store | 5         | I Lease a Space From Others |              | 36849    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer               |
		| When do you want your policy to start?                                                 |                      |
		| When did you start your business?                                                      | Started 2 years ago  |
		| How is your business structured?                                                       | Corporation          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 30000                |
		| Are there any delivery drivers on staff (includes bicycles)?                           | no                   |
		| Do any employees only do general office work and do not work a cash register?          | no                   |
		| Business                                                                               | Adult Video Store    |
		| Address                                                                                | 220 W 14th St;Auburn |
		| Contact First Name                                                                     | TestF                |
		| Contact Last Name                                                                      | TestL                |
		| Email                                                                                  | Test@Test123.com     |
		| Phone                                                                                  | 1231231321           |
		| Business website                                                                       |                      |
	Then user verifies the Payroll Calculator page
	Then user fills out the Wage Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 7.25                  | 5                   | 20             |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name | 
		| NameF      | NameL     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |    
	Then user begins the WC AI page setting the FEIN with value 23-1212123
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |     
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
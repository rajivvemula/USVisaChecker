Feature: WC_ProfessionalBaseketballTeam_I

Issued Quote For Keyword: Professional Basketball Team
Reason: State HI
Employee option: Various employees - 1
ZIPCode: 96746 
Employee Payroll: 40,000
Entity type: Limited Liability Co. (LLC)
Years in business: 2 years
Included owner officers: 2

@WC @Issued @Hospitality @YourServices @Regression @HI 
Scenario: WC Professional Basketball Team policy issued in HI
	Given user starts a quote with:
		| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Professional Basketball Team | 1         | I Lease a Space From Others |              | 96746    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40,000                      |
		| Are there any scouts or traveling recruiters on staff?                                 | No                          |
		| Are there any clerical office staff?                                                   | Yes                         |
		| Business                                                                               | Test NJ LLC ; Test DBA      |
		| Address                                                                                | 872 Kamalu Rd;Kapaa         |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | AutomationTest@biberk.com   |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	And user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| How are the athletes paid?                                                | All W2 |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you use any volunteers or donated labor?                               | no     |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	When user sets the additional information page state unemployment insurance value to: 215985181975
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

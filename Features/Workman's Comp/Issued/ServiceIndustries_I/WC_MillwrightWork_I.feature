Feature: WC_MillwrightWork_I

Issuing a Millwright Work policy

@Service @WC @Issued @Regression @NJ @YourServices
Scenario: WC Millwright Work issuing a policy for NJ
	Given user starts a quote with:
		| Industry        | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Millwright Work |           | I work at a job site |              | 08088    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                              | Answer                               |
		| When do you want your policy to start?                                |                                      |
		| When did you start your business?                                     | Started 7 years ago                  |
		| How is your business structured?                                      | Individual/Sole Proprietor           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099? | no                                   |
		| Insured First Name                                                    | Shubal                               |
		| Insured Last Name                                                     | Stearns                              |
		| Address                                                               | 198 Red Lion Rd;Southampton Township |
		| Email                                                                 | Test@Test123.com                     |
		| Phone                                                                 | 1231233333                           |
		| Business website                                                      | test.com                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| Insured First Name | Insured Last Name | W2 payroll | annual payroll |
		| Shubal             | Stearns           | yes        | 50000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| Do you do any welding work?                                               | no     |
		| Do you install any overhead doors?                                        | no     |
		| Do you install any new commercial refrigeration or freezer units?         | no     |
		| Do you install any new equipment?                                         | Yes    |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you perform any work over 30 feet above ground level?                  | yes    |
		| What is the max depth in feet you work underground?                       | 5      |
		| What is the max height in feet you work above ground level?               | 0      |
		| Do you review MVRs for all employees with a driving exposure?             | No     |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 83-2803691
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value             |
		| Payment Option      | One Pay Plan      |
		| CC Name             | Millwright Worker |
		| CC Number           | 4111111111111111  |
		| CC Expiration Month | 11                |
		| CC Expiration Year  | 25                |
		| Autopay             | Yes               |
		| First Name          | Millwright        |
		| Last Name           | Worker            |
		| Email               | Test@Test123.com  |
		| Phone               | 1231233333        |
		| Same Billing Info?  | Yes               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
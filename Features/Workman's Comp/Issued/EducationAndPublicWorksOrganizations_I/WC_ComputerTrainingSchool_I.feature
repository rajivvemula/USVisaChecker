Feature: WC_ComputerTrainingSchool_I
Issuing a Computer Training School policy in Kansas

@WC @Issued @Education @Regression @KS @YourServices
Scenario: WC Computer Training School issued policy in KS
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Computer Training School | 10        | I Lease a Space From Others |              | 66103    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                         | Answer                          |
		| When do you want your policy to start?                                                           |                                 |
		| When did you start your business?                                                                | Started 9 years ago             |
		| How is your business structured?                                                                 | Partnership                     |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)           | 440440                          |
		| Are there any security personnel, maintenance, janitorial, bus drivers, or food service workers? | no                              |
		| Business                                                                                         | Kansas Computer Training center |
		| Address                                                                                          | 4215 Rainbow Blvd;Kansas City   |
		| Fill Contact                                                                                     |                                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 3      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty                     |
		| Billy      | Bob       | Professor, Teacher, or Admin |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Madison    | Ken       |
		| Emilee     | Harrison  |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None       |
		| Are any children or students younger than five years old?                 | No         |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes        |
		| Do you use any volunteers or donated labor?                               | no         |
		| Do you have multiple locations in more than one state?                    | no         |
		| Federal Employer Identification Number (FEIN)                             | 23-1326965 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Test Pay                          |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | FN                                |
		| Last Name           | LN                                |
		| Email               | FNLN@gamil.com                    |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
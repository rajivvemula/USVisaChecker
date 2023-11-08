Feature: WC_YMCAYWCAYMHAYWHAInstitution_I

Issuing a YMCA, YWCA, YMHA or YWHA, Institution policy

@Service @WC @Issued @HI @Regression @YourServices
Scenario: WC YMCA YWCA YMHA YWHA Institution Issuing a policy for Hawaii
	Given user starts a quote with:
		| Industry                              | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| YMCA, YWCA, YMHA or YWHA, Institution | 10        | I Own a Property & Lease to Others |              | 96814    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                |
		| When do you want your policy to start?                                                 |                                       |
		| When did you start your business?                                                      | Started 10 years or more ago          |
		| How is your business structured?                                                       | Corporation                           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50,000                                |
		| Do you provide any boxing, martial arts, climbing, or gymnastics training/classes?     | no                                    |
		| Do you pay any class instructors or personal trainers using 1099s?                     | no                                    |
		| Business                                                                               | Young Mens Christian Association;YMCA |
		| Address                                                                                | 1313 Pensacola St;Honolulu            |
		| Fill Contact                                                                           |                                       |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                          | Answer     |
		| Do you offer any live fun such as archery or axes, batting cages, driving ranges, or ice skating? | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                          | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                         | yes        |
		| Do you use any volunteers or donated labor?                                                       | no         |
		| Do you provide any scuba diving training?                                                         | no         |
		| Do you have multiple locations in more than one state?                                            | no         |
		| Federal Employer Identification Number (FEIN)                                                     | 23-1965495 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1965495
	When user sets the additional information page state unemployment insurance value to: 215985181975
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Young Mens Christian Association  |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL
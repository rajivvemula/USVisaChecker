Feature: WC_RegisteredNurse_I

Issuing a policy for a Registered Nurse Cardiac Specialist 

@Health @WC @MN @Regression @Yourservices
Scenario: WC Registered Nurse policy issued in Minnesota
	Given user starts a quote with:
		| Industry         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Registered Nurse | 1         | I Lease a Space From Others |              | 55345    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 7 years ago          |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                        |
		| Business                                                                               | Cardiac Specialist           |
		| Address                                                                                | 3639 Sunrise Dr E;Minnetonka |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Nurse      | Joy       |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer     |
		| What type of care do you provide?                                                                      | Specialist |
		| What field is your main specialty?                                                                     | Cardiac    |
		| Do you provide chiropractor or physical therapy care?                                                  | no         |
		| Do you provide internal medicine or podiatry care?                                                     | no         |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes        |
		| Do you use any volunteers or donated labor?                                                            | no         |
		| Do you have multiple locations in more than one state?                                                 | no         |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-0271174
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 20% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: BOP
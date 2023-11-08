Feature: WC_FamilyPlanningCounselingServices_I

Issuing a Family Planning Counseling Services policy

@Staging @Regression @WC @Issued @Health @MO 
Scenario: WC Family Planning Counseling Services policy issued in Missouri
	Given user starts a quote with:
		| Industry                             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Family planning counseling services  | 5         | I Lease a Space From Others |              | 65401    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                |
		| When do you want your policy to start?                                                 |                       |
		| When did you start your business?                                                      | Started 4 years ago   |
		| How is your business structured?                                                       | Partnership           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 60000                 |
		| Business                                                                               | Family counseling     |
		| Address                                                                                | 812 Orchard Dr;Rolla  |
		| Contact First Name                                                                     | TestF                 |
		| Contact Last Name                                                                      | TestL                 |
		| Email                                                                                  | Test@Test123.com      |
		| Phone                                                                                  | 1231231321            |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 3      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer                                                         |
		| Do you take on any clients with developmental disabilities?                                            | Yes - a few of our clients may have developmental disabilities |
		| Do you provide any alcohol or drug abuse counseling?                                                   | No                                                             |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no                                                             |
		| Do you accept clients who have been convicted of a violent crime?                                      | no                                                             |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None                                                           |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes                                                            |
		| Do you use any volunteers or donated labor?                                                            | no                                                             |
		| Do you have multiple locations in more than one state?                                                 | no                                                             |
		| Federal Employer Identification Number (FEIN)                                                          | 23-1234567                                                     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Multi-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1234567
	Then wc user handles 3 excluded oo with these values:
		| Set Name    |
		| NameA NameB |
		| NameC NameD |
		| NameE	NameF |
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
	Then user verifies that these LOBs are recommended: PL,BOP

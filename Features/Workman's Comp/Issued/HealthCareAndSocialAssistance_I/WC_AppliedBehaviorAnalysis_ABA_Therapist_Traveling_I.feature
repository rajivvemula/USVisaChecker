Feature: WC_AppliedBehaviorAnalysis_ABA_Therapist_Traveling_I

@Health @Regression @WC @Issued @AZ @YourServices
Scenario: WC Applied Behavior Analysis ABA Therapist Traveling issued policy in AZ
	Given user starts a quote with:
		| Industry                                             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Applied Behavior Analysis (ABA) Therapist: Traveling | 5         | I Lease a Space From Others |              | 85705    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                    |
		| When do you want your policy to start?                                                 |                           |
		| When did you start your business?                                                      | Started 4 years ago       |
		| How is your business structured?                                                       | Partnership               |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 90000                     |
		| Are there any travelling salespersons on staff that do not interact with clients?      | no                        |
		| Are there any administrative staff that do not interact with clients and never travel? | no                        |
		| Do you make any payments to workers using IRS Form 1099?                               | no                        |
		| Business                                                                               | Applied Behavior Analysis |
		| Address                                                                                | 1807 W Gardner St;Tucson  |
		| Contact First Name                                                                     | TestF                     |
		| Contact Last Name                                                                      | TestL                     |
		| Email                                                                                  | Test@Test123.com          |
		| Phone                                                                                  | 1231231321                |
		| Business website                                                                       |                           |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Hillary    | Lansen    |
		| Parker     | Wilton    |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer                   |
		| Are any of the home health workers Registered Nurses or Nurse Practitioners?                           | All (100%)               |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None                     |
		| Do you offer any live-in services or 24 hour shifts?                                                   | No                       |
		| Do you review MVRs for all employees with a driving exposure?                                          | No                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | no                       |
		| When was your last policy in effect?                                                                   | Never no prior insurance |
		| Do you use any volunteers or donated labor?                                                            | no                       |
		| Do you have multiple locations in more than one state?                                                 | no                       |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
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
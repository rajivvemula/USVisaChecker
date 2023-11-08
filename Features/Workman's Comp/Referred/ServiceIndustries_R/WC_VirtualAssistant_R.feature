Feature: WC_VirtualAssistant_R
Ineligible quote for Keyword: Virtual Assistant
Referred for doing physical work

@Service @WC @Regression @Referred @LA
Scenario: WC Virtual Assistant gets referred due to doing direct physical work
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Virtual Assistant | 7         | I Lease a Space From Others |              | 70518    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                     |
		| When do you want your policy to start?                                                 |                            |
		| When did you start your business?                                                      | Started 7 years ago        |
		| How is your business structured?                                                       | Corporation                |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                      |
		| Do any employees travel frequently for sales or consultation?                          | no                         |
		| Business                                                                               | Virtual Assistant Referral |
		| Address                                                                                | 210 S Morgan Ave;Broussard |
		| Contact First Name                                                                     | TestF                      |
		| Contact Last Name                                                                      | TestL                      |
		| Email                                                                                  | Test@Test123.com           |
		| Phone                                                                                  | 1231231321                 |
		| Business website                                                                       | test.com                   |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty       |
		| OneF       | OneL      | Doesn't Travel |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                          | Answer                                |
		| Do you do any direct physical work such as construction, landscaping, or farming? | yes                                   |
		| Describe the direct physical work:                                                | farming, landscaping and construction |
		| In the past 3 years how many Workers' Compensation claims were reported?          | None                                  |
		| Do you have multiple locations in more than one state?                            | no                                    |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                      |
		| Business name      | Virtual Assistant Referral |
		| Contact first name | TestF                      |
		| Contact last name  | TestL                      |
		| Email              | TestCert@Plan.com          |
		| Phone              | (123) 123-1321             |
		| Business website   | www.TestPartnerCert.com    |
	Then user verifies the refer thank you page appears
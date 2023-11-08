Feature: WC_RecruitingServices_NoStaffingServices_R

Created to Test Refer for Do you provide any staffing services?  and What is the compensation arrangement for your staffing services? for MN.

@WC @Referred @MN @Regression @RecruitingServices
Scenario: Recruiting Services: No Staffing Services
	Given user starts a quote with:
		| Industry                                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Recruiting Services: No Staffing Services | 8         | I Lease a Space From Others |              | 55106    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                                                        |
		| When do you want your policy to start?                                                 |                                                                               |
		| When did you start your business?                                                      | Started this year                                                             |
		| How is your business structured?                                                       | Corporation                                                                   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                                                                         |
		| Do you provide any staffing services?                                                  | yes                                                                           |
		| What is the compensation arrangement for your staffing services?                       | Client pays us the worker's salary plus commission and then we pay the worker |
		| What is the annual pay from your business to temporary workers you help staff?         | 20,000                                                                        |
		| Business                                                                               | John's Recruiting                                                             |
		| Address                                                                                | 886 Arcade St;St Paul                                              |
		| Contact First Name                                                                     | TestF                                                                         |
		| Contact Last Name                                                                      | TestL                                                                         |
		| Email                                                                                  | Test@Test123.com                                                              |
		| Phone                                                                                  | 1231231321                                                                    |
		| Business website                                                                       | test.com                                                                      |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 1      |
		| How many owners/officers do you want to cover with this policy?                        | 1      |
	Then user continues on from the WC OO page
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 Payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 20000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                       | Answer                                      |
		| In the past 3 years how many Workers' Compensation claims were reported?                       | None                                        |
		| Do you have multiple locations in more than one state?                                         | no                                          |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Auto XMOD          |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears

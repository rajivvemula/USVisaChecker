Feature: WC_DanceSchool_R
Ineligible Quote for Keyword: Dance School
Reason: Multi-State condition found.
Description: Multi-State option is selected by the user.
Employee option: Various employees - 15
ZIPCode: 75220
Employee Payroll: 1,250,000
Entity type: LLC
Years in business: Started 10 years or more ago
Included owner officers: 4
Excluded owner officer: 1
EL Limits: 100,000/500,000/100,000
Payment Option: 20% Down + 9 Monthly Installments

@Hospitality @WC @Referred @TX @Regression
Scenario: WC Dance School gets referred because multi-state condition found
	Given user starts a quote with:
		| Industry     | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Dance School | 15        | I Own a Property & Lease to Others |              | 75220    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                        |
		| Do you make any payments to workers using IRS Form 1099?                               | no                           |
		| Business                                                                               | Dance School                 |
		| Address                                                                                | 2917 Lombardy Ln;Dallas      |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231233212                   |
		| Business website                                                                       | test.com                     |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 50000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes        |
		| Do you use any volunteers or donated labor?                               | no         |
		| Do you have multiple locations in more than one state?                    | yes        |
		| Federal Employer Identification Number (FEIN)                             | 23-1665987 |
	Then user begins the WC AI page having the FEIN with value 23-1665987
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Dance School            |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | 1231233212              |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
Feature: WC_ActuarialServices_R
Ineligible quote: REFERRED - Potential misclassification. Submit description of ops to UW. Direct physical work is not contemplated by consultant class.
Keyword: Actuarial Services
Yes I have Employees
Number of employee : 3
Business Operation: I Work at a Job Site
ZIP Code: 17601
Included Officer: 0
Business started year : Started 8 years ago
Business Structured: Partnership

@Referred @Regression @Staging @PA @Service
Scenario: WC Actuarial Services gets referred due to potential misclassification
	Given user starts a quote with:
		| Industry           | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Actuarial Services | 3         | I Work at a Job Site |              | 17601    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                   |
		| When do you want your policy to start?                                                 |                          |
		| When did you start your business?                                                      | Started 8 years ago      |
		| How is your business structured?                                                       | Partnership              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                    |
		| Do any employees travel frequently for sales, consultation, or auditing?               | no                       |
		| Do you provide any staffing services?                                                  | no                       |
		| Business                                                                               | Test refer               |
		| Address                                                                                | 701 SE 71st St;Lancaster |
		| Contact First Name                                                                     | TestF                    |
		| Contact Last Name                                                                      | TestL                    |
		| Email                                                                                  | Test@Test123.com         |
		| Phone                                                                                  | 1231231231               |
		| Business website                                                                       | test.com                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                | Answer |
		| How many owners/officers does your business have?                                       | 2      |
		| How many owners/officers do you want to cover with this policy?                         | 2      |
		| Do any included owners/officers travel frequently for sales, consultation, or auditing? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer |
		| Do you do any direct physical work such as construction, landscaping, or farming?                      | no     |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None   |
		| Do you have multiple locations in more than one state?                                                 | no     |
	Then user begins the WC AI page setting the FEIN with value 832803691
	Then wc user handles 2 excluded oo with these values:
		| Set Name  |
		| OneF OneL |
		| TwoF TwoL |
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Refer              |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | 1231231231              |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears

Feature: WC_BoysAndGirlsClub_R
Reason: Number of claims specified 2 >= threshold number 2.
Description: Total number of claims in past three years exceeds the threshold based on class, state, and payroll amount.
Ineligible quote for the 
Keyword: Boys and Girls Club
Employee option: 10
ZIP code: 07043
Business Structured: LLC
Business Operation: I Lease a Space From Others
Business started year : Been around a while, started 10 or more years ago

@WC @Regression @Referred @Education @NJ
Scenario: WC Boys And Girls Club gets referred due to number of claims greater than two
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Boys and Girls Club | 10        | I Lease a Space From Others |              | 07043    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                     |
		| When do you want your policy to start?                                                 |                            |
		| When did you start your business?                                                      | Started 6 years ago        |
		| How is your business structured?                                                       | Corporation                |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 800000                     |
		| Business                                                                               | Test Number Of Claims      |
		| Address                                                                                | 117 Mt Hebron Rd;Montclair |
		| Contact First Name                                                                     | TestF                      |
		| Contact Last Name                                                                      | TestL                      |
		| Email                                                                                  | Test@Test123.com           |
		| Phone                                                                                  | 1231231321                 |
		| Business website                                                                       | test.com                   |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| TestF      | TestL     | yes        | 50000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?  | 2      |
		| Are any children or students younger than five years old?                 | No     |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you use any volunteers or donated labor?                               | no     |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Number Of Claims   |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
Feature: WC_CoffeeAndTeaSupplyStore_Retail_R
Ineligible Quote for Keyword: Coffee and Tea Supply Store: Retail
Reason: Prior customer relationship N9WC956710, Previous Customer - In Collections based on Phone.
Yes I have Employees
Number of employees : 15
Business Operation: I Lease a Space From Others 
ZIP Code: 07043
Included Officer: 2
Business started year : Started 10 or more years ago
Business Structured: LLC
Cust Phone: 2134548480

@Retail @WC @Referred @NJ @Regression
Scenario: WC Coffee And Tea Supply Store: Reatil gets referred
	Given user starts a quote with:
		| Industry                            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Coffee and Tea Supply Store: Retail | 11        | I Lease a Space From Others |              | 07043    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000                       |
		| Are there any delivery drivers on staff (includes bicycles)?                           | no                           |
		| Business                                                                               | ReferBasedOnPhone            |
		| Address                                                                                | 177 Lorraine Ave;Montclair   |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 9492784950                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                             | Answer |
		| Do you want to buy coverage for the business owners? | yes    |
		| How many owners/officers are there?                  | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| TestF      | TestL     | yes        | 40000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | ReferBasedOnPhone       |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | 9492784950              |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
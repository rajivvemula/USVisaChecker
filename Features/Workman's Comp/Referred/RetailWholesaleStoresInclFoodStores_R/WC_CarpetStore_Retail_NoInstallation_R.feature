Feature: WC_CarpetStore_Retail_NoInstallation_R
Ineligible quote for Keyword: Carpet Store: Retail; No Installation
Refer due to potential misclassification, in addition please check whether subbed out work always has cert collected. 
No more than 50% of subcontracted install is allowed..
Yes I have Employee
Number of employee : 10
Business Operation: I Run My Business From Property I Own 
ZIP Code: 73301
Included Officer: 1
Business started year : Started 5 years ago
Business Structured: Partnership
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments 

@Retail @WC @Referred @TX @Regression
Scenario: WC Carpet Store: Retail No Installation gets referred
	Given user starts a quote with:
	| Industry                              | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Carpet Store: Retail; No Installation | 10        | I Run My Business From Property I Own |              | 73301    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                                                | Answer                  |
		| When do you want your policy to start?                                                                  |                         |
		| When did you start your business?                                                                       | Started 2 years ago     |
		| How is your business structured?                                                                        | Corporation             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                  | 500,000                 |
		| Do any employees deliver goods but wouldn't help set up or install anything?                            | no                      |
		| Are there any retail store employees that do not do any installation, maintenance, or contracting work? | no                      |
		| Do any employees only do general office work and do not work a cash register?                           | no                      |
		| Business                                                                                                | TestCarpetStore         |
		| Address                                                                                                 | 242 Lincoln St;Austin   |
		| Contact First Name                                                                                      | TestF                   |
		| Contact Last Name                                                                                       | TestL                   |
		| Email                                                                                                   | Test@Test123.com        |
		| Phone                                                                                                   | 1231231321              |
		| Business website                                                                                        | test.com                |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 2      |
		| How many owners/officers do you want to cover with this policy?                        | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 Payroll | Annual Payroll | Job Duty              |
		| TestF      | TestL     | yes        | 40000          | Store Operations      |
		| TwoF       | TwoL      | yes        | 40000          | General Office Worker |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                     | Answer                                  |
		| Do you pay any subcontractors/1099 workers to install, service, or do repairs for customers? | no                                      |
		| What percentage of your overall sales involve delivery?                                      | 20                                      |
		| What percentage of delivery is done by a third party or independent contractors?             | 20                                      |
		| Are certificates of insurance kept for all third parties that deliver on your behalf?        | No we don't require they have insurance |
		| What is the annual pay to third parties that deliver on your behalf?                         | 20000                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?                     | 2                                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                    | yes                                     |
		| Do you have multiple locations in more than one state?                                       | yes                                     |
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
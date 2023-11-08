Feature: WC_CeramicTileStore_Retail_NoInstallation_R
Ineligible quote - Keyword: Ceramic Tile Store: Retail; No Installation
Description: Refer due to potential misclassification, in addition please check whether subbed out work always has cert collected. 
No more than 50% of subcontracted install is allowed..
Yes I have Employees
Number of employees : 6
Business Operation: I Run My Business From Property I Own 
ZIP Code: 11211
Included Officer: 1
Business started year : Started 7 years ago
Business Structured: LLC

@Retail @WC @Regression @Referred @NY 
Scenario: WC Ceramic Tile Store: Retail No Installation gets referred 
	Given user starts a quote with:
		| Industry                                    | Employees | Location                         | Own or Lease | ZIP Code | LOB |
		| Ceramic Tile Store: Retail; No Installation | 6         | I Run My Business Out of My Home |              | 11211    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                | Answer                      |
		| When do you want your policy to start?                                                                  |                             |
		| When did you start your business?                                                                       | Started 7 years ago         |
		| How is your business structured?                                                                        | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                  | 700000                      |
		| Do any employees deliver goods but wouldn't help set up or install anything?                            | no                          |
		| Are there any retail store employees that do not do any installation, maintenance, or contracting work? | no                          |
		| Do any employees only do general office work and do not work a cash register?                           | no                          |
		| Business                                                                                                | Ceramic Tile Store          |
		| Address                                                                                                 | 147 Powers St;Brooklyn      |
		| Contact First Name                                                                                      | TestF                       |
		| Contact Last Name                                                                                       | TestL                       |
		| Email                                                                                                   | Test@Test123.com            |
		| Phone                                                                                                   | 1231231321                  |
		| Business website                                                                                        | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty              |
		| OneF       | OneL      | yes        | 40000          | General Office Worker |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                     | Answer                                  |
		| Do you pay any subcontractors/1099 workers to install, service, or do repairs for customers? | no                                      |
		| What percentage of your overall sales involve delivery?                                      | 100                                     |
		| What percentage of delivery is done by a third party or independent contractors?             | 100                                     |
		| Are certificates of insurance kept for all third parties that deliver on your behalf?        | No we don't require they have insurance |
		| What is the annual pay to third parties that deliver on your behalf?                         | 48,000                                  |
		| In the past 3 years how many Workers' Compensation claims were reported?                     | None                                    |
		| Do you currently have a Workers' Compensation insurance policy in effect?                    | yes                                     |
		| Do you have multiple locations in more than one state?                                       | no                                      |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Ceramic Tile Store      |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
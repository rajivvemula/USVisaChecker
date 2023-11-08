Feature: WC_PetAndPetSupplyStore_R
Keyword: Pet and Pet Supply Store 
Ineligible quote: Experience Mod not within the allowable limits
Yes I have Employee
Number of employee : 11
Business Operation: I Lease a Space From Others
ZIP Code: 10122
Included Officer: 1
Business started year : Started 12 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 
XMOD: 1.5
153 W 29th St, New York, NY 10001

@Retail @WC @Referred @NY @Regression
Scenario: WC Pet And Pet Supply Store gets referred because exp mod not within the allowable limits
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Pet and Pet Supply Store | 11        | I Lease a Space From Others |              | 10001    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000                       |
		| Business                                                                               | Pet Store Xmod not in limits |
		| Address                                                                                | 153 W 29th St;New York       |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 Payroll | Annual Payroll |
		| TestF      | TestL     | Yes        | 40000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                      | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?      | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect?     | yes    |
		| Do you have multiple locations in more than one state?                        | no     |
		| Does your business have a state-issued experience modification factor (XMOD)? | yes    |
		| Enter the value for experience modification factor:                           | 1.5    |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                    |
		| Business name      | Test Multi State Referal |
		| Contact first name | TestF                    |
		| Contact last name  | TestL                    |
		| Email              | TestCert@Plan.com        |
		| Phone              | (123) 123-1321           |
		| Business website   | www.TestPartnerCert.com  |
	Then user verifies the refer thank you page appears
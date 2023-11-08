Feature: WC_Florist_R

Creating a quote that will referr because W2 payroll is less than 90% of industry min 

@Regression @WC @Retail @Referred @ID
Scenario: WC Florist policy referred in Idaho
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 5         | I Lease a Space From Others |              | 83338    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                   |
		| When do you want your policy to start?                                                 |                          |
		| When did you start your business?                                                      | Started 5 years ago      |
		| How is your business structured?                                                       | Corporation              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 30000                    |
		| Business                                                                               | Test Florist             |
		| Address                                                                                | 801 S Lincoln Ave;Jerome |
		| Contact First Name                                                                     | TestF                    |
		| Contact Last Name                                                                      | TestL                    |
		| Email                                                                                  | Test@Test123.com         |
		| Phone                                                                                  | 1231231321               |
		| Business website                                                                       |                          |
	Then user verifies the Payroll Calculator page
	Then user fills out the Wage Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 7.25                  | 5                   | 15             |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user begins the WC AI page setting the FEIN with value 23-1212123
	Then wc user handles 1 excluded oo with these values:
		| Set Name    |
		| NameF NameL |
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Florist            |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
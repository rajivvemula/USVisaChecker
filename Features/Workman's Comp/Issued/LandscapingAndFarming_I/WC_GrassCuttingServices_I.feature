Feature: WC_GrassCuttingServices_I

Issuing a Grass Cutting Policy in NH

@WC @Issued @Regression @Landscaping @NH @YourServices
Scenario: WC Grass Cutting Services policy gets Issued for NH state
	Given user starts a quote with:
		| Industry               | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Grass Cutting Services | 3         | I Work at a Job Site |              | 03103    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                               |
		| When do you want your policy to start?                                                 |                                      |
		| When did you start your business?                                                      | Started 7 years ago                  |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 70000                                |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                   |
		| Business                                                                               | Test refer                           |
		| Address                                                                                | 340 COMMERCIAL ST STE 401;Manchester |
		| Contact First Name                                                                     | TestF                                |
		| Contact Last Name                                                                      | TestL                                |
		| Email                                                                                  | Test@Test123.com                     |
		| Phone                                                                                  | 2551234587                           |
		| Business website                                                                       | test.com                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                    | Answer     |
		| Do you trim trees above ground level or remove trees/stumps?                                | no         |
		| Do you do any new landscaping such as laying down bricks,  sod, or stones or planting work? | no         |
		| Do you do any roofing work?                                                                 | no         |
		| Do you ever transport six or more workers in the same vehicle?                              | no         |
		| Do you do any framing work?                                                                 | no         |
		| Do you provide any lot or land clearing services?                                           | no         |
		| Do you do any construction work such as carpentry, decking, handyman jobs, or painting?     | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                    | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                   | yes        |
		| Do you have multiple locations in more than one state?                                      | no         |
		| Federal Employer Identification Number (FEIN)                                               | 23-1326967 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	And wc user handles 2 covered oo
	And user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| CC Name             | Funky Chicken-cheese   |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | N/A                    |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	And user verifies the WC thank you page appearance
	And user verifies that these LOBs are recommended: GL

# Issued Scenario where total W2 payroll / NumberofEmployees  is LESS than Industry/SubIndustry min payroll (10000)
# and there are less than three employees.
@WC @Issued @Regression @NY @Landscaping
Scenario: WC Grass Cutting Services policy gets Issued for NY state
	Given user starts a quote with:
		| Industry               | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Grass Cutting Services | 2         | I Work at a Job Site |              | 10001    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 9500                        |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Test refer                  |
		| Address                                                                                | 93 ELLIOTT AVE;New York     |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 2551234587                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the Wage Calculator page
	Then user fills out the Wage Calculator with these values:
	| Average Employee Wage | Number of Employees | Hours per Week |
	| 15                    | 1                   | 13             |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
	| First Name | Last Name | W2 payroll | Annual Payroll |
	| Billy      | Bob       | yes        | 5000           |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                    | Answer     |
		| Do you trim trees above ground level or remove trees/stumps?                                | no         |
		| Do you do any new landscaping such as laying down bricks,  sod, or stones or planting work? | no         |
		| Do you do any roofing work?                                                                 | no         |
		| Do you ever transport six or more workers in the same vehicle?                              | no         |
		| Do you do any framing work?                                                                 | no         |
		| Do you provide any lot or land clearing services?                                           | no         |
		| Do you do any construction work such as carpentry, decking, handyman jobs, or painting?     | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                    | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                   | yes        |
		| Do you have multiple locations in more than one state?                                      | no         |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1326965
	And wc user handles 2 covered oo
	And user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| CC Name             | Funky Chicken-cheese   |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | N/A                    |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	And user verifies the WC thank you page appearance
	And user verifies that these LOBs are recommended: GL
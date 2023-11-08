Feature: WC_XMODPreQuote_U

US 71882 
WC Solar Panel Manufactor FEIN/SSN is only being asked on one page, after the quote selection for no XMOD in state 
WC Fireplace Installation FEIN/SSN asked prequote in XMOD state, while shown twice only is displayed in AI page

@Manufacturing @WC @Unit @NJ @YourServices

Scenario: WC Solar Panel Manufactor state w/o xmod w/ taxid after quote
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Solar Panel Manufacturing | 5         | I Lease a Space From Others |              | 08054    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                         | Answer                |
		| When do you want your policy to start?                                                                           |                       |
		| When did you start your business?                                                                                | Started 8 years ago   |
		| How is your business structured?                                                                                 | Corporation           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                           | 40000                 |
		| Are there any delivery drivers on staff?                                                                         | no                    |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process?                  | no                    |
		| Are there any administrative or back office employees that are not involved at all in the manufacturing process? | no                    |
		| Business                                                                                                         | Test Manual           |
		| Address                                                                                                          | 100 main st;Mt Laurel |
		| Contact First Name                                                                                               | TestF                 |
		| Contact Last Name                                                                                                | TestL                 |
		| Email                                                                                                            | Test@Test123.com      |
		| Phone                                                                                                            | 1231231321            |
		| Business website                                                                                                 | test.com              |
	Then user verifies the Wage Calculator page
	When the business is not seasonal
	Then user fills out the Wage Calculator with these values:
		| Question | Average Employee Wage | Number of Employees | Hours per Week |
		| Answer   | 15                    | 5                   | 40             |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| OneF       | OneL      | yes        | 50000          | Manufacturer |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | no                                            |
		| When was your last policy in effect?                                      | Never no prior insurance                      |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	
@WC @Unit @VT @Regression @YourServices
Scenario: WC Insurance Inspector for state with XMOD prequote
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Insurance Inspector | 25        | I Lease a Space From Others |              | 05478    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer              |
		| When do you want your policy to start?                                                 |                     |
		| When did you start your business?                                                      | Started 7 years ago |
		| How is your business structured?                                                       | Corporation         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000               |
		| Do any employees only do general office work and rarely travel?                        | no                  |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                  |
		| Business                                                                               | Test Manual         |
		| Address                                                                                | 100 main st;Georgia |
		| Contact First Name                                                                     | TestF               |
		| Contact Last Name                                                                      | TestL               |
		| Email                                                                                  | Test@Test123.com    |
		| Phone                                                                                  | 1231231321          |
		| Business website                                                                       | test.com            |
	Then user verifies the Wage Calculator page
	When the business is not seasonal
	Then user fills out the Wage Calculator with these values:
		| Question | Average Employee Wage | Number of Employees | Hours per Week |
		| Answer   | 15                    | 25                  | 40             |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                 | Answer                         |
		| Do you do any boiler inspections for commercial, industrial, or multi-family residences? | no                             |
		| Do you travel to damaged properties to adjust claims?                                    | no                             |
		| Do you do any installation, repair, or damage restoration services?                      | no                             |
		| Do you do any asbestos inspection?                                                       | no                             |
		| In the past 3 years how many Workers' Compensation claims were reported?                 | None                           |
		| Do you perform any work over 30 feet above ground level?                                 | no                             |
		| Do you perform any work underground including in trenches, holes, or tunnels?            | no                             |
		| Do you inspect any roofs?                                                                | no                             |
		| Do you currently have a Workers' Compensation insurance policy in effect?                | no                             |
		| When was your last policy in effect?                                                     | 30 days to 6 months ago        |
		| Has there been any worker injuries or accidents since the last policy was in effect?     | No to the best of my knowledge |
		| Do you have multiple locations in more than one state?                                   | no                             |
		| Federal Employer Identification Number (FEIN)                                            | 23-1234567                     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1234567
	Then wc user handles 1 excluded oo with these values:
		| Set Name    |
		| NameA NameB |
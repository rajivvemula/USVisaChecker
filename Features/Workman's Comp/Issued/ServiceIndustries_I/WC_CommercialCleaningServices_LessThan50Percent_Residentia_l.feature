Feature: WC_CommercialCleaningServices_LessThan50Percent_Residential_I
Issuing a WC Commercial Cleaning Services: Less than 50% Residential Policy in Connecticut
 
@Service @WC @Issued @CT @Regression @YourServices
Scenario: WC Commercial Cleaning Services: Less than 50% Residential issued policy in CT
	Given user starts a quote with:
		| Industry                                                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Commercial Cleaning Services: Less than 50% Residential | 13        | I Lease a Space From Others |              | 26554    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                   |
		| When do you want your policy to start?                                                 |                                          |
		| When did you start your business?                                                      | Started 9 years ago                      |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                                    |
		| Are there any employees that do not do any cleaning or maintenance work?               | No                                       |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                       |
		| Business                                                                               | Connecticut Commercial Cleaning Services |
		| Address                                                                                | 164 Country Estates;Fairmont             |
		| Fill Contact                                                                           |                                          |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                | Answer |
		| How many owners/officers does your business have?                                       | 4      |
		| How many owners/officers do you want to cover with this policy?                         | 2      |
		| Are there any included owners/officers that do not do any cleaning or maintenance work? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                   | Answer     |
		| What percentage of work done is water damage, fire damage, or mold restoration?            | 10         |
		| Do you do any construction related work such as carpentry, drywall, or demolition?         | no         |
		| Do you ever transport six or more workers in the same vehicle?                             | no         |
		| Do you clean any chimneys by crawling inside or climbing on roofs to access them?          | no         |
		| Do you clean any exterior windows above ground level?                                      | no         |
		| Do you offer any bulk removal services such as furniture, mattresses, or large appliances? | no         |
		| What percentage of work done is residential cleaning?                                      | 10         |
		| In the past 3 years how many Workers' Compensation claims were reported?                   | None       |
		| Do you do biological hazard clean up?                                                      | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                  | yes        |
		| Do you have multiple locations in more than one state?                                     | no         |
		| Federal Employer Identification Number (FEIN)                                              | 23-1965495 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	Then wc user handles 2 excluded oo with these values:
		| Set Name     |
		| Rivera Scott |
		| Theresa Lark |
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| Payment Option      | One Pay Plan           |
		| CC Name             | Test                   |
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
	Then user verifies the WC thank you page appearance
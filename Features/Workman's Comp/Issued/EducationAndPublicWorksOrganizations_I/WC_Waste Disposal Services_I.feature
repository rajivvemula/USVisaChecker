Feature: WC_WasteDisposalServices_I

Issuing a Waste Dipsoal Service policy in Florida.
@WC @Issued @FL @Education
Scenario: WC WasteDisposal policy issued in Florida
	Given user starts a quote with:
		| Industry                | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Waste Disposal Services | 7         | I Run My Business From Property I Own |              | 32091    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer              |
		| When do you want your policy to start?                                                 |                     |
		| When did you start your business?                                                      | Started 9 years ago |
		| How is your business structured?                                                       | Corporation         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000               |
		| Do any employees only do general office work and rarely travel?                        | No                  |
		| Business                                                                               | WasteDisposal;WD    |
		| Address                                                                                | 732 Alton Rd;Starke |
		| Fill Contact                                                                           |                     |
	Then user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty              |
		| Billy      | Bob       | yes        | 52000          | Operations            |
		| Bob        | Billy     | yes        | 52000          | General Office Worker |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                   | Answer                               |
		| Do you offer any bulk removal services such as furniture, mattresses, or large appliances? | no                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?                   | None                                 |
		| Are pick-up systems fully mechanized and/or automated?                                     | no                                   |
		| Do you review MVRs for all employees with a driving exposure?                              | Yes at the time of hire and annually |
		| Do you currently have a Workers' Compensation insurance policy in effect?                  | yes                                  |
		| Do you use any volunteers or donated labor?                                                | no                                   |
		| Do you have multiple locations in more than one state?                                     | no                                   |
		| Federal Employer Identification Number (FEIN)                                              | 23-2657748                           |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	Then user verifies that the Florida Premium Estimate Disclosure table contains these values:
		| Class Code | Class Code Description              | Estimated Annual Remuneration | Manual Rate |
		| 9403       | GARBAGE, ASHES OR REFUSE COLLECTION | $257,120.00                   | 5.22        |
		| 8810       | CLERICAL OFFICE EMPLOYEES NOC       | $57,200.00                    | 0.15        |
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user lands on and continues past the Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field                       | Value                             |
		| Payment Option              | 25% Down + 9 Monthly Installments |
		| CC Name                     | Florida Auto Repair               |
		| CC Number                   | 4111111111111111                  |
		| CC Expiration Month         | 11                                |
		| CC Expiration Year          | 25                                |
		| Autopay                     | Yes                               |
		| First Name                  | Florida                           |
		| Last Name                   | Auto Repair                       |
		| Email                       | FloridaAutoReapir@Automotive.com  |
		| Phone                       | 7777777777                        |
		| Same Billing Info?          | Yes                               |
		| Read Florida Applications?  | Yes                               |
		| Read Foregoing Application? | Yes                               |

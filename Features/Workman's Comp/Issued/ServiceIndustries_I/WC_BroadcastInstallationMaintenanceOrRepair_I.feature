Feature: WC_BroadcastInstallationMaintenanceOrRepair_I

WC Broadcast Installation Maintenance Or Repair Issued Policy In New Hampshire

@YourServices @WC @Issued @Regression @NH @Service
Scenario: WC Broadcast Installation Maintenance Or Repair Issued In New Hampshire
	Given user starts a quote with:
		| Industry                                       | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Broadcast Installation, Maintenance, or Repair | 11        | I Lease a Space From Others |              | 03218    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                    |
		| When do you want your policy to start?                                                 |                                           |
		| When did you start your business?                                                      | Started 9 years ago                       |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)               |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                                    |
		| Are there any cost estimators on staff that wouldn't do any direct physical work?      | no                                        |
		| Do any employees only do clerical office work or operate a retail store?               | no                                        |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                        |
		| Business                                                                               | Broadcast Installation Maintenance;Repair |
		| Address                                                                                | 948 Province Rd;Barnstead                 |
		| Fill Contact                                                                           |                                           |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer     |
		| Do you do any work higher than 30 feet above ground?                      | no         |
		| Do you erect radio, cellular, or television towers?                       | no         |
		| Do you do any work lower than 10 feet below ground?                       | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None       |
		| Do you climb on any utility poles?                                        | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes        |
		| Do you have multiple locations in more than one state?                    | no         |
		| Federal Employer Identification Number (FEIN)                             | 23-1626549 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page having the FEIN with value 23-1626549
	Then wc user handles 1 excluded oo with these values:
		| Set Name    | Set Job | Set DOB    |
		| NameA NameB | Member  | 09/09/1991 |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 10% Down + 10 Monthly Installments |
		| CC Name             | Broadcast                          |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | TestF                              |
		| Last Name           | TestL                              |
		| Email               | TestFTestL@Test123.com             |
		| Phone               | 7777777777                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: WC
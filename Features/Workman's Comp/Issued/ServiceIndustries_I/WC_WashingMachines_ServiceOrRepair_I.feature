Feature: WC_WashingMachines_ServiceOrRepair_I
Issuing Washing Machines: Service or Repair policy
zip code:24018

#@Service @WC @Issued @VA @Regression
Scenario: WC Washing Machines: Service Or Repair creates an issued policy for Virginia
	Given user starts a quote with:
		| Industry                               | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Washing Machines: Service or Repair    | 15        | I Lease a Space From Others        |              | 24018    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When did you start your business?                                                      | Started 8 years ago         |
		| How is your business structured?                                                       | Partnership                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                      |
		| Are there any employees that never travel to job sites or do any construction work?    | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               |                             |
		| Address                                                                                | 6542 Old Mill Rd;Roanoke    |
		| Fill Contact                                                                           |                             |
    #Manually click on continue ( mapping logic has to be implemented task:73585)
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                           | Answer |
		| How many owners/officers does your business have?                                                  | 2      |
		| How many owners/officers do you want to cover with this policy?                                    | 2      |
		| Are there any included owners/officers that never travel to job sites or do any construction work? | No     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                     | Answer                           |
		| Do you provide written guidelines and training on proper lifting techniques? | yes                              |
		| Do you service or repair appliances?                                         | Yes we service/repair appliances |
		| In the past 3 years how many Workers' Compensation claims were reported?     | None                             |
		| Do you review MVRs for all employees with a driving exposure?                | No                               |
		| Do you currently have a Workers' Compensation insurance policy in effect?    | yes                              |
		| Do you have multiple locations in more than one state?                       | no                               |	
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 2 excluded oo with these values:
		| Set Name    |
		| NameA NameB |
		| NameC NameD |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 27                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 3211234567                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: GL

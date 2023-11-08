Feature: WC_AmazonDeliveryService_I
Issuing a WC Amazon Delivery Service policy in NY
ZIP Code: 10001
Additional Info page - Setting the SSN scenario

@OwnerOfficer @Issued @WC @Transportation @NY
Scenario: WC Amazon Delivery Service creates issued policy in NY
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Amazon Delivery Service | 3         | I Lease a Space From Others |              | 10001    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer               |
		| When do you want your policy to start?                                                 |                      |
		| When did you start your business?                                                      | Started 9 years ago  |
		| How is your business structured?                                                       | Corporation          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 240240               |
		| Are there any employees that do not drive and do not load/unload goods?                | no                   |
		| Do any owner operators or sub-haulers transport goods on your behalf?                  | no                   |
		| Business                                                                               | Amazon Deliveries    |
		| Address                                                                                | 429 7th Ave;New York |
		| Fill Contact                                                                           |                      |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 3      |
	Then user handles the WC Covered OO with these values:
		| Name | W2 payroll | Annual Payroll |
		|      | yes        | 14000          |
		|      | yes        | 15000          |
		|      | yes        | 16000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                               |
		| What type of vehicle is primarily used for your business?                                                          | Flatbed truck                        |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                                 |
		| What is the maximum weight (in lbs.) of any item being handled or delivered?                                       | 20                                   |
		| Do you review MVRs for all employees with a driving exposure?                                                      | Yes at the time of hire and annually |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | no                                   |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                                   |
		| When was your last policy in effect?                                                                               | Never no prior insurance             |
		| Do you have multiple locations in more than one state?                                                             | no                                   |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the SSN with value 231-11-1111
	Then wc user handles 3 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                |
		| Payment Option      | One Pay Plan         |
		| CC Name             | Funky Chicken-cheese |
		| CC Number           | 4111111111111111     |
		| CC Expiration Month | 11                   |
		| CC Expiration Year  | 25                   |
		| Autopay             | No                   |
		| First Name          | Funky                |
		| Last Name           | Kong                 |
		| Email               | FunkyKong@Cheese.com |
		| Phone               | 7777777777           |
		| Same Billing Info?  | Yes                  |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that the following LOBs are recommended: BOP
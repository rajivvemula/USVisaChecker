Feature: WC_FurnitureMovingAndStorage_D
Keyword: Furniture Moving and Storage
Ineligible quote - response to carrier question FEIN (blacklisted)
Zip Code: 34465
City: Beverly Hills
Employee option: 15
Business Operation: I Lease a Space From Others
Years in Businiess: 7
Payroll: 800000
Entity type: LLC
FEIN: 83-1978320    

@Health @WC @Declined @FL @Regression
Scenario: WC Furniture Moving And Storage gets declined due to blacklisted FEIN
	Given user starts a quote with:
		| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Furniture Moving and Storage | 15        | I Lease a Space From Others |              | 34465    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                       | Answer                          |
		| When do you want your policy to start?                                                                         |                                 |
		| When did you start your business?                                                                              | Started 7 years ago             |
		| How is your business structured?                                                                               | Limited Liability Co. (LLC)     |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                         | 800000                          |
		| Are there any back office employees that would never assist with moves, handle any goods, or drive any trucks? | no                              |
		| Are there any drivers that drive trucks you own or lease but pay via 1099?                                     | no                              |
		| Do any owner operators or sub-haulers transport goods on your behalf?                                          | no                              |
		| Business                                                                                                       | Furniture Moving and Storage    |
		| Address                                                                                                        | 7 N Washington St;Beverly Hills |
		| Contact First Name                                                                                             | TestF                           |
		| Contact Last Name                                                                                              | TestL                           |
		| Email                                                                                                          | Test@Test123.com                |
		| Phone                                                                                                          | 1231231321                      |
		| Business website                                                                                               | test.com                        |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| OneF       | OneL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                     | Answer                               |
		| Do you provide written guidelines and training on proper lifting techniques? | no                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?     | None                                 |		
		| Do you review MVRs for all employees with a driving exposure?                | Yes at the time of hire and annually |
		| Do you currently have a Workers' Compensation insurance policy in effect?    | yes                                  |
		| Do you have multiple locations in more than one state?                       | no                                   |
		| Federal Employer Identification Number (FEIN)                                | 83-1978320                           |
	Then user verifies the WC decline page appearance
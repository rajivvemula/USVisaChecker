Feature: WC_ShoeRepair_D

Decline - DeclineReason:Occupancy Type and years in business is not eligible 
The conditions for referral per US 94210 are:
1. quote should use the keyword for Industry = 'Service Industries' and Subindustry = 'Installation/Repair' 
2. Occupancy = Lease
3. Years in busines < 2 yrs
Keyword: Shoe Repair

@WC @Regression @Declined @Cali
Scenario: WC Shoe Repair quote is declined in Cali
	Given user starts a quote with:
		| Industry    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Shoe Repair | 3         | I Lease a Space From Others |              | 90012    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 1 year ago          |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100,000                     |
		| Do any employees only do general office work and do not work a cash register?          | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | WC Shoe Repair              |
		| Address                                                                                | 100 S Main St;Los Angeles   |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       |                             |
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the WC decline page appearance
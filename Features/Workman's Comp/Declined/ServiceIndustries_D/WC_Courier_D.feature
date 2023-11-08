Feature: WC_Courier_D
Issuing a Courier - New Jersey Issued Policy 
 
@Service @WC @Declined @NJ @Regression @YourServices
Scenario: WC Courier policy issued in New Jersey
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Courier  | 3         | I Lease a Space From Others |              | 08608    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 9 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                       |
		| Are there any employees that do not drive and do not load/unload goods?                | yes                         |
		| Do you make any payments to workers using IRS Form 1099?                               | no                          |
		| Business                                                                               | Courier LLC;CE              |
		| Address                                                                                | 128 Steese Hwy;Trenton      |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                             | Answer |
		| Do you want to buy coverage for the business owners? | no     |
		| How many owners/officers are there?                  | 1      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Vera       | Angel     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                               |
		| Does your business have a USDOT Number?                                                                            | no                                   |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                        | 0 - 50 miles                         |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                            | no                                   |
		| Are any deliveries or pick-ups made by bicycle?                                                                    | yes                                  |
		| What type of vehicle is primarily used for your business?                                                          | Flatbed truck                        |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                                 |
		| What is the maximum weight (in lbs.) of any item being handled or delivered?                                       | 10                                   |
		| Do you review MVRs for all employees with a driving exposure?                                                      | Yes at the time of hire and annually |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes                                  |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                                   |
		| Do you have multiple locations in more than one state?                                                             | no                                   |
		| Does your business have a state-issued experience modification factor (XMOD)?                                      | no                                   |
	Then user verifies the WC decline page appearance
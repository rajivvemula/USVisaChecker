Feature: WC_LoungeOrNightClub_D
Ineligible Quote for:
Keyword: Lounge Or Night Club
Reason: DeclineReason::Decline due to moral hazard. There was an uninsured injury and the employer is now seeking insurance.
Employee option: Various employees - 6
ZIPCode: 13838
Employee Payroll: 300,000
Entity type: Limited Liability Co. (LLC)
Years in business: Started this year
Included owner officers: No
Excluded owner officer: 1

@Restaurant @WC @Declined @NY @Regression
Scenario: WC Lounge Or Night Club gets declined because accidents/injuries happened while not covered
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lounge or Night Club | 6         | I Lease a Space From Others |              | 13838    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                        |
		| When do you want your policy to start?                                                 |                               |
		| When did you start your business?                                                      | Started this year             |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 300,000                       |
		| Business                                                                               | Lounge Or Night Club Referral |
		| Address                                                                                | 28 River St;Sidney            |
		| Contact First Name                                                                     | TestF                         |
		| Contact Last Name                                                                      | TestL                         |
		| Email                                                                                  | Test@Test123.com              |
		| Phone                                                                                  | 1231231321                    |
		| Business website                                                                       | test.com                      |
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
		| Question                                                                             | Answer                                   |
		| In the past 3 years how many Workers' Compensation claims were reported?             | None                                     |
		| Do you use bouncers or security guards?                                              | No                                       |
		| Are you open after 2 A.M.?                                                           | yes                                      |
		| Do you currently have a Workers' Compensation insurance policy in effect?            | no                                       |
		| When was your last policy in effect?                                                 | 30 days to 6 months ago                  |
		| Has there been any worker injuries or accidents since the last policy was in effect? | Yes there has been injuries or accidents |
		| Do you have multiple locations in more than one state?                               | no                                       |
	Then user verifies the WC decline page appearance
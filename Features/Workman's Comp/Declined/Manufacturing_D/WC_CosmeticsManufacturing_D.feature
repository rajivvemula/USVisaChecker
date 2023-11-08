Feature: WC_CosmeticsManufacturing_D
Ineligible Quote for Keyword: Cosmetics Manufacturing
Quote gets declined because customer selects Yes to handle, store, or transport any hazardous corrosive substances
Number of employee : 20
Business Operation: I Lease a Space From Others
ZIP Code: 03227
Included Officer: 3
Excluded Officer:2
Business started year : Started 6 years ago
Business Structured: LLC

@WC @Manufacturing @Regression @Declined @IL @OwnerOfficer
Scenario: WC Cosmetics Manufacturing gets declined because customer selects Yes to handle, store, or transport any hazardous corrosive substances
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Cosmetics Manufacturing | 20        | I Lease a Space From Others |              | 03227    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                                                         | Answer                        |
		| When do you want your policy to start?                                                                           |                               |
		| When did you start your business?                                                                                | Started 6 years ago           |
		| How is your business structured?                                                                                 | Limited Liability Co. (LLC)   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                           | 70000                         |
		| Are there any delivery drivers on staff?                                                                         | no                            |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process?                  | no                            |
		| Are there any administrative or back office employees that are not involved at all in the manufacturing process? | no                            |
		| Business                                                                                                         | Fluffy Maui LLC               |
		| Address                                                                                                          | 550 W 25th St;Center Sandwich |
		| Contact First Name                                                                                               | TestF                         |
		| Contact Last Name                                                                                                | TestL                         |
		| Email                                                                                                            | automationtest@biberk.com     |
		| Phone                                                                                                            | 1231231321                    |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	And user handles the WC OO kickoff questions with these values:
		| Question                                                          | Answer |
		| How many owners/officers does your business have?                 | 5+     |
		| How many owners/officers do you want to cover with this policy?   | 3      |
		| How many owners/officers do you want to exclude from this policy? | 2      |
	Then user continues on from the WC OO page
	And user verifies the appearance of the WC Your Services Page
	And user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you handle, store, or transport any hazardous corrosive substances?    | yes                                           |
		| Do you handle, store, or transport any explosives or blasting agents?     | no                                            |
		| Do you handle, store, or transport any ammonium nitrate?                  | no                                            |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the WC decline page appearance
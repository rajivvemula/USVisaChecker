Feature: WC_MusicianBand_D
Ineligible Quote for the 
Keyword: Pawn shop
Reason: DeclineReason: want insurance to cover volunteers
Employee option: 2
ZIP code: 07601
Business Structured: Partnership
Business Operation: I Lease a Space From Others  
Business started year : Started 8 years ago


@WC @Hospitality @Declined @SC @Regression
Scenario: WC Musician: Band declined because want insurance to cover volunteers
	Given user starts a quote with:
		| Industry       | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Musician: Band | 2         | I Lease a Space From Others |              | 07106    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer               |
		| When do you want your policy to start?                                                 |                      |
		| When did you start your business?                                                      | Started 8 years ago  |
		| How is your business structured?                                                       | Corporation          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 200000               |
		| Are there any actors, entertainers, or musicians on staff?                             | No                   |
		| Do you make any payments to workers using IRS Form 1099?                               | No                   |
		| Business                                                                               | Musician, Band       |
		| Address                                                                                | 2 MONTROSE ST;Newark |
		| State                                                                                  | NJ                   |
		| Zip Code                                                                               | 07106                |
		| Contact First Name                                                                     | Musician             |
		| Contact Last Name                                                                      | Band                 |
		| Email                                                                                  | test@test123.com     |
		| Phone                                                                                  | 1212631654           |
		| Business website                                                                       | www.GoldandPawn.com  |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty              |
		| Billy      | Bob       | yes        | 52000          | Operations or Cashier |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                          | Answer |
		| Do you use pyrotechnics?                                                          | no     |
		| Do you perform acts with knives, other sharp objects, fire, or live ammunition?   | no     |
		| Do you do any work higher than 30 feet above ground?                              | no     |
		| Do you help set up furniture or install any sound/lighting at events?             | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?          | None   |
		| Do you work with lions, tigers, leopards, bears, elephants, or venomous reptiles? | no     |
		| Do you currently have a Workers' Compensation insurance policy in effect?         | yes    |
		| Do you use any volunteers or donated labor?                                       | yes    |
		| What percentage of workers are volunteers or donated labor?                       | 40     |
		| Were you looking to buy insurance, in case of an injury, for your volunteers?     | Yes    |
		| Do you have multiple locations in more than one state?                            | no     |
	Then user verifies the WC decline page appearance
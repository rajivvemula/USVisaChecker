Feature: WC_CondominiumResidential_I

Issued Policy for the Keyword: Condominium: Residential; Association Risk Only
ZIP code: 19954

@WC @Issued @DE @Regression @YourServices 
Scenario: WC Condominium Residential issued policy in DE
	Given user starts a quote with:
		| Industry                                        | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Condominium: Residential; Association Risk Only | 3         | I Run My Business From Property I Own |              | 19954    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                         |
		| When do you want your policy to start?                                                 |                                |
		| When did you start your business?                                                      | Started 9 years ago            |
		| How is your business structured?                                                       | Corporation                    |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                         |
		| Are there any cost estimators on staff that wouldn't do any direct physical work?      | no                             |
		| Do any employees only do general office work and rarely travel?                        | no                             |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                             |
		| Business                                                                               | MD Auto Garage;MAG             |
		| Address                                                                                | 13999 Aspen Cove Court;Houston |
		| Contact First Name                                                                     | TestF                          |
		| Contact Last Name                                                                      | TestL                          |
		| Email                                                                                  | Test@Test123.com               |
		| Phone                                                                                  | 1231231321                     |
		| Business website                                                                       | test.com                       |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                    | Answer |
		| How many owners/officers does your business have?                                           | 1      |
		| How many owners/officers do you want to cover with this policy?                             | 1      |
		| Are any included owners/officers cost estimators that wouldn't do any direct physical work? | No     |
		| Do any included owners/officers only do general office work and rarely travel?              | No     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
	    | Question                                                                                   | Answer                   |
	    | What percentage of work done is water damage, fire damage, or mold restoration?            | 0                        |
	    | Do you ever transport six or more workers in the same vehicle?                             | no                       |
	    | Do you clean any chimneys by crawling inside or climbing on roofs to access them?          | no                       |
	    | Do you clean any exterior windows above ground level?                                      | no                       |
	    | Do you engage in any new construction, remodeling, or framing work?                        | yes                      |
	    | Do you engage in any roofing work?                                                         | no                       |
	    | What percentage of work is framing?                                                        | 10                       |
	    | Do you offer any bulk removal services such as furniture, mattresses, or large appliances? | no                       |
	    | In the past 3 years how many Workers' Compensation claims were reported?                   | None                     |
	    | Do you currently have a Workers' Compensation insurance policy in effect?                  | no                       |
	    | When was your last policy in effect?                                                       | Never no prior insurance |
	    | Do you have multiple locations in more than one state?                                     | no                       |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1234567
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | MAG Auto Garage                   |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
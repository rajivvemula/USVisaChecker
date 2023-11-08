Feature: WC_DaySpasWithBodyMassages_I

Issuing a Day Spas: With Body Massages policy

@Service @WC @Issued @Cali @Regression @YourServices
Scenario: WC Day Spas: With Body Massages issuing a policy for CA
	Given user starts a quote with:
		| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Day Spas: With Body Massages | 0         | I Lease a Space From Others |              | 93944    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                 | Answer                           |
		| When do you want your policy to start?                   |                                  |
		| When did you start your business?                        | Started 10 years or more ago     |
		| How is your business structured?                         | Corporation                      |
		| Do you make any payments to workers using IRS Form 1099? | no                               |
		| Business                                                 | R. Lee Ermey's Spa Services;ESS  |
		| Address                                                  | 443 Chaplain Magsig Ave;Monterey |
		| Fill Contact                                             |                                  |
	Then user verifies the appearance of the WC Owners and Officers Page
	And user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	And user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| Are you open after 10 P.M.?                                               | yes    |
		| What percentage of work is done at client's locations?                    | 10     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization | Value |
		| N/A           | N/A   |
	Then user begins the WC AI page setting the FEIN with value 23-7277824
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Preservation Guy                  |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | Yes                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL,BOP
Feature: WC_HospitalGeneral_I
Issuing policy for Hospital: General
ZIP Code: 29706 (SC)
130 Walnut St, Chester, SC 29706

@WC @Regression @Health @Issued @SC
Scenario: WC Hospital: General creates issued policy in South Carolina
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hospital: General | 7         | I Lease a Space From Others |              | 29706    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                            |
		| When do you want your policy to start?                                                          |                                   |
		| When did you start your business?                                                               | Started 9 years ago               |
		| How is your business structured?                                                                | Non-Profit Corp 501(c)(3)         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 440440                            |
		| Are there any licensed employee physicians, RNs, practical nurses, directors or administrators? | no                                |
		| Are there any administrative staff that never interact with clients/patients?                   | no                                |
		| Do you make any payments to workers using IRS Form 1099?                                        | no                                |
		| Business                                                                                        | General Hospital;General Hospital |
		| Address                                                                                         | 130 Walnut St;Chester             |
		| Fill Contact                                                                                    |                                   |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                   | Answer |
		| How many owners/officers does your business have?                                          | 1      |
		| How many owners/officers do you want to cover with this policy?                            | 1      |
		| Are any included owners/officers licensed physicians, nurses, directors or administrators? | No     |
		| Are there any included owners/officers that never interact with clients/patients?          | No     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer     |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None       |
		| Do you make any payments to individuals or businesses using IRS Form 1099?                             | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes        |
		| Do you use any volunteers or donated labor?                                                            | no         |
		| Do you have multiple locations in more than one state?                                                 | no         |
		| Federal Employer Identification Number (FEIN)                                                          | 23-2651148 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Multi-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page having the FEIN with value 23-2651148
	Then wc user handles 1 excluded oo with these values:
		| Set Name       |
		| General Doctor |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 20% Down + 9 Monthly Installments |
		| CC Name             | Funky Chicken-cheese              |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | Funky                             |
		| Last Name           | Kong                              |
		| Email               | FunkyKong@Cheese.com              |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
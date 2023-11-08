Feature: PL_HealthcareAssistant_I

Issuing a PL Policy using the Healthcare Assistant keyword to verify Your Services new Class Level Questions.
Question: What kind of assistant are you?

@Regression @PL @HealthCare @Issued @ND
Scenario: PL Healthcare Assistant Issued policy in ND
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Healthcare Assistant | 1         | I Lease a Space From Others |              | 58108    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | HA               | Southgate Dr S   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2010   |
		| How many healthcare professionals work for your business? | 1      |
		| How many health students work for your business?          | 0      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer           |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No               |
		| What kind of assistant are you?                                                                                                                                                                                                                        | Dental Assistant |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No               |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No               |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Tester             |
		| Last Name              | EJ                 |
		| Address                | 12 Bargaintown St. |
		| Apt/Suite              |                    |
		| City                   | Fargo              |
		| Use as Mailing Address | Yes                |
		| Email                  | abc@tester.com     |
		| Business Phone         | 3213213211         |
		| Ext                    |                    |
		| Website/Social         |                    |
		| Have Broker            | No                 |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Tester EJ           |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 12 Bargaintown St   |
		| ZIP Code       | 58108               |
		| City           | Fargo               |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
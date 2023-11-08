Feature: PL_RegisteredNurse_I

Issuing a PL Policy using the Registered Nurse keyword to verify Your Services new Class Level Questions.

@Regression @PL @HealthCare @Issued @ND
Scenario: PL Registered Nurse Issued policy in ND
	Given user starts a quote with:
		| Industry                           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Registered Nurse                   | 2         | I Lease a Space From Others |              | 58108    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Nurse            | Southgate Dr S   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2010   |
		| How many healthcare professionals work for your business? | 2      |
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
		| Question                                                                                                                                                                                                                                               | Answer |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No     |
		| Do you provide facial injection, fillers, or laser treatment services?                                                                                                                                                                                 | No     |
		| Do you assist with any surgeries?                                                                                                                                                                                                                      | No     |
		| Are any of the business owner(s) or staff Intensive Care Unit (ICU) specialists?                                                                                                                                                                       | No     |
		| Do you assist with labor/delivery of babies?                                                                                                                                                                                                           | No     |
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No     |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No     |
		| Are you a nurse practitioner?                                                                                                                                                                                                                          | No     |
		| Are you a Physicians Assistant?                                                                                                                                                                                                                        | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
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
		| Business Phone         | 3213213221         |
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
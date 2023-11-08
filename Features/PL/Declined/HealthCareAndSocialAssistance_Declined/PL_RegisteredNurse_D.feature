Feature: PL_RegisteredNurse_D

Declined a PL Policy with the Registered Nurse keyword and verified Your Services new Class Level Questions.
Question: Is all general anesthesia or deep sedation work done in a hospital or accredited facility?

@Regression @PL @HealthCare
Scenario: PL Registered Nurse gets Declined
	Given user starts a quote with:
		| Industry         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Registered Nurse | 2         | I Lease a Space From Others |              | 58011    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Nurse            | 407 Main St      | No  |
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
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | Yes    |
		| Is all general anesthesia or deep sedation work done in a hospital or accredited facility?                                                                                                                                                             | No     |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No     |
		| Are you a nurse practitioner?                                                                                                                                                                                                                          | No     |
		| Are you a Physicians Assistant?                                                                                                                                                                                                                        | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer          |
		| First Name             | Test            |
		| Last Name              | EJ              |
		| Address                | 407 Main St     |
		| Apt/Suite              | 3               |
		| City                   | Buffalo         |
		| Use as Mailing Address | No              |
		| Mailing Address        | 407 Main St     |
		| Mailing Apt/Suite      | 3               |
		| Mailing ZIP            | 58011           |
		| Mailing City           | Buffalo         |
		| Email                  | abc@bargain.com |
		| Business Phone         | 3213212321      |
		| Ext                    | 123             |
		| Website/Social         | www.tester.com  |
	Then user verifies the PL decline page appearance
Feature: PL_SpeechTherapist_I

Issuing a PL Policy using the Speech Therapist: Non-Traveling keyword to verify Business Details page new Industry Level Questions and Your Services new Class Level Questions.

@Regression @PL @HealthCare @ND @Issued
Scenario: PL Speech Therapist: Non-Traveling Issued policy in ND
	Given user starts a quote with:
		| Industry                        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Speech Therapist: Non-Traveling | 0         | I Lease a Space From Others |              | 58011    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | Business Address | DBA |
		| Individual/Sole Proprietor | 407 Main St      | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                                            | Answer                 |
		| What year was your business started?                                                                                | 2010                   |
		| How many healthcare professionals work for your business?                                                           | 2                      |
		| Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)? | Independent Contractor |
		| Have you obtained this professional healthcare designation within the last two years?                               | Yes                    |
		| When did you graduate or obtain this designation?                                                                   |                        |
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
		| Do you perform any Intraoperative neurophysiological monitoring (IONM) or intraoperative neuromonitoring?                                                                                                                                              | No     |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer         |
		| First Name             | Tester         |
		| Last Name              | EJ             |
		| Address                | 407 Main St    |
		| Apt/Suite              |                |
		| City                   | Buffalo        |
		| Use as Mailing Address | Yes            |
		| Email                  | abc@tester.com |
		| Business Phone         | 3213213211     |
		| Ext                    |                |
		| Website/Social         |                |
		| Have Broker            | No             |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Monthly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Mandatory           |
		| CC Name        | Tester              |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 407 Main St         |
		| ZIP Code       | 58011               |
		| City           | Buffalo             |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
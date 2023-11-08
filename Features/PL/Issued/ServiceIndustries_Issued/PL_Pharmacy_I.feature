Feature: PL_Pharmacy_I

@Regression @PL @Retail @Issued @UT
Scenario: PL Pharmacy issued policy in UT
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Pharmacy | 2         | I Lease a Space From Others |              | 84076    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Samus Medicine   | 10333 8000 E     | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2019   |
		| How many healthcare professionals work for your business? | 3      |
		| How many health students work for your business?          | 0      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer |
		| When should your policy start?                                                         |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes    |
		| Does your current policy have a retroactive date?                                      | Yes    |
		| What is the retroactive date?                                                          |        |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0      |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No     |
		| Do you do any manufacturing or sell any products under your own label?                                                                                                                                                                                 | No     |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | TestF              |
		| Last Name              | TestLast           |
		| Address                | 225 S Canal St     |
		| Apt/Suite              |                    |
		| City                   | Tridell            |
		| Use as Mailing Address | Yes                |
		| Email                  | accountant@biz.com |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | Pharmacy            |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/24               |
		| Street Address | 225 S Canal St      |
		| ZIP Code       | 84076               |
		| City           | Tridell             |
		| Phone          | 9198857474          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC
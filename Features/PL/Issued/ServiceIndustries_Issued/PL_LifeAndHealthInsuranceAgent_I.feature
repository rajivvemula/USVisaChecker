Feature: PL_LifeAndHealthInsuranceAgent_I

@Regression @PL @Service @Staging @Issued @PA
Scenario: PL Life And Health Insurance Agent issued policy in PA
	Given user starts a quote with:
		| Industry                        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Life and Health Insurance Agent | 0         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business      | Business Address | DBA | LLC |
		| Corporation        | Test PL Quote E&O LLC | 1060 Church Rd   | No  | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer  |
		| What year was your business started?         | 2020    |
		| What is your estimated gross annual revenue? | 250,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer   |
		| When should your policy start?                                                         |          |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes      |
		| Does your current policy have a retroactive date?                                      | Yes      |
		| What is the retroactive date?                                                          | 1/1/2021 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0        |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer      |
		| Do you provide financial investment advice?                                                                                                                                                                                                            | No          |
		| Do you adjust claims?                                                                                                                                                                                                                                  | No          |
		| Do you provide advice or services that require a Certified Public Accountant?                                                                                                                                                                          | No          |
		| Do you sell any Property & Casualty Insurance?                                                                                                                                                                                                         | No          |
		| Do you act as a broker for any reinsurance contracts such as quota shares or excess loss treaties?                                                                                                                                                     | No          |
		| Do you function as a Managing General Agent/Underwriter (MGA)?                                                                                                                                                                                         | No          |
		| Do you create, manage, or provide services for a Health Maintenance Organization (HMO) plan?                                                                                                                                                           | No          |
		| Which types of Life & Health insurance do you sell?                                                                                                                                                                                                    | Health;Life |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No          |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer                      |
		| First Name             | TestF                       |
		| Last Name              | TestL                       |
		| Address                | 100 Test Road               |
		| Apt/Suite              |                             |
		| City                   | York                        |
		| Use as Mailing Address | Yes                         |
		| Email                  | LifeAndHealth@Insurance.com |
		| Business Phone         | 1231231321                  |
		| Ext                    | 1234                        |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 100 Test Road       |
		| ZIP Code       | 17404               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      | 1234                |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: BOP
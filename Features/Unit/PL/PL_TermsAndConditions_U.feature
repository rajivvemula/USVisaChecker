Feature: PL_TermsAndConditions_U
PL insurance agent test to verify the Terms and Conditions page.
keeping Triat for pipeline run until we add soft credit check step

@Unit @PL @TandC
Scenario: PL verify the Terms and Conditions page
	Given user starts a quote with:
		| Industry        | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Insurance Agent | 7         | I Run My Business From Property I Own |              | 74468    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business        | Insured First Name | Insured Last Name | Business Address | DBA | LLC |
		| Corporation        | Test PL Insurance Agent | FN                 | LN                | 103 Main St      | No  | No  |
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
	#soft credit check step to be added
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer                  |
		| First Name             | TestF                   |
		| Last Name              | TestL                   |
		| Address                | 103 Main St             |
		| Apt/Suite              |                         |
		| City                   | Wainwright              |
		| Use as Mailing Address | Yes                     |
		| Email                  | TestAgent@Insurance.com |
		| Business Phone         | 8339680442              |
		| Ext                    |                         |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	Then user verifies the PL terms and conditions page appearance
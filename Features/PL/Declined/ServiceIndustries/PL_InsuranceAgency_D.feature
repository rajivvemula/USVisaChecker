Feature: PL_InsuranceAgency_D

Partial Feature File added for implementing the "Then user verifes the PL purchase page appearance" step logic - US 71967
Insurance Agency Decline Path : "Do you do any work as a public adjustor?": "Yes"

#@PL @ServiceIndustry @Regression @Declined
Scenario: PL Insurance Agency gets Declined
	Given user starts a quote with:
		| Industry         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Insurance Agency | 5         | I Lease a Space From Others |              | 33065    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business | Business Address | DBA |
		| Limited Liability Co LLC | Samus Insurance  | 9604 NW 35th Ct  | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer   |
		| What year was your business started?         | 2019     |
		| What is your estimated gross annual revenue? | $100,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                     | Answer     |
		| When should your policy start?                                               |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?       | Yes        |
		| Does your current policy have a retroactive date?                            | Yes        |
		| What is the retroactive date?                                                | 06/01/2022 |
		| How many Errors & Omissions claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer           |
		| What types of customers do you serve?                                                                                                                                                                                                                  | Individuals only |
		| Do you provide financial investment advice?                                                                                                                                                                                                            | No               |
		| Do you adjust claims?                                                                                                                                                                                                                                  | Yes              |
		| Do you do any work as a public adjustor?                                                                                                                                                                                                               | Yes              |
		| Do you adjust Asbestos, Energy, Environmental, or Marine claims?                                                                                                                                                                                       | Yes              |
		| Do you have a written procedure for handling large claims volume increases from a catastrophe?                                                                                                                                                         | No               |
		| Do you provide advice or services that require a Certified Public Accountant?                                                                                                                                                                          | No               |
		| Which types of Property & Casualty insurance do you sell?                                                                                                                                                                                              | Homeowners       |
		| Do you sell insurance products directly over the internet?                                                                                                                                                                                             | No               |
		| Do you act as a broker for any reinsurance contracts such as quota shares or excess loss treaties?                                                                                                                                                     | Yes              |
		| Do you function as a Managing General Agent/Underwriter (MGA)?                                                                                                                                                                                         | No               |
		| Do you create, manage, or provide services for a Health Maintenance Organization (HMO) plan?                                                                                                                                                           | No               |
		| Do you help set up or service self-insurance, risk retention groups, or captives?                                                                                                                                                                      | Yes              |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No               |
	Then user fills out About You page with these values:
		| Question       | Answer         |
		| First Name     | Test           |
		| Last Name      | Zero           |
		| Address        | 100 Main St    |
		| Appt/Suite     |                |
		| City           | Coral Springs  |
		| Email          | zero@samus.com |
		| Business Phone | 2789282892     |
	Then user verifies the PL decline page appearance
 Feature:PL_MixedMartialArtsTraining_R

Task 81855: Staging Regression | Create Test Case | PL | Referral | High Premium

@PL @Hospitality @Regression @Referred @Staging @Cali @Ignore
Scenario: PL Mixed Martial Arts Training Referred
	Given user starts a quote with:
		| Industry                    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Mixed Martial Arts Training | 12        | I Lease a Space From Others |              | 75014    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | DBA |
		| Individual/Sole Proprietor | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer      |
		| What year was your business started?         | 2020        |
		| What is your estimated gross annual revenue? | 350,000,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 11/01/2020 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                     |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | Yes                        |
		| To whom do you provide training?                                                                                                                                                                                                                       | One on One Training Only   |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | Yes                        |
		| Describe the athletic competitions:                                                                                                                                                                                                                    | TEST MMA TRAINING CASE 16  |
		| Do you train professional athletes?                                                                                                                                                                                                                    | No                         |
		| What training do you provide?                                                                                                                                                                                                                          | Dance;Yoga;Weight Training |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                         |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                         |
	Then user fills out About You page with these values:
		| Question               | Answer                  |
		| First Name             | Test PL API             |
		| Last Name              | Test Case 16            |
		| Address                | 202 North St            |
		| Apt/Suite              |                         |
		| City                   | Irving                  |
		| Use as Mailing Address | Yes                     |
		| Email                  | TestCert@Plan.com       |
		| Business Phone         | (123) 123-1231          |
		| Ext                    | 1234                    |
		| Website/Social         | www.TestPartnerCert.com |
		| Have Broker            | Yes                     |
		| Manager First Name     | Yum                     |
		| Manager Last Name      | Yo                      |
		| Manager Phone Number   | (909) 565-9999          |
		| Manager Phone Ext      | 778                     |
		| Manager Email          | dfgfdg@ff.lol           |
	When user fills out the PL refer page with these values:
		| Field              | Value                            |
		| Insured first name | Test PL API                      |
		| Insured last name  | Test Case 16                     |
		| Contact first name | Test PL API                      |
		| Contact last name  | Test Case 16                     |
		| Broker first name  | Broker                           |
		| Broker last name   | Test Case 16                     |
		| Broker Email       | Broker@TestPlan.com              |
		| Email              | TestCert@Plan.com                |
		| Broker Phone       | (777) 123-1231                   |
		| Broker Ext         | 7777                             |
		| Phone              | (123) 123-1231                   |
		| Ext                | 1234                             |
		| Business website   | www.MixedMartialArtsTraining.com |
	Then user verifies the PL refer confirmation appearance

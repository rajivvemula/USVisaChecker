Feature: PL_TitleAgent_R

Referral Target Question: Which property services are provided?
Answer: Real Estate Agent
Referral Reason: Yes to non-eligible risk. Referral need to add real estate agent forms.

@PL @Staging @Regression @Service @Referred
Scenario: PL_TitleAgent_R Title Agent UW Question Checkbox
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Title Agents | 0         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure          | Name of Business          | Business Address      | DBA      |
		| Limited Liability Co. (LLC) | Test PL Refer UW Checkbox | 2125 York Crossing Dr | Test DBA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2016   |
		| What is your estimated gross annual revenue? | 450000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Which property services are provided?                                                                                                                                                                                                                  | Real Estate Agent |
		| Do you collect private data?                                                                                                                                                                                                                           | Yes               |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user fills out About You page with these values:
		| Question               | Answer        |
		| First Name             | TestF         |
		| Last Name              | TestL         |
		| Address                | 100 Test Road |
		| City                   | York          |
		| Use as Mailing Address | Yes           |
		| Email                  | test@biz.com  |
		| Business Phone         | 3172491913    |
	When user fills out the PL refer page with these values:
		| Field              | Value                     |
		| Business name      | Test PL Refer UW Checkbox |
		| DBA                | Test DBA                  |
		| Contact first name | TestF                     |
		| Contact last name  | TestL                     |
		| Email              | test@biz.com              |
		| Phone              | (317) 249-1913            |
	Then user verifies the PL refer confirmation appearance
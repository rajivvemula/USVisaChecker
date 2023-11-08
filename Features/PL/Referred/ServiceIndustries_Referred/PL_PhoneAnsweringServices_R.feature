Feature: PL_PhoneAnsweringServices_R

//Task 81861: Staging Regression | Create Test Case | PL | Referral | Low Payroll

@PL @Service @Regression @Referred @Staging
Scenario: PL Phone Answering Services Referred
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Phone Answering Services | 7         | I Lease a Space From Others |              | 06001    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address    | DBA |
		| Sub-Chapter Corp   | TEST PL API CASE 20 | 160 Country Club Rd | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer  |
		| What year was your business started?                      | 2021    |
		| What is your estimated gross annual revenue?              | 100,000 |
		| Do you use a written contract or statement of work (SOW)? | Never   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                | Answer |
		| Do you currently have a Professional Liability (E&O) policy in effect?  | No     |
		| Have you had a Professional Liability (E&O) policy in the last 3 years? | No     |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                                   |
		| Do you collect private data?                                                                                                                                                                                                                           | No                                       |
		| Do you record all calls with customers?                                                                                                                                                                                                                | Yes we keep records for more than 1 year |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                       |
	Then user fills out About You page with these values:
		| Question               | Answer                  |
		| First Name             | TEST PL API             |
		| Last Name              | TEST CASE 20            |
		| Address                | 441 Lovely St           |
		| Apt/Suite              |                         |
		| City                   | Avon                    |
		| Use as Mailing Address | Yes                     |
		| Email                  | TestCert@Plan.com       |
		| Business Phone         | (123) 123-1321          |
		| Ext                    | 1234                    |
		| Website/Social         | www.TestPartnerCert.com |
		| Have Broker            | No                      |
	When user fills out the PL refer page with these values:
		| Field              | Value                   |
		| Business name      | TEST PL API CASE 20     |
		| Contact first name | TEST PL API             |
		| Contact last name  | TEST CASE 20            |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the PL refer confirmation appearance
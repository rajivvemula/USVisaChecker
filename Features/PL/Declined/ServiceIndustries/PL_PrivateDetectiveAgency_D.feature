Feature: PL_PrivateDetectiveAgency_D

Declination of the Private Detective Agency keyword caused by answering the "Do you provide bodyguard services?" in the affirmative.
21 W 75th St, New York, NY 10023

@PL @Declined @Service
Scenario: PL Private Detective Agency declined Private detective bodyguard
	Given user starts a quote with:
		| Industry                 | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Private Detective Agency | 7         | I Own a Property & Lease to Others |              | 10023    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business          | Business Address | DBA |
		| Limited Liability Co LLC | Guardian Detective Agency | 21 W 75th St     | GDA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer  |
		| What year was your business started?         | 1990    |
		| What is your estimated gross annual revenue? | 700,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Do you provide security services for any of these?                                                                                                                                                                                                     | None of the Above |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No                |
		| Do you do work outside the U.S. and Canada?                                                                                                                                                                                                            | No                |
		| Do you engage in bail bond recovery, bounty hunting, car repossession, or evictions?                                                                                                                                                                   | No                |
		| Do you provide bodyguard services?                                                                                                                                                                                                                     | Yes               |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user fills out About You page with these values:
		| Question               | Answer       |
		| First Name             | Barney       |
		| Last Name              | Calhoun      |
		| Address                | 21 W 75th St |
		| Apt/Suite              | 1            |
		| City                   | New York     |
		| Use as Mailing Address | Yes          |
		| Email                  | test@biz.com |
		| Business Phone         | 7777777777   |
		| Ext                    | 7777         |
		| Website/Social         | www.test.com |
		| Have Broker            | No           |
	Then user verifies the PL decline page appearance

@PL @Declined @Service @Staging
Scenario: PL_PrivateDetectiveAgency_D Private detective UW Question Decline
	Given user starts a quote with:
		| Industry                 | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Private Detective Agency | 2         | I Own a Property & Lease to Others |              | 55322    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         |  Business Address | DBA    |
		| Individual/Sole Proprietor |  11360 US-212     | TPAC25 |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer  |
		| What year was your business started?         | 2021    |
		| What is your estimated gross annual revenue? | 225,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 3                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer   |
		| Do you provide security services for any of these?                                                                                                                                                                                                     | Airports |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No       |
		| Do you do work outside the U.S. and Canada?                                                                                                                                                                                                            | No       |
		| Are there any drivers that drive trucks you own but pay via 1099?                                                                                                                                                                                      | No       |
		| Do you engage in bail bond recovery, bounty hunting, car repossession, or evictions?                                                                                                                                                                   | No       |
		| Do you provide bodyguard services?                                                                                                                                                                                                                     | No       |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No       |
	Then user fills out About You page with these values:
		| Question               | Answer              |
		| First Name             | TEST PL API         |
		| Last Name              | TEST CASE 25        |
		| Address                | 15580 114TH sT      |
		| Apt/Suite              |                     |
		| City                   | Young America       |
		| Use as Mailing Address | Yes                 |
		| Email                  | test@biz.com        |
		| Business Phone         | 1231231321          |
		| Ext                    | 1234                |
		| Website/Social         | TestPartnerCert.com |
		| Have Broker            | No                  |
	Then user verifies the PL decline page appearance
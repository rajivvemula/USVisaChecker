Feature: PL_HazardGroupsAndNumberOfClaims

Refer for number of Claims = 1
Decline for number of Claims >= 2

@PL @Unit @Referred @NY
Scenario: Verify PL is Refer with 1 claim for any Hazard Group
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Resume Consulting | 1         | I Lease a Space From Others |              | 10001    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | DBA |
		| Corporation        | Whitestone Titles | ROL |
	Then user verifies the appearance of the PL Business Details page
	And user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2000   |
		| What is your estimated gross annual revenue?              | 500000 |
		| Do you use a written contract or statement of work (SOW)? | Never  |
	And user verifies the appearance of the PL Coverage Details page
	And user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 1                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide staffing services?                                                                                                                                                                                                                      | No     |
		| Do any volunteers give advice or provide care on your behalf?                                                                                                                                                                                          | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer       |
		| First Name             | Marty        |
		| Last Name              | Mailbox      |
		| Address                | 123 Fake st  |
		| City                   | Manhattan    |
		| Use as Mailing Address | Yes          |
		| Email                  | test@biz.com |
		| Business Phone         | 3172491913   |
	When user fills out the PL refer page with these values:
		| Field              | Value             |
		| Business name      | Whitestone Titles |
		| DBA                | ROL               |
		| Contact first name | Marty             |
		| Contact last name  | Mailbox           |
		| Email              | test@biz.com      |
		| Phone              | (317) 249-1913    |
	Then user verifies the PL refer confirmation appearance

@PL @Unit @Declined @NV
Scenario: Verify PL is Declined with 2 claims for any Hazard Group
	Given user starts a quote with:
		| Industry  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Appraiser | 1         | I Lease a Space From Others |              | 89109    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | DBA |
		| Corporation        | Whitestone Titles | ROL |
	Then user verifies the appearance of the PL Business Details page
	And user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2000   |
		| What is your estimated gross annual revenue? | 50000  |
	And user verifies the appearance of the PL Coverage Details page
	And user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 2                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you act as a real estate agent/broker?                                                                                                                                                                                                              | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer       |
		| First Name             | Marty        |
		| Last Name              | Mailbox      |
		| Address                | 123 Fake st  |
		| City                   | Las Vegas    |
		| Use as Mailing Address | Yes          |
		| Email                  | test@biz.com |
		| Business Phone         | 3172491913   |
	Then user verifies the PL decline page appearance

@PL @Unit @Declined @MN
Scenario: Verify PL is Declined with 2 or more claims for any Hazard Group
	Given user starts a quote with:
		| Industry              | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Reinsurance Brokerage | 1         | I Lease a Space From Others |              | 55406    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | DBA |
		| Corporation        | Whitestone Titles | ROL |
	Then user verifies the appearance of the PL Business Details page
	And user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2000   |
		| What is your estimated gross annual revenue? | 50000  |
	And user verifies the appearance of the PL Coverage Details page
	And user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 5+                        |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer       |
		| First Name             | Marty        |
		| Last Name              | Mailbox      |
		| Address                | 123 Fake st  |
		| City                   | Minneapolis  |
		| Use as Mailing Address | Yes          |
		| Email                  | test@biz.com |
		| Business Phone         | 3172491913   |
	Then user verifies the PL decline page appearance
Feature: PL_UpdateYourQuote
Partial Feature File added for implementing the "Then user verifies the PL Customize Your Plan modal appears" step logic 

Scenario: PL Update Your Quote modal partial file
	Given user starts a quote with:
		| Industry                                | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Graphic Designers: No Sign Installation | 2         | I Run My Business From Property I Own |              | 65781    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | DBA |
		| Corporation        | Mikes Graphics   | MGD |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer  |
		| What year was your business started?                      | 2000    |
		| What is your estimated gross annual revenue?              | 250,000 |
		| Do you use a written contract or statement of work (SOW)? | Never   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                | Answer |
		| Do you currently have a Professional Liability (E&O) policy in effect?  | No     |
		| Have you had a Professional Liability (E&O) policy in the last 3 years? | No     |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you have a written procedure to check materials for copyright or trademark violations?                                                                                                                                                              | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer              |
		| First Name             | Mike                |
		| Last Name              | Jones               |
		| Address                | 109 Long Dr         |
		| City                   | Willard             |
		| Use as Mailing Address | Yes                 |
		| Email                  | MikeJones@yahoo.com |
		| Business Phone         | 7777777777          |
		| Ext                    | 7777                |
		| Website/Social         | www.MikeJones.com   |
	Then user verifies the appearance of the PL Summary page
	#Add the PL Summary logic step here
	Then user adjusts their Yearly - Standard quote with these values:
		| Question           | Answer     |
		| Deductible PO      | $5,000     |
		| Limits PO          | $1,000,000 |
		| Limits Agg         | $2,000,000 |
		| Plus Deductible PO |            |
		| Plus Limits PO     |            |
		| Plus Limits Agg    |            |
		| Plus CL Agg        |            |
		| Plus PL Agg        |            |
	Then user fills out the PL Customize Your Plan Modal wih these values:
		| Question   | Answer    |
		| Deductible | 1,000     |
		| Limits     | 1,000,000 |
		| Aggregate  | 1,000,000 |
	Then user selects their Yearly - Standard Quote

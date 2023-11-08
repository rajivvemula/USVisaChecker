Feature: PL_GenerateProposalEmail_U

Verify that the UI indicates a proposal email has been generated for a PL policy

@Regression @PL @Staging
Scenario: Dance Instructor Proposal Email
	Given user starts a quote with:
		| Industry         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Dance Instructor | 3         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure          | Name of Business   | Business Address | DBA |
		| Limited Liability Co. (LLC) | Test PL Harassment | 1060 Church Rd   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer   |
		| What year was your business started?         | 2020     |
		| What is your estimated gross annual revenue? | $400,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer             |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | No                 |
		| To whom do you provide training?                                                                                                                                                                                                                       | Group Fitness Only |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | No                 |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                 |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                 |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer            |
		| First Name             | Expert            |
		| Last Name              | Dancer            |
		| Address                | 100 Test Road     |
		| Apt/Suite              |                   |
		| City                   | York              |
		| Use as Mailing Address | Yes               |
		| Email                  | Expert@Dancer.com |
		| Business Phone         | 1542659875        |
		| Ext                    | 1217              |
		| Website/Social         |                   |
		| Have Broker            | No                |
	Then user verifies the appearance of the PL Summary page
	Then user adjusts their Yearly - Standard quote with these values:
		| Question      | Answer     |
		| Deductible PO | $2,500     |
		| Limits PO     | $3,000,000 |
		| Limits Agg    | $3,000,000 |
	Then user verifies that the following deductible or coverage values are displayed on the Quote page:
		| DeductibleOrCoverage | Value      |
		| Deductible PO        | $2,500     |
		| Limits PO            | $3,000,000 |
		| Limits Agg           | $3,000,000 |
		| SAbuse Agg           | $250,000   |
	When user emails their Standard quote
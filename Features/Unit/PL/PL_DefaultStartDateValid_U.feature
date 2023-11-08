Feature: PL_DefaultStartDateValid_U

Verify that the default start date value of the PL path is valid 
 
@Unit @PL @PL_DefaultStartDateValid
Scenario: Verify PL default start date value
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA) | 0         | I Work at a Job Site |              | 77002    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | DBA |
		| Individual/Sole Proprietor | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                                            | Answer                 |
		| What year was your business started?                                                                                | 2020                   |
		| How many healthcare professionals work for your business?                                                           | 1                      |
		| Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)? | Independent Contractor |
		| Have you obtained this professional healthcare designation within the last two years?                               | Yes                    |
		| When did you graduate or obtain this designation?                                                                   |                        |
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
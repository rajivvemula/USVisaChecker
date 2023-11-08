Feature: PL_PhysicianAssistant_I

Made to ensure bug 79939 is working 
make sure the question "Which of these areas do you practice?" accepts multiple inputs

@Unit 
Scenario: Physicians Assistant (PA) ND 58108
	Given user starts a quote with:
		| Industry                           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA)          | 2         | I Lease a Space From Others |              | 58108    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | DBA |
		| Corporation        | PA              | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2019   |
		| How many healthcare professionals work for your business? | 2      |
		| How many health students work for your business?          | 0      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | Yes                       |
		| What is the retroactive date?                                                          | 07/07/2022                |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
	| Question                                                                                                                                                                                                                                               | Answer                                          |
	| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | Yes                                             |
	| Do you assist with any surgeries?                                                                                                                                                                                                                      | No                                              |
	| Which of these areas do you practice?                                                                                                                                                                                                                  | Pain Management Monitoring;Alternative Medicine |
	| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No                                              |
	| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No                                              |
	| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                              |
	Then user verifies the appearance of the PL About You Page
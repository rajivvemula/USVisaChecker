Feature: PL_Lawyer_R
Referral due to "Premium exceeds $25,000."

@PL @Referred @Service @Regression 
Scenario: PL Lawyer gets referred
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lawyer   | 2         | I Lease a Space From Others |              | 60606    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | Business Address | DBA |
		| Corporation        | Refer Our Lawyers | 15872 Co Rd 29   | ROL |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                         | Answer |
		| What year was your business started?                             | 2000   |
		| How many attorneys does your firm have?                          | 1      |
		| Do you use any of counsel or independent contractor attorneys?   | Yes    |
		| Number of full-time of counsel/independent contractor attorneys: | 2      |
		| Number of part-time of counsel/independent contractor attorneys: | 2      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 10/10/2010 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 1          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer      |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No          |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No          |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Real Estate |
		| Does your business own a Title Agency?                                                                                                                                                                                                                 | Yes         |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | No          |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No          |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No          |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No          |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No          |
		| Do you want to save up to 35% with a soft credit check?                                                                                                                                                                                                | No          |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question       | Answer         |
		| First Name     | Teddy          |
		| Last Name      | Roosevelt      |
		| City           | Haymarket      |
		| Email          | lawyer@law.com |
		| Business Phone | (432) 123-4423 |
	Then user verifies the appearance of the PL Attorneys - Nearly Finished page with these values:
		| Question     | Answer                |
		| Attorney     | D'Andre Hopkins-Ceely |
		| FT           | Paula Abdul           |
		| FT           | The Grinch            |
		| PT           | Thebees Knees         |
		| PT           | Laura Lu              |
		| Title Agency | Titles Are Cool       |
	When user fills out the PL refer page with these values:
		| Field              | Value             |
		| Business name      | Refer Our Lawyers |
		| Contact first name | Teddy             |
		| Contact last name  | Roosevelt         |
		| Email              | lawyer@law.com    |
		| Phone              | (432) 123-4423    |
	Then user verifies the PL refer confirmation appearance
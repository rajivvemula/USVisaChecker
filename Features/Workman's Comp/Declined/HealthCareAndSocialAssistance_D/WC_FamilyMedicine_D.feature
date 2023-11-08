Feature: WC_FamilyMedicine_D
Ineligible quote - ZIP Code - 20002
DeclineReason:User selected an excluded business type with 0 employees.
Keyword: Family Medicine
No Employee
Number of employee : 0
Business Operation: I Lease a Space From Others
Included Officer: 1
Business started year : Started 5 years ago
Business Structured: LLC

@WC @Declined @DC @Regression @Health
Scenario: WC Family Medicine gets declined becasue user selected an excluded business type with 0 employees
  Given user starts a quote with:
	| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Family Medicine | 0         | I Lease a Space From Others |              | 20002    | WC  |
  Then user verifies the appearance of the WC About You Page
  Then user fills out the WC About You page with these values:
    | Question                                            | Answer                    |
    | When do you want your policy to start?              |                           |
    | When did you start your business?                   | Started 9 years ago       |
    | How is your business structured?                    | Partnership               |
    | What is the total annual payroll for W-2 employees? | 50000                     |
    | Business                                            | Race Track Referral       |
    | Address                                             | 1275 1ST ST NE;Washington |
    | Contact First Name                                  | TestF                     |
    | Contact Last Name                                   | TestL                     |
    | Email                                               | Test@Test123.com          |
    | Phone                                               | 1231231321                |
    | Business website                                    | test.com                  |
  Then user verifies the appearance of the WC Owners and Officers Page 
  Then user handles the WC OO kickoff questions with these values:
    | Question                                                                                                     | Answer |
    | How many owners/officers does your business have?                                                            | 2      |    
  Then user continues on from the WC OO page
  Then user verifies the appearance of the WC Your Services Page
  Then user fills out the WC Your Services page
	| Question                                                                                               | Answer       |
	| What type of care do you provide?                                                                      | Primary Care |
	| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no           |
	| In the past 3 years how many Workers' Compensation claims were reported?                               | None         |
	| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes          |
	| Do you use any volunteers or donated labor?                                                            | no           |
	| Do you have multiple locations in more than one state?                                                 | no           |
  Then user verifies the WC decline page appearance

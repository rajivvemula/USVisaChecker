Feature: WC_AdultLivingFacility_NoMedicalCare_R
Ineligible Quote;
Description: Policy gets referred due to premium exceeding max allowable value for sales/online..
Keyword: Adult Living Facility: No Medical Care
Employee option: Various employees - 30
ZIPCode: 07043
Employee Payroll: 1,500,000
Entity type: Corporation
Years in business: Started last year
Included owner officers: Yes 2
Excluded owner officer: 2

@WC @Regression @Referred @Health @MA
Scenario: WC Adult Living Facility No Medical Care gets referred due to policy premium exceeding max allowable
	Given user starts a quote with:
		| Industry                               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Adult Living Facility: No Medical Care | 30        | I Lease a Space From Others |              | 02152    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                  | Answer                        |
		| When do you want your policy to start?                                                    |                               |
		| When did you start your business?                                                         | Started 6 years ago           |
		| How is your business structured?                                                          | Corporation                   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)    | 2,000,000                     |
		| Do any employees only do general office work and would never interact with any residents? | no                            |
		| Business                                                                                  | Premium Exceeds Max Allowable |
		| Address                                                                                   | 242 Lincoln St;Winthrop       |
		| Contact First Name                                                                        | TestF                         |
		| Contact Last Name                                                                         | TestL                         |
		| Email                                                                                     | Test@Test123.com              |
		| Phone                                                                                     | 1231231321                    |
		| Business website                                                                          | test.com                      |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty                         |
		| TestF      | TestL     | yes        | 40000          | Interacts with residents/clients |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer     |
		| Do you accept clients that have been diagnosed with a form of dementia?                                | No         |
		| Do you provide any alcohol or drug abuse counseling?                                                   | No         |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no         |
		| What percentage of residents or clients are ambulatory?                                                | 0          |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes        |
		| Do you use any volunteers or donated labor?                                                            | no         |
		| Do you have multiple locations in more than one state?                                                 | no         |
		| Federal Employer Identification Number (FEIN)                                                          | 63-1212123 |
	Then user begins the WC AI page having the FEIN with value 63-1212123
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Number Of Claims   |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears
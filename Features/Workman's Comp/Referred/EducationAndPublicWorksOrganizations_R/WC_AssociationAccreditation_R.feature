Feature: WC_AssociationAccreditation_R

Referring an Association Accreditation policy due to DirectOK = No

@Education @WC @Referred @ID @Regression @YourServices
Scenario: WC Association Acreditation policy gets referred due to DirectOK = No
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Association Accreditation | 0         | I Lease a Space From Others |              | 83705    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                 | Answer                       |
		| When do you want your policy to start?                   |                              |
		| When did you start your business?                        | Started 10 years or more ago |
		| How is your business structured?                         | Corporation                  |
		| Do you make any payments to workers using IRS Form 1099? | no                           |
		| Business                                                 | Association Accreditation;AA |
		| Address                                                  | 1799 S Jackson St;Boise      |
		| Fill Contact                                             |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| Do you operate a gym or do any fitness instruction?                       | no     |
		| Do you provide any hands on construction training?                        | no     |
		| Do you do any scuba, ski, or surf training?                               | no     |
		| Do you provide hands on medical or CPR training?                          | no     |
		| Do you provide firearms training?                                         | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you use any volunteers or donated labor?                               | no     |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user begins the WC AI page setting the FEIN with value 23-7277824
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                      |
		| Business name      | Test Employee Wage Too Low |
		| Contact first name | TestF                      |
		| Contact last name  | TestL                      |
		| Email              | TestCert@Plan.com          |
		| Phone              | (123) 123-1321             |
		| Business website   | www.TestPartnerCert.com    |
	Then user verifies the refer thank you page appears
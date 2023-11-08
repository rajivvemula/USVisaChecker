Feature: WC_FLSoleProprietorOfficers_U

Task 92752 Verification that a WC policy for a Floridia sole proprietors in the services industry requires the user to include an officer.

@WC @FL @Regression @Unit @Service
Scenario: WC Verifying that Florida sole proprietors in the services industry would have to include officers
	Given user starts a quote with:
		| Industry          | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Boiler Inspection | 4         | I Own a Property & Lease to Others |              | 32205    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                            |
		| When do you want your policy to start?                                                 |                                                   |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Individual/Sole Proprietor                        |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50,000                                            |
		| Are there any cost estimators on staff that wouldn't do any direct physical work?      | no                                                |
		| Do any employees only do general office work and rarely travel?                        | no                                                |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                                |
		| Insured First Name                                                                     | Indi                                              |
		| Insured Last Name                                                                      | Vidual                                            |
		| Address                                                                                | 2902 Riverside Ave;Jacksonville                   |
		| Email                                                                                  | BoilerInspection@Test123.com                      |
		| Phone                                                                                  | 777-777-7777                                      |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user verifies that the How many owners/officers does your business have? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 1             |
Feature: WC_Florist_I

Verifies various staging regression test scenarios

@Staging @Regression @WC @Retail @Issued @KS
Scenario: WC Florist Corp policy issued in Kansas
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 66402    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer               |
		| When do you want your policy to start?                                                 |                      |
		| When did you start your business?                                                      | Started 2 years ago  |
		| How is your business structured?                                                       | Corporation          |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                |
		| Business                                                                               | Test Auto XMOD       |
		| Address                                                                                | 220 W 14th St;Auburn |
		| Contact First Name                                                                     | TestF                |
		| Contact Last Name                                                                      | TestL                |
		| Email                                                                                  | Test@Test123.com     |
		| Phone                                                                                  | 1231231321           |
		| Business website                                                                       | test.com             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 3      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name |
		| OneF       | OneL      |
		| TwoF       | TwoL      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name | Checkbox |
		| ThreeF     | ThreeL    | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Have Name | Set SSN     |
		|           | 102-20-1202 |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @AZ
Scenario: WC Florist LLC policy issued in AZ
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 85705    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                       |
		| Business                                                                               | Test AZ LLC;Test DBA        |
		| Address                                                                                | 1807 W Gardner St;Tucson    |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	And user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 3      |
		| How many owners have less than 50% ownership? State law requires that they be covered. | 0      |
		| How many owners/officers do you want to cover with this policy?                        | 1      |
	And user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 1             |
		| 2             |
		| 3             |
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 3      |
		| How many owners have less than 50% ownership? State law requires that they be covered. | 2      |
		| How many owners/officers do you want to cover with this policy?                        | 2      |
	And user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 2             |
		| 3             |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | % Ownership | W2 payroll | Annual Payroll |
		| OneF       | OneL      | Yes         | yes        | 50000          |
		| TwoF       | TwoL      | Yes         | yes        | 50000          |
	And user handles the WC Excluded OO with these values:
		| First Name | Last Name | Checkbox |
		| ThreeF     | ThreeL    | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
    Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | No               |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: BOP

@Staging @Regression @WC @Retail @Issued @PA
Scenario: WC Florist Ghost Policy Issued in PA
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 0         | I Lease a Space From Others |              | 17404    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                               | Answer                      |
		| When do you want your policy to start? |                             |
		| When did you start your business?      | Started 2 years ago         |
		| How is your business structured?       | Limited Liability Co. (LLC) |
		| Business                               | Test Ghost Policy;Test DBA  |
		| Address                                | 100 Test Road;York          |
		| Contact First Name                     | TestF                       |
		| Contact Last Name                      | TestL                       |
		| Email                                  | Test@Test123.com            |
		| Phone                                  | 1231231321                  |
		| Business website                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 4      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 1             |
		| 2             |
		| 3             |
		| 4             |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 3 excluded oo with these values:
		| Set Name      |
		| OneF OneL     |
		| TwoF TwoL     |
		| ThreeF ThreeL |
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @ID
Scenario: WC Florist Flag 4 Corp policy issued in ID
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 83702    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 2 years ago          |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                        |
		| Business                                                                               | Test ID Flag 4 Corp;Test DBA |
		| Address                                                                                | 780 S 14th St;Boise          |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 1             |
		| 2             |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Set Name  |
		| OneF OneL |
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @TX
Scenario: WC Florist Flag 4 Sub Corp policy issued in TX
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 75104    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                           |
		| When do you want your policy to start?                                                 |                                  |
		| When did you start your business?                                                      | Started 2 years ago              |
		| How is your business structured?                                                       | Sub-Chapter Corp                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                            |
		| Business                                                                               | Test TX Flag 4 Sub-Corp;Test DBA |
		| Address                                                                                | 1979 Mason Ln ;Cedar Hill        |
		| Contact First Name                                                                     | TestF                            |
		| Contact Last Name                                                                      | TestL                            |
		| Email                                                                                  | Test@Test123.com                 |
		| Phone                                                                                  | 1231231321                       |
		| Business website                                                                       | test.com                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 1             |
		| 2             |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 40000          |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| TwoF       | TwoL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		| TwoF TwoL |
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @NY
Scenario: WC Florist Corp policy issued in NY _ Iteration 1
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 13903    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Corporation                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                       |
		| Business                                                                               | Test NY Corp;Test DBA       |
		| Address                                                                                | 11 Burlington St;Binghamton |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 0             |
		| 1             |
		| 2             |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 50000          |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| TwoF       | TwoL      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		| TwoF TwoL |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @NY
Scenario: WC Florist Corp policy issued in NY_ Iteration 2
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 13903    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Corporation                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                       |
		| Business                                                                               | Test NY Corp;Test DBA       |
		| Address                                                                                | 11 Burlington St;Binghamton |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 3      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 50000          |
		| TwoF       | TwoL      | yes        | 50000          |
		| ThreeF     | ThreeL    | yes        | 50000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 3 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @NH 
Scenario: WC Florist Corp policy issued in NH
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 03055    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                |
		| When do you want your policy to start?                                                 |                       |
		| When did you start your business?                                                      | Started 2 years ago   |
		| How is your business structured?                                                       | Corporation           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                 |
		| Business                                                                               | Test NH Corp;Test DBA |
		| Address                                                                                | 15 Wall St;Milford    |
		| Contact First Name                                                                     | TestF                 |
		| Contact Last Name                                                                      | TestL                 |
		| Email                                                                                  | Test@Test123.com      |
		| Phone                                                                                  | 1231231321            |
		| Business website                                                                       | test.com              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user verifies that the How many owners/officers do you want to cover with this policy? dropdown options are equivalent to the following:
		| Option        |
		| please choose |
		| 0             |
		| 1             |
		| 2             |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Set Name  | Set Job | Set DOB    |
		| OneF OneL | Member  | 09/01/1991 |
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance

@Staging @Regression @WC @Retail @Issued @NJ
Scenario: WC Florist LLC policy issued in NJ
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 1         | I Lease a Space From Others |              | 08204    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40,000                      |
		| Business                                                                               | Test NJ LLC ; Test DBA      |
		| Address                                                                                | 916 Lafayette St;Cape May   |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | AutomationTest@biberk.com   |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                             | Answer |
		| Do you want to buy coverage for the business owners? | Yes    |
		| How many owners/officers are there?                  | 2      |
	And user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| OneF       | OneL      | yes        | 50000          |
		| TwoF       | TwoL      | yes        | 50000          |
	Then user continues on from the WC OO page
	And user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| What percentage of your overall sales involve delivery?                   | 0      |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization | Value |
		| N/A           |       |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
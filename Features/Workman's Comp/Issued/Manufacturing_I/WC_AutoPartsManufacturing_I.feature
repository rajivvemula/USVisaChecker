Feature: WC_AutoPartsManufacturing_I
NOTE: Verifying the OO rules for the following States as mentioned in the US 104559
 AK (LLC, Corporation)
 LA (LLC, Corporation)
 MN (LLC, Corporation)
  
@Manufacturing @WC @Issued @AK @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in Alaska for Biz type LLC
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 99780    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                      |
		| When do you want your policy to start?                                                          |                             |
		| When did you start your business?                                                               | Started 5 years ago         |
		| How is your business structured?                                                                | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000                       |
		| Are there any delivery drivers on staff?                                                        | no                          |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                          |
		| Do any employees only do general office work and rarely travel?                                 | no                          |
		| Business                                                                                        | Test OO rules               |
		| Address                                                                                         | 1314 Alaska Hwy;Tok         |
		| Contact First Name                                                                              | TestF                       |
		| Contact Last Name                                                                               | TestL                       |
		| Email                                                                                           | Test@Test123.com            |
		| Phone                                                                                           | 1231231321                  |
		| Business website                                                                                | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty               |
		| TestF      | TestL     | Traveling Salespersons |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
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
	 
@Manufacturing @WC @Issued @AK @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in Alaska for Biz type Corporation
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 99780    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer              |
		| When do you want your policy to start?                                                          |                     |
		| When did you start your business?                                                               | Started 3 years ago |
		| How is your business structured?                                                                | Corporation         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000               |
		| Are there any delivery drivers on staff?                                                        | no                  |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                  |
		| Do any employees only do general office work and rarely travel?                                 | no                  |
		| Business                                                                                        | Test OO rules       |
		| Address                                                                                         | 1314 Alaska Hwy;Tok |
		| Contact First Name                                                                              | TestF               |
		| Contact Last Name                                                                               | TestL               |
		| Email                                                                                           | Test@Test123.com    |
		| Phone                                                                                           | 1231231321          |
		| Business website                                                                                | test.com            |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| TestF      | TestL     | yes        | 80000          | Manufacturer |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
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

@Manufacturing @WC @Issued @LA @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in LA for Biz type LLC
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 99780    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                           |
		| When do you want your policy to start?                                                          |                                  |
		| When did you start your business?                                                               | Started 5 years ago              |
		| How is your business structured?                                                                | Limited Liability Co. (LLC)      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000                            |
		| Are there any delivery drivers on staff?                                                        | no                               |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                               |
		| Do any employees only do general office work and rarely travel?                                 | no                               |
		| Business                                                                                        | Test OO rules                    |
		| Address                                                                                         | 4900 SAINT MARY ST;Mentasta Lake |
		| Contact First Name                                                                              | TestF                            |
		| Contact Last Name                                                                               | TestL                            |
		| Email                                                                                           | Test@Test123.com                 |
		| Phone                                                                                           | 1231231321                       |
		| Business website                                                                                | test.com                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty               |
		| TestF      | TestL     | Traveling Salespersons |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
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

@Manufacturing @WC @Issued @LA @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in LA for Biz type Corporation
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 99780    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                           |
		| When do you want your policy to start?                                                          |                                  |
		| When did you start your business?                                                               | Started 3 years ago              |
		| How is your business structured?                                                                | Corporation                      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000                            |
		| Are there any delivery drivers on staff?                                                        | no                               |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                               |
		| Do any employees only do general office work and rarely travel?                                 | no                               |
		| Business                                                                                        | Test OO rules                    |
		| Address                                                                                         | 4900 SAINT MARY ST;Mentasta Lake |
		| Contact First Name                                                                              | TestF                            |
		| Contact Last Name                                                                               | TestL                            |
		| Email                                                                                           | Test@Test123.com                 |
		| Phone                                                                                           | 1231231321                       |
		| Business website                                                                                | test.com                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| TestF      | TestL     | yes        | 80000          | Manufacturer |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
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

@Manufacturing @WC @Issued @MN @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in MN for Biz type LLC
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 55406    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                      |
		| When do you want your policy to start?                                                          |                             |
		| When did you start your business?                                                               | Started 5 years ago         |
		| How is your business structured?                                                                | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000                       |
		| Are there any delivery drivers on staff?                                                        | no                          |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                          |
		| Do any employees only do general office work and rarely travel?                                 | no                          |
		| Business                                                                                        | Test OO rules               |
		| Address                                                                                         | 3110 E Lake St;Minneapolis  |
		| Contact First Name                                                                              | TestF                       |
		| Contact Last Name                                                                               | TestL                       |
		| Email                                                                                           | Test@Test123.com            |
		| Phone                                                                                           | 1231231321                  |
		| Business website                                                                                | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| TestF      | TestL     | yes        | 80000          | Manufacturer |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
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

@Manufacturing @WC @Issued @MN @Regression @OwnerOfficer
Scenario: WC Auto Parts Manufacturing creates issued policy in MN for Biz type Corp
	Given user starts a quote with:
		| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auto Parts Manufacturing | 3         | I Lease a Space From Others |              | 55406    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                     |
		| When do you want your policy to start?                                                          |                            |
		| When did you start your business?                                                               | Started 3 years ago        |
		| How is your business structured?                                                                | Corporation                |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 50000                      |
		| Are there any delivery drivers on staff?                                                        | no                         |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                         |
		| Do any employees only do general office work and rarely travel?                                 | no                         |
		| Business                                                                                        | Test OO rules              |
		| Address                                                                                         | 3110 E Lake St;Minneapolis |
		| Contact First Name                                                                              | TestF                      |
		| Contact Last Name                                                                               | TestL                      |
		| Email                                                                                           | Test@Test123.com           |
		| Phone                                                                                           | 1231231321                 |
		| Business website                                                                                | test.com                   |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty     |
		| TestF      | TestL     | yes        | 80000          | Manufacturer |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?  | no                                            |
		| Do your employees deliver any of your finished product?                   | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?      | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes                                           |
		| Do you have multiple locations in more than one state?                    | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-3456789
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 28               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
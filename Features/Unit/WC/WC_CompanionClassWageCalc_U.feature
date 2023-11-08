Feature: WC_CompanionClassWageCalc_U

Verifies the logic for Wage page related to comapnion classes
The annual payroll for W-2 employees should be equal or above the 50,000 for companion classes payroll questions to appear
First Unit test verifies the comapnion classes payroll questions and input fields on About you page stay enabled
Second Unit test verifies the comapnion classes payroll questions and input fields on About you page becomes disabled (greyed out)

@Unit @WC @Cali @Regression @Auto
Scenario: WC Garage: Auto Repair quote issued for Cali with enabled questions and input fields
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Garage: Auto Repair | 5         | I Lease a Space From Others |              | 90012    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                    |
		| When do you want your policy to start?                                                 |                           |
		| When did you start your business?                                                      | Started 5 years ago       |
		| How is your business structured?                                                       | Corporation               |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000                    |
		| Do you have any auto salespersons on staff?                                            | yes;20000                 |
		| Do any employees do any roadside assistance or towing?                                 | yes;40000                 |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | yes;20000                 |
		| Business                                                                               | The best garage           |
		| Address                                                                                | 100 S Main St;Los Angeles |
		| Fill Contact                                                                           |                           |
	And user verifies the Wage Calculator page
	Then user fills out the Wage Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 20                    | 2                   | 40             |
		| 20                    | 1                   | 40             |
		| 15                    | 1                   | 40             |
		| 15                    | 1                   | 40             |
	Then user clicks back and modify from the Payroll Calculator
	Then user verifies the appearance of the WC About You Page
	Then user verifies the following companion class payroll answers and input fields:
		| Question                                                                               | Disabled  |
		| Do you have any auto salespersons on staff?                                            | not       |
		| Do any employees do any roadside assistance or towing?                                 | not       |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | not       |

@Unit @WC @Cali @Regression @Auto
Scenario: WC Garage: Auto Repair quote issued for Cali with disabled questions and input fields
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Garage: Auto Repair | 3         | I Lease a Space From Others |              | 90012    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                    |
		| When do you want your policy to start?                                                 |                           |
		| When did you start your business?                                                      | Started 5 years ago       |
		| How is your business structured?                                                       | Corporation               |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100000                    |
		| Do you have any auto salespersons on staff?                                            | yes;20000                 |
		| Do any employees do any roadside assistance or towing?                                 | yes;40000                 |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | yes;20000                 |
		| Business                                                                               | The best garage           |
		| Address                                                                                | 100 S Main St;Los Angeles |
		| Fill Contact                                                                           |                           |
	And user verifies the Wage Calculator page
	Then user fills out the Wage Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 20                    | 2                   | 40             |
		| 20                    | 1                   | 40             |
		| 15                    | 1                   | 40             |
		| 15                    | 1                   | 40             |
    And user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page 
	Then user clicks back and modify from the WC Owners and Officers Page
	Then user verifies the appearance of the WC About You Page
	Then user verifies the following companion class payroll answers and input fields:
		| Question                                                                               | Disabled |
		| Do you have any auto salespersons on staff?                                            | yes      |
		| Do any employees do any roadside assistance or towing?                                 | yes      |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | yes      |
	

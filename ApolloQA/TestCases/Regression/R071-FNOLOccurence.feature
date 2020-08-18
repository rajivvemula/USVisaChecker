Feature: R071-FNOLOccurence
	Smoke Test FNOL Creation

@FNOL
Scenario Outline:4 Verify All Inputs on FNOL Occurence
	When FNOL Occurence User enter <Value> for <Input> 
	Then FNOL Occurence User should see <Value> For that <Input> 
	And FNOL Occurence User is required to have values for the <Input> as <Required>  

	Examples: 
	| Input        | Value          | Required |
	| first        | John           | true     |
	| middle       | J              | false    |
	| last         | Smith          | true     |
	| suffix       | Mr             | false    |
	| email        | john@gmail.com | false    |
	| dol          | 8/13/2020      | true     |
	| tol          | 12:01 AM       | true     |
	| dr           | 8/13/2020      | true     |
	| tr           | 12:01 AM       | true     |
	| policyNumber | 10005          | false    |
	| descLoss     | Sample         | true     |
	| phoneNumber  | 123-123-1234   | false    |
	| policeName   | LAPD           | false    |
	| policeNumber | 12312312       | false    |
	| fireName     | LAFD           | false    |
	| FireNumber   | 7/8/2022       | false    |

Scenario Outline:5 Verify All Selects on FNOL Occurence
	When FNOL Occurence User clicks on <Select> 
	Then FNOL Occurence User should see all values to be present in <Select> 
	And FNOL Occurence User is required to have Select values for the <Select> as <SelectRequired> 

	Examples: 
	| Select    | SelectRequired |
	| how       | true           |
	| related   | false           |
	| phoneType | false           |
	| catField  | false           |
	| policeIn  | false           |
	| FireIn    | false           |

Scenario: User is able to save an FNOL
	When User enters sample FNOL Info
	Then User is able to click save Fnol
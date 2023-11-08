Feature: WC_PetAndPetSupplyStore_I
Keyword: Pet and Pet Supply Store 
Calim were reported is 2
Yes I have Employee
Number of employee : 11
Business Operation: I Lease a Space From Others
ZIP Code: 18702
Included Officer: 1
Business started year : Started 12 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 10% Down + 10 Monthly Installments


Scenario: WC Pet And Pet Supply Store creates issued policy in PA
	Given user starts a quote with:
	| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Pet and Pet Supply Store |           | I Lease a Space From Others |              | 18702    | WC  |

Feature: WC_ConcreteConstructionWithPourWalls_I
Issued Policy for;
Keyword: Concrete Construction: With Pouring of Walls
Employee option: Various employees - 10
ZIP Code: 21075
Employee Payroll: 100000
Entity Type: Corporation
Years in business: Started last year
Included owner officers: No
Excluded owner officer: 0
EL Limits: 100K/500K/100K
Payment Option: 15% Down + 9 Monthly Installments
Credit card: American Express
	
Scenario: WC Concrete Construction With Pouring policy issued for Texas
	Given user starts a quote with:
		| Industry                                     | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Concrete Construction: With Pouring of Walls | 10        | I Run My Business From Property I Own |              | 78660    | WC  |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
		| Deductible Per Claim                               | Per Claim - $500        |
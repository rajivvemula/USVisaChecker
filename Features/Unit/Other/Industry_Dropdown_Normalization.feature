Feature: Industry_Dropdown_Normalization

Normalizing text for industries containing words Nonprofit and Nonemergency 

@Unit @Regression
Scenario Outline: Normalizing text for industries containing words Nonprofit and Nonemergency 
	Given user starts a quote with:
		| Industry   | 
		| <industry> | 

Examples:
	| industry                          |
	| Non-profit Community Coalition    |
	| Non profit Job Training           |
	| Nonprofit: Political Organization |
	| Non Emergency Medical Transport   |
	| Non-emergency Medical Transport   |
	| Nonemergency Medical Transport    |
	| Non-Medical Billing Services      |
	| Florist                           |
	
	




@NoBrowser
Feature: Risks
	Scenarios that will test the business rules around Risks



Scenario Outline: Deleting risk rule for BO_vs_GL subLines
	Given new quote is created for '<SubLine>'
	And user adds '1' '<RiskType>' risks to the quote
	When user removes the previously added '<RiskType>'
	Then assert business rule around deleting related risks if '1' '<RiskType>' risk was deleted

Examples: 
	| SubLine | RiskType |
	| BP      | Location |
	| BP      | Building |
	| GL      | Location |
	| GL      | Building |


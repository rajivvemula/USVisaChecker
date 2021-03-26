Feature: GlobalSearch

#TODO
Scenario Outline: TC 25643 Global Search - Search Items
	Given user is successfully logged into biberk
	And user validates search for '<Criteria>'

	Examples: 
	| Criteria            |
	| EntityType          |
	| EntityName          |
	| EntityNumber        |
	| TypeDescription     |
	| StatusDescription   |
	| SourceSystem        |
	| PolicyHolderName    |
#broken?	| AgencyOrganization  |
	| CarrierOrganization |
	| AdjusterName        |
	| TaxIdLastFour       |
	| ValidPolicyNumber   |
	| ValidQuoteNumber    |
	| ValidClaimNumber    |

	
	# bugReported - 32061
	@bugReported
	Examples: 
	| Criteria        |
	| UnderwriterName |










Feature: GlobalSearch

#TODO
@tc:37621
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
	| AgencyOrganization  |
	| CarrierOrganization |
	| AdjusterName        |
	| TaxIdLastFour       |
	| ValidPolicyNumber   |
	| ValidQuoteNumber    |
	| ValidClaimNumber    |
	| ValidFnolNumber     |

	
	# bugReported - 32061
	@bugReported
	Examples: 
	| Criteria        |
	| UnderwriterName |










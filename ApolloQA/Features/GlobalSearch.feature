﻿Feature: GlobalSearch

@tc:37621 @tc:25643
Scenario Outline: TC Global Search - Search Items
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
	| AdjusterName        |
	| ValidPolicyNumber   |
	| ValidQuoteNumber    |
	| ValidClaimNumber    |
	| ValidFnolNumber     |

# Ignore - Organization changes currently underway - AC 09/02
	#| AgencyOrganization  |
	#| CarrierOrganization |
	#| TaxIdLastFour       |
	#| PolicyHolderName    |

	
	# bugReported - 32061
	@bugReported
	Examples: 
	| Criteria        |
	| UnderwriterName |










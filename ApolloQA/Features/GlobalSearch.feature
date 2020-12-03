﻿Feature: GlobalSearch

# TODO : 15 and 17 work in QA1. Just need to push latest to QA2
Scenario: TC 22799 : Global Search - Search Items
	Given user is successfully logged into biberk
	And user validates search for 'EntityType'
	And user validates search for 'EntityName'
	And user validates search for 'EntityNumber'
	And user validates search for 'TypeDescription'
	And user validates search for 'StatusDescription'
	And user validates search for 'SourceSystem'
	And user validates search for 'PolicyHolderName'
	And user validates search for 'AgencyOrganization'
	And user validates search for 'CarrierOrganization'
	#And user validates search for 'UnderwriterName'
	And user validates search for 'AdjusterName'
	#And user validates search for 'TaxIdLastFour'
	And user validates search for 'ValidPolicyNumber'
	And user validates search for 'ValidQuoteNumber'
	And user validates search for 'ValidClaimNumber'
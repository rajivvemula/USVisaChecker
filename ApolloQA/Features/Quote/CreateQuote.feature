Feature: CreateQuote


@tc:17022 @tc:17024 @tc:17027 @tc:17974 @tc:17028 @tc:37651
Scenario Outline: Create quote using a newly created organization
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org with <State>
	And User enters quote details on Quote Page
	When user clicks 'Next' Button
	Then Toast containing was created. is visible 
	When user clicks 'Business Information' Sidetab
	Then User verifies quote details on Business Information Page
	Then User checks Governing <State> are correctly matching
	 

    Examples:
	| State |
	| IL    |
	| AZ    |
	| NV    |
	| SC    |
	| GA    |
	| CA    |
	| TX    |
	| IN    |
	| TN    |
	| MO    |
	
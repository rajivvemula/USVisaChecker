Feature: R004A-CreateAPolicy
	This is a temporary file to create a policy(feature to be deprecated)

@reg @pol
Scenario: Create a policy with basic attributes
	Given User is on Policy List Page
	When User clicks New Policy Button
	Then User is on Insert Policy Page
	When User inputs basic attributes for new policy
	And User clicks on Submit Policy
	Then User is shown the toast saying the new policy created

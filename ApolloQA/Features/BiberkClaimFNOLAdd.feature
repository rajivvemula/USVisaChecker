Feature: BiberkClaimFNOLAdd

@background
Scenario: Login biBerk home page with valid credentials
  Given user landed biBerk page with valid URL 
	When user enters username: ApolloTestUserG311@biberk.com and password: ApolloTest12
	And user attempts to login
   Then user login successfully to biBerk page

@biBerkClaimFNOLAdd @SmokeTest
Scenario: Carrier Pigeon Is not a how notice was received option
Given user clicks on waffle menu
When user clicks on Claims
And user clicks on +FNOL button to begin an FNOL report
Then user verifies 'Carrier Pigeon' is not an option
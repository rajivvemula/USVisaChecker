Feature: BiBerkLogin
	Login biBerk home page

@biBerkLogin @SmokeTest
Scenario: (1) Login biBerk home page with valid credentials
  Given user landed biBerk page with valid URL 
	When user enters username: ApolloTestUserG311@biberk.com and password: ApolloTest12
	And user attempts to login
   Then user login successfully to biBerk page


Scenario: Make sure user is logged in
	Given user is successfully logged into biberk
	
﻿Feature: apolloLogin
	Login biBerk home page with valid credentials

@SmokeTest @newWindow
#To Do: password should come from keyvault
Scenario: Login biBerk home page with valid credentials
  Given user landed biBerk page with valid URL 
	When user enters username: ApolloTestUserG311@biberk.com and password: ApolloTest12
	And user attempts to login
   Then user login successfully to biBerk page 

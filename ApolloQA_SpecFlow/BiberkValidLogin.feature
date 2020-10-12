Feature: BiBerkLogin
	Login biBerk home page with valid credentials



@biBerkLogin
Scenario: Login biBerk home page with valid credentials
  Given user1 landed biBerk page with valid URL 
    And user1 enter valid username and click on Next CTA
    And user1 enter valid password and click on Sign in CTA
    And user1 click on Stay signed in No CTA 
   Then user1 login successfully to biBerk page
    And user1 logout of biBerk home page
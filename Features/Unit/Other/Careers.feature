Feature: Careers

Navigates to the careers page, then clicks the Open Position button where the user will be redirected to another website

@currentTest @Unit @Regression
Scenario: Career Page Navigation
	Given user lands on biBerk Home page
	Then user navigates to the careers page
	Then user clicks on the Open Positions button
	Then user verifies new tab for job search

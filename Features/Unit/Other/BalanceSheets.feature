Feature: BalanceSheets
The Balance sheets PDF file should get opened in a new tab when the Balance Sheets link is being clicked in the Home page footer section.

@Unit @Regression @Ignore
Scenario: Validate Balance Sheets link opens a PDF file 
   Given user lands on biBerk Home page
   Then user verifies the navigation to Balance sheets PDF file
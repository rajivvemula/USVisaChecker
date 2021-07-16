Feature: Quote Section UWResults
o as many keywords as possible

@tc:39143
Scenario Outline: Automatic Decline Based on keyword
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org state IL
	When User changes <Keyword>
	When user clicks 'Next' Button
	When user clicks 'Summary' Sidetab
	And user waits for spinner to load
	When user clicks on UW Results Sidetab
	Then User verifies the Quote has a declined <Status> on UW Results

	Examples: 
	| Keyword                                                 | Status  |
	| Auto Body Repair Shop                                   | Decline |
	| Auto Collision Repair                                   | Decline |
	| Auto Conversion or Auto Customization                   | Decline |
	| Auto Dealership: New                                    | Decline |
	| Auto Dealership: New and Used                           | Decline |
	| Auto Dealership: Used                                   | Decline |
	| Auto Detailing                                          | Decline |
	| Auto Glass Repair and Replacement Servies               | Decline |
	| Auto Manufacturing Plant                                | Refer   |
	| Auto Mechanic: No Body Work                             | Decline |
	| Auto Mechanic: Some Body Work                           | Decline |
	| Auto Oil Change and Lubrication Shops: No Gas Station   | Decline |
	| Auto Oil Change and Lubrication Shops: No Gas Station   | Decline |
	| Auto Oil Change and Lubrication Shops: With Gas Station | Decline |
	| Auto Oil Change and Lubrication Shops: With Gas Station | Decline |
	| Auto Painting Shop: No Body Work                        | Decline |
	| Auto Parts Manufacturing                                | Refer   |
	| Auto Parts Wholesaler                                   | Decline |
	| Auto Recycling                                          | Decline |
	| Auto Rental Shop                                        | Decline |
	| Auto Repair: No Body Work                               | Decline |
	| Auto Repair: Some Body Work                             | Decline |
	| Auto Reposessing                                        | Decline |
	| Auto Restoration                                        | Decline |
	| Auto Sales                                              | Decline |
	| Auto Salvage                                            | Decline |
	| Auto Service or Repair Center                           | Decline |
Feature: Quote_UWResults



#This scenario is built to be expanded to as many keywords as possible

Scenario Outline: Automatic Decline Based on keyword
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org state IL
	When User changes <Keyword>
	When user clicks 'Next' Button
	When user clicks 'Summary' Sidetab
	When user clicks 'Next' Button
	Then User verifies the Quote has a declined status on UW Results

	Examples: 
	| Keyword                                                 |
	| Auto Body Repair Shop                                   |
	| Auto Body Repair Shop                                   |
	| Auto Collision Repair                                   |
	| Auto Conversion or Auto Customization                   |
	| Auto Dealership: New                                    |
	| Auto Dealership: New and Used                           |
	| Auto Dealership: Used                                   |
	| Auto Detailing                                          |
	| Auto Glass Repair and Replacement Servies               |
	| Auto Manufacturing Plant                                |
	| Auto Mechanic: No Body Work                             |
	| Auto Mechanic: Some Body Work                           |
	| Auto Oil Change and Lubrication Shops: No Gas Station   |
	| Auto Oil Change and Lubrication Shops: No Gas Station   |
	| Auto Oil Change and Lubrication Shops: With Gas Station |
	| Auto Oil Change and Lubrication Shops: With Gas Station |
	| Auto Painting Shop: No Body Work                        |
	| Auto Parts Manufacturing                                |
	| Auto Parts Wholesaler                                   |
	| Auto Recycling                                          |
	| Auto Rental Shop                                        |
	| Auto Repair: No Body Work                               |
	| Auto Repair: Some Body Work                             |
	| Auto Reposessing                                        |
	| Auto Restoration                                        |
	| Auto Sales                                              |
	| Auto Salvage                                            |
	| Auto Service or Repair Center                           |

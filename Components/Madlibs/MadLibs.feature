@newWindow
@casey
Feature: MadLibs


Scenario: Madlibs Test - Granular
	Given user lands on biBerk homepage
	When user clicks Get a Quote
	Then URL contains get-a-quote
	When user enters flor for AutoComplete input field What's your industry?
	Then AutoComplete input field displays following options
	| Option Text                          |
	| Floriculture: No Trees               |
	| Floriculture: With Trees             |
	| Florist                              |
	| Florist Wholesaler                   |
	When user selects AutoComplete option Florist
	Then the following fields have values
	| Display Text          | Field Type   | Value        |
	| What's your industry? | Autocomplete | Florist      |
	When user clicks Let's Go! button
	Then TileSet Do you have any employees? contains the following tiles
	| Tile Text             |
	| Yes, I have employees |
	| No, just the owner(s) |
	When user selects tile for Yes, I have employees
	Then tile Yes, I have employees is selected
	When user clicks Next button
	When user enters employee count of 5
	When user clicks Next button
	Then TileSet Where does your business operate? contains the following tiles
	| Tile Text                             |
	| I Run My Business Out of My Home      |
	| I Lease a Space From Others           |
	| I Work at a Job Site                  |
	| I Run My Business From Property I Own |
	| I Own a Property & Lease to Others    |
	When user selects tile for I Run My Business Out of My Home
	Then tile I Run My Business Out of My Home is selected
	When user clicks Next button
	When user enters ZIP code 18704
	When user clicks Next button
	Then the following LOBs are available
	| LOB Name                      |
	| Workers' Compensation         |
	| Workers' Compensation Rewrite |
	| General Liability             |
	| General Liability + Property  |
	When user selects LOB as Workers' Compensation
	Then URL contains get-wc/businessinfo


Scenario Outline: Madlibs Test - Scenario Outline example with condensed steps
	Given user starts a new quote with below values
	| Industry   | Employees   | Location   | ZIP Code   | LOB   |
	| <Industry> | <Employees> | <Location> | <ZIP Code> | <LOB> |

Examples:
| Industry             | Employees | Location                              | ZIP Code | LOB                          |
| Florist              | 5         | I Run My Business From Property I Own | 18704    | Workers' Compensation        |
| Software Development | 2         | I Lease a Space From Others           | 18702    | Professional Liability (E&O) |
| Automatic Car Wash   | 13        | I Own a Property & Lease to Others    | 18705    | General Liability            |
	

Scenario Outline: Madlibs Test - Scenario Outline example with condensed steps (Alternative)
	Given user starts a new quote with <Industry>, <Employees>, <Location>, <ZIP Code>, <LOB>

Examples:
| Industry                     | Employees | Location                              | ZIP Code | LOB                          |
| Banana Wholesaler            | 7         | I Run My Business From Property I Own | 18704    | General Liability + Property |
#| Professional Dodge Ball Team | 4         | I Own a Property & Lease to Others    | 18705    | Commercial Auto              |

	
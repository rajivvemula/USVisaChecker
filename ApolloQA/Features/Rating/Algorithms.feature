@NoBrowser
Feature: Algorithms

@ratingTests
Scenario: Test Rating Algorithm
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	#When expected values are gathered
	#Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| IL    | VA00029   |
	| IL    | VA00036   |
	| IL    | VA00043   |
	| IL    | VA00054   |

	| SC    | VA00058   |
	| SC    | VA00065   |
	| SC    | VA00043   |
	| SC    | VA00050   |

	| CA    | VA00058   |
	| cA    | VA00065   |
	| cA    | VA00043   |
	| cA    | VA00050   |


@ratingTests
Scenario: Test Rating Algorithm Static Quote
	Given quote with Id 10660 is loaded
	When expected values are gathered
	Then expected values should match the system output


@ratingTests
Scenario: Find USDOT with matching criteria
	Then USDOT with criteria is found 

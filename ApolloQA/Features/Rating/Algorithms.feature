@NoBrowser
Feature: Algorithms

@ratingTests
Scenario: Test Rating Algorithm
	Given quote for '<State>' and '<Algorithm>' is set to Quoted

	Examples: 
	| State | Algorithm |
	| IL    | VA00029   |
	| IL    | VA00036   |
	| IL    | VA00043   |
	| IL    | VA00054   |



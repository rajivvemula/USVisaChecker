Feature: USVisaChecker


@tag1
Scenario Outline: US Visa checker
	Given Check US slots for following <Username> and <Password>

	Examples: 
	| Username                   | Password   |
	| vydyamdwarakamai@gmail.com | 92cktaYV@  |
	| manormaupadhyay8@gmail.com | USvisa@123 |

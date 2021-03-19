Feature: Rating Tables

@ratingTests
Scenario: Test rating manual against PDF
	Given <state> tables are parsed into json object
	And tables are loaded from the system
	When both manuals are compared
	Then there shouldn't be any differences

	Examples: 
	| state |
#	| IL    |
    | SC	|
#	| AZ    |
#	| GA    |
#	| IN    |
#	| MO    |
#	| NV    |
#	| TN    |
#	| TX    |
#	| CA    |
#	| SC    |

@ratingTests
Scenario: Test rating manual against CSV
	Given <state> csv is parsed into json object
	And tables are loaded from the system
	When both manuals are compared
	Then there shouldn't be any differences

	Examples: 
	| state |
#	| IL    |
    | SC	|
#	| AZ    |
#	| GA    |
#	| IN    |
#	| MO    |
#	| NV    |
#	| TN    |
#	| TX    |
#	| CA    |
#	| SC    |


#this is the string used to find all the tables within each state's manual
#1.) open the manual in Chrome 
#2.) hit Ctrl+P 
#3.) enter these strings into Pages->Custom field
#
#IL -  54-81,85-87,90,92,94,96,98-102,104-107,113,118-1933
#SC - 54-95, 100, 102, 104, 106, 108-112, 114-118, 127-4656
#AZ - 54-81, 85-87, 89, 91, 93, 95, 97-101, 103-106, 112, 117-1845
#CA - 54-83, 87-88, 91, 93, 95, 97, 99-103, 105-109, 115, 119-2603
#GA - 54-81, 85, 88, 90, 92, 94, 96-100, 102-105, 111, 116-2343
#IN - 54-81, 85, 88, 90, 92, 94, 96-100, 102-105, 111, 116-2358
#MO - 54-81, 85, 88, 90, 92, 94, 96-100, 102-105, 111, 116-2354
#NV - 54-81, 85, 88, 90, 92, 94, 96-100, 102-105, 111, 116-1773
#TN - 54-81, 85, 88, 90, 92, 94, 96-100, 102-105, 111, 116-2317
#TX - 54, 81, 85, 88, 90, 90, 94, 96-100, 102-105, 111, 116-2535
#
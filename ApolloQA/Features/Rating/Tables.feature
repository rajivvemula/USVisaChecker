@NoBrowser
Feature: Rating Tables

# Pre-requisites:
# 
#  manual for state should be loaded into ./Data/RatingManual/<state> (each table should be an excel file)
#  


# Instructions to parsing a PDF Manual:
# video: https://coveryourbusinessnew.sharepoint.com/:v:/s/hitachi/EaKA6NANgD9JjXEBgyunZsoBgTzsbOjF0t1-w_qwCC6GeA?e=vwyJLa
#
# 1.) Extract all the tables from the PDF manual. Achieve this using chrome or edge (hit Ctrl+P, enter the below strings and print to PDF)
# 2.) Note: if there are special tables (tables with no headers that have different dimenssions in your manual, look for territory & TT.1 tables if those look different those are special tables)
# 3.) Split the PDF into parts of 1500 pages (same as above with string 1-1500, etc)
# 3.) use Tabula to parse each part into a Zip of CSVs, find instructions here: https://dev.azure.com/biberk/_git/Apollo?path=%2FUtility%2FRateTable%2FExtractor (solution has a readme)
# 4.) once you get each part into a Zip of CSV, extract them into their own folder, then go into the first folder and bulk rename all files to the same filename
# 5.) (reapeat for any subsequent parts) navigate to the part, then copy all CSVs, then paste them into the first folder, then rename the newly pasted files to the same filename as step 4.
# 6.) proceed taking the first folder on step 4 through the solution on step 3



#
# Instructions to execute
#
# 1.) Navigate to default.srprofile
# 2.) Identify the <Filter> tag
# 3.) Remove the negation ('!') from the @ratingTests tag
#
#


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
#     Special Tables: 267-277, 503-504, 545-561, 683-684, 685-687, 723-727, 792-793, 795-797, 1121-1123, 1181-1190, 1230-1241, 1332-1333, 1465-1467, 1480-1496, 1504-1505, 1547-1551, 1814-1815, 1926-1928
#TX - 54, 81, 85, 88, 90, 90, 94, 96-100, 102-105, 111, 116-2535
#     Special Tables: 91-92, 130, 195-225, 451-455, 463, 496-543, 664-668, 670-677, 685, 713-726, 750, 791-794, 796-802, 804, 1126-1132, 1140, 1165, 1172-1198, 1212, 1256-1288, 1379-1383, 1405, 1486-1533, 1563-1567,1580-1587,1597, 1636-1649, 1674, 1704,1733, 1773, 1822, 1911-1915, 1931, 2027-2034,2038,2084, 2109, 2134, 2160, 2183, 2196, 2208, 2220, 2231, 2245, 2267, 2461
#     

#     KNOWN ISSUES
#
#      BUG 33584
#
@ratingTests
Scenario: Test rating manual against PDF
	Given <state> tables are parsed into json object
	And tables are loaded from the system for date 2021-08-01
	When both manuals are compared
	Then there shouldn't be any differences

	Examples: 
	| state |
	| IL    |
    | SC	|
#	| AZ    |
	| GA    |
	| IN    |
	| MO    |
	| NV    |
	| TN    |
	| TX    |
	| CA    |


@ratingTests
Scenario: Test rating manual against CSV
	Given <state> csv is parsed into json object
	And tables are loaded from the system for date 2021-03-01
	When both manuals are compared
	Then there shouldn't be any differences

	Examples: 
	| state |
#	| IL    |
    | SC	|
#	| AZ    |
#	| GA    |
	| IN    |
#	| MO    |
#	| NV    |
#	| TN    |
#	| TX    |
	| CA    |


Feature: PieChartBackupAppearance
Verify the appearance of the backup pie chart page as you approach it with different keywords.

#####################################################################################################
# This set of tests is meant to check the appearance of every LOB/Availability TYPE combo.
# For instance, WC Available and Recommended, WC Available and Not Recommended, WC Not Available...
#####################################################################################################

@Unit @Smoke @PieChartBackup
#WC - Available and Recommended
#PL - Not Available
#GL - Available and Not Recommended
#BP - Available and Recommended
#CA - Available and Recommended
Scenario: Backup - WC and CA recommended only
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease                | ZIP Code |
		| Hot Shot Trucking | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 60606    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| PL  | Not Available                 |
		| GL  | Available and Not Recommended |
		| WC  | Available and Recommended     |
		| BP  | Available and Recommended     |
		| CA  | Available and Recommended     |
		

@Unit @Smoke @PieChartBackup
#GL - Not Available
#CA - Not Available
Scenario: Backup - CA and GL Not Available
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry           | Employees | Location                              | Own or Lease       | ZIP Code |
		| Furniture Assembly | 0         | I Run My Business From Property I Own | Inventory or Stock | 60606    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status        |
		| GL  | Not Available |
		| CA  | Not Available |


@Unit @Smoke @PieChartBackup
#WC - Available and Not Recommended
Scenario: Backup - WC Available Not Recommended
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry | Employees | Location                              | Own or Lease       | ZIP Code |
		| Florist  | 0         | I Run My Business From Property I Own | Tools or Equipment | 60606    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| WC  | Available and Not Recommended |

@Unit @Smoke @PieChartBackup
#PL - Available and Recommended
#BP - Not Available
Scenario: Backup - PL Recommended, BP Not Available
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                         | Client Home | Own or Lease | ZIP Code |
		| Accountant | 0         | I Run My Business Out of My Home | No          |              | 17601    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                    |
		| BP  | Not Available             |
		| PL  | Available and Recommended |
		
@Unit @Smoke @PieChartBackup
#WC - Not Available
Scenario: Backup - WC Not Available
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code |
		| Hair Salon | 3         | I Lease a Space From Others |              | 44436    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status        |
		| WC  | Not Available |


#####################################################################################################
#The Following were specifically created to verify BOP/GL Recommendations, etc:
#####################################################################################################

@Unit @Smoke @PieChartBackup
Scenario: Backup - BOP_GL_Rule_1 Do Not Recommend BOP
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Lease a Space From Others | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                    |
		| GL  | Available and Recommended |
		| BP  | Not Available             |
Examples:
	| industry                                                 | emp | ool                | zip   |
	| Appliance Repair                                         | 2   |                    | 06010 |
	| Commercial Remodeling and Renovating: General Contractor | 0   | Tools or Equipment | 60706 |


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_2 Do Not Recommend GL
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                    |
		| GL  | Not Available             |
		| BP  | Available and Recommended |
Examples:
	| industry                                            | emp | location                              | ool | zip   |
	| Alarm or Intercommunication Systems Installation    | 2   | I Own a Property & Lease to Others    |     | 85001 |
	| Burglar and Fire Alarm: With Sprinkler Installation | 2   | I Run My Business From Property I Own |     | 90210 |
	| Animal Hospital                                     | 6   | I Own a Property & Lease to Others    |     | 80015 |
	| Quick-lube shop                                     | 3   | I Run My Business From Property I Own |     | 06010 |
	| Roofing Contractor                                  | 0   | I Own a Property & Lease to Others    |     | 92423 |


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_3 Recommend GL, BOP Available Not Recommended
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Recommended     |
		| BP  | Available and Not Recommended |
Examples:
	| industry   | emp | location                         | ool                | zip   |
	| Drywalling | 3   | I Run My Business Out of My Home | Tools or Equipment | 60606 |
	| Gardener   | 3   | I Work at a Job Site             | Tools or Equipment | 95688 |


@Unit @Smoke @PieChartBackup
Scenario: Backup - BOP_GL_Rule_4 TEHOME Recommend BOP, GL Available Not Recommended
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                         | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Run My Business Out of My Home | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Available and Recommended     |
Examples:
	| industry           | emp | ool                          | zip   |
	| Shingling          | 2   | Furniture                    | 46011 |
	| Appliance Repair   | 2   | Inventory or Stock           | 46013 |
	| Roofing Contractor | 0   | Furniture;Inventory or Stock | 92423 |


@Unit @Smoke @PieChartBackup
Scenario: Backup - BOP_GL_Rule_4 TEJOBSITE Recommend BOP, GL Available Not Recommended
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location             | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Work at a Job Site | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Available and Recommended     |
Examples:
	| industry          | emp | ool                | zip   |
	| Reglaze Bathrooms | 2   | Furniture          | 50327 |
	| Mudjacking        | 2   | Inventory or Stock | 90011 |


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_5 TEHOME BOP Not Available, GL Available Not Recommended because PL
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                         | Client Home | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Run My Business Out of My Home | <home>      | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Not Available                 |
Examples:
	| industry                      | emp | home | ool | zip   |
	| IT Software Training Services | 2   | No   |     | 66006 | #Education & Public Works/Organizations
	| Hair Salon                    | 4   | No   |     | 07303 | #Service Industries
	| Attorney                      | 2   | No   |     | 27513 | #Service Industries


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_6 TEJOBSITE Recommend BOP, GL Available Not Recommended
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location             | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Work at a Job Site | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Not Available                 |
Examples:
	| industry                             | emp | ool | zip   |
	| Irrigation Management Consulting     | 3   |     | 19131 | #Education & Public Works/Organizations
	| Database Designer                    | 2   |     | 48006 | #Service Industries
	| Interior Decorators: No Installation | 1   |     | 60101 | #Service Industries


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_7 TEHOME Do Not Recommend BOP
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location                         | Client Home | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Run My Business Out of My Home | <home>      | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Available and Recommended     |
Examples:
	| industry                       | emp | home | ool                                             | zip   |
	| Nonprofit: Food Bank           | 2   |      | Furniture                                       | 68004 | #Nebraska
	| Household Appliance Wholesaler | 2   |      | Inventory or Stock                              | 89883 | #Nevada
	| Executive Coaching             | 2   | No   | Tools or Equipment                              | 07001 | #New Jersey
	| Car Wash: Full Service         | 0   |      | Furniture;Inventory or Stock;Tools or Equipment | 63941 | #Missouri


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - BOP_GL_Rule_7 TEJOBSITE Do Not Recommend BOP
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location             | Own or Lease | ZIP Code |
		| <industry> | <emp>     | I Work at a Job Site | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Available and Recommended     |
Examples:
	| industry        | emp | ool                                             | zip   |
	| Prosthetist     | 2   | Furniture                                       | 89018 | #Nevada
	| Actuary         | 3   | Inventory or Stock                              | 19131 | #Pennsylvania
	| App Development | 1   | Tools or Equipment                              | 27513 | #North Carolina
	| Auditor         | 0   | Furniture;Inventory or Stock;Tools or Equipment | 80001 | #Colorado


@Unit @Smoke @PieChartBackup
Scenario: Backup - BOP_GL_Rule_8 Recommend GL only
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                    |
		| GL  | Available and Recommended |
		| BP  | Not Available             |
Examples:
	| industry               | emp | location                         | ool | zip   |
	| Car Wash: Full Service | 0   | I Run My Business Out of My Home |     | 48001 |
	| Hospital: Veterinary   | 0   | I Work at a Job Site             |     | 02212 |


@Unit @Smoke @PieChartBackup
Scenario: Backup - Gate 9 - Recommend GL only
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry      | Employees | Location                    | Own or Lease | ZIP Code |
		| Doughnut Shop | 0         | I Lease a Space From Others |              | 55029    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status                        |
		| GL  | Available and Not Recommended |
		| BP  | Available and Recommended     |


#####################################################################################################
#The Following were specifically created to verify WC Recommendations:
#####################################################################################################

@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - WC_Rule_1 WC available but not recommended based on industry
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status |
		| WC  | <wc>   |
Examples:
	| industry                                 | emp | location                              | ool | zip   | wc                            |
	| Retail Store: Automotive Parts           | 0   | I Run My Business Out of My Home      |     | 24606 | Available and Not Recommended |
	| Tutoring Center                          | 0   | I Lease a Space From Others           |     | 33177 | Available and Not Recommended |
	| Surgeon                                  | 0   | I Work at a Job Site                  |     | 03751 | Available and Not Recommended |
	| Orchestra                                | 0   | I Run My Business From Property I Own |     | 40855 | Available and Not Recommended |
	| Recording Equipment Manufacturing        | 0   | I Own a Property & Lease To Others    |     | 99903 | Available and Not Recommended |
	| Deli: with table service and deep frying | 0   | I Run My Business Out of My Home      |     | 62011 | Available and Not Recommended |
	| Supermarket: no gas sales                | 0   | I Lease a Space From Others           |     | 39286 | Available and Not Recommended |


@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - WC_Rule_2 WC available but not recommended based on subindustry
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Client Home | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <home>      | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status |
		| WC  | <wc>   |
Examples:
	| industry                                     | emp | location                              | home | ool | zip   | wc                            |
	| Appraiser                                    | 0   | I Work at a Job Site                  |      |     | 89106 | Available and Not Recommended |
	| Legal Services                               | 0   | I Run My Business From Property I Own |      |     | 28345 | Available and Not Recommended |
	| Bookkeeping                                  | 0   | I Own a Property & Lease To Others    |      |     | 28097 | Available and Not Recommended |
	| Barber Shops                                 | 0   | I Run My Business Out of My Home      | No   |     | 57342 | Available and Not Recommended |
	| Property Management: Rowhouse                | 0   | I Lease a Space From Others           |      |     | 47236 | Available and Not Recommended |
	| Janitorial Services: 50% or More Residential | 0   | I Work at a Job Site                  |      |     | 29940 | Available and Not Recommended |


# Verify impact of Inventory or Stock checkbox 
@Unit @Smoke @PieChartBackup
Scenario Outline: Backup - Inventory or Stock
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status |
		| GL  | <gl>   |
		| BP  | <bop>  |
Examples:
	| industry           | emp | location                    | ool                | zip   | gl                            | bop                       |
	| Accountant         | 2   | I Lease a Space From Others | Inventory or Stock | 55001 | Available and Not Recommended | Available and Recommended |
	| Drywall Contractor | 2   | I Lease a Space From Others | Inventory or Stock | 37066 | Available and Not Recommended | Available and Recommended |


@Unit @Smoke @PieChartBackup
Scenario: Backup - Pie Chart _ Discontinued Industries
	Given user will land on path with recommendation view: Simple
	Given user has navigated to the following URL within the host environment: get-a-quote/
	Then user verifies that the <industry> industry is not in the list of available industries
Examples:
	| industry                                      |
	| Highway, Street, and Bridge Construction      |
	| General Contractor: We do some work ourselves |


@Unit @Smoke @PieChartBackup
Scenario: Backup - Pie Chart _ Ineligible Industries For CA In NJ
	Given user will land on path with recommendation view: Simple
	And user starts a quote with:
		| Industry   | Employees | Location             | Own or Lease | ZIP Code |
		| <industry> | 0         | I Work at a Job Site | Vehicles;    | 08701    |
	And seeks to validate the backup Pie Chart Page with:
		| LOB | Status        |
		| CA  | Not Available |
Examples:
	| industry                           |
	| Construction: General Contractor   |
	| Construction: Handyman             |
	| Construction: Specialty; Carpentry |


@Unit @Smoke @PieChartBackup
Scenario Outline: BOP_GL for added Trucker class mapping
	Given user will land on path with recommendation view: Pie
	And user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    |
	And seeks to validate the Pie Chart Page with:
		| LOB | Status |
		| GL  | <gl>   |
		| BP  | <bop>  |
Examples:
	| industry                                 | emp | location                              | ool                                             | zip   | gl                            | bop                       |
	| Milk Hauling: over 300 miles             | 0   | I Own a Property & Lease to Others    |                                                 | 90012 | Not Available                 | Available and Recommended |
	| Brine Hauling: Over 300 Miles            | 0   | I Run My Business From Property I Own |                                                 | 90012 | Not Available                 | Available and Recommended |
	| Automobile Driveaway Service             | 0   | I Run my Business Out of My Home      | Furniture;Inventory or Stock;Tools or Equipment | 90012 | Available and Not Recommended | Available and Recommended |
	| Bulk Hauling: under 300 miles            | 0   | I Work at a Job Site                  | Furniture;Inventory or Stock;Tools or Equipment | 90012 | Available and Not Recommended | Available and Recommended |
	| Fedex Delivery Service                   | 0   | I Run my Business Out of My Home      |                                                 | 90012 | Available and Recommended     | Not Available             |
	| Newspaper Delivery                       | 0   | I Work at a Job Site                  |                                                 | 90012 | Available and Recommended     | Not Available             |
	| Logistics Services: own trucks that haul | 0   | I Lease a Space From Others           |                                                 | 90012 | Available and Not Recommended | Available and Recommended |
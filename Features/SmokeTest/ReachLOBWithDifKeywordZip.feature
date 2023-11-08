Feature: ReachLOBWithDifKeywordZip

Reach a specified line of business with different keywords and zip codes.

@Unit @Smoke
Scenario Outline: User Reaches WC
	Given user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    | <lob> |
Examples:
	| industry                                    | emp | location                              | ool | zip   | lob |
	| Fencing Contractor                          | 11  | I Run My Business From Property I Own |     | 68381 | WC  |
	| Exercise Club                               | 0   | I Own a Property & Lease to Others    |     | 68722 | WC  |
	| Orthodontist                                | 0   | I Lease a Space From Others           |     | 08401 | WC  |
	| Manned Aerial Photography: With Helicopters | 2   | I Work at a Job Site                  |     | 06699 | WC  |


@Unit @Smoke
Scenario Outline: User Reaches CA
	Given user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    | <lob> |
Examples:
	| industry                                                   | emp | location                              | ool | zip   | lob |
	| Shipping: Local Hauling: Less than 300 miles               | 3   | I Lease a Space From Others           |     | 75949 | CA  |
	| Delivery: Goods; Retail to Homes; No Furniture or Mattress | 0   | I Own a Property & Lease to Others    |     | 37680 | CA  |
	| Amazon Delivery Service                                    | 1   | I Work at a Job Site                  |     | 54211 | CA  |
	| Newspaper Delivery                                         | 0   | I Run My Business From Property I Own |     | 54152 | CA  |


@Unit @Smoke
Scenario Outline: User Reaches PL
	Given user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    | <lob> |
Examples:
	| industry                          | emp | location                              | ool | zip   | lob |
	| Secretarial Services              | 9   | I Lease a Space From Others           |     | 30305 | PL  |
	| Journalist                        | 2   | I Own a Property & Lease to Others    |     | 35179 | PL  |
	| Spin Class Instructor             | 1   | I Run My Business From Property I Own |     | 72260 | PL  |
	| Information Technology Consulting | 4   | I Work at a Job Site                  |     | 55613 | PL  |


@Unit @Smoke
Scenario Outline: User Reaches BOP
	Given user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    | <lob> |
Examples:
	| industry                                  | emp | location                              | ool       | zip   | lob |
	| Hospitality: Fast Food Restaurants        | 1   | I Run My Business From Property I Own |           | 38317 | BP  |
	| Wallboard Contractor                      | 0   | I Work at a Job Site                  | Furniture | 63673 | BP  |
	| Finish Carpentry Contractor: With Framing | 0   | I Lease a Space From Others           | Furniture | 94131 | BP  |
	| Hedge Fund                                | 9   | I Own a Property & Lease to Others    |           | 28718 | BP  |
	

@Unit @Smoke
Scenario Outline: User Reaches GL
	Given user starts a quote with:
		| Industry   | Employees | Location   | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <ool>        | <zip>    | <lob> |
Examples:
	| industry          | emp | location                    | ool | zip   | lob |
	| FroYo Shop        | 2   | I Work at a Job Site        |     | 38665 | GL  |
	| Safety Consulting | 7   | I Lease a Space From Others |     | 03805 | GL  |


@Unit @Smoke
Scenario Outline: User Reaches LOB for Home Occupancy
	Given user starts a quote with:
		| Industry   | Employees | Location   | Client Home | Own or Lease | ZIP Code | LOB   |
		| <industry> | <emp>     | <location> | <home>      | <ool>        | <zip>    | <lob> |
Examples:
	| industry                                  | emp | location                         | home | ool                | zip   | lob |
	| Clinical Nurse Specialist                 | 0   | I Run My Business Out of My Home | no   | Tools or Equipment | 34218 | BP  |
	| Commercial Carpentry: No Residential Work | 2   | I Run My Business Out of My Home |      |                    | 19891 | WC  |
	| Taxicab company: more than one vehicle    | 11  | I Run My Business Out of My Home |      |                    | 47836 | CA  |
	| Drugstore: Pharmacy                       | 0   | I Run My Business Out of My Home | no   |                    | 35080 | PL  |
	| Pressure Washing                          | 0   | I Run My Business Out of My Home |      |                    | 01571 | GL  |
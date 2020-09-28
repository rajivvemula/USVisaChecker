Feature: US-13121-Add vehicle screen to Organization
	As an underwriter, 
	I want to be able to add vehicles to an organization 
	and show them in a grid, so that I can associate them in a policy coverage.



Scenario:TC01 Verify Grid Titles in Vehicle Organization
	Given User is on Homepage
	When User creates an Organization
	| Name       | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
	When User navigates to Vehicles SideTab
	Then Verify correct page orgVehicle is displayed
	Then Grid column label is displayed
	| Key | Value         |
	| a   | Veh #         |
	| b   | Year          |
	| c   | Make & Model  |
	| d   | VIN           |
	| e   | GVW           |
	| f   | Cost New      |
	| g   | Stated Amount |

Scenario:TC02 Add a Vehicle to Organization
	When User adds vehicle to Organization
	| VIN    | Year | Make   | Model | Trim |  Category             | SubCategory | Code                    | Seating   | Gross    | Cost  | Value | Stated |
	| Random | 2015 | Toyota | Camry | SE   |  Cars, Pickup, or SUV | Car - Coupe | Airport Limousines -826 | 5 or less | 0 - 5000 | 10000 | 11000 | 12000  |
	Then Verify vehicle is added to Organization

Scenario:TC03 Vehicle Added is displayed in Grid
	Then Verify vehicle VIN is displayed in grid
Feature: C006-Add A Vehicle To Organization
Add a Vehicle to Organization


Scenario: Add a Vehicle to Organization
	When User adds vehicle to Organization
	| VIN    | Year | Make   | Model | Trim |  Category             | SubCategory | Code                    | Seating   | Gross    | Cost  | Value | Stated |
	| Random | 2015 | Toyota | Camry | SE   |  Cars, Pickup, or SUV | Car - Coupe | Airport Limousines -826 | 5 or less | 0 - 5000 | 10000 | 11000 | 12000  |
	Then Verify vehicle is added to Organization


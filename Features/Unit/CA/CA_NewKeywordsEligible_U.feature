Feature: CA_NewKeywordsEligible_U

Verify that certain keywords are now eligible on CA path

@Unit @CA  
Scenario: CA New Keywords Eligible Unit Inustry Services
	Given user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| <Industry> | 2         | I Run My Business From Property I Own | Vehicles     | 32563    | CA  |
	Then user waits for the app to finish loading
	Then user verifies the appearance of the Start Your Quote page
Examples:
	| Industry                                                |
	| Aftermarket Auto Parts Store: No Repair or Service      |
	| Aftermarket Auto Parts Store: With Repair or Service    |
	| Aftermarket Auto Parts Wholesalers                      |
	| Auto Body Repair Shop                                   |
	| Auto Collision Repair                                   |
	| Auto Conversion or Auto Customization                   |
	| Auto Detailing                                          |
	| Auto Mechanic: No Body Work                             |
	| Auto Mechanic: Some Body Work                           |
	| Auto Oil Change and Lubrication Shops: No Gas Station   |
	| Auto Oil Change and Lubrication Shops: With Gas Station |
	| Auto Painting Shop: No Body Work                        |
	| Auto Parts Wholesaler                                   |
	| Auto Repair: No Body Work                               |
	| Auto Repair: Some Body Work                             |
	| Auto Reposessing                                        |
	| Auto Restoration                                        |
	| Auto Service or Repair Center                           |
	| Auto Storage Garage: No Maintenance                     |
	| Auto Storage Garage: With Maintenance                   |
	| Automatic Car Wash                                      |
	| Beverage Can Recycling                                  |
	| Broken Glass Dealer                                     |
	| Car Tire Dealer                                         |
	| Car Wash: Full Service                                  |
	| Container Recycling: Beverage; Bottle, or Can           |
	| Containerized Trash Removal                             |
	| Conversion or Customization: vehicles                   |
	| Debris Removal Services                                 |
	| Diesel Engine Repair                                    |
	| Dumpster Rental Service                                 |
	| Filling Station: No Service or Repair                   |
	| Filling Station: With Service or Repair                 |
	| Furniture Moving and Storage                            |
	| Furniture Removal Services                              |
	| Furniture Warehouse                                     |
	| Garage: Auto Repair                                     |
	| Garbage Hauler                                          |
	| Garbage, Ashes, or Refuse Collection                    |
	| Gas Station: With repair                                |
	| Gasoline Station: no repair                             |
	| Iron or Steel Scrap Dealer                              |
	| Junk Removal Services                                   |
	| Mobile Auto Mechanic: Including Trucks                  |
	| Mobile Auto Mechanic: No Trucks                         |
	| Mobile Car Wash or Detailing                            |
	| Movers                                                  |
	| Paintless Dent Repair                                   |
	| Paper Shredding Service                                 |
	| Petrol Station: no repair                               |
	| Petrol Station: With repair                             |
	| Pool Service                                            |
	| Powder Coating                                          |
	| Quick-lube shop                                         |
	| Quick-lube Shop: With Gas Station                       |
	| Recycling Services: Including Scrap Metal               |
	| Recycling Services: No Scrap Metal                      |
	| Retail Store: Automotive Parts                          |
	| Retail Store: Car Batteries                             |
	| Rubber Tire Dealer                                      |
	| RV Repair                                               |
	| Scrap Plastics Dealer                                   |
	| Street Sweeping or Cleaning                             |
	| Tire Service                                            |
	| Transportation: Livestock, Equine, or Animals           |
	| Truck Mechanic: No Body Work                            |
	| Truck Mechanic: Some Body Work                          |
	| Truck or Recreational Vehicle (RV) Body Shop            |
	| Truck Repair: No Body Work                              |
	| Truck Storage Garage: No Maintenance                    |
	| Truck Washing Service: Self Service                     |
	| Used Automotive Parts Store                             |
	| Used Bottle Dealer                                      |
	| Van Conversion or Van Customization                     |
	| Waste Collection                                        |
	| Water Treatment Services                                |
	| Window Tinting: Including Automotive                    |
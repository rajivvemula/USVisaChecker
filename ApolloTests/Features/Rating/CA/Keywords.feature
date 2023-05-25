@NoBrowser 
Feature: Keywords

A short summary of the feature


Scenario: 01_Specific Quote Test Rating
	Given quote with Id 110966 is loaded
	When expected values are gathered
	Then expected values should match the system output

@ignore
Scenario: Generate Keyword Feature File
	When user loads all Keywords from the DB
	Then All Keywords are added to this file for '<state>'

	Examples: 
	| state |
	| IL    |
	| SC    |

@ignore
Scenario: Test Rating Keyword
	Given quote for line=7 and Keyword '<Keyword>' in '<State>' is set to Quoted

	Examples: 
	| State | Keyword                                                  |
	| IL    | Theater: Live Shows                                      |
	| IL    | Travel Agencies                                          |
	| IL    | Nursing Home                                             |
	| IL    | Retail Store: Automotive Parts                           |
	| IL    | Auto Reposessing                                         |
	| IL    | Towing Services                                          |
	| IL    | General Contractor: All work is subcontracted out        |
	| IL    | Cabinetry or Interior Trim Installation                  |
	| IL    | Asphalt Paving                                           |
	| IL    | Construction Project Management no contracting employees |
	| IL    | Excavation                                               |
	| IL    | Blasting Contractor                                      |
	| IL    | Garbage, Ashes, or Refuse Collection                     |
	| IL    | Sawmill Operation                                        |
	| IL    | Landscape Gardening: No Tree Removal or Excavation       |
	| IL    | Beverage Can Recycling                                   |
	| IL    | Dentist                                                  |
	| IL    | Personal Care Assistants                                 |
	| IL    | Bee Raising                                              |
	| IL    | Public Library                                           |
	| IL    | Social Worker                                            |
	| IL    | Television Broadcasting                                  |
	| IL    | Bakery Store: Retail                                     |
	| IL    | Charter Bus Service                                      |
	| IL    | Bus Tours                                                |
	| IL    | Summer Camps                                             |
	| IL    | Hotel: No Restaurant                                     |
	| IL    | Clothing Manufacturing                                   |
	| IL    | Manufacturing: Meat Products                             |
	| IL    | Manufacturing: Food Products                             |
	| IL    | Carbonated Beverage Manufacturing                        |
	| IL    | Fish Curing                                              |
	| IL    | Restaurant: Fast Food; Take Out Only; No Deep Frying     |
	| IL    | Lunch Wagon                                              |
	| IL    | Building Materials Dealer                                |
	| IL    | E-commerce                                               |
	| IL    | Produce Wholesaler                                       |
	| IL    | Grocery Store: Wholesale                                 |
	| IL    | Poultry Wholesaler                                       |
	| IL    | Chinese Food: Packaged or Frozen; Wholesaler             |
	| IL    | Cider Wholesaler                                         |
	| IL    | Fish Wholesaler                                          |
	| IL    | Property Management: Commercial Buildings Only           |
	| IL    | Airport Car Service                                      |
	| IL    | Delivery: Mail, Parcel or Package; No USPS Contract      |
	| IL    | Trucking: Local Hauling: less than 300 miles             |
	| IL    | Installation of Household Appliances including Delivery  |
	| IL    | Bus Company                                              |
	| IL    | Dump Truck Hauling: Gravel, Dirt, and Sand               |
	| IL    | Fulfillment Center                                       |
	| IL    | Milk Hauling: over 300 miles                             |
	| IL    | Newspaper Delivery                                       |
	| IL    | Anhydrous Ammonia Dealer                                 |
	| IL    | Moving Company                                           |
	| IL    | Mental Health Counselor                                  |
	| IL    | Office Machine: Installation, Service, or Repair         |
	| IL    | Kennels: Breeding, Boarding, or Sales                    |
	| IL    | Home Health Aide: No Registered Nurses                   |
	| IL    | Limousine Company                                        |
	| IL    | Private Detective Agency                                 |
	| IL    | Uber Driver                                              |
	| IL    | Taxicab company: more than one vehicle                   |
	| IL    | Ridesharing                                              |
	| IL    | Retail Store: Automotive Parts                           |
	| IL    | Car Tire Dealer                                          |
	| IL    | Concrete Dealer, Ready-Mixed                             |

##AUTOGENERATED BELOW THIS FOR STATE IL
#	| IL    | Retail Store: Automotive Parts                                                                   |
#	| IL    | Gasoline Station: no repair                                                                      |
#	| IL    | Auto Rental Shop                                                                                 |
#	| IL    | Rubber Tire Dealer                                                                               |
#	| IL    | Vehicle Sales: No Repair Work                                                                    |
#	| IL    | Auto Body Repair Shop                                                                            |
#	| IL    | Car Wash: Full Service                                                                           |
#	| IL    | Conversion or Customization: vehicles                                                            |
#	| IL    | Auto Service or Repair Center                                                                    |
#	| IL    | Cabinetry or Interior Trim Installation                                                          |
#	| IL    | Flat Cement Work: No Self-Bearing Work                                                           |
#	| IL    | Concrete Construction: No Pouring of Walls                                                       |
#	| IL    | Masonry Contractor                                                                               |
#	| IL    | Plastering or Stucco Work: Interior and/or Exterior                                              |
#	| IL    | HVAC and Refrigeration Systems                                                                   |
#	| IL    | Plumbing                                                                                         |
#	| IL    | Sheet Metal Work: Away From Shop                                                                 |
#	| IL    | Welding or Cutting                                                                               |
#	| IL    | Drywalling                                                                                       |
#	| IL    | Electrical Work                                                                                  |
#	| IL    | Excavation                                                                                       |
#	| IL    | Grading of Land                                                                                  |
#	| IL    | Insulation Work                                                                                  |
#	| IL    | Lathing Contractor                                                                               |
#	| IL    | Painting: Both Inside and Outside; 3 Stories or Less                                             |
#	| IL    | Paperhanging                                                                                     |
#	| IL    | Colleges                                                                                         |
#	| IL    | School: K-12 Education                                                                           |
#	| IL    | Firefighters                                                                                     |
#	| IL    | Garbage, Ashes, or Refuse Collection                                                             |
#	| IL    | Police Officers                                                                                  |
#	| IL    | Ambulance Service Cos. and EMS                                                                   |
#	| IL    | Dentist                                                                                          |
#	| IL    | Home Health Aide: No Registered Nurses                                                           |
#	| IL    | Medical Laboratory                                                                               |
#	| IL    | Hospital: General                                                                                |
#	| IL    | Hospital: Veterinary                                                                             |
#	| IL    | Child Day Care Center                                                                            |
#	| IL    | Nursing Home                                                                                     |
#	| IL    | Retirement Living Center: No care provided                                                       |
#	| IL    | Amusement Park or Exhibition Operation                                                           |
#	| IL    | Public Library                                                                                   |
#	| IL    | Theater: Live Shows                                                                              |
#	| IL    | Summer Camps                                                                                     |
#	| IL    | Hotel: No Restaurant                                                                             |
#	| IL    | Billiard Hall                                                                                    |
#	| IL    | Bowling Lane                                                                                     |
#	| IL    | Yacht Club                                                                                       |
#	| IL    | Social Club                                                                                      |
#	| IL    | Exercise or Health Club                                                                          |
#	| IL    | Roller-Skating Rink Operation                                                                    |
#	| IL    | Shooting Gallery                                                                                 |
#	| IL    | YMCA, YWCA, YMHA or YWHA, Institution                                                            |
#	| IL    | Nurseries: With Trees                                                                            |
#	| IL    | Landscape Gardening: No Tree Removal or Excavation                                               |
#	| IL    | Lawn Maintenance: No Tree Removal or Excavation                                                  |
#	| IL    | Parks and Gardens                                                                                |
#	| IL    | Sprinkler Installation: Inside Buildings                                                         |
#	| IL    | Tree Prune, Spray, and Trim: No Removal or Excavation                                            |
#	| IL    | Manufacturing: Food Products                                                                     |
#	| IL    | Manufacturing: Meat Products                                                                     |
#	| IL    | Clothing Manufacturing                                                                           |
#	| IL    | Cosmetics Manufacturing                                                                          |
#	| IL    | Die Casting Manufacturing                                                                        |
#	| IL    | Embroidery Manufacturing                                                                         |
#	| IL    | Furniture Manufacturing                                                                          |
#	| IL    | Instrument Manufacturing                                                                         |
#	| IL    | Machinery Manufacturing                                                                          |
#	| IL    | Paper Manufacturing                                                                              |
#	| IL    | Pharmaceutical Manufacturing                                                                     |
#	| IL    | Plumbing Products Manufacturing                                                                  |
#	| IL    | Precision Turned Product Manufacturing                                                           |
#	| IL    | Restaurant: Fast Food; Take Out Only; No Deep Frying                                             |
#	| IL    | Bar                                                                                              |
#	| IL    | Lounge or Night Club                                                                             |
#	| IL    | Bakery Store: Retail                                                                             |
#	| IL    | Coffee Shop                                                                                      |
#	| IL    | Doughnut Shop                                                                                    |
#	| IL    | Grocery Store: Retail; No Gas Sales                                                              |
#	| IL    | Beverage Store: Alcoholic                                                                        |
#	| IL    | Supermarket: no gas sales                                                                        |
#	| IL    | Bicycles Store: Retail                                                                           |
#	| IL    | Bookstore: New Only                                                                              |
#	| IL    | Camera and Photographic Supplies Store: Retail                                                   |
#	| IL    | Clothing Store: Retail                                                                           |
#	| IL    | Convenience Store: No Cooking; No Gas Station                                                    |
#	| IL    | Department Store                                                                                 |
#	| IL    | Drugstore: Pharmacy                                                                              |
#	| IL    | Flooring: Floor Covering Store; No Installation                                                  |
#	| IL    | Florist                                                                                          |
#	| IL    | Furniture or Mattress Store: Retail                                                              |
#	| IL    | Retail Store: General Merchandise                                                                |
#	| IL    | Jewelry Store: Retail                                                                            |
#	| IL    | Pawn Shop                                                                                        |
#	| IL    | Pet and Pet Supply Store                                                                         |
#	| IL    | Shoe Store: Retail                                                                               |
#	| IL    | Sporting Goods Store: Retail                                                                     |
#	| IL    | Toy Store: Retail                                                                                |
#	| IL    | Building Materials Dealer                                                                        |
#	| IL    | Hardware Store: Retail                                                                           |
#	| IL    | Home Improvement Store: Retail                                                                   |
#	| IL    | Retail Store: Paint or Wallpaper                                                                 |
#	| IL    | Retail Store: Plumbers Supplies                                                                  |
#	| IL    | Installation of Household Appliances including Delivery                                          |
#	| IL    | Burglar and Fire Alarm Installation: No Sprinklers                                               |
#	| IL    | Ceiling Installation                                                                             |
#	| IL    | Fencing Contractor                                                                               |
#	| IL    | Millwright Work                                                                                  |
#	| IL    | Swimming Pool, Sauna, or Spa Construction                                                        |
#	| IL    | Hair Salon                                                                                       |
#	| IL    | Laundry and Dry Cleaning                                                                         |
#	| IL    | Nail Salon                                                                                       |
#	| IL    | Sun Tanning Salon                                                                                |
#	| IL    | Tattoo Parlors                                                                                   |
#	| IL    | Accountant                                                                                       |
#	| IL    | Architects                                                                                       |
#	| IL    | Attorney                                                                                         |
#	| IL    | Auditor                                                                                          |
#	| IL    | Bank                                                                                             |
#	| IL    | Computer Programming or Design                                                                   |
#	| IL    | Employment Placement Agencies                                                                    |
#	| IL    | Real Estate Agency & Appraisers                                                                  |
#	| IL    | Salespersons or Collectors: Traveling                                                            |
#	| IL    | Residential Cleaning Services: Franchise                                                         |
#	| IL    | Carpet, Rug, or Upholstery Cleaning                                                              |
#	| IL    | Cemetery Operations                                                                              |
#	| IL    | Exterminator or Pest Control                                                                     |
#	| IL    | Funeral Director                                                                                 |
#	| IL    | Inspection of Insurance Risks                                                                    |
#	| IL    | Kennels: Breeding, Boarding, or Sales                                                            |
#	| IL    | Locksmith                                                                                        |
#	| IL    | Mailing or Addressing Co. or Letter Service Shop                                                 |
#	| IL    | Mobile Crane Rental: With Operators                                                              |
#	| IL    | Pet Grooming: No Travelling                                                                      |
#	| IL    | Snow Removal                                                                                     |
#	| IL    | Taxidermist                                                                                      |
#	| IL    | Telecommunications Co.                                                                           |
#	| IL    | Undertaker                                                                                       |
#	| IL    | Upholstering                                                                                     |
#	| IL    | Bus Company                                                                                      |
#	| IL    | Limousine Company                                                                                |
#	| IL    | Messenger or Courier Service                                                                     |
#	| IL    | Trucking: Local Hauling: less than 300 miles                                                     |
#	| IL    | Trucking: Long Distance Hauling: more than 300 miles                                             |
#	| IL    | Storage Warehouse: Cold                                                                          |
#	| IL    | Storage Warehouse: Furniture                                                                     |
#	| IL    | Storage Warehouse: General                                                                       |
#	| IL    | Religious Organizations                                                                          |
#	| IL    | Commercial Cleaning Services: Less than 50% Residential                                          |
#	| IL    | Group Home for the Disabled                                                                      |
#	| IL    | Assisted Living Facility                                                                         |
#	| IL    | Window Washing: 3 stories or less                                                                |
#	| IL    | Equipment Rental                                                                                 |
#	| IL    | Towing Services                                                                                  |
#	| IL    | Dealers: Hay, Grain, or Feed                                                                     |
#	| IL    | Day Spas: No Body Massages                                                                       |
#	| IL    | Ice Cream or Yogurt Shops                                                                        |
#	| IL    | Gun Shop                                                                                         |
#	| IL    | Humane Society                                                                                   |
#	| IL    | Check Cashing Establishments                                                                     |
#	| IL    | Stenographer or Court Reporter                                                                   |
#	| IL    | Notaries                                                                                         |
#	| IL    | Title Agents                                                                                     |
#	| IL    | Ticket Agencies                                                                                  |
#	| IL    | Telemarketing                                                                                    |
#	| IL    | Travel Agencies                                                                                  |
#	| IL    | Public Relations Agencies                                                                        |
#	| IL    | Stockbrokers                                                                                     |
#	| IL    | Financial Planners                                                                               |
#	| IL    | Credit Reporting Agencies                                                                        |
#	| IL    | Advertising Agencies: No Sign Installation                                                       |
#	| IL    | Private Detective Agency                                                                         |
#	| IL    | Professional Trade Assocation                                                                    |
#	| IL    | Interior Decorators: No Installation                                                             |
#	| IL    | Video Rental                                                                                     |
#	| IL    | Retail Store: Tobacco Products                                                                   |
#	| IL    | Signs & Banners Store: Retail                                                                    |
#	| IL    | Paper Products Store: Retail                                                                     |
#	| IL    | Variety Store                                                                                    |
#	| IL    | Retail Store: Party Supplies                                                                     |
#	| IL    | Musical Instruments Store: Retail; No Pianos or Organs                                           |
#	| IL    | Trophies Store: Retail                                                                           |
#	| IL    | Picture and Frame Store: Retail                                                                  |
#	| IL    | Computer Store: Retail                                                                           |
#	| IL    | Beauty Supply Store: Retail                                                                      |
#	| IL    | Candy Store: Retail                                                                              |
#	| IL    | Army/Navy Stores                                                                                 |
#	| IL    | Retail Store: Janitorial Supplies                                                                |
#	| IL    | Kitchen Accessories Store: Retail                                                                |
#	| IL    | Leather or Hide Products                                                                         |
#	| IL    | Optical or Hearing Aid: Store or Services                                                        |
#	| IL    | Office Machine: Installation, Service, or Repair                                                 |
#	| IL    | Art/Hobby Supplies                                                                               |
#	| IL    | Household Appliances Retail: Store                                                               |
#	| IL    | Retail Store: Electrical Lighting / Supplies                                                     |
#	| IL    | Retail Store: Fabric                                                                             |
#	| IL    | HVAC Equipment Retail: Store                                                                     |
#	| IL    | Monuments Store: Retail                                                                          |
#	| IL    | Gardening Supplies Store: Retail                                                                 |
#	| IL    | Gift Shop                                                                                        |
#	| IL    | Wood Products Store                                                                              |
#	| IL    | Fur/Garments Store: Retail                                                                       |
#	| IL    | Equipment Fixtures or Supplies Store: Retail                                                     |
#	| IL    | Printing, Copying, or Duplicating                                                                |
#	| IL    | Beverage Store: Non-Alcoholic                                                                    |
#	| IL    | Concession Stands or Snack Bars                                                                  |
#	| IL    | Siding Installation                                                                              |
#	| IL    | Computers: Installation and Repair                                                               |
#	| IL    | Photography: No Drones                                                                           |
#	| IL    | Auctioneers                                                                                      |
#	| IL    | Engraving                                                                                        |
#	| IL    | Art Gallery                                                                                      |
#	| IL    | Interior Decorators: With Installation                                                           |
#	| IL    | Sign Painting or Lettering: No Spray Paint; Inside Only                                          |
#	| IL    | Shoe Repair                                                                                      |
#	| IL    | Sprinkler Installation: Lawns                                                                    |
#	| IL    | Glass and Glazing Work: With Work Outside Shop                                                   |
#	| IL    | Tuxedo Rental                                                                                    |
#	| IL    | Wig Store                                                                                        |
#	| IL    | Floor Installation: With Carpeting                                                               |
#	| IL    | Lunch Wagon                                                                                      |
#	| IL    | Trade, Vocational or Technical School                                                            |
#	| IL    | Rifle Range                                                                                      |
#	| IL    | Bike Shop: With Repair; No Motorcycle                                                            |
#	| IL    | Auction                                                                                          |
#	| IL    | CPA                                                                                              |
#	| IL    | Certified Public Accountant                                                                      |
#	| IL    | Tax Preparation Services                                                                         |
#	| IL    | Bookkeeping                                                                                      |
#	| IL    | CFP (Certified Financial Planner)                                                                |
#	| IL    | Certified Financial Planners                                                                     |
#	| IL    | Estate Planners                                                                                  |
#	| IL    | Bid: Auctioneers                                                                                 |
#	| IL    | Donut Shop                                                                                       |
#	| IL    | Headhunting Services: No staffing services                                                       |
#	| IL    | Imaging Diagnostic Services                                                                      |
#	| IL    | Babysitting                                                                                      |
#	| IL    | Pipe Fitting                                                                                     |
#	| IL    | Gardener                                                                                         |
#	| IL    | Nursing Care: Non-Travelling                                                                     |
#	| IL    | Cabling: Inside Buildings                                                                        |
#	| IL    | Electrician                                                                                      |
#	| IL    | Wiring Services                                                                                  |
#	| IL    | Heating Ventilation and Air Conditioning Contractor                                              |
#	| IL    | HVAC Services                                                                                    |
#	| IL    | Refrigeration and Cooling: Installation, Service or Repair                                       |
#	| IL    | Wallpapering                                                                                     |
#	| IL    | Painting: Outside of Buildings Only; 3 Stories or Less                                           |
#	| IL    | Painting: Inside of Buildings Only                                                               |
#	| IL    | Pest Control                                                                                     |
#	| IL    | Exterminator                                                                                     |
#	| IL    | Pet Groomer: No Travelling                                                                       |
#	| IL    | Bicycle Courier                                                                                  |
#	| IL    | Animal Grooming                                                                                  |
#	| IL    | Animal Shelter                                                                                   |
#	| IL    | Software Development                                                                             |
#	| IL    | Software Engineering                                                                             |
#	| IL    | Software Programming                                                                             |
#	| IL    | Programmer                                                                                       |
#	| IL    | Web Design                                                                                       |
#	| IL    | E-commerce                                                                                       |
#	| IL    | Application Development                                                                          |
#	| IL    | Computer Programmer                                                                              |
#	| IL    | Insurance Agency                                                                                 |
#	| IL    | Insurance Brokerage                                                                              |
#	| IL    | Temporary Employment Agency                                                                      |
#	| IL    | Recruiting Services: No Staffing Services                                                        |
#	| IL    | Doggy Day Care                                                                                   |
#	| IL    | Pet Training                                                                                     |
#	| IL    | Pet Boarding                                                                                     |
#	| IL    | Pet Sitting                                                                                      |
#	| IL    | Appraiser                                                                                        |
#	| IL    | Vault Maintenance                                                                                |
#	| IL    | Liquor Store                                                                                     |
#	| IL    | Home Repairs: No Framing                                                                         |
#	| IL    | Recreation Camps                                                                                 |
#	| IL    | Public Golf Course                                                                               |
#	| IL    | Framing Contractor                                                                               |
#	| IL    | Handyman: No Framing Work                                                                        |
#	| IL    | General Contractor: All work is subcontracted out                                                |
#	| IL    | GC                                                                                               |
#	| IL    | Used Automotive Parts Store                                                                      |
#	| IL    | Gas Station: no repair                                                                           |
#	| IL    | Van Conversion or Van Customization                                                              |
#	| IL    | Automatic Car Wash                                                                               |
#	| IL    | Garage: Auto Repair                                                                              |
#	| IL    | Truck Washing Service: Full Service                                                              |
#	| IL    | Auto Restoration                                                                                 |
#	| IL    | Aftermarket Auto Parts Store: No Repair or Service                                               |
#	| IL    | Retail Store: Car Batteries                                                                      |
#	| IL    | Antique Auto Sales                                                                               |
#	| IL    | Auto Conversion or Auto Customization                                                            |
#	| IL    | Handyperson: No Framing                                                                          |
#	| IL    | Auto Collision Repair                                                                            |
#	| IL    | Auto Mechanic: No Body Work                                                                      |
#	| IL    | Driveway Installation                                                                            |
#	| IL    | Sidewalk Installation                                                                            |
#	| IL    | Auto Dealership: New and Used                                                                    |
#	| IL    | Auto Sales                                                                                       |
#	| IL    | Prefinished Hardwood Floor Installation Only                                                     |
#	| IL    | Car Rentals and Leasing                                                                          |
#	| IL    | Truck Stop: No Repair                                                                            |
#	| IL    | Automobile Rentals and Leasing                                                                   |
#	| IL    | Kitchen Cabinetry Installation                                                                   |
#	| IL    | Finish Carpentry Contractor: No Framing                                                          |
#	| IL    | Civic Association                                                                                |
#	| IL    | Business Association                                                                             |
#	| IL    | Auto Salvage                                                                                     |
#	| IL    | Motorcycle Dealer                                                                                |
#	| IL    | Outdoor Recreational Dealer                                                                      |
#	| IL    | Auto Painting Shop: No Body Work                                                                 |
#	| IL    | Tire Retreading                                                                                  |
#	| IL    | Car Tire Dealer                                                                                  |
#	| IL    | Orthodontist                                                                                     |
#	| IL    | Library                                                                                          |
#	| IL    | Deli: No Table Service                                                                           |
#	| IL    | Diner: No Alcohol Sales                                                                          |
#	| IL    | Pool Hall or Billiards                                                                           |
#	| IL    | Barber Shops                                                                                     |
#	| IL    | Beauty Salon                                                                                     |
#	| IL    | Limo Driver                                                                                      |
#	| IL    | Bus Driver                                                                                       |
#	| IL    | Taxidermy                                                                                        |
#	| IL    | Private Investigator                                                                             |
#	| IL    | Mortician                                                                                        |
#	| IL    | Embalmer                                                                                         |
#	| IL    | Petrol Station: no repair                                                                        |
#	| IL    | Filling Station: No Service or Repair                                                            |
#	| IL    | Roofer                                                                                           |
#	| IL    | Stucco Contractor: Interior and/or Exterior                                                      |
#	| IL    | Wall Board Installation                                                                          |
#	| IL    | Vocational School                                                                                |
#	| IL    | Churches                                                                                         |
#	| IL    | Synagogue                                                                                        |
#	| IL    | University                                                                                       |
#	| IL    | Trash Collector                                                                                  |
#	| IL    | Waste Collection                                                                                 |
#	| IL    | Periodontist                                                                                     |
#	| IL    | Exodontist                                                                                       |
#	| IL    | Catering                                                                                         |
#	| IL    | Smorgasbord                                                                                      |
#	| IL    | Duckpin Bowling                                                                                  |
#	| IL    | Actuary                                                                                          |
#	| IL    | Ad Agency: No Sign Installation                                                                  |
#	| IL    | EMS                                                                                              |
#	| IL    | Paralegal                                                                                        |
#	| IL    | Pastry Shop: Retail                                                                              |
#	| IL    | Bake Shop: Retail                                                                                |
#	| IL    | Pub                                                                                              |
#	| IL    | Lounge                                                                                           |
#	| IL    | Saloon                                                                                           |
#	| IL    | Alehouse                                                                                         |
#	| IL    | Security Systems Installation                                                                    |
#	| IL    | Electrical Technician                                                                            |
#	| IL    | Inn: No Restaurant                                                                               |
#	| IL    | Animal Hospital                                                                                  |
#	| IL    | Courier                                                                                          |
#	| IL    | Yogurt Shop                                                                                      |
#	| IL    | Tombstone Maker                                                                                  |
#	| IL    | Sneakers: Store                                                                                  |
#	| IL    | Uber Driver                                                                                      |
#	| IL    | Business Analyst                                                                                 |
#	| IL    | Septic or Cesspool Cleaning                                                                      |
#	| IL    | Snack Stand: concessions                                                                         |
#	| IL    | Electronics Store                                                                                |
#	| IL    | Computer Repair Store                                                                            |
#	| IL    | Optometrist                                                                                      |
#	| IL    | Podiatrist: Physician                                                                            |
#	| IL    | Urologist: Physician                                                                             |
#	| IL    | Family Medicine                                                                                  |
#	| IL    | Pediatrician: Physician                                                                          |
#	| IL    | Portrait Studio                                                                                  |
#	| IL    | Pharmacy                                                                                         |
#	| IL    | Drugstore Retail                                                                                 |
#	| IL    | Apothecary                                                                                       |
#	| IL    | Property Management: Commercial Buildings Only                                                   |
#	| IL    | Property Management: Apartment or Condo                                                          |
#	| IL    | Property Management: Mobile Home or Trailer Park                                                 |
#	| IL    | Building Operations: Commercial or Dwelling                                                      |
#	| IL    | Building Operations: Condos and Apartments                                                       |
#	| IL    | Building Operations: Mobile Home or Trailer Park                                                 |
#	| IL    | Commercial Lending                                                                               |
#	| IL    | Formal Wear                                                                                      |
#	| IL    | Glazing                                                                                          |
#	| IL    | DVD Rental Store                                                                                 |
#	| IL    | Shingling                                                                                        |
#	| IL    | Chauffeur                                                                                        |
#	| IL    | Bed and Breakfast                                                                                |
#	| IL    | Alarm or Intercommunication Systems Installation                                                 |
#	| IL    | Health Spa                                                                                       |
#	| IL    | Janitorial Services: Less than 50% Residential                                                   |
#	| IL    | Pharmaceutical Research                                                                          |
#	| IL    | Court Reporter                                                                                   |
#	| IL    | Custom Kitchens Installation                                                                     |
#	| IL    | Waterproofing Basements                                                                          |
#	| IL    | Stonemason                                                                                       |
#	| IL    | Fitness Gym                                                                                      |
#	| IL    | School Transportation                                                                            |
#	| IL    | Caregiver                                                                                        |
#	| IL    | Window Coverings Installation                                                                    |
#	| IL    | Precast Concrete Work                                                                            |
#	| IL    | Airport Car Service                                                                              |
#	| IL    | Newspaper Delivery                                                                               |
#	| IL    | Chiropractor                                                                                     |
#	| IL    | Bus Tours                                                                                        |
#	| IL    | Truck Rental                                                                                     |
#	| IL    | Truck Leasing                                                                                    |
#	| IL    | Art Galleries                                                                                    |
#	| IL    | Physical Therapist: Non-traveling                                                                |
#	| IL    | Occupational Therapist: Non-traveling                                                            |
#	| IL    | Satellite Installation                                                                           |
#	| IL    | Gutter Installation                                                                              |
#	| IL    | Basketball Camp                                                                                  |
#	| IL    | Food Truck                                                                                       |
#	| IL    | Sealcoating                                                                                      |
#	| IL    | Tutoring Center                                                                                  |
#	| IL    | Property Preservation                                                                            |
#	| IL    | Museum                                                                                           |
#	| IL    | Art Museum                                                                                       |
#	| IL    | Sign Painting or Lettering: Outside                                                              |
#	| IL    | Moving Company                                                                                   |
#	| IL    | Movers                                                                                           |
#	| IL    | Self-Storage Warehouses                                                                          |
#	| IL    | Restaurant: Bistro; No Alcohol Sales                                                             |
#	| IL    | Restaurant: Buffet                                                                               |
#	| IL    | Cafe: No Table Service; No Hot Food                                                              |
#	| IL    | Restaurant: Family; No Alcohol Sales                                                             |
#	| IL    | Restaurant: Fine-Dining; No Alcohol Sales                                                        |
#	| IL    | Restaurant: Pizza; No Deep Frying; No Table Service                                              |
#	| IL    | Professional Employer Organization                                                               |
#	| IL    | Financial Advisors                                                                               |
#	| IL    | Hedge Fund                                                                                       |
#	| IL    | Arts and Crafts Store                                                                            |
#	| IL    | Athletic Apparel Store                                                                           |
#	| IL    | Award Store                                                                                      |
#	| IL    | Footwear Store: Retail                                                                           |
#	| IL    | Chocolate Shop                                                                                   |
#	| IL    | Clothes Store                                                                                    |
#	| IL    | Clothes Manufacturing                                                                            |
#	| IL    | Copy Store                                                                                       |
#	| IL    | Dime Store                                                                                       |
#	| IL    | Dollar Store                                                                                     |
#	| IL    | Five and Ten Store                                                                               |
#	| IL    | Flowers Shop                                                                                     |
#	| IL    | Auto Repair: No Body Work                                                                        |
#	| IL    | Auto Repair: Some Body Work                                                                      |
#	| IL    | Glasses, Lenses, or Eyewear store                                                                |
#	| IL    | Gravestone Maker                                                                                 |
#	| IL    | Headstone Maker                                                                                  |
#	| IL    | Hunting Store                                                                                    |
#	| IL    | Laundromat: Self-Service; Non-supervised                                                         |
#	| IL    | Brewpub                                                                                          |
#	| IL    | Luncheonette: no alcohol sales                                                                   |
#	| IL    | Mini Storage                                                                                     |
#	| IL    | Mini-Storage                                                                                     |
#	| IL    | Minimart: No Gas Station; No Cooking                                                             |
#	| IL    | Public Notary                                                                                    |
#	| IL    | Record or Cds Store: Retail                                                                      |
#	| IL    | Property Management: Rowhouse                                                                    |
#	| IL    | Running Store                                                                                    |
#	| IL    | Sandwich Shop: No Table Service; No Deep Frying                                                  |
#	| IL    | Custom Tailoring                                                                                 |
#	| IL    | Seamstress                                                                                       |
#	| IL    | Custom Dressmaker                                                                                |
#	| IL    | Delivery: Mail, Parcel or Package; No USPS Contract                                              |
#	| IL    | Delivery: Mail, Parcel or Package; USPS Contract                                                 |
#	| IL    | Shipping: Local Hauling: Less than 300 miles                                                     |
#	| IL    | Shipping: Long Distance Hauling: More than 300 miles                                             |
#	| IL    | Shipping: Mail, Parcel or Package: No USPS Contract                                              |
#	| IL    | Shipping: Mail, Parcel or Package: USPS Contract                                                 |
#	| IL    | Ski and Snowboard Rental: No Resorts                                                             |
#	| IL    | Suitcase Store                                                                                   |
#	| IL    | Luggage Store: Retail                                                                            |
#	| IL    | Travel Agent                                                                                     |
#	| IL    | Variety Shop                                                                                     |
#	| IL    | Watch Store                                                                                      |
#	| IL    | Woodworking: With Sawmill                                                                        |
#	| IL    | Hair Supplies, Hair Extensions Store: Retail                                                     |
#	| IL    | Interior Design: With Installation                                                               |
#	| IL    | Quick Stop: No Gas Station; No Cooking                                                           |
#	| IL    | Cleaning Supplies Store Only                                                                     |
#	| IL    | Clock Repair Store                                                                               |
#	| IL    | Outdoor Goods Store                                                                              |
#	| IL    | Outfitter: Outdoor Goods                                                                         |
#	| IL    | Outfitter: Clothing                                                                              |
#	| IL    | Sports Equipment Store                                                                           |
#	| IL    | Surfboards Shop                                                                                  |
#	| IL    | Milk Store                                                                                       |
#	| IL    | Cheese Shop                                                                                      |
#	| IL    | Exercise Equipment Store: Retail                                                                 |
#	| IL    | Toupee Store                                                                                     |
#	| IL    | Boats Rental and Shop                                                                            |
#	| IL    | Water Ski Rental and Shop                                                                        |
#	| IL    | Water Sports                                                                                     |
#	| IL    | Social Worker                                                                                    |
#	| IL    | Insurance Company                                                                                |
#	| IL    | Reinsurance Company                                                                              |
#	| IL    | Bicycle Repair Shop                                                                              |
#	| IL    | Bike Shop: With Repair; Including Motorcycles                                                    |
#	| IL    | Fireplace Installation                                                                           |
#	| IL    | Roofing Contractor                                                                               |
#	| IL    | Day Care                                                                                         |
#	| IL    | Logging                                                                                          |
#	| IL    | Logger                                                                                           |
#	| IL    | Irrigation Installation                                                                          |
#	| IL    | Private Security Guards                                                                          |
#	| IL    | Domestic Workers: More than 20 hours per week                                                    |
#	| IL    | Homeowner Need Policy for Nanny: Live-in                                                         |
#	| IL    | Provider of Nanny Services                                                                       |
#	| IL    | Tennis Courts                                                                                    |
#	| IL    | Miniature Golf                                                                                   |
#	| IL    | Minigolf                                                                                         |
#	| IL    | Putt-putt                                                                                        |
#	| IL    | Putt putt                                                                                        |
#	| IL    | Berry Farming                                                                                    |
#	| IL    | Berry Picking                                                                                    |
#	| IL    | Strawberry Farming                                                                               |
#	| IL    | Strawberry Picking                                                                               |
#	| IL    | Cattle Raising                                                                                   |
#	| IL    | Cattle Farming                                                                                   |
#	| IL    | Dairy Farm                                                                                       |
#	| IL    | Soybean Farming                                                                                  |
#	| IL    | Wheat Farming                                                                                    |
#	| IL    | Rice Farming                                                                                     |
#	| IL    | Wine Vineyard                                                                                    |
#	| IL    | Vineyard                                                                                         |
#	| IL    | Wine Grape Grower                                                                                |
#	| IL    | Potato Farming                                                                                   |
#	| IL    | Potato Grower                                                                                    |
#	| IL    | Orange Groves                                                                                    |
#	| IL    | Apple Orchard                                                                                    |
#	| IL    | Hog Farming                                                                                      |
#	| IL    | Chicken Egg Production                                                                           |
#	| IL    | Sheep Farming                                                                                    |
#	| IL    | Goat Farming                                                                                     |
#	| IL    | Bean Farming                                                                                     |
#	| IL    | Lemon Orchards                                                                                   |
#	| IL    | Lemon Groves                                                                                     |
#	| IL    | Grain Farming                                                                                    |
#	| IL    | Cattle Ranching                                                                                  |
#	| IL    | Livestock Raising                                                                                |
#	| IL    | Crop Farms                                                                                       |
#	| IL    | Equestrian Facility                                                                              |
#	| IL    | Horse Trainer                                                                                    |
#	| IL    | Equestrian Training                                                                              |
#	| IL    | Molding                                                                                          |
#	| IL    | Pet Sitter                                                                                       |
#	| IL    | Dog Walker                                                                                       |
#	| IL    | Printing Supply Store                                                                            |
#	| IL    | IT Installation: Exterior Cable or Line                                                          |
#	| IL    | Mobile Phone Store                                                                               |
#	| IL    | Cell Phone Store                                                                                 |
#	| IL    | Cellphone Store                                                                                  |
#	| IL    | Paintless Dent Repair                                                                            |
#	| IL    | Garage Door Installer                                                                            |
#	| IL    | Chimney Cleaning                                                                                 |
#	| IL    | Chimney Mason                                                                                    |
#	| IL    | Pressure Washing                                                                                 |
#	| IL    | Property Maintenance: Buildings                                                                  |
#	| IL    | Property Restoration                                                                             |
#	| IL    | Sign Installation                                                                                |
#	| IL    | Tree Services: No Removal or Excavation                                                          |
#	| IL    | Tree Removal: not logging                                                                        |
#	| IL    | Door Installation or Window Installation: No Overhead                                            |
#	| IL    | Dance Instructor                                                                                 |
#	| IL    | Mental Health Counselor                                                                          |
#	| IL    | Dance Studio                                                                                     |
#	| IL    | Senior Home Care: No Registered Nurses                                                           |
#	| IL    | Private Duty Home Care: No Registered Nurses                                                     |
#	| IL    | Adult Living Facility: With Medical Care                                                         |
#	| IL    | Stall Cleaning: Horses                                                                           |
#	| IL    | Property Maintenance: Apartment or Condo                                                         |
#	| IL    | Property Maintenance: Mobile Home                                                                |
#	| IL    | Comic books Store: New Only                                                                      |
#	| IL    | Comic book dealer                                                                                |
#	| IL    | Home Fashions Store                                                                              |
#	| IL    | Telecommunications Repair                                                                        |
#	| IL    | Wallboard Contractor                                                                             |
#	| IL    | Drywall Contractor                                                                               |
#	| IL    | Home Cleaning: Franchise                                                                         |
#	| IL    | Tree Removal or Logging                                                                          |
#	| IL    | Vape Shop                                                                                        |
#	| IL    | Vaporizer Shop                                                                                   |
#	| IL    | Vape Store                                                                                       |
#	| IL    | Smoke Shop                                                                                       |
#	| IL    | Garbage Hauler                                                                                   |
#	| IL    | Junk Removal Services                                                                            |
#	| IL    | Recycling Services: No Scrap Metal                                                               |
#	| IL    | Debris Removal Services                                                                          |
#	| IL    | Copier Services                                                                                  |
#	| IL    | Copy Services                                                                                    |
#	| IL    | Printing Services Store: Retail                                                                  |
#	| IL    | Web Development                                                                                  |
#	| IL    | Boutique Shop                                                                                    |
#	| IL    | Boutique Store                                                                                   |
#	| IL    | Actor                                                                                            |
#	| IL    | Acupuncture Therapist                                                                            |
#	| IL    | Solar Panel Installation                                                                         |
#	| IL    | Copier Repair Services                                                                           |
#	| IL    | Residential Carpentry: Framing Only                                                              |
#	| IL    | Lawyer                                                                                           |
#	| IL    | Law Firm                                                                                         |
#	| IL    | Hamburger Patty Manufacturing                                                                    |
#	| IL    | Manufacturing: Sausage Casings                                                                   |
#	| IL    | Manufacturing: Beef Jerky                                                                        |
#	| IL    | Meat Dehydration Processing                                                                      |
#	| IL    | Fish Curing                                                                                      |
#	| IL    | Asphalt Paving                                                                                   |
#	| IL    | Street Paving                                                                                    |
#	| IL    | Road Paving or Repaving                                                                          |
#	| IL    | Asphalt Installation                                                                             |
#	| IL    | Real Estate Appraisers                                                                           |
#	| IL    | Caretaker: Property Maintenance                                                                  |
#	| IL    | Caretaker: In-Home Personal Assistant                                                            |
#	| IL    | Information Technology Consulting                                                                |
#	| IL    | Carpet Cleaning                                                                                  |
#	| IL    | Tree Trimming: No Removal or Excavation                                                          |
#	| IL    | Beautician                                                                                       |
#	| IL    | Auto Transport: Under 300 miles                                                                  |
#	| IL    | Auto Transport: Over 300 miles                                                                   |
#	| IL    | Cottage Rentals                                                                                  |
#	| IL    | Chalet Rentals                                                                                   |
#	| IL    | Bulk Hauling: under 300 miles                                                                    |
#	| IL    | Bulk Hauling: over 300 miles                                                                     |
#	| IL    | Animal Parts Rendering                                                                           |
#	| IL    | Brewery                                                                                          |
#	| IL    | Microbrewery                                                                                     |
#	| IL    | Beer Factory                                                                                     |
#	| IL    | Accounting Services                                                                              |
#	| IL    | Actuarial Consulting                                                                             |
#	| IL    | Actuarial Services                                                                               |
#	| IL    | Acupressure Services                                                                             |
#	| IL    | Phone Answering Services                                                                         |
#	| IL    | Application Service Provider                                                                     |
#	| IL    | Auctioneering                                                                                    |
#	| IL    | Audiologist                                                                                      |
#	| IL    | Cosmetology Services                                                                             |
#	| IL    | Brand Consulting                                                                                 |
#	| IL    | Business Manager Services                                                                        |
#	| IL    | Civil Engineering Consulting: No General Contracting                                             |
#	| IL    | Claims Adjusting: no travelling                                                                  |
#	| IL    | Claims Adjusting: travelling                                                                     |
#	| IL    | Air Conditioner Manufacturing                                                                    |
#	| IL    | Refrigeration Equipment Manufacturing                                                            |
#	| IL    | Alarm Manufacturing: Burglar, Fire, or Smoke                                                     |
#	| IL    | Communication Equipment Manufacturing                                                            |
#	| IL    | Recording Equipment Manufacturing                                                                |
#	| IL    | Manufacturing: Electrical Connector                                                              |
#	| IL    | Electronic Capacitor Manufacturing                                                               |
#	| IL    | Electronic Resistor Manufacturing                                                                |
#	| IL    | Refrigerator Manufacturing                                                                       |
#	| IL    | Solar Panel Manufacturing                                                                        |
#	| IL    | Semiconductor Manufacturing                                                                      |
#	| IL    | Vacuum Manufacturing                                                                             |
#	| IL    | Manufacturing: Electrical Equipment                                                              |
#	| IL    | Home Health Therapist                                                                            |
#	| IL    | Manufacturing: Hamburger                                                                         |
#	| IL    | Precision Machined Parts Manufacturing: With Plastic                                             |
#	| IL    | Fence Repair                                                                                     |
#	| IL    | Fence Contractor                                                                                 |
#	| IL    | Fence Installation                                                                               |
#	| IL    | Videographer: No Drones                                                                          |
#	| IL    | Staffing Agency                                                                                  |
#	| IL    | Stage Lighting Setup                                                                             |
#	| IL    | Motion Picture Studio                                                                            |
#	| IL    | Motion Picture Production                                                                        |
#	| IL    | Film Studio                                                                                      |
#	| IL    | Television Broadcasting                                                                          |
#	| IL    | TV Broadcasting                                                                                  |
#	| IL    | Radio Broadcasting                                                                               |
#	| IL    | Television Production                                                                            |
#	| IL    | Dance Ensemble                                                                                   |
#	| IL    | Fitness Center                                                                                   |
#	| IL    | Boxing Gym                                                                                       |
#	| IL    | Exercise Club                                                                                    |
#	| IL    | Recreation Center: indoors                                                                       |
#	| IL    | Athletic Club                                                                                    |
#	| IL    | Exercise Facility                                                                                |
#	| IL    | Fitness Club                                                                                     |
#	| IL    | Yoga Studio                                                                                      |
#	| IL    | CrossFit Instructor                                                                              |
#	| IL    | Ballet Instructor                                                                                |
#	| IL    | Spin Class Instructor                                                                            |
#	| IL    | Pilates Instructor                                                                               |
#	| IL    | Gymnastics Training                                                                              |
#	| IL    | Climbing Gym                                                                                     |
#	| IL    | Indoor Rock Climbing Gym                                                                         |
#	| IL    | Karate Training Center                                                                           |
#	| IL    | Martial Arts Training                                                                            |
#	| IL    | Taekwondo Training                                                                               |
#	| IL    | Jiu Jitsu Training                                                                               |
#	| IL    | UFC Gym                                                                                          |
#	| IL    | Mixed Martial Arts Training                                                                      |
#	| IL    | Zumba Dance Studio                                                                               |
#	| IL    | Tap Dance Studio                                                                                 |
#	| IL    | Swimming Pool Facility                                                                           |
#	| IL    | Dance School                                                                                     |
#	| IL    | FroYo Shop                                                                                       |
#	| IL    | Frozen Yogurt Store                                                                              |
#	| IL    | Building Inspection                                                                              |
#	| IL    | Clothing Apparel Store                                                                           |
#	| IL    | Computer Consulting: No Client Hardware Installation                                             |
#	| IL    | Web Developer                                                                                    |
#	| IL    | Computer Network Developer                                                                       |
#	| IL    | Control Systems Integration Consulting: No Part Sales                                            |
#	| IL    | Control Systems Integration Consulting: With Part Sales                                          |
#	| IL    | Court Reporting Services                                                                         |
#	| IL    | Credit Counseling                                                                                |
#	| IL    | Dance Therapist                                                                                  |
#	| IL    | Data Processing Services: Data Entry                                                             |
#	| IL    | Automated Data Processing Services                                                               |
#	| IL    | Database Designer                                                                                |
#	| IL    | Dietition                                                                                        |
#	| IL    | Nutritionist                                                                                     |
#	| IL    | Digital Marketing                                                                                |
#	| IL    | Direct Marketing Services                                                                        |
#	| IL    | Document Preparation Services                                                                    |
#	| IL    | Draftsman Services: No Contracting Work                                                          |
#	| IL    | Educational Consulting                                                                           |
#	| IL    | Electrical Engineering                                                                           |
#	| IL    | Manufacturing: Electrical Engineering                                                            |
#	| IL    | Environmental Engineering                                                                        |
#	| IL    | Esthetician                                                                                      |
#	| IL    | Executive Placement Agency: No staffing services                                                 |
#	| IL    | Furniture or Mattress Delivery                                                                   |
#	| IL    | Delivery: Goods; Retail to Homes; No Furniture or Mattress                                       |
#	| IL    | Expert Witness Services                                                                          |
#	| IL    | Exterior Cleaning Services                                                                       |
#	| IL    | Financial Auditing Services                                                                      |
#	| IL    | Graphic Designers: No Sign Installation                                                          |
#	| IL    | Hair Stylist                                                                                     |
#	| IL    | Home Furnishings Store                                                                           |
#	| IL    | Human Resources Consulting                                                                       |
#	| IL    | Hypnotist                                                                                        |
#	| IL    | Hypnotherapist                                                                                   |
#	| IL    | Industrial Engineering Consulting: No Parts Sales                                                |
#	| IL    | Industrial Engineering Consulting: With Parts Sales                                              |
#	| IL    | Insurance Inspector                                                                              |
#	| IL    | Investment Advisor                                                                               |
#	| IL    | IT Consulting                                                                                    |
#	| IL    | IT Project Management                                                                            |
#	| IL    | Event Planner: No Catering                                                                       |
#	| IL    | Event Planner: Catering                                                                          |
#	| IL    | IT Software Training Services                                                                    |
#	| IL    | Lawn Care Services: No Tree Removal or Excavation                                                |
#	| IL    | Legal Support Services                                                                           |
#	| IL    | Life Coach: No Behavioral Health                                                                 |
#	| IL    | Market Research Firm                                                                             |
#	| IL    | Marketing Consulting                                                                             |
#	| IL    | Media Consulting                                                                                 |
#	| IL    | Marriage Therapist                                                                               |
#	| IL    | Family Therapist                                                                                 |
#	| IL    | Masseuse                                                                                         |
#	| IL    | Massage Therapist                                                                                |
#	| IL    | Medical Billing Services                                                                         |
#	| IL    | Mortgage Brokerage                                                                               |
#	| IL    | Nail Technician                                                                                  |
#	| IL    | Notary Services                                                                                  |
#	| IL    | Personal Care Assistants                                                                         |
#	| IL    | Personal Trainer: Health and Fitness                                                             |
#	| IL    | Plumbers: Contracting                                                                            |
#	| IL    | Process Engineering Consulting: No Parts Sales                                                   |
#	| IL    | Process Engineering Consulting: With Parts Sales                                                 |
#	| IL    | Project Management Consulting for Construction Industry                                          |
#	| IL    | Construction Project Management no contracting employees                                         |
#	| IL    | Audio Visual Technician: No Stage Lighting                                                       |
#	| IL    | Tuck-pointer                                                                                     |
#	| IL    | Tuck-Pointing Contractor                                                                         |
#	| IL    | Semi-pro Soccer Team                                                                             |
#	| IL    | Semi-pro Basketball Team                                                                         |
#	| IL    | Professional Soccer Team                                                                         |
#	| IL    | Professional Basketball Team                                                                     |
#	| IL    | Professional Dodge Ball Team                                                                     |
#	| IL    | Semi-pro Lacrosse Team                                                                           |
#	| IL    | Professional Lacrosse Team                                                                       |
#	| IL    | Semi-pro Football Team                                                                           |
#	| IL    | Professional Football Team                                                                       |
#	| IL    | Football Camp                                                                                    |
#	| IL    | Lacrosse Camp                                                                                    |
#	| IL    | Semi-pro Baseball Team                                                                           |
#	| IL    | Professional Baseball Team                                                                       |
#	| IL    | Professional Hockey Team                                                                         |
#	| IL    | Semi-pro Hockey Team                                                                             |
#	| IL    | Tool and Die Shop                                                                                |
#	| IL    | Toolmaker                                                                                        |
#	| IL    | Manufacturing: Tools                                                                             |
#	| IL    | Manufacturing: Angle Rings                                                                       |
#	| IL    | Manufacturing: Arbors                                                                            |
#	| IL    | Manufacturing: Knives                                                                            |
#	| IL    | Manufacturing: Drill Bits                                                                        |
#	| IL    | Manufacturing: Broaches                                                                          |
#	| IL    | Manufacturing: Cams                                                                              |
#	| IL    | Manufacturing: Chasers                                                                           |
#	| IL    | Manufacturing: Chucks                                                                            |
#	| IL    | Manufacturing: Clamps                                                                            |
#	| IL    | Manufacturing: Collars                                                                           |
#	| IL    | Manufacturing: Collets                                                                           |
#	| IL    | Manufacturing: Counterbore                                                                       |
#	| IL    | Countersink Manufacturing (tool accessory)                                                       |
#	| IL    | Files Manufacturing (tool accessory)                                                             |
#	| IL    | Hobs Manufacturing (metal gear cutting tool)                                                     |
#	| IL    | Manufacturing: Honing Heads                                                                      |
#	| IL    | Manufacturing: Hopper Feed Devices                                                               |
#	| IL    | Manufacturing: Dies and Taps                                                                     |
#	| IL    | Manufacturing: Taps and Dies                                                                     |
#	| IL    | Pushers manufacturing (tool accessory)                                                           |
#	| IL    | Reamers manufacturing (tool accessory)                                                           |
#	| IL    | Sine bars manufacturing (tool accessory)                                                         |
#	| IL    | Thread cutting dies manufacturing (tool accessory)                                               |
#	| IL    | Diemaker                                                                                         |
#	| IL    | Moldmaker                                                                                        |
#	| IL    | Manufacturing: Tools or Tool Attachment                                                          |
#	| IL    | Process Delivery: Legal Documents                                                                |
#	| IL    | Delivery of Process                                                                              |
#	| IL    | Real Estate Agent                                                                                |
#	| IL    | Real Estate Broker                                                                               |
#	| IL    | Marketing Research Consulting                                                                    |
#	| IL    | Resume Consulting                                                                                |
#	| IL    | Search Engine Services: SEO or SEM                                                               |
#	| IL    | Social Media Consulting                                                                          |
#	| IL    | Speech Therapist: Non-Traveling                                                                  |
#	| IL    | Stock Brokering                                                                                  |
#	| IL    | Substance Abuse Counseling: No Housing or Healthcare                                             |
#	| IL    | Talent Agency                                                                                    |
#	| IL    | Translating Services                                                                             |
#	| IL    | Translation Services                                                                             |
#	| IL    | Interpreter Services                                                                             |
#	| IL    | Travel Agency                                                                                    |
#	| IL    | Transportation Engineering: Project Management                                                   |
#	| IL    | Transportation Engineering: Consulting                                                           |
#	| IL    | Website Design Services                                                                          |
#	| IL    | Copy Machine Repair                                                                              |
#	| IL    | Office Equipment Repair                                                                          |
#	| IL    | Interior Carpentry Contractor: No Framing                                                        |
#	| IL    | Smoke Alarm Installers: No Sprinklers                                                            |
#	| IL    | Burglar Alarm Installers                                                                         |
#	| IL    | Fire Alarm Installers: No Sprinkler Installation                                                 |
#	| IL    | Art Dealer                                                                                       |
#	| IL    | Mattress Store: Retail                                                                           |
#	| IL    | Blinds Store                                                                                     |
#	| IL    | Window Treatment Store                                                                           |
#	| IL    | Bricklayer                                                                                       |
#	| IL    | Secretarial Services                                                                             |
#	| IL    | Receptionist Services                                                                            |
#	| IL    | Disc Jockey                                                                                      |
#	| IL    | DIY Shop                                                                                         |
#	| IL    | Ductwork: Installation or Repair                                                                 |
#	| IL    | Fitness Instructor                                                                               |
#	| IL    | Furniture Assembly                                                                               |
#	| IL    | Massage Parlor                                                                                   |
#	| IL    | Day Spas: With Body Massages                                                                     |
#	| IL    | First Aid Training                                                                               |
#	| IL    | CPR Training                                                                                     |
#	| IL    | Flooring Contractor: With Carpet Installation                                                    |
#	| IL    | Flower Arrangements                                                                              |
#	| IL    | Furniture Removal Services                                                                       |
#	| IL    | General Store                                                                                    |
#	| IL    | Teahouse                                                                                         |
#	| IL    | Tea Room                                                                                         |
#	| IL    | Hat Store                                                                                        |
#	| IL    | Motel: No Restaurant                                                                             |
#	| IL    | Juice Bar                                                                                        |
#	| IL    | Kitchen or Bathroom Showrooms                                                                    |
#	| IL    | Handbag, Purses Store: Retail                                                                    |
#	| IL    | Elevator Repair or Installation                                                                  |
#	| IL    | Musician: Band                                                                                   |
#	| IL    | Ceramic Tile Installation: No Stone or Marble                                                    |
#	| IL    | Dog Day Care                                                                                     |
#	| IL    | Vending Machine Services                                                                         |
#	| IL    | Arcade Games Services: With Installation or Repair                                               |
#	| IL    | Pinball Machines Operator                                                                        |
#	| IL    | Vending Machine Operator                                                                         |
#	| IL    | Coffee Service Company                                                                           |
#	| IL    | Coin-Operated Amusement Machine Services                                                         |
#	| IL    | Network and Systems Administration Services                                                      |
#	| IL    | Newsstand                                                                                        |
#	| IL    | Journalist                                                                                       |
#	| IL    | Nightclub                                                                                        |
#	| IL    | Saloon Bar                                                                                       |
#	| IL    | Novelty Shop: Retail                                                                             |
#	| IL    | Cocktail Lounge                                                                                  |
#	| IL    | Tavern                                                                                           |
#	| IL    | Discotheque                                                                                      |
#	| IL    | Cabaret                                                                                          |
#	| IL    | Gentlemen's Club                                                                                 |
#	| IL    | Strip Club                                                                                       |
#	| IL    | NVQ Assessor                                                                                     |
#	| IL    | Optician                                                                                         |
#	| IL    | Plastering Contractor: Interior and/or Exterior                                                  |
#	| IL    | Sign Erection                                                                                    |
#	| IL    | Sweet Shop                                                                                       |
#	| IL    | Swimming Pool Cleaning: No Installation                                                          |
#	| IL    | Hookah Lounge                                                                                    |
#	| IL    | Concert Lighting                                                                                 |
#	| IL    | TV Installation                                                                                  |
#	| IL    | TV or Radio Repair                                                                               |
#	| IL    | Internet Service Provider                                                                        |
#	| IL    | Furniture Repair or Restoration Services                                                         |
#	| IL    | Vehicle Sales: With Repair                                                                       |
#	| IL    | Vintage Clothes Shop                                                                             |
#	| IL    | Adult Video Store                                                                                |
#	| IL    | Waste Disposal Services                                                                          |
#	| IL    | Tax and Accounting Services                                                                      |
#	| IL    | Greeting Card Publisher                                                                          |
#	| IL    | Books Printing                                                                                   |
#	| IL    | Digital Printing                                                                                 |
#	| IL    | Electronic Prepress                                                                              |
#	| IL    | Electrotyping                                                                                    |
#	| IL    | Lithographing                                                                                    |
#	| IL    | Playing Card Manufacturing                                                                       |
#	| IL    | Flexographic Printing                                                                            |
#	| IL    | Greeting Card Printing                                                                           |
#	| IL    | Letterpress Printing                                                                             |
#	| IL    | Silk Screen Printing                                                                             |
#	| IL    | Magazine Printing                                                                                |
#	| IL    | Delivery of Goods: Manufacturer to Wholesaler or Wholesaler to Retailer: Under 300 miles         |
#	| IL    | Delivery of Goods: Manufacturer to Wholesaler or Wholesaler to Retailer: Over 300 miles          |
#	| IL    | Orchard Work, Fumigating, or Pruning                                                             |
#	| IL    | Artificial Turf Installation                                                                     |
#	| IL    | Grass Cutting Services                                                                           |
#	| IL    | Weed and Brush Spraying                                                                          |
#	| IL    | Lumbering                                                                                        |
#	| IL    | Commercial Carpentry: No Residential Work                                                        |
#	| IL    | Commercial Carpentry: Some Residential Work                                                      |
#	| IL    | Painting and Drywall: 3 stories or less                                                          |
#	| IL    | Social Services Organization                                                                     |
#	| IL    | Adult Developmental Disabled Training                                                            |
#	| IL    | Bread Manufacturing                                                                              |
#	| IL    | Cracker Manufacturing                                                                            |
#	| IL    | Bakery: Wholesale                                                                                |
#	| IL    | Pretzel Manufacturing                                                                            |
#	| IL    | Pretzel Store: Retail                                                                            |
#	| IL    | Macaroni, Spaghetti, or Noodles Manufacturing                                                    |
#	| IL    | Manufacturing: Cured Meats - Brined, Dried and Salted                                            |
#	| IL    | Manufacturing: Bacon                                                                             |
#	| IL    | Manufacturing: Malt Liquor                                                                       |
#	| IL    | Airport Runway: Paving or Repaving                                                               |
#	| IL    | Asphalt Laying: Street or Roads                                                                  |
#	| IL    | Line Painting: Highways, Roads or Parking Lots                                                   |
#	| IL    | Parking Lot Line Painting Only                                                                   |
#	| IL    | Safety Grooving of Road Surfaces                                                                 |
#	| IL    | Asphalt Road Spraying                                                                            |
#	| IL    | Sewer Installation                                                                               |
#	| IL    | Storm Drain Installation                                                                         |
#	| IL    | Asphalt Laying: Driveway, Floor, Yard or Sidewalk Only                                           |
#	| IL    | Concrete Floor Construction: No Self-Bearing Work                                                |
#	| IL    | Landfill Operation                                                                               |
#	| IL    | Blasting Contractor                                                                              |
#	| IL    | Street or Road Rock Excavation                                                                   |
#	| IL    | Peat Digging                                                                                     |
#	| IL    | Basement Excavation                                                                              |
#	| IL    | Sheetrock Installation or Repairs                                                                |
#	| IL    | Gypsum Board Installation                                                                        |
#	| IL    | Taping and Seaming of Wallboard                                                                  |
#	| IL    | Office Furniture and Workstation Setup                                                           |
#	| IL    | Display Rack Installation                                                                        |
#	| IL    | Weatherization Program                                                                           |
#	| IL    | Weather Stripping Installation                                                                   |
#	| IL    | Rock Wool Installation                                                                           |
#	| IL    | Acoustical Insulation Material Installation: No Ceilings                                         |
#	| IL    | Sound Insulation Installation: No Ceilings                                                       |
#	| IL    | Hardwood Floor Installation: Not prefinished                                                     |
#	| IL    | Floor Sanding or Scraping                                                                        |
#	| IL    | Acoustical Ceiling Installation: Suspended Grid Type                                             |
#	| IL    | Sound Ceiling Insulation Installation                                                            |
#	| IL    | Aluminium Siding Installation                                                                    |
#	| IL    | Land Surveyor                                                                                    |
#	| IL    | Topographer                                                                                      |
#	| IL    | Mapmaker                                                                                         |
#	| IL    | Roofing Sheet Metal Work                                                                         |
#	| IL    | Ironworker                                                                                       |
#	| IL    | Fire Door Installation: No Overhead                                                              |
#	| IL    | Overhead Door Installation                                                                       |
#	| IL    | Storm Window or Storm Door Installation                                                          |
#	| IL    | Mobile Home Setup                                                                                |
#	| IL    | Boiler Brick Work: With Installation or Repair                                                   |
#	| IL    | Cement Block Erection                                                                            |
#	| IL    | Hardscaping Installation                                                                         |
#	| IL    | Pavers Installation: Decorative Brick or Stone                                                   |
#	| IL    | Cement Finishing                                                                                 |
#	| IL    | Concrete Parking Garage Construction                                                             |
#	| IL    | Concrete Reinforcing Rod Setting                                                                 |
#	| IL    | Grouting: With Drilling: Placing Of Cement, Plastic Compounds Or Concrete, Or Pumping Of Fly Ash |
#	| IL    | Guniting                                                                                         |
#	| IL    | Shotcrete Installation                                                                           |
#	| IL    | Panel Or Wall Installation: Precast Concrete                                                     |
#	| IL    | Retaining Wall Contractor: Concrete                                                              |
#	| IL    | Pump Installation: Water                                                                         |
#	| IL    | Sump Pump Installation                                                                           |
#	| IL    | Quick-lube shop                                                                                  |
#	| IL    | Quick-lube Shop: With Gas Station                                                                |
#	| IL    | Auto Oil Change and Lubrication Shops: No Gas Station                                            |
#	| IL    | Auto Oil Change and Lubrication Shops: With Gas Station                                          |
#	| IL    | Delivery: Courier Service                                                                        |
#	| IL    | Poultry Farm                                                                                     |
#	| IL    | Poultry Hatcheries                                                                               |
#	| IL    | Chicken Farm                                                                                     |
#	| IL    | Turkey Farm                                                                                      |
#	| IL    | Egg Producer Farm                                                                                |
#	| IL    | Document Scanning Services                                                                       |
#	| IL    | Medical Records Scanning Services                                                                |
#	| IL    | Assaying Services                                                                                |
#	| IL    | Food Laboratory                                                                                  |
#	| IL    | Biomedical Research Laboratory                                                                   |
#	| IL    | Radiological Laboratory Services: Medical                                                        |
#	| IL    | Laboratory Testing Services: Veterinary                                                          |
#	| IL    | Soil Testing Laboratory                                                                          |
#	| IL    | Toxicology Laboratory                                                                            |
#	| IL    | Building Materials Testing Laboratory                                                            |
#	| IL    | Petroleum Testing Laboratory                                                                     |
#	| IL    | Animal Testing Laboratory                                                                        |
#	| IL    | Clinical Laboratory Services                                                                     |
#	| IL    | Bridge Building: Metal                                                                           |
#	| IL    | Cell Tower Erection                                                                              |
#	| IL    | Smokestacks or Industrial Chimney Cleaning                                                       |
#	| IL    | Iron Erection or Steel Erection: 3 or more stories                                               |
#	| IL    | Steel Frame Structure Erection                                                                   |
#	| IL    | Tank Erection: Steel                                                                             |
#	| IL    | Windmill Erection: Metal                                                                         |
#	| IL    | Painting: Bridges, Steel Structures, or Tanks                                                    |
#	| IL    | Banister, Railing, Or Guard Erection: Metal                                                      |
#	| IL    | Ornamental Iron Grill or Railing Erection                                                        |
#	| IL    | CCTV Installation or Repair                                                                      |
#	| IL    | Closed Circuit Television Systems: Installation or Repair                                        |
#	| IL    | Smoke Alarm Installers: With Sprinkler Installation                                              |
#	| IL    | Fire Alarm Installers: With Sprinkler Installation                                               |
#	| IL    | Burglar and Fire Alarm: With Sprinkler Installation                                              |
#	| IL    | Paratransit Services: Disabled persons transportation                                            |
#	| IL    | App Development                                                                                  |
#	| IL    | Technical Manuals Writing                                                                        |
#	| IL    | Air Conditioning Window-Type Units: Service Or Repair                                            |
#	| IL    | Appliances: Household or Commercial; Service or Repair                                           |
#	| IL    | Dryers, Household Or Commercial: Service Or Repair                                               |
#	| IL    | Washing Machines: Service or Repair                                                              |
#	| IL    | Stoves: Household or Commercial; Service or Repair                                               |
#	| IL    | Refrigerator: Household; Service or Repair                                                       |
#	| IL    | Grocery Store: Wholesale                                                                         |
#	| IL    | Butter Wholesaler                                                                                |
#	| IL    | Cheese Wholesaler                                                                                |
#	| IL    | Chinese Food: Packaged or Frozen; Wholesaler                                                     |
#	| IL    | Cider Wholesaler                                                                                 |
#	| IL    | Coffee Wholesaler: No Grinding Or Roasting                                                       |
#	| IL    | Dairy Products Wholesaler                                                                        |
#	| IL    | Flour Wholesaler                                                                                 |
#	| IL    | Frozen Food Wholesaler                                                                           |
#	| IL    | Organic Food Wholesaler                                                                          |
#	| IL    | Spice Wholesaler                                                                                 |
#	| IL    | Tea Wholesaler: No Blending or Mixing                                                            |
#	| IL    | Produce Wholesaler                                                                               |
#	| IL    | Fruit or Vegetable Wholesaler                                                                    |
#	| IL    | Household Appliance Wholesaler                                                                   |
#	| IL    | Vacuum Wholesalers                                                                               |
#	| IL    | Air Conditioner Wholesalers                                                                      |
#	| IL    | Refrigerator Wholesaler                                                                          |
#	| IL    | Fish Wholesaler                                                                                  |
#	| IL    | Poultry Wholesaler                                                                               |
#	| IL    | Fresh Meat Wholesaler                                                                            |
#	| IL    | Office Equipment Wholesaler                                                                      |
#	| IL    | Office Machine Wholesaler                                                                        |
#	| IL    | Office Supplies Wholesaler                                                                       |
#	| IL    | Furniture Store: Wholesaler                                                                      |
#	| IL    | Tobacco Products Wholesaler                                                                      |
#	| IL    | Medical Equipment Wholesaler                                                                     |
#	| IL    | Dental Equipment Wholesaler                                                                      |
#	| IL    | Hospital Equipment Wholesaler                                                                    |
#	| IL    | New Commercial Building Construction: General Contractor                                         |
#	| IL    | Stained Glass Restoration                                                                        |
#	| IL    | Calcimining: 3 stories or less                                                                   |
#	| IL    | Whitewashing                                                                                     |
#	| IL    | Outdoor Shingle Staining                                                                         |
#	| IL    | Granite Countertop Installation                                                                  |
#	| IL    | Curtain Or Drapery Installation                                                                  |
#	| IL    | Venetian Blind Installation                                                                      |
#	| IL    | Window Shade Installation                                                                        |
#	| IL    | Window Treatment Installation                                                                    |
#	| IL    | Livestock Auctioneer                                                                             |
#	| IL    | Breeding Farm: Horse                                                                             |
#	| IL    | Cattle Dealer                                                                                    |
#	| IL    | Floriculture: With Trees                                                                         |
#	| IL    | Private Bus Operation                                                                            |
#	| IL    | School Bus Operation                                                                             |
#	| IL    | Milk Hauling: over 300 miles                                                                     |
#	| IL    | Milk Hauling: under 300 miles                                                                    |
#	| IL    | Furniture Moving and Storage                                                                     |
#	| IL    | Furniture Warehouse                                                                              |
#	| IL    | Automobile Driveaway Service                                                                     |
#	| IL    | Brine Hauling: Over 300 Miles                                                                    |
#	| IL    | Brine Hauling: Under 300 Miles                                                                   |
#	| IL    | Rental, Sales, or Service of Construction Equipment                                              |
#	| IL    | Forklift Truck Dealer                                                                            |
#	| IL    | Machinery and Equipment Rental                                                                   |
#	| IL    | Contractor Equipment: Rental, Sales, or Service                                                  |
#	| IL    | Auto Glass Repair and Replacement Services                                                       |
#	| IL    | Household Goods Manufacturing: Plastic                                                           |
#	| IL    | Plastics Manufacturing: Injection Molding                                                        |
#	| IL    | Plastics Plumbing Fixture Manufacturing                                                          |
#	| IL    | Doll Manufacturing                                                                               |
#	| IL    | Drums or Containers Manufacturing: Plastic                                                       |
#	| IL    | Fabricated Products Manufacturing: Plastic                                                       |
#	| IL    | Button Manufacturing                                                                             |
#	| IL    | Bone or Ivory Goods Manufacturing                                                                |
#	| IL    | Plastics Manufacturing: Fabrication or Machining                                                 |
#	| IL    | Precision Machined Parts Manufacturing: Plastics Only                                            |
#	| IL    | Precision Machined Parts Manufacturing: No Plastic                                               |
#	| IL    | Water Damage Restoration                                                                         |
#	| IL    | Mold Damage Restoration                                                                          |
#	| IL    | Fire or Smoke Damage Restoration                                                                 |
#	| IL    | Mold Remediation Services                                                                        |
#	| IL    | Restoration Services: Fire, Water, Smoke, or Mold                                                |
#	| IL    | Asbestos Removal Services                                                                        |
#	| IL    | Antique Store: More Than Half of Sales is Furniture                                              |
#	| IL    | Antique Store: Less Than Half of Sales is Furniture                                              |
#	| IL    | Remediation Services: Fire, Water, Smoke, or Mold                                                |
#	| IL    | Valet Services                                                                                   |
#	| IL    | Auto Storage Garage: No Maintenance                                                              |
#	| IL    | Parking Garage Services                                                                          |
#	| IL    | Parking Lot Station                                                                              |
#	| IL    | Truck Storage Garage: No Maintenance                                                             |
#	| IL    | Truck Storage Garage: With Maintenance                                                           |
#	| IL    | Auto Storage Garage: With Maintenance                                                            |
#	| IL    | Fender Repairing, Automobile                                                                     |
#	| IL    | Charter Bus Service                                                                              |
#	| IL    | Airport Shuttle Service                                                                          |
#	| IL    | Scheduled Lines Bus Operation                                                                    |
#	| IL    | Shuttle Service                                                                                  |
#	| IL    | New Car Dealership                                                                               |
#	| IL    | Auto Dealership: Used                                                                            |
#	| IL    | Auto Dealership: New                                                                             |
#	| IL    | Recreational Vehicle Dealership                                                                  |
#	| IL    | Truck Dealership                                                                                 |
#	| IL    | Motorcycle Dealership                                                                            |
#	| IL    | Transportation Services for the Elderly                                                          |
#	| IL    | Trailer Sales                                                                                    |
#	| IL    | Flammability Testing Laboratory                                                                  |
#	| IL    | Asphalt Mixing Plant                                                                             |
#	| IL    | Commercial Lumber Yard                                                                           |
#	| IL    | Concrete Dealer, Ready-Mixed                                                                     |
#	| IL    | Landscaping Supplies Dealer                                                                      |
#	| IL    | Peat Moss Dealer                                                                                 |
#	| IL    | Fence Dealer: No Installation or Repair                                                          |
#	| IL    | Sawdust Dealer                                                                                   |
#	| IL    | Soapstone Products Manufacturing                                                                 |
#	| IL    | Mortar Manufacturing                                                                             |
#	| IL    | Dry Ice Dealer                                                                                   |
#	| IL    | Insulation Dealer: No Installation                                                               |
#	| IL    | Concrete Mixing Plant                                                                            |
#	| IL    | Secondhand Building Materials Dealer                                                             |
#	| IL    | Iron or Steel Scrap Dealer                                                                       |
#	| IL    | Beverage Can Recycling                                                                           |
#	| IL    | Used Bottle Dealer                                                                               |
#	| IL    | Scrap Plastics Dealer                                                                            |
#	| IL    | Broken Glass Dealer                                                                              |
#	| IL    | Paper Shredding Service                                                                          |
#	| IL    | Container Recycling: Beverage; Bottle, or Can                                                    |
#	| IL    | Cullet Dealer: Broken Or Refuse Glass                                                            |
#	| IL    | Chickens: Slaughtering, Dressing, and Packing                                                    |
#	| IL    | Turkeys: Slaughtering, Dressing, and Packing                                                     |
#	| IL    | Poultry: Slaughtering, Dressing, and Packing                                                     |
#	| IL    | House Rental Operation                                                                           |
#	| IL    | Cooperative Building Operation                                                                   |
#	| IL    | Condominium Complex Operation                                                                    |
#	| IL    | Maid Services: Non-Franchise                                                                     |
#	| IL    | Aerobics Studio                                                                                  |
#	| IL    | Tai Chi Instruction                                                                              |
#	| IL    | Wholesaler: Plumbers Supplies                                                                    |
#	| IL    | Heating, Ventilating or Air Conditioning Wholesaler                                              |
#	| IL    | Tube or Pipe Merchant                                                                            |
#	| IL    | Surfing Instructor                                                                               |
#	| IL    | Scuba Diving Instructor                                                                          |
#	| IL    | Surf Instructor                                                                                  |
#	| IL    | Wholesaler: Electrical Supplies                                                                  |
#	| IL    | Electronic Components Wholesaler                                                                 |
#	| IL    | Lighting Fixtures and Supplies Wholesaler                                                        |
#	| IL    | Early Head Start Program                                                                         |
#	| IL    | Pre-School                                                                                       |
#	| IL    | High School                                                                                      |
#	| IL    | Middle School                                                                                    |
#	| IL    | Kindergarten                                                                                     |
#	| IL    | Elementary School                                                                                |
#	| IL    | Private Tutor                                                                                    |
#	| IL    | Fraternal Organization                                                                           |
#	| IL    | VFW Post                                                                                         |
#	| IL    | Country Club                                                                                     |
#	| IL    | Fishing Club                                                                                     |
#	| IL    | Quick Service Restaurant                                                                         |
#	| IL    | Meals on Wheels                                                                                  |
#	| IL    | Dance Club                                                                                       |
#	| IL    | Gastropub                                                                                        |
#	| IL    | Music Venue                                                                                      |
#	| IL    | Sports Bar                                                                                       |
#	| IL    | Wine Bar                                                                                         |
#	| IL    | Dive Bar                                                                                         |
#	| IL    | Investigative Agency                                                                             |
#	| IL    | Banana Wholesaler                                                                                |
#	| IL    | Mushroom Wholesaler                                                                              |
#	| IL    | Garlic Wholesaler                                                                                |
#	| IL    | Potato Wholesaler                                                                                |
#	| IL    | Sausage Casings Wholesaler: No Manufacturing                                                     |
#	| IL    | Residential Remodeling and Renovating: General Contractor: With Framing Work                     |
#	| IL    | Commercial Remodeling and Renovating: General Contractor                                         |
#	| IL    | Home Remodeling: General Contractor; With Framing                                                |
#	| IL    | New Residential Construction: Houses; General Contractor                                         |
#	| IL    | Builder: New Residential Buildings                                                               |
#	| IL    | Builder: New Commercial Buildings                                                                |
#	| IL    | Residential Carpentry: No Framing                                                                |
#	| IL    | Residential Carpentry: With Framing                                                              |
#	| IL    | Stonework Contractor                                                                             |
#	| IL    | Retaining Wall Contractor: Masonry                                                               |
#	| IL    | Civil Engineering Consulting: General Contractor                                                 |
#	| IL    | Household Appliances: Installation, Repair, or Service                                           |
#	| IL    | Deli: with table service and deep frying                                                         |
#	| IL    | Sandwich Shop: With Table Service                                                                |
#	| IL    | Butcher Shop: Retail; No Handling of Livestock                                                   |
#	| IL    | Seafood Market: Retail                                                                           |
#	| IL    | Butcher Shop: Wholesaler; No Handling of Livestock                                               |
#	| IL    | Fresh Meat Store: Retail                                                                         |
#	| IL    | Seafood Market: Wholesaler                                                                       |
#	| IL    | Meat, Fish, or Poultry Store: Retail                                                             |
#	| IL    | Butcher: Handling of Livestock                                                                   |
#	| IL    | Bridal Shop                                                                                      |
#	| IL    | Children's Clothing Store                                                                        |
#	| IL    | Linens Shop: Retail                                                                              |
#	| IL    | Maternity Apparel Shop                                                                           |
#	| IL    | Womens Clothing and Accessories Store                                                            |
#	| IL    | Men's Clothing Store                                                                             |
#	| IL    | Beverage Outlet Store: Retail                                                                    |
#	| IL    | Bagel Shop: Retail                                                                               |
#	| IL    | Cookie Shop: Retail                                                                              |
#	| IL    | Carpet Wholesaler                                                                                |
#	| IL    | Floor Coverings Wholesaler                                                                       |
#	| IL    | Mattress Store: Wholesaler                                                                       |
#	| IL    | Carpet Store: Retail; No Installation                                                            |
#	| IL    | Pool Table Store: Retail                                                                         |
#	| IL    | Pool Table Wholesaler                                                                            |
#	| IL    | Musical Instruments Store: Retail; With Pianos or Organs                                         |
#	| IL    | Musical Instruments Wholesaler                                                                   |
#	| IL    | Piano Store                                                                                      |
#	| IL    | Balloon Wholesaler                                                                               |
#	| IL    | Book Wholesaler                                                                                  |
#	| IL    | Secondhand Clothing Store                                                                        |
#	| IL    | Drugstore Products Wholesaler                                                                    |
#	| IL    | Firearms Wholesaler                                                                              |
#	| IL    | Firearms Store: Retail                                                                           |
#	| IL    | Cell Phone Wholesaler                                                                            |
#	| IL    | Restaurant Supply Wholesaler                                                                     |
#	| IL    | Sporting Goods Wholesaler                                                                        |
#	| IL    | Office Supply Wholesaler                                                                         |
#	| IL    | Potato Chip Wholesaler                                                                           |
#	| IL    | Beauty Supply Wholesaler                                                                         |
#	| IL    | Nuts Wholesaler                                                                                  |
#	| IL    | Bath or Kitchen Fixture Store                                                                    |
#	| IL    | Underground Telecommunications Cable Laying                                                      |
#	| IL    | Cable Television Hookup                                                                          |
#	| IL    | Cable Broadcasting Networks                                                                      |
#	| IL    | Cable Television Network                                                                         |
#	| IL    | Cable Splicer: Telecommunication                                                                 |
#	| IL    | Phone System Installer: No Underground Cable Laying                                              |
#	| IL    | Arborist                                                                                         |
#	| IL    | Hot Tub or Spa Store: Retail                                                                     |
#	| IL    | Swimming Pool Supply Store: No Installation                                                      |
#	| IL    | Ceramic Tile Store: Retail; No Installation                                                      |
#	| IL    | Confectionery Store: Retail                                                                      |
#	| IL    | Used Clothing Store                                                                              |
#	| IL    | Computer Wholesaler                                                                              |
#	| IL    | Cosmetics Store: Retail                                                                          |
#	| IL    | Dog Groomer                                                                                      |
#	| IL    | Goodwill Store                                                                                   |
#	| IL    | Greeting Card Store: Retail                                                                      |
#	| IL    | Luggage Wholesaler                                                                               |
#	| IL    | Medical Supplies Wholesaler                                                                      |
#	| IL    | Office Supplies Store: Retail                                                                    |
#	| IL    | Stationery Store: Retail                                                                         |
#	| IL    | Thrift Store: more than half of sales is furniture                                               |
#	| IL    | Thrift Store: less than half of sales is furniture                                               |
#	| IL    | Vitamin Store: Retail                                                                            |
#	| IL    | Vitamin Wholesaler                                                                               |
#	| IL    | Golf Pro Shop                                                                                    |
#	| IL    | Photocopy Shop                                                                                   |
#	| IL    | Blueprint Reproduction Services                                                                  |
#	| IL    | Microfilming Services                                                                            |
#	| IL    | Auto Parts Wholesaler                                                                            |
#	| IL    | Film Production Company                                                                          |
#	| IL    | Sound Recording Studio                                                                           |
#	| IL    | Amusement Device Operator: Traveling                                                             |
#	| IL    | Carnival: Traveling                                                                              |
#	| IL    | Circus: Traveling                                                                                |
#	| IL    | Delinquent youth halfway group home                                                              |
#	| IL    | Group home for the emotionally disturbed                                                         |
#	| IL    | Halfway group home for delinquents and ex-offenders                                              |
#	| IL    | Juvenile halfway group home                                                                      |
#	| IL    | Marriage Counseling Services                                                                     |
#	| IL    | Family planning counseling services                                                              |
#	| IL    | Children Counseling Services                                                                     |
#	| IL    | Physical Therapist: Traveling                                                                    |
#	| IL    | Financial Management Consulting                                                                  |
#	| IL    | Immigration Consulting                                                                           |
#	| IL    | General Management Consulting                                                                    |
#	| IL    | Business Consulting                                                                              |
#	| IL    | Hospice Care: At Client's Residence                                                              |
#	| IL    | Hospice Care Facility: Non-traveling                                                             |
#	| IL    | Private Golf Course                                                                              |
#	| IL    | Homemaker Services                                                                               |
#	| IL    | Direct Mail Advertising Services                                                                 |
#	| IL    | Mail Sorting Services                                                                            |
#	| IL    | Collection Agency                                                                                |
#	| IL    | Boiler Inspection                                                                                |
#	| IL    | Inventory Counting Services                                                                      |
#	| IL    | Low Voltage Electrical Work                                                                      |
#	| IL    | X-ray Installation, Maintenance, or Repair                                                       |
#	| IL    | Data Processing Systems: Installation or Repair                                                  |
#	| IL    | Electronic Bank Equipment: Installation and Service                                              |
#	| IL    | Auto Reposessing                                                                                 |
#	| IL    | Dermatological Lab: Testing Cosmetics                                                            |
#	| IL    | Document Conservation Services                                                                   |
#	| IL    | Analytical Chemical Firm                                                                         |
#	| IL    | Blood Bank                                                                                       |
#	| IL    | Birthing Center                                                                                  |
#	| IL    | Cryobank                                                                                         |
#	| IL    | Chiropodist                                                                                      |
#	| IL    | Medical Clinic: Outpatient Services Only                                                         |
#	| IL    | Clinic: Inpatient or Outpatient Services                                                         |
#	| IL    | Mental Health Hospital                                                                           |
#	| IL    | Mental Health Halfway House                                                                      |
#	| IL    | Mental Health Living Facility                                                                    |
#	| IL    | Osteopath Office                                                                                 |
#	| IL    | X-Ray Services Laboratory                                                                        |
#	| IL    | Plastic Surgeon: Physician                                                                       |
#	| IL    | Substance Abuse Halfway House                                                                    |
#	| IL    | Children's Hospital                                                                              |
#	| IL    | Substance Abuse Living Facility                                                                  |
#	| IL    | Alcoholism Rehabilitation Hospital                                                               |
#	| IL    | Drug Addiction Rehabilitation Hospital                                                           |
#	| IL    | Drug Addiction Rehabilitation Living Facility                                                    |
#	| IL    | Physical Rehabilitation Hospital                                                                 |
#	| IL    | Alcoholism Rehabilitation Living Facility                                                        |
#	| IL    | Alcoholism Counseling: no housing or medical treatment                                           |
#	| IL    | Drug Addiction Counseling: No housing or medical treatment                                       |
#	| IL    | Home Health Aide: With Registered Nurses                                                         |
#	| IL    | Private Duty Home Care: With Registered Nurses                                                   |
#	| IL    | Senior Home Care: With Registered Nurses                                                         |
#	| IL    | Home Infusion Therapist                                                                          |
#	| IL    | Patrol Service                                                                                   |
#	| IL    | Bee Raising                                                                                      |
#	| IL    | Artificial Insemination of Animals                                                               |
#	| IL    | Veterinarian                                                                                     |
#	| IL    | Dog Obedience Classes                                                                            |
#	| IL    | Worm Raising                                                                                     |
#	| IL    | Convalescent Home                                                                                |
#	| IL    | Retirement Living Center: With Registered Nurse care                                             |
#	| IL    | Long Term Care Facility                                                                          |
#	| IL    | Public Accounting Firm                                                                           |
#	| IL    | Mosque                                                                                           |
#	| IL    | Computer Training School                                                                         |
#	| IL    | English as a Second Language Instructor                                                          |
#	| IL    | Charter School                                                                                   |
#	| IL    | Orchestra                                                                                        |
#	| IL    | Movie Theater: No Live Shows                                                                     |
#	| IL    | Cinema                                                                                           |
#	| IL    | Multiplex Cinema                                                                                 |
#	| IL    | Comedy Club                                                                                      |
#	| IL    | Movie Film Studio                                                                                |
#	| IL    | Miniature Golf and Batting Cages                                                                 |
#	| IL    | Golf Driving Range: No Course                                                                    |
#	| IL    | Gun Range Only                                                                                   |
#	| IL    | Gun Range: With Retail Sales                                                                     |
#	| IL    | Shooting Range                                                                                   |
#	| IL    | Zoo                                                                                              |
#	| IL    | Ski Resort                                                                                       |
#	| IL    | Batting Cages                                                                                    |
#	| IL    | Boys and Girls Club                                                                              |
#	| IL    | Waxing or Hair Removal Services                                                                  |
#	| IL    | Boy Scout or Girl Scout Camping Operations                                                       |
#	| IL    | Recreational Vehicle (RV) Campground                                                             |
#	| IL    | Homeless Shelter                                                                                 |
#	| IL    | Pre-Parole or Probation Halfway House                                                            |
#	| IL    | Foreign Currency Exchange                                                                        |
#	| IL    | Savings and Loan Institution                                                                     |
#	| IL    | Portable Toilet Leasing                                                                          |
#	| IL    | Dumpster Rental Service                                                                          |
#	| IL    | Containerized Trash Removal                                                                      |
#	| IL    | Construction Site Cleanup Services                                                               |
#	| IL    | Oil Spill Cleanup                                                                                |
#	| IL    | Casino: No Hotel                                                                                 |
#	| IL    | Casino: With Hotel                                                                               |
#	| IL    | Demolition Services                                                                              |
#	| IL    | Building Raising or Moving                                                                       |
#	| IL    | Mechanical Engineering Consulting                                                                |
#	| IL    | Manufacturing Product Design Consulting                                                          |
#	| IL    | Carpet Installation                                                                              |
#	| IL    | Freight Broker                                                                                   |
#	| IL    | Freight Forwarder                                                                                |
#	| IL    | Horseback Riding Stables                                                                         |
#	| IL    | Concrete Mixing Service                                                                          |
#	| IL    | Transportation: Livestock, Equine, or Animals                                                    |
#	| IL    | Etailer                                                                                          |
#	| IL    | Event Setup and Teardown: Stages or Tents                                                        |
#	| IL    | Bounce House Rentals                                                                             |
#	| IL    | Ice Rink Setup and Teardown                                                                      |
#	| IL    | Carnival Setup and Teardown                                                                      |
#	| IL    | Tile Installation: No Stone or Marble                                                            |
#	| IL    | Tile Installation: Stone or Marble                                                               |
#	| IL    | Floor Installation: No Carpeting                                                                 |
#	| IL    | Flooring Contractor: No Carpet Installation                                                      |
#	| IL    | Pet Grooming: With Travel                                                                        |
#	| IL    | Retirement Living Center: With Care; No Registered Nurses                                        |
#	| IL    | Book Editing: No Printing                                                                        |
#	| IL    | Comedian                                                                                         |
#	| IL    | Cabin Cleaner: Aircraft                                                                          |
#	| IL    | Cosmetics Wholesaler                                                                             |
#	| IL    | Dental Laboratory                                                                                |
#	| IL    | Dental Technician                                                                                |
#	| IL    | Fire Extinguisher Inspection                                                                     |
#	| IL    | Timber Harvester                                                                                 |
#	| IL    | Homeowner Need Policy for Nanny: Not Live-in; <= 20 hrs/wk                                       |
#	| IL    | Freight Securement: No Transport                                                                 |
#	| IL    | Warehouse: Load and Unload Trucks; No Transport                                                  |
#	| IL    | Driving School                                                                                   |
#	| IL    | Driver Education Program                                                                         |
#	| IL    | Personal Assistant: Office Work Only                                                             |
#	| IL    | Pharmaceutical Sales                                                                             |
#	| IL    | Gem and Minerals Store: Retail                                                                   |
#	| IL    | Online Software Sales                                                                            |
#	| IL    | Security Camera Systems Installation                                                             |
#	| IL    | Startup Accelerator                                                                              |
#	| IL    | Tennis Instructor                                                                                |
#	| IL    | Auto Mechanic: Some Body Work                                                                    |
#	| IL    | Truck Mechanic: No Body Work                                                                     |
#	| IL    | Truck Mechanic: Some Body Work                                                                   |
#	| IL    | Dump Truck Hauling: Gravel, Dirt, and Sand                                                       |
#	| IL    | Manufacturer Sales Representative                                                                |
#	| IL    | Aviation Maintenance                                                                             |
#	| IL    | Air Charter or Air Taxi                                                                          |
#	| IL    | Aircraft Carrier                                                                                 |
#	| IL    | Aviation Flight Testing: No Helicopters                                                          |
#	| IL    | Aviation Training School                                                                         |
#	| IL    | Reglaze Bathrooms                                                                                |
#	| IL    | Electroplating                                                                                   |
#	| IL    | Investment Management Firm                                                                       |
#	| IL    | Venture Capital                                                                                  |
#	| IL    | Private Equity                                                                                   |
#	| IL    | Housekeeping: Franchise                                                                          |
#	| IL    | Public Detective Agency                                                                          |
#	| IL    | Private Patrol Agency                                                                            |
#	| IL    | Psychiatrist                                                                                     |
#	| IL    | Psychologist: Non-Travelling                                                                     |
#	| IL    | Commodity Broker                                                                                 |
#	| IL    | Cabinet Manufacturing: No Installation                                                           |
#	| IL    | Sawmill Operation                                                                                |
#	| IL    | Family Practice Physician                                                                        |
#	| IL    | Internal Medicine Physician                                                                      |
#	| IL    | Domestic Violence Shelter                                                                        |
#	| IL    | Women Shelter                                                                                    |
#	| IL    | Children Shelter                                                                                 |
#	| IL    | Gynecologist: Physician                                                                          |
#	| IL    | OBGYN Physician: Outpatient Only                                                                 |
#	| IL    | OBGYN Physician: With Inpatient                                                                  |
#	| IL    | Manned Aerial Photography: No Helicopters                                                        |
#	| IL    | Alternative Dispute Resolution                                                                   |
#	| IL    | Animal Waste Removal                                                                             |
#	| IL    | Bar and Grill                                                                                    |
#	| IL    | Bingo Hall                                                                                       |
#	| IL    | DirecTV Installation                                                                             |
#	| IL    | Correctional Officer                                                                             |
#	| IL    | Deck Repair                                                                                      |
#	| IL    | Contract Embroidery                                                                              |
#	| IL    | Erosion Control                                                                                  |
#	| IL    | Commercial Seeding                                                                               |
#	| IL    | Boat Towing                                                                                      |
#	| IL    | Executive Coaching                                                                               |
#	| IL    | Cattle Feeding                                                                                   |
#	| IL    | Fiber Optic Testing                                                                              |
#	| IL    | Fruit Farming                                                                                    |
#	| IL    | Logistics Services: do not own actual trucks                                                     |
#	| IL    | Metal Stud Framing                                                                               |
#	| IL    | Motorcycle Tours                                                                                 |
#	| IL    | Lawn Mowing Service                                                                              |
#	| IL    | Newspaper Publishing                                                                             |
#	| IL    | Painting: Inside of Homes Only                                                                   |
#	| IL    | Performing Arts Theatre                                                                          |
#	| IL    | Property Management: Rental Properties                                                           |
#	| IL    | Real Estate Staging Services                                                                     |
#	| IL    | Truck Repair: No Body Work                                                                       |
#	| IL    | Plumbing and HVAC Services                                                                       |
#	| IL    | After School Enrichment Program                                                                  |
#	| IL    | Medical Marijuana Dispensary: No Growing                                                         |
#	| IL    | Marijuana Grower                                                                                 |
#	| IL    | Recreational Marijuana Dispensary: No Growing                                                    |
#	| IL    | Aftermarket Auto Parts Store: With Repair or Service                                             |
#	| IL    | Aftermarket Auto Parts Wholesalers                                                               |
#	| IL    | Restaurant: Bistro; With Alcohol Sales                                                           |
#	| IL    | Cabling: Outside Buildings                                                                       |
#	| IL    | Car Wash: Self Service                                                                           |
#	| IL    | Convenience Store: No Cooking; With Gas Station                                                  |
#	| IL    | Convenience Store: With Cooking; With Gas Station                                                |
#	| IL    | Convenience Store: With Cooking; No Gas Station                                                  |
#	| IL    | Deli: with table service, no deep frying                                                         |
#	| IL    | Diner: With Alcohol Sales                                                                        |
#	| IL    | Metal Door or Window Installation: No Overhead                                                   |
#	| IL    | Restaurant: Family; With Alcohol Sales                                                           |
#	| IL    | Restaurant: Fast Food; Take Out Only; With Deep Frying                                           |
#	| IL    | Restaurant: With Dine In                                                                         |
#	| IL    | Filling Station: With Service or Repair                                                          |
#	| IL    | Gas Station: With repair                                                                         |
#	| IL    | Gasoline Station: With repair                                                                    |
#	| IL    | Grocery Store: Retail; With Gas Sales                                                            |
#	| IL    | Hotel: With Restaurant                                                                           |
#	| IL    | Inn: With Restaurant                                                                             |
#	| IL    | Laundromat: Self-Service; Supervised                                                             |
#	| IL    | Lawn Care Services: With Tree Removal or Excavation                                              |
#	| IL    | Lawn Maintenance: With Tree Removal or Excavation                                                |
#	| IL    | Luncheonette: With alcohol sales                                                                 |
#	| IL    | Painting: Both Inside and Outside; 4 Stories or More                                             |
#	| IL    | Painting: Outside of Buildings Only; 4 Stories or More                                           |
#	| IL    | Painting and Drywall: 4 stories or more                                                          |
#	| IL    | Petrol Station: With repair                                                                      |
#	| IL    | Restaurant: Pizza; With Deep Frying; No Table Service                                            |
#	| IL    | Sandwich Shop: No Table Service; With Deep Frying                                                |
#	| IL    | Supermarket: With gas sales                                                                      |
#	| IL    | Truck Washing Service: Self Service                                                              |
#	| IL    | Window Washing: 4 stories or more                                                                |
#	| IL    | Minimart: No Gas Station; With Fast Food                                                         |
#	| IL    | Minimart: no gas, With limited cooking                                                           |
#	| IL    | Minimart with gas and fast food                                                                  |
#	| IL    | Minimart: With Gas Station; Limited Cooking                                                      |
#	| IL    | Minimart with gas, no cooking                                                                    |
#	| IL    | Quick Stop: no gas, With fast food                                                               |
#	| IL    | Quick Stop: no gas, With limited cooking                                                         |
#	| IL    | Quick Stop: With Gas Station; Fast Food                                                          |
#	| IL    | Quick Stop with gas and limited cooking                                                          |
#	| IL    | Quick Stop with gas, no cooking                                                                  |
#	| IL    | Motel: With Restaurant                                                                           |
#	| IL    | Restaurant: Fine-Dining; With Alcohol Sales                                                      |
#	| IL    | Bookstore: With Used                                                                             |
#	| IL    | Cabinet Manufacturing: With Installation                                                         |
#	| IL    | Comic Books Store: Including Used                                                                |
#	| IL    | Drone Operator                                                                                   |
#	| IL    | Sign Painting or Lettering: With Spray Paint; Inside Only                                        |
#	| IL    | Landscape Gardening: With Tree Removal or Excavation                                             |
#	| IL    | Photography: With Drones                                                                         |
#	| IL    | Videographer: With Drones                                                                        |
#	| IL    | Beverage Wholesaler                                                                              |
#	| IL    | Beer Wholesaler                                                                                  |
#	| IL    | Alumina and Aluminum Production and Processing                                                   |
#	| IL    | Appliance stores, household-type, used                                                           |
#	| IL    | Audio System Installation                                                                        |
#	| IL    | Manufacturing: Beverage and Tobacco                                                              |
#	| IL    | Bicycle Assembly and Distribution                                                                |
#	| IL    | Business Schools and Computer and Management Training                                            |
#	| IL    | Rentals: Cabin or Chalet                                                                         |
#	| IL    | Cable and Other Subscription Programming                                                         |
#	| IL    | Campgrounds                                                                                      |
#	| IL    | Candle Making or Manufacturing                                                                   |
#	| IL    | Civic and Social Organizations                                                                   |
#	| IL    | Coal Mining                                                                                      |
#	| IL    | Community Food, Housing, Emergency, and Relief Services                                          |
#	| IL    | Computer and Electronic Product Manufacturing                                                    |
#	| IL    | Elderly Care Services                                                                            |
#	| IL    | Power Generation, Transmission and Distribution                                                  |
#	| IL    | Escalator Installation                                                                           |
#	| IL    | Farm Equipment Repair                                                                            |
#	| IL    | Fiber, Yarn, and Thread Mills                                                                    |
#	| IL    | Florist Wholesaler                                                                               |
#	| IL    | Highway, Street, and Bridge Construction                                                         |
#	| IL    | Hunting and Trapping                                                                             |
#	| IL    | Jewelry Repair                                                                                   |
#	| IL    | Land Subdivision                                                                                 |
#	| IL    | Lighting and Sound Production Companies                                                          |
#	| IL    | Lyft Driver                                                                                      |
#	| IL    | Postal Service                                                                                   |
#	| IL    | Primary Metal Manufacturing                                                                      |
#	| IL    | Satellite Telecommunications                                                                     |
#	| IL    | Sawmills and Wood Preservation                                                                   |
#	| IL    | Scenic and Sightseeing Transportation                                                            |
#	| IL    | Scheduled Air Transport: Less Than 20 passengers or cargo                                        |
#	| IL    | Sheep and Goat Farming                                                                           |
#	| IL    | Ship and Boat Building                                                                           |
#	| IL    | Sports Performance or Player Development                                                         |
#	| IL    | Textile Furnishings Mills                                                                        |
#	| IL    | Toy Manufacturers                                                                                |
#	| IL    | Utility System Construction                                                                      |
#	| IL    | Water, Sewage, and Other Systems                                                                 |
#	| IL    | Wood Product Manufacturing                                                                       |
#	| IL    | Apartment Buildings: 4 Units or Less; No Offices                                                 |
#	| IL    | Apartment Buildings: 4 Units or Less; With Offices                                               |
#	| IL    | Apartment Buildings: Over 4 Units; No Offices                                                    |
#	| IL    | Apartment Buildings: Over 4 Units; With Offices                                                  |
#	| IL    | Collectibles and Memorabilia Wholesaler                                                          |
#	| IL    | Collectibles and Memorabilia Store                                                               |
#	| IL    | Condominium: Commercial; Association Risk Only                                                   |
#	| IL    | Condominium: Office; Association Risk Only                                                       |
#	| IL    | Gardening and Light Farming Supply Wholesalers                                                   |
#	| IL    | Hardware and Tools Wholesalers                                                                   |
#	| IL    | Wholesalers: Janitorial Supplies                                                                 |
#	| IL    | Jewelry Wholesalers                                                                              |
#	| IL    | Stationery or Paper Products Wholesalers                                                         |
#	| IL    | Townhouse Associations: Over 4 Units; No Offices                                                 |
#	| IL    | Townhouse Associations: Over 4 Units; With Offices                                               |
#	| IL    | Optical and Hearing Aid Wholesalers                                                              |
#	| IL    | Shopping Center: No Full Cooking Restaurants                                                     |
#	| IL    | Shopping Center: With Full Cooking Restaurant                                                    |
#	| IL    | Condominium: Residential; Association Risk Only                                                  |
#	| IL    | Painting: Inside and Outside of Homes                                                            |
#	| IL    | Auto Detailing                                                                                   |
#	| IL    | Restaurant: Carryout                                                                             |
#	| IL    | Fire Suppression System Installation                                                             |
#	| IL    | Tree Services: With Removal or Excavation                                                        |
#	| IL    | Tree Trimming  With Removal or Excavation                                                        |
#	| IL    | Fiber Optic Cable Laying                                                                         |
#	| IL    | Nursing Care: Travelling                                                                         |
#	| IL    | Art Classes                                                                                      |
#	| IL    | Sports Cards Shop: Retail                                                                        |
#	| IL    | Awnings Installation: No Manufacturing                                                           |
#	| IL    | Awnings Manufacturing: No Installation                                                           |
#	| IL    | Awnings Manufacturing: With Installation                                                         |
#	| IL    | Career Coach                                                                                     |
#	| IL    | Support Coordination Agency                                                                      |
#	| IL    | Walking Tours                                                                                    |
#	| IL    | Quality Assurance Consulting                                                                     |
#	| IL    | Irrigation Management Consulting                                                                 |
#	| IL    | Fashion Design                                                                                   |
#	| IL    | Clothing Design                                                                                  |
#	| IL    | Retail Store: Fashion Accessories                                                                |
#	| IL    | Party Accessory Wholesaler                                                                       |
#	| IL    | Novelty Wholesaler                                                                               |
#	| IL    | Seaweed Harvesting                                                                               |
#	| IL    | Healthcare Management Consulting                                                                 |
#	| IL    | Vacation Rentals                                                                                 |
#	| IL    | Internet Sales                                                                                   |
#	| IL    | Medical Office: Outpatient Only                                                                  |
#	| IL    | Marking Flag Manufacturing                                                                       |
#	| IL    | Mobile Small Engine Repair                                                                       |
#	| IL    | Online Sales                                                                                     |
#	| IL    | Artist Agent                                                                                     |
#	| IL    | Pharmaceutical Consulting                                                                        |
#	| IL    | Residential Cleaning Services: Non-Franchise                                                     |
#	| IL    | Home Cleaning: Non-Franchise                                                                     |
#	| IL    | CD, DVD Store: Retail                                                                            |
#	| IL    | Self Defense Training                                                                            |
#	| IL    | Nutritional Products Store: Retail                                                               |
#	| IL    | Nutritional Products Wholesaler                                                                  |
#	| IL    | Seminar Speaker                                                                                  |
#	| IL    | Kale Farming                                                                                     |
#	| IL    | Supply Chain Management                                                                          |
#	| IL    | Non-profit Community Coalition                                                                   |
#	| IL    | Escape Room                                                                                      |
#	| IL    | Agriculture Consulting                                                                           |
#	| IL    | Aircraft Parts Sales: New Only; No Repair or Service                                             |
#	| IL    | Aircraft Parts Sales: Used; No Repair or Service                                                 |
#	| IL    | Aircraft Parts Sales: Used; With Repair or Service                                               |
#	| IL    | Aircraft Parts Sales: New Only; With Repair or Service                                           |
#	| IL    | Wedding Planner: No Catering                                                                     |
#	| IL    | Wedding Planner: Catering                                                                        |
#	| IL    | Mobile Auto Mechanic: No Trucks                                                                  |
#	| IL    | Mobile Auto Mechanic: Including Trucks                                                           |
#	| IL    | Skin Care Center: Dermatologists                                                                 |
#	| IL    | Behavioral Health Therapist: Outpatient; Non-Traveling                                           |
#	| IL    | Behavioral Health Therapist: Inpatient                                                           |
#	| IL    | Broadcast Installation, Maintenance, or Repair                                                   |
#	| IL    | Business Broker                                                                                  |
#	| IL    | Commercial Pilot                                                                                 |
#	| IL    | Private Pilot: No Helicopters                                                                    |
#	| IL    | Media Commercial Production                                                                      |
#	| IL    | Weight Loss Center                                                                               |
#	| IL    | Cool Sculpting                                                                                   |
#	| IL    | Core Drilling and Cutting Services                                                               |
#	| IL    | Transportation of Goods: Manufacturer to Wholesaler or Wholesaler to Retailer: over 300 miles    |
#	| IL    | Transportation of Goods: Manufacturer to Wholesaler or Wholesaler to Retailer: under 300 miles   |
#	| IL    | Fiber Optics Drilling                                                                            |
#	| IL    | Home Inspection                                                                                  |
#	| IL    | Party Rentals                                                                                    |
#	| IL    | Apartment Punch Out and Turn Over Services                                                       |
#	| IL    | Halloween Store: Retail                                                                          |
#	| IL    | Horse and Carriage Rides                                                                         |
#	| IL    | Picture Frame Wholesaler                                                                         |
#	| IL    | ATM Machine Services                                                                             |
#	| IL    | Wine Consulting: No manufacturing or growing                                                     |
#	| IL    | Real Estate Fix and Flip: With Framing                                                           |
#	| IL    | Shed Installation: No Metal                                                                      |
#	| IL    | Shed Installation: Metal                                                                         |
#	| IL    | Leaf Guard Installation                                                                          |
#	| IL    | Metal Finishing                                                                                  |
#	| IL    | Family Fun: Go Karts, Bumper Cars, Minigolf, Batting Cages                                       |
#	| IL    | Mobile Car Wash or Detailing                                                                     |
#	| IL    | American Legion                                                                                  |
#	| IL    | Neurofeedback Laboratory                                                                         |
#	| IL    | Neurologist: Outpatient Only; Physician                                                          |
#	| IL    | Neurosurgeon                                                                                     |
#	| IL    | Organizing and De-cluttering Services                                                            |
#	| IL    | Painting: Outside of Homes Only                                                                  |
#	| IL    | Auto Manufacturing Plant                                                                         |
#	| IL    | Urgent or Walk-in Medical Care Facility                                                          |
#	| IL    | Applied Behavior Analysis (ABA) Therapist: Non-Traveling                                         |
#	| IL    | Lifeguard                                                                                        |
#	| IL    | Radon Mitigation                                                                                 |
#	| IL    | Greenhouse Grower                                                                                |
#	| IL    | Behavioral Health Therapist: Outpatient Only; Traveling                                          |
#	| IL    | Occupational Therapist: Traveling                                                                |
#	| IL    | Vacuum Cleaner Store: Retail Including Service                                                   |
#	| IL    | Powersports Vehicle, ATV, or Watercraft Manufacturing                                            |
#	| IL    | Horse Shelter                                                                                    |
#	| IL    | Kayak Rentals                                                                                    |
#	| IL    | Applied Behavior Analysis (ABA) Therapist: Traveling                                             |
#	| IL    | Housekeeping: Non-Franchise                                                                      |
#	| IL    | Auto Parts Manufacturing                                                                         |
#	| IL    | Steel Barrel or Drum Manufacturing                                                               |
#	| IL    | Sheet Metal Work: Shop Only                                                                      |
#	| IL    | Metal Stamping Manufacturing                                                                     |
#	| IL    | Marine Construction: Boats or Docks                                                              |
#	| IL    | Ice Skating Rink                                                                                 |
#	| IL    | Jewelry Manufacturing                                                                            |
#	| IL    | Christmas Tree Store                                                                             |
#	| IL    | Pet and Pet Supply Wholesaler                                                                    |
#	| IL    | Railroad Construction, Operation, or Maintenance                                                 |
#	| IL    | Traffic Control or Flagging Services                                                             |
#	| IL    | Handyman: Including Framing Work                                                                 |
#	| IL    | Handyperson: With Framing                                                                        |
#	| IL    | Home Repairs: With Framing                                                                       |
#	| IL    | Television, Radio, Cell Phone, or Telephone Manufacturing                                        |
#	| IL    | Coppersmith: Shop Only                                                                           |
#	| IL    | Concrete Products Manufacturing: No Installation                                                 |
#	| IL    | Pallet Manufacturing                                                                             |
#	| IL    | Box Manufacturing                                                                                |
#	| IL    | Transformer Manufacturing                                                                        |
#	| IL    | Circuit Breaker Manufacturing                                                                    |
#	| IL    | Motor or Generator Manufacturing                                                                 |
#	| IL    | Pyroxylin Manufacturing                                                                          |
#	| IL    | Plastics Manufacturing: Sheets, Rods, or Tubes                                                   |
#	| IL    | Rubber Goods Manufacturing                                                                       |
#	| IL    | Pump Manufacturing                                                                               |
#	| IL    | Computer Consulting: With Client Hardware Installation                                           |
#	| IL    | Sawmill                                                                                          |
#	| IL    | Boiler Maker or Boilermaking operations                                                          |
#	| IL    | Fence Manufacturing: No Installation                                                             |
#	| IL    | Coat Hanger Manufacturing                                                                        |
#	| IL    | Chain Manufacturing                                                                              |
#	| IL    | Planing or Molding Mill                                                                          |
#	| IL    | Chemical Manufacturing: New                                                                      |
#	| IL    | Chemical Manufacturing: Blending only                                                            |
#	| IL    | Office Machine Manufacturing: Printers or Computers                                              |
#	| IL    | Screw, Nuts, or Bolts Manufacturing                                                              |
#	| IL    | Manufacturing: Paper Goods: Tissue, Towel, Plate, Napkin                                         |
#	| IL    | Oxygen or Hydrogen Manufacturing                                                                 |
#	| IL    | Corrugated or Fiberboard Container Manufacturing                                                 |
#	| IL    | Metal Sign Manufacturing                                                                         |
#	| IL    | Fertilizer Manufacturing                                                                         |
#	| IL    | Carbonated Beverage Manufacturing                                                                |
#	| IL    | Glass and Glazing Work: Shop Only                                                                |
#	| IL    | Iron or Steel Fabrication: Non-Structural; No Install                                            |
#	| IL    | Iron or Steel Fabrication: Structural; No Installation                                           |
#	| IL    | Ink or Paint Manufacturing                                                                       |
#	| IL    | Hardware Manufacturing                                                                           |
#	| IL    | Ice Skate Manufacturing                                                                          |
#	| IL    | Residential Remodeling and Renovating: General Contractor                                        |
#	| IL    | Home Remodeling: General Contractor; No Framing                                                  |
#	| IL    | Real Estate Fix and Flip: No Framing                                                             |
#	| IL    | Advertising Agencies: With Sign Installation                                                     |
#	| IL    | Ad Agency: With Sign Installation                                                                |
#	| IL    | Graphic Designer: With Sign Installation                                                         |
#	| IL    | Miscellaneous Machine Repair                                                                     |
#	| IL    | Maid Services: Franchise                                                                         |
#	| IL    | Procurement Consulting                                                                           |
#	| IL    | Oncologist: Physician                                                                            |
#	| IL    | Speech Therapist: Traveling                                                                      |
#	| IL    | Homeowner Need Policy for Nanny: Not Live-in; > 20 hrs/wk                                        |
#	| IL    | Domestic Workers: 20 hours or less per week                                                      |
#	| IL    | Non-Emergency Medical Transport                                                                  |
#	| IL    | Grease Trap Services                                                                             |
#	| IL    | Sewer or Storm Drain Clean Up Services                                                           |
#	| IL    | Hazardous Spill Cleanup Services                                                                 |
#	| IL    | Property Management: Strip Malls                                                                 |
#	| IL    | Property Management: Commercial Buildings and Residential                                        |
#	| IL    | Waffle Stand                                                                                     |
#	| IL    | Radiation Safety Services                                                                        |
#	| IL    | Parking Lot Maintenance                                                                          |
#	| IL    | Screws, Nuts, or Bolts Store: Retail                                                             |
#	| IL    | Screws, Nuts, or Bolts Wholesaler                                                                |
#	| IL    | Marine Repair or Maintenance                                                                     |
#	| IL    | Industrial Machinery Repair                                                                      |
#	| IL    | Psychotherapist                                                                                  |
#	| IL    | Spices, Herbs, and Seasonings Store: Retail                                                      |
#	| IL    | Mobile Food Cart                                                                                 |
#	| IL    | Pottery Studio                                                                                   |
#	| IL    | Commercial Fishing                                                                               |
#	| IL    | Metal Building Repair                                                                            |
#	| IL    | Fulfillment Center                                                                               |
#	| IL    | Bartender                                                                                        |
#	| IL    | Water Treatment Services                                                                         |
#	| IL    | Music Instructor                                                                                 |
#	| IL    | Janitorial Services: 50% or More Residential                                                     |
#	| IL    | Truck or Recreational Vehicle (RV) Body Shop                                                     |
#	| IL    | Anesthesiologist: Physician                                                                      |
#	| IL    | Cardiologist: Physician                                                                          |
#	| IL    | Clinical or Anatomical Pathologist: Physician                                                    |
#	| IL    | Gastroenterologist: Physician                                                                    |
#	| IL    | Immunologist or Allergist: Physician                                                             |
#	| IL    | Delivery: Goods; Retail to Homes; Furniture or Mattress                                          |
#	| IL    | Grocery or Food Delivery Service                                                                 |
#	| IL    | Fedex Delivery Service                                                                           |
#	| IL    | Amazon Delivery Service                                                                          |
#	| IL    | Cafe: No Table Service: With Hot Food                                                            |
#	| IL    | Cafe: With Table Service                                                                         |
#	| IL    | Restaurant: Pizza; No Deep Frying; With Table Service                                            |
#	| IL    | Restaurant: Pizza; With Deep Frying; With Table Service                                          |
#	| IL    | Computer Hardware Engineering                                                                    |
#	| IL    | Geologist                                                                                        |
#	| IL    | Kitchen Hood, Duct, or Exhaust Services                                                          |
#	| IL    | Professional Race Team: Motocross, NASCAR, or Formula One                                        |
#	| IL    | Audio Visual Technician: With Stage Lighting                                                     |
#	| IL    | Credit Union                                                                                     |
#	| IL    | Literary Agent                                                                                   |
#	| IL    | Logistics Services: own trucks that haul                                                         |
#	| IL    | Woodworking: No Sawmill                                                                          |
#	| IL    | Elevator Inspection                                                                              |
#	| IL    | Lobbyist                                                                                         |
#	| IL    | Street Sweeping or Cleaning                                                                      |
#	| IL    | Political Campaign                                                                               |
#	| IL    | Firework Operations                                                                              |
#	| IL    | Amusement Device Operator: Non-Traveling                                                         |
#	| IL    | Axe Throwing                                                                                     |
#	| IL    | Aviation Flight Testing: With Helicopters                                                        |
#	| IL    | Manned Aerial Photography: With Helicopters                                                      |
#	| IL    | Private Pilot: With Helicopters                                                                  |
#	| IL    | News Reporter                                                                                    |
#	| IL    | Iron Erection or Steel Erection: Less than 3 stories                                             |
#	| IL    | Recycling Services: Including Scrap Metal                                                        |
#	| IL    | Swimming Pool Cleaning: With Installation                                                        |
#	| IL    | Swimming Pool Supply Store: With Installation                                                    |
#	| IL    | Plastering or Stucco Work: Interior Only                                                         |
#	| IL    | Stucco Contractor: Interior Only                                                                 |
#	| IL    | Plastering Contractor: Interior Only                                                             |
#	| IL    | Iron or Steel Fabrication: Non-Structural; With Install                                          |
#	| IL    | Iron or Steel Fabrication: Structural; With Installation                                         |
#	| IL    | Construction Project Management with contracting employees                                       |
#	| IL    | Home Healthcare Aide                                                                             |
#	| IL    | Healthcare Management Social Services                                                            |
#	| IL    | Home Improvement Contractor: No Framing                                                          |
#	| IL    | Home Improvement Contractor: With Framing                                                        |
#	| IL    | Commercial Cleaning Services: 50% or more residential                                            |
#	| IL    | Landscape Maintenance Only: No Tree Removal or Excavation                                        |
#	| IL    | Landscape Maintenance Only with Tree Removal or Excavation                                       |
#	| IL    | General Contractor: We do some work ourselves                                                    |
#	| IL    | Interior Carpentry Contractor: With Framing                                                      |
#	| IL    | Finish Carpentry Contractor: With Framing                                                        |
#	| IL    | Concrete Construction: With Pouring of Walls                                                     |
#	| IL    | Medical Marijuana Dispensary: With Growing                                                       |
#	| IL    | Recreational Marijuana Dispensary: With Growing                                                  |
#	| IL    | Medical or Recreational Marijuana Dispensary: No Growing                                         |
#	| IL    | Medical or Recreational Marijuana Dispensary: With Growing                                       |
#	| IL    | Bookbinder                                                                                       |
#	| IL    | Film Editor                                                                                      |
#	| IL    | Loss Control Inspector                                                                           |
#	| IL    | Structured Settlement Consulting                                                                 |
#	| IL    | Recruiting Services: With Staffing Services                                                      |
#	| IL    | Adult Living Facility: No Medical Care                                                           |
#	| IL    | Archery Range                                                                                    |
#	| IL    | Grain or Feed Milling                                                                            |
#	| IL    | Farm Machinery Operator Services                                                                 |
#	| IL    | Hay Baling Services                                                                              |
#	| IL    | Nurseries: No Trees                                                                              |
#	| IL    | Floriculture: No Trees                                                                           |
#	| IL    | Farm Equipment: Rental, Sales, or Service                                                        |
#	| IL    | Headhunting Services: With staffing services                                                     |
#	| IL    | Executive Placement Agency: With staffing services                                               |
#	| IL    | Project Management Consulting Not Construction Industry                                          |
#	| IL    | Clothing Wholesaler                                                                              |
#	| IL    | Animal Carcass Removal                                                                           |
#	| IL    | Primary Care Physician                                                                           |
#	| IL    | Non-Medical Billing Services                                                                     |
#	| IL    | Interior Design: No Installation                                                                 |
#	| IL    | Beaver Trapping                                                                                  |
#	| IL    | Coffee and Tea Supply Store: Retail                                                              |
#	| IL    | Kitchen Accessories Wholesaler                                                                   |
#	| IL    | Roadside Assistance                                                                              |
#	| IL    | Call Center Services                                                                             |
#	| IL    | Camera and Photographic Supplies Wholesaler                                                      |
#	| IL    | Manufacturing: Ice                                                                               |
#	| IL    | Ice Sculpting                                                                                    |
#	| IL    | Log Hauling                                                                                      |
#	| IL    | Premium Finance                                                                                  |
#	| IL    | Electrical Engineering Consulting                                                                |
#	| IL    | Legal Services                                                                                   |
#	| IL    | Geotechnical Engineering                                                                         |
#	| IL    | Association Accreditation                                                                        |
#	| IL    | Trustee Services                                                                                 |
#	| IL    | Reinsurance Brokerage                                                                            |
#	| IL    | Alarm Monitoring Services                                                                        |
#	| IL    | Life Insurance Agency                                                                            |
#	| IL    | Forensic Accounting                                                                              |
#	| IL    | Manufacturing: Cannabis Food Products                                                            |
#	| IL    | Medical Marijuana Manufacturing                                                                  |
#	| IL    | IT installation: inside network setup                                                            |
#	| IL    | Early Education Teacher                                                                          |
#	| IL    | Language Teacher                                                                                 |
#	| IL    | Elementary Teacher                                                                               |
#	| IL    | Mudjacking                                                                                       |
#	| IL    | Auto Recycling                                                                                   |
#	| IL    | Mechanical Engineering                                                                           |
#	| IL    | Linen, Towel, or Uniform Laundry Services                                                        |
#	| IL    | Structural Engineering                                                                           |
#	| IL    | Life and Health Insurance Agency                                                                 |
#	| IL    | Vegetable Farming                                                                                |
#	| IL    | Mushroom Farming                                                                                 |
#	| IL    | Aircraft Manufacturing                                                                           |
#	| IL    | General Merchandise Wholesaler                                                                   |
#	| IL    | Seed Merchant                                                                                    |
#	| IL    | Crop Dusting                                                                                     |
#	| IL    | Loan Servicing                                                                                   |
#	| IL    | Mausoleum                                                                                        |
#	| IL    | Art Conservator                                                                                  |
#	| IL    | Forensic Analytical Laboratory                                                                   |
#	| IL    | Fumigation Services                                                                              |
#	| IL    | Art Therapist                                                                                    |
#	| IL    | Reflexology                                                                                      |
#	| IL    | Microblading                                                                                     |
#	| IL    | Bicycle Rentals                                                                                  |
#	| IL    | Rental Property Owner: 1 to 4 Family Dwellings                                                   |
#	| IL    | Rental Real Estate: 1 to 4 Family Dwellings                                                      |
#	| IL    | Rental Property Owner: Residential Over 4 Family                                                 |
#	| IL    | Rental Real Estate: Residential Over 4 Family                                                    |
#	| IL    | Landlord: 1 to 4 Family Dwellings                                                                |
#	| IL    | Landlord: Residential Over 4 Family                                                              |
#	| IL    | Taxicab company: more than one vehicle                                                           |
#	| IL    | Taxicab driver: only one vehicle                                                                 |
#	| IL    | Air Duct Cleaning                                                                                |
#	| IL    | Anhydrous Ammonia Dealer                                                                         |
#	| IL    | Appliance Repair                                                                                 |
#	| IL    | Architecture                                                                                     |
#	| IL    | Artist                                                                                           |
#	| IL    | Au Pair                                                                                          |
#	| IL    | Author                                                                                           |
#	| IL    | Bakery at my Residence                                                                           |
#	| IL    | Bee Keeping                                                                                      |
#	| IL    | Benefits Consulting                                                                              |
#	| IL    | Biological Consulting                                                                            |
#	| IL    | Biotechnology Engineering                                                                        |
#	| IL    | Blogger                                                                                          |
#	| IL    | Boat Detailing                                                                                   |
#	| IL    | Body Contouring                                                                                  |
#	| IL    | Body Sculpting                                                                                   |
#	| IL    | Book Publishing                                                                                  |
#	| IL    | Cell Tower Modification                                                                          |
#	| IL    | Certified Registered Nurse Anesthetist (CRNA)                                                    |
#	| IL    | Child Daycare Center                                                                             |
#	| IL    | Chimney Sweep                                                                                    |
#	| IL    | Clearing house (finance)                                                                         |
#	| IL    | Closing Agent                                                                                    |
#	| IL    | CNC Machining                                                                                    |
#	| IL    | Concrete Foundation Work: Houses                                                                 |
#	| IL    | Consumer Lending                                                                                 |
#	| IL    | Crude Oil Dealer                                                                                 |
#	| IL    | Customer Service Management Consulting                                                           |
#	| IL    | Cyber Security Consulting                                                                        |
#	| IL    | Data Storage Services                                                                            |
#	| IL    | Daycare Center                                                                                   |
#	| IL    | Delivery: Goods; Terminal to Terminal                                                            |
#	| IL    | Diesel Engine Repair                                                                             |
#	| IL    | Dropshipping                                                                                     |
#	| IL    | Ecommerce                                                                                        |
#	| IL    | Economist                                                                                        |
#	| IL    | Environmental Consulting                                                                         |
#	| IL    | Equine Training                                                                                  |
#	| IL    | Escrow Agent or Agency                                                                           |
#	| IL    | Eyelash Extension                                                                                |
#	| IL    | Firearms Training                                                                                |
#	| IL    | Food Vendor                                                                                      |
#	| IL    | Foreclosure Agent or Agency                                                                      |
#	| IL    | Freelance Writing                                                                                |
#	| IL    | Fuel Oil Dealer                                                                                  |
#	| IL    | Fuel Oil Hauler                                                                                  |
#	| IL    | Gasoline, LPG, or Oil Dealer                                                                     |
#	| IL    | Geophysical Surveying Services                                                                   |
#	| IL    | Group Daycare                                                                                    |
#	| IL    | Guitar Teacher                                                                                   |
#	| IL    | Gutter Cleaning                                                                                  |
#	| IL    | Hairdresser                                                                                      |
#	| IL    | Hairstylist                                                                                      |
#	| IL    | Health Insurance Agent or Agency                                                                 |
#	| IL    | Hemp Fabric Products Manufacturing                                                               |
#	| IL    | Horseback Racing Stables                                                                         |
#	| IL    | Horseback Riding Stables - No Racing                                                             |
#	| IL    | Hospitality: Fast Food Restaurants                                                               |
#	| IL    | Hospitality: Full Service Restaurants                                                            |
#	| IL    | Hospitality: Hotels                                                                              |
#	| IL    | Hospitality: Overseas Cruise Ships                                                               |
#	| IL    | Hot Shot Trucking                                                                                |
#	| IL    | Insurance Agent                                                                                  |
#	| IL    | K-12 Teacher                                                                                     |
#	| IL    | Kava or Kratom Bar                                                                               |
#	| IL    | Laser Hair Removal - Electrolysis                                                                |
#	| IL    | Life and Health Insurance Agent                                                                  |
#	| IL    | Life Insurance Agent                                                                             |
#	| IL    | Liquefied Petroleum Gas Dealer (LPG/Propane/Butane)                                              |
#	| IL    | Loan Brokerage                                                                                   |
#	| IL    | Loan Signing Agent                                                                               |
#	| IL    | Lumper Services                                                                                  |
#	| IL    | Machining                                                                                        |
#	| IL    | Magazine Publishing                                                                              |
#	| IL    | Makeup Artist                                                                                    |
#	| IL    | Manicurist                                                                                       |
#	| IL    | Manufacturing: Pet Food                                                                          |
#	| IL    | Mapping Services                                                                                 |
#	| IL    | Material Handling                                                                                |
#	| IL    | Medical Spa                                                                                      |
#	| IL    | Millwork                                                                                         |
#	| IL    | Ministry                                                                                         |
#	| IL    | Music Teacher                                                                                    |
#	| IL    | Mutual Fund Agencies                                                                             |
#	| IL    | Non Emergency Medical Transport                                                                  |
#	| IL    | Nurse Practitioner                                                                               |
#	| IL    | Oil Refining                                                                                     |
#	| IL    | Operations Consulting                                                                            |
#	| IL    | Opinion Polling Services                                                                         |
#	| IL    | Orchard Farming                                                                                  |
#	| IL    | Oversized Load Escort                                                                            |
#	| IL    | Payroll Processing Services                                                                      |
#	| IL    | Permanent Makeup Services                                                                        |
#	| IL    | Personal Chef                                                                                    |
#	| IL    | Petroleum Engineering                                                                            |
#	| IL    | Petroleum Extraction or Exploration                                                              |
#	| IL    | Petroleum Manufacturing (Fuel oil, LPG, Propane, Butane)                                         |
#	| IL    | Phlebotomist                                                                                     |
#	| IL    | Pilot Car Service                                                                                |
#	| IL    | Podcast                                                                                          |
#	| IL    | Pool Service                                                                                     |
#	| IL    | Portfolio Fund Managing                                                                          |
#	| IL    | Powder Coating                                                                                   |
#	| IL    | Property & Casualty Insurance Agency                                                             |
#	| IL    | Property & Casualty Insurance Agent                                                              |
#	| IL    | Psychologist: Traveling                                                                          |
#	| IL    | Real Estate Agency                                                                               |
#	| IL    | Real Estate Brokerage                                                                            |
#	| IL    | Realtor                                                                                          |
#	| IL    | Registered Nurse                                                                                 |
#	| IL    | Retail Store: Handbags, Purses                                                                   |
#	| IL    | RV Repair                                                                                        |
#	| IL    | Safety Consulting                                                                                |
#	| IL    | Scientific Consulting                                                                            |
#	| IL    | Security Consulting                                                                              |
#	| IL    | Settlement Agent                                                                                 |
#	| IL    | Signing Agency Including Loans                                                                   |
#	| IL    | Skin Care Center: Not Dermatologists                                                             |
#	| IL    | Soap Making                                                                                      |
#	| IL    | Social Work Services                                                                             |
#	| IL    | Strategy Consulting                                                                              |
#	| IL    | Stump Grinding                                                                                   |
#	| IL    | Surgeon                                                                                          |
#	| IL    | Tattoo Artist                                                                                    |
#	| IL    | Technology: Network Design                                                                       |
#	| IL    | Technology: Software Development                                                                 |
#	| IL    | Teeth Whitening                                                                                  |
#	| IL    | Telemedicine                                                                                     |
#	| IL    | Tire Service                                                                                     |
#	| IL    | Title Abstractor                                                                                 |
#	| IL    | Transportation of Goods: Terminal to Terminal                                                    |
#	| IL    | Tree Nut Farming                                                                                 |
#	| IL    | Tree Removal: No Logging                                                                         |
#	| IL    | Tree Trimming: With Removal or Excavation                                                        |
#	| IL    | Trucking: Retail to Homes; Including Furniture or Mattress                                       |
#	| IL    | Trucking: Retail to Homes; No Furniture or Mattress                                              |
#	| IL    | Urban Planner                                                                                    |
#	| IL    | Web or Domain Hosting                                                                            |
#	| IL    | Window Tinting: Including Automotive                                                             |
#	| IL    | Window Tinting: No Automotive                                                                    |
#	| IL    | Writer                                                                                           |
#	| IL    | Transaction Coordinator for Real Estate Industry                                                 |
#	| IL    | Ridesharing                                                                                      |
#	| IL    | Kinesiotherapy                                                                                   |
#	| IL    | Physicians Assistant (PA)                                                                        |
#	| IL    | Prosthetist                                                                                      |
#	| IL    | Radiology Assistant                                                                              |
#	| IL    | Medical Dosimetrist                                                                              |
#	| IL    | Licensed Vocational Nurse (LVN)                                                                  |
#	| IL    | Licensed Practical Nurse (LPN)                                                                   |
#	| IL    | Respiratory Care Provider or Respiratory Therapist                                               |
#	| IL    | Transportation of Goods: Delivery to Consumers                                                   |
#	| IL    | Transportation of Passengers: Bus                                                                |
#	| IL    | Transportation of Passengers: Boats                                                              |
#	| IL    | Transportation of Passengers: Limousine Company                                                  |
#	| IL    | Transportation of Passengers: Ridesharing                                                        |
#	| IL    | Transportation of Passengers: Taxi; 1 vehicle                                                    |
#	| IL    | Transportation of Passengers: Taxi; more than 1 vehicle                                          |
#	| IL    | Arbitration or Mediation                                                                         |
#	| IL    | Healthcare Technician                                                                            |
#	| IL    | Medical Technician                                                                               |
#	| IL    | Medical Technologist                                                                             |
#	| IL    | Healthcare Technologist                                                                          |
#	| IL    | Hearing Therapist: Non-traveling                                                                 |
#	| IL    | Clinical Nurse Specialist                                                                        |
#	| IL    | Colon Hydrotherapy                                                                               |
#	| IL    | Clinical Research Coordinator                                                                    |
#	| IL    | Interpreter Services: Deaf                                                                       |
#	| IL    | Enterostomal Therapist                                                                           |
#	| IL    | Licensed Clinical Social Worker                                                                  |
#	| IL    | Pedorthist                                                                                       |
#	| IL    | Psychotherapy                                                                                    |
#	| IL    | Education: K-12                                                                                  |
#	| IL    | Emergency Medical Technician (EMT)                                                               |
#	| IL    | General Contractor: No Contracting Employees                                                     |
#	| IL    | General Contractor: With Contracting Employees                                                   |
#	| IL    | Pharmacist                                                                                       |
#	| IL    | Education: Pre-K                                                                                 |
#	| IL    | Medical Clinic: Inpatient                                                                        |
#	| IL    | Midwife or Midwifery                                                                             |
#	| IL    | Public Adjuster                                                                                  |
#	| IL    | Bottling or Canning Services                                                                     |
#	| IL    | Frozen Food Manufacturing                                                                        |
#	| IL    | Candy Manufacturing                                                                              |
#	| IL    | Healthcare Assistant                                                                             |
#	| IL    | Healthcare Aide                                                                                  |
#	| IL    | Hearing Therapist: Traveling                                                                     |
#	| IL    | Doula                                                                                            |
#	| IL    | Interpreter Services: Language                                                                   |
#	| IL    | Education: College                                                                               |
#	| IL    | Education: Vocational; Classroom Only                                                            |
#	| IL    | Education: Vocational; Hands On Instruction                                                      |
#	| IL    | Dental Hygienist                                                                                 |
#	| IL    | Amazon Delivery Service and Retail Operations                                                    |
#	| IL    | Cryotherapy                                                                                      |
#	| IL    | Music Therapy or Therapist                                                                       |
#	| IL    | Transportation of Passengers: Boat                                                               |
#	| IL    | Bodyguard Services                                                                               |
#	| IL    | Nonprofit: Awareness/Education                                                                   |
#	| IL    | Nonprofit: Community Coalition                                                                   |
#	| IL    | Nonprofit: Emergency Relief                                                                      |
#	| IL    | Nonprofit: Food Bank                                                                             |
#	| IL    | Nonprofit: Healthcare; Hospital - Not Veterinarian                                               |
#	| IL    | Nonprofit: Healthcare; Hospital - Veterinarian                                                   |
#	| IL    | Nonprofit: Healthcare; Not hospital                                                              |
#	| IL    | Nonprofit: Job Training                                                                          |
#	| IL    | Nonprofit: Labor Union Organization                                                              |
#	| IL    | Nonprofit: Political Organization                                                                |
#	| IL    | Nonprofit: Religious Organization                                                                |
#	| IL    | Nonprofit: Substance Abuse; No Housing or Healthcare                                             |
#	| IL    | Nonprofit: Substance Abuse; Halfway House                                                        |
#	| IL    | Nonprofit: Substance Abuse; Living Facility                                                      |
#	| IL    | Nonemergency Medical Transport                                                                   |
#	| IL    | Entertainment: Amusement Parks                                                                   |
#	| IL    | Entertainment: DJ                                                                                |
#	| IL    | Entertainment: Event Promoter                                                                    |
#	| IL    | Entertainment: Live Music Venue                                                                  |
#	| IL    | Entertainment: Music Production; No Live Music                                                   |
#	| IL    | Entertainment: Nightclub                                                                         |
#	| IL    | Entertainment: Outdoor Activities                                                                |
#	| IL    | Entertainment: Party Rentals                                                                     |
#	| IL    | Entertainment: Performer                                                                         |
#	| IL    | Construction: General Contractor                                                                 |
#	| IL    | Construction: Handyman                                                                           |
#	| IL    | Construction: Specialty; Carpentry                                                               |
#	| IL    | Construction: Specialty; Concrete                                                                |
#	| IL    | Construction: Specialty; Drywall                                                                 |
#	| IL    | Construction: Specialty; Electrical                                                              |
#	| IL    | Construction: Specialty; Highway, Street, and Bridge                                             |
#	| IL    | Construction: Specialty; HVAC                                                                    |
#	| IL    | Construction: Specialty; Masonry                                                                 |
#	| IL    | Construction: Specialty; Plumbing                                                                |
#	| IL    | Construction: Specialty; Roofing                                                                 |
#	| IL    | Construction: We do a variety of work                                                            |

#AUTOGENERATED ABOVE THIS FOR STATE IL


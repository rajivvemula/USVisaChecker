Feature: CA_OperationsPageHelpErrorText_U

Verifying Help and Error Texts using diffrent keyword and states

@Unit @CA @Transportation @Cali
Scenario: CA Operations Page Help Error Text Unit Hot Shot Trucking In California
	Given user starts a quote with:
		| Industry          | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 3         | I Work at a Job Site | Vehicles     | 95204    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 1687 N California St |          | Stockton |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | California      | 3000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | Yes 3 or more years | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias               | Type  |
		| HaulIntermodal               | Error |
		| TrailerInterchangeAgreements | Error |
		| VehicleRadius                | Error |
		| FineArt                      | Error |
		| ResidentialMoving            | Error |
		| TeamDriving                  | Error |
		| TravelToMexico               | Error |
		| ClaimCount                   | Error |
		| Chains                       | Error |
		| Biohazard                    | Error |
		| BorrowVehicles               | Error |
		| USDOT                        | Error |
		| CaliOperatingAuth            | Error |
		| TrailerInterchangeAgreements | Help  |
		| VehicleRadius                | Help  |
		| FineArt                      | Help  |
		| ResidentialMoving            | Help  |
		| Biohazard                    | Help  |
		| BorrowVehicles               | Help  |
		| USDOT                        | Help  |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Towing Services In SC
	Given user starts a quote with:
		| Industry        | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Towing Services | 3         | I Work at a Job Site | Vehicles     | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1              | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 7501 Garners Ferry Rd |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Plowing Snow |
		| 1M1AE07Y63W014598 | South Carolina  | 5000          | Yes          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | Yes 3 or more years | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias | Type  |
		| OnCall         | Error |
		| Salvage        | Error |
		| SC-Authority   | Error |
		| SC-Authority   | Help  |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Uber Driver In IL
	Given user starts a quote with:
		| Industry    | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 3         | I Work at a Job Site | Vehicles     | 60629    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City       | Select an Address |
		| 2000                  | Corporation             | 515 W Jefferson Blvd |          | Fort Wayne |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Fare Box |
		| 1M1AE07Y63W014598 | Illinois        | 3000          | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias | Type  |
		| PartyBus       | Error |
		| DayCare        | Error |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Limo Driver In CA
	Given user starts a quote with:
		| Industry    | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Limo Driver | 3         | I Work at a Job Site | Vehicles     | 93644    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 40112 Highway 41 |          | Oakhurst | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure | Parking Address | Vehicle Worth |
		| 2L1MJ5LK0FBL00196 | SUV         | California      | 8000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias | Type  |
		| ServiceAccess  | Error |
		| PUC            | Error |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Art Therapist In IL
	Given user starts a quote with:
		| Industry      | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Art Therapist | 3         | I Work at a Job Site | Vehicles     | 60629    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City    | Select an Address |
		| 2000                  | Corporation             | 40112 Highway 41 |          | Chicago | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Client Locations | Vehicle Worth |
		| 1D4GP24E17B260680 | Illinois        | Yes              | 1200          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias    | Type  |
		| EmergencyResponse | Error |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Hot Shot Trucking In GA
	Given user starts a quote with:
		| Industry          | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 3         | I Work at a Job Site | Vehicles     | 31093    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1        | Address2 | City          | Select an Address |
		| 2000                  | Corporation             | 1879 Watson Bld |          | Warner Robins | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Georgia         | 3000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | Yes 3 or more years | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                 | Answer |
		| Does your business have a USDOT Number?                                                                                  | Yes    |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)? | No     |
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias | Type  |
		| GA-Authority   | Error |

@Unit @CA @Transportation
Scenario: CA Operations Page Help Error Text Roadside Assistance In TX
	Given user starts a quote with:
		| Industry            | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Roadside Assistance | 3         | I Work at a Job Site | Vehicles     | 75662    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1            | Address2 | City    | Select an Address |
		| 2000                  | Corporation             | 906 US Highwy 259 N |          | Kilgore | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Plowing Snow |
		| 1FUBA5CG83LL10209 | Texas           | 9000          | Yes          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | TX      | 08/08/1988 | Yes 3 or more years | No       | 12345678 |
	Then user clicks continue from the Drivers page
	Then user verifies each help and error element on the CA Operations page for the following questions:
		| Question Alias | Type  |
		| TXAuth         | Error |
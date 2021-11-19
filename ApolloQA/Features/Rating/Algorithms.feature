@NoBrowser
Feature: Algorithms
  As a user, I want to test every single algorithm for a given state
  1.)Run e2e quote for the given algorithm or coverage
  2.)Run Engine on this framework (Data.Rating.Engine) to gather expected results
  3.)Compare results from step 1 with results from step 2


# Pre-requisites
# 1.) Keyvault authenticated:  
#     Tools->Options-> Azure Service Authentication
# 2.) SQL whitelisted
#     Login to the environment's SQL locally or through devops
#
#
#
# Instructions to execute
#
# 1.) Switch runsettings to rating.runsettings
#
#
#


@ratingTests
Scenario: Test Rating Algorithm Static Quote
	Given quote with Id 15056 is loaded
	When expected values are gathered
	Then expected values should match the system output

@ratingTests @IL
Scenario: IL - Test Rating Algorithm

	Given quote for 'IL' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples:
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00029               |
	| VA00030               |
	| VA00031               |
	| VA00032               |
	| VA00033               |
	| VA00034               |
	| VA00035               |
	| VA00036               |
	| VA00037               |
	| VA00038               |
	| VA00039               |
	| VA00040               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00045               |
	| VA00046               |
	| VA00047               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00054               |
	| VA00055               |
	| VA00056               |


@ratingTests @SC
Scenario: SC - Test Rating Algorithm 
	Given quote for 'SC' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |
	| VA00075               |
	| VA00076               |
	| VA00077               |
	| VA00078               |
	| VA00079               |
	| VA00080               |
	| VA00081               |
	| VA00082               |
	| VA00083               |
	| VA00084               |
	| VA00085               |
	| VA00086               |
	| VA00087               |
	| VA00088               |

 @ratingTests @CA
Scenario: CA - Test Rating Algorithm 
	Given quote for 'CA' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |

@ratingTests @GA
Scenario: GA - Test Rating Algorithm 
	Given quote for 'GA' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |	 


@ratingTests @State_IN
Scenario: IN - Test Rating Algorithm 
	Given quote for 'IN' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	 | Algorithm or Coverage |
	 | Trailer Interchange   |
	 | In-Tow                |
	 | Rental Reimbursement  |
	 | Cargo Coverage        |
	 | VA00059               |
	 | VA00060               |
	 | VA00061               |
	 | VA00062               |
	 | VA00063               |
	 | VA00064               |
	 | VA00065               |
	 | VA00066               |
	 | VA00067               |
	 | VA00068               |
	 | VA00069               |
	 | VA00041               |
	 | VA00042               |
	 | VA00043               |
	 | VA00044               |
	 | VA00070               |
	 | VA00071               |
	 | VA00072               |
	 | VA00048               |
	 | VA00049               |
	 | VA00050               |
	 | VA00051               |
	 | VA00052               |
	 | VA00053               |
	 | VA00073               |
	 | VA00055               |
	 | VA00074               |

	@ratingTests @State_TN
Scenario: TN - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |

	@ratingTests @State_MO
Scenario: MO - Test Rating Algorithm 
	Given quote for 'MO' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |

		@ratingTests @TX
Scenario: TX - Test Rating Algorithm 
	Given quote for 'TX' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00074               |

	@ratingTests @NV
Scenario: NV - Test Rating Algorithm

	Given quote for 'NV' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples:
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00029               |
	| VA00030               |
	| VA00031               |
	| VA00032               |
	| VA00033               |
	| VA00034               |
	| VA00035               |
	| VA00036               |
	| VA00037               |
	| VA00038               |
	| VA00039               |
	| VA00040               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00045               |
	| VA00046               |
	| VA00047               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00054               |
	| VA00055               |
	| VA00056               |

		@ratingTests @WI
Scenario: WI - Test Rating Algorithm

	Given quote for 'WI' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |

		@ratingTests @AZ
Scenario: AZ - Test Rating Algorithm

	Given quote for 'AZ' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples:
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00029               |
	| VA00030               |
	| VA00031               |
	| VA00032               |
	| VA00033               |
	| VA00034               |
	| VA00035               |
	| VA00036               |
	| VA00037               |
	| VA00038               |
	| VA00039               |
	| VA00040               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00045               |
	| VA00046               |
	| VA00047               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00054               |
	| VA00055               |
	| VA00056               |

	
		@ratingTests @CO
Scenario: CO - Test Rating Algorithm

	Given quote for 'CO' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples:
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |
	| VA00050               |
	| VA00051               |
	| VA00052               |
	| VA00053               |
	| VA00073               |
	| VA00055               |
	| VA00074               |


@ignore
Scenario: Find USDOT with matching criteria
	Then USDOT with criteria is found 

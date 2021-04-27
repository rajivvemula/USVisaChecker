@NoBrowser
Feature: Algorithms

@ratingTests @State_TN
Scenario: Test Rating Algorithm Static Quote
	Given quote with Id 11062 is loaded
	When expected values are gathered
	Then expected values should match the system output


@ratingTests
Scenario: Test Rating Algorithm
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| IL    | VA00029   |
	| IL    | VA00036   |
	| IL    | VA00043   |
	| IL    | VA00054   |

	| SC    | VA00058   |
	| SC    | VA00063   |
	| SC    | VA00043   |
	| SC    | VA00050   |

	| CA    | VA00058   |
	| CA    | VA00065   |
	| CA    | VA00043   |
	| CA    | VA00050   |

	| GA    | VA00058   |
	| GA    | VA00065   |
	| GA    | VA00043   |
	| GA    | VA00050   |

	|IN|UM00026|


@ratingTests @SC
Scenario: SC - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| SC    | VA00058   |
	| SC    | VA00059   |
	| SC    | VA00060   |
	| SC    | VA00061   |
	| SC    | VA00062   |
	| SC    | VA00063   |
	| SC    | VA00064   |
	| SC    | VA00065   |
	| SC    | VA00066   |
	| SC    | VA00067   |
	| SC    | VA00068   |
	| SC    | VA00069   |
	| SC    | VA00041   |
	| SC    | VA00042   |
	| SC    | VA00043   |
	| SC    | VA00044   |
	| SC    | VA00070   |
	| SC    | VA00071   |
	| SC    | VA00072   |
	| SC    | VA00048   |
	| SC    | VA00049   |
	| SC    | VA00050   |
	| SC    | VA00051   |
	| SC    | VA00052   |
	| SC    | VA00053   |
	| SC    | VA00073   |
	| SC    | VA00055   |
	| SC    | VA00074   |
	| SC    | VA00075   |
	| SC    | VA00076   |
	| SC    | VA00077   |
	| SC    | VA00078   |
	| SC    | VA00079   |
	| SC    | VA00080   |
	| SC    | VA00081   |
	| SC    | VA00082   |
	| SC    | VA00083   |
	| SC    | VA00084   |
	| SC    | VA00085   |
	| SC    | VA00086   |
	| SC    | VA00087   |
	| SC    | VA00088   |
 @ratingTests @CA
Scenario: CA - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| CA    | VA00058   |
	| CA    | VA00059   |
	| CA    | VA00060   |
	| CA    | VA00061   |
	| CA    | VA00062   |
	| CA    | VA00063   |
	| CA    | VA00064   |
	| CA    | VA00065   |
	| CA    | VA00066   |
	| CA    | VA00067   |
	| CA    | VA00068   |
	| CA    | VA00069   |
	| CA    | VA00041   |
	| CA    | VA00042   |
	| CA    | VA00043   |
	| CA    | VA00044   |
	| CA    | VA00070   |
	| CA    | VA00071   |
	| CA    | VA00072   |
	| CA    | VA00048   |
	| CA    | VA00049   |
	| CA    | VA00050   |
	| CA    | VA00051   |
	| CA    | VA00052   |
	| CA    | VA00053   |
	| CA    | VA00073   |
	| CA    | VA00055   |
	| CA    | VA00074   |
	| CA    | VA00089   |
@ratingTests @GA
Scenario: GA - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| GA    | VA00058   |
	| GA    | VA00059   |
	| GA    | VA00060   |
	| GA    | VA00061   |
	| GA    | VA00062   |
	| GA    | VA00063   |
	| GA    | VA00064   |
	| GA    | VA00065   |
	| GA    | VA00066   |
	| GA    | VA00067   |
	| GA    | VA00068   |
	| GA    | VA00069   |
	| GA    | VA00041   |
	| GA    | VA00042   |
	| GA    | VA00043   |
	| GA    | VA00044   |
	| GA    | VA00070   |
	| GA    | VA00071   |
	| GA    | VA00072   |
	| GA    | VA00048   |
	| GA    | VA00049   |
	| GA    | VA00050   |
	| GA    | VA00051   |
	| GA    | VA00052   |
	| GA    | VA00053   |
	| GA    | VA00073   |
	| GA    | VA00055   |
	| GA    | VA00074   |


@ratingTests @State_IN
Scenario: IN - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| IN    | VA00058   |
	| IN    | VA00059   |
	| IN    | VA00060   |
	| IN    | VA00061   |
	| IN    | VA00062   |
	| IN    | VA00063   |
	| IN    | VA00064   |
	| IN    | VA00065   |
	| IN    | VA00066   |
	| IN    | VA00067   |
	| IN    | VA00068   |
	| IN    | VA00069   |
	| IN    | VA00041   |
	| IN    | VA00042   |
	| IN    | VA00043   |
	| IN    | VA00044   |
	| IN    | VA00070   |
	| IN    | VA00071   |
	| IN    | VA00072   |
	| IN    | VA00048   |
	| IN    | VA00049   |
	| IN    | VA00050   |
	| IN    | VA00051   |
	| IN    | VA00052   |
	| IN    | VA00053   |
	| IN    | VA00073   |
	| IN    | VA00055   |
	| IN    | VA00074   |

	@ratingTests @State_TN
Scenario: TN - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| TN    | VA00058   |
	| TN    | VA00059   |
	| TN    | VA00060   |
	| TN    | VA00061   |
	| TN    | VA00062   |
	| TN    | VA00063   |
	| TN    | VA00064   |
	| TN    | VA00065   |
	| TN    | VA00066   |
	| TN    | VA00067   |
	| TN    | VA00068   |
	| TN    | VA00069   |
	| TN    | VA00041   |
	| TN    | VA00042   |
	| TN    | VA00043   |
	| TN    | VA00044   |
	| TN    | VA00070   |
	| TN    | VA00071   |
	| TN    | VA00072   |
	| TN    | VA00048   |
	| TN    | VA00049   |
	| TN    | VA00050   |
	| TN    | VA00051   |
	| TN    | VA00052   |
	| TN    | VA00053   |
	| TN    | VA00073   |
	| TN    | VA00055   |
	| TN    | VA00074   |



	@ratingTests @State_MO
Scenario: MO - Test Rating Algorithm 
	Given quote for '<State>' and '<Algorithm>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples: 
	| State | Algorithm |
	| MO    | VA00058   |
	| MO    | VA00059   |
	| MO    | VA00060   |
	| MO    | VA00061   |
	| MO    | VA00062   |
	| MO    | VA00063   |
	| MO    | VA00064   |
	| MO    | VA00065   |
	| MO    | VA00066   |
	| MO    | VA00067   |
	| MO    | VA00068   |
	| MO    | VA00069   |
	| MO    | VA00041   |
	| MO    | VA00042   |
	| MO    | VA00043   |
	| MO    | VA00044   |
	| MO    | VA00070   |
	| MO    | VA00071   |
	| MO    | VA00072   |
	| MO    | VA00048   |
	| MO    | VA00049   |
	| MO    | VA00050   |
	| MO    | VA00051   |
	| MO    | VA00052   |
	| MO    | VA00053   |
	| MO    | VA00073   |
	| MO    | VA00055   |
	| MO    | VA00074   |
@ratingTests
Scenario: Find USDOT with matching criteria
	Then USDOT with criteria is found 

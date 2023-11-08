Feature: COI_WrongPhone_WrongPolicy

User puts in wrong phone number Or wrong policy number wich leads to an Error page

@COI @Unit @NotPP
Scenario: COI - wrong phone number leads to an Error page
	Given user navigates to the COI page
	Then user verifies landing on Get a Certificate of Insurance login page
	Then user fills in the COI Page with these values:
	   | Policy Number | Phone      |
	   | N9PL686470    | 3213213211 |
	Then user verifies the appearance of the COI Error Page


@COI @Unit @NotPP
Scenario: COI - wrong policy number leads to an Error page
	Given user navigates to the COI page
	Then user verifies landing on Get a Certificate of Insurance login page
	Then user fills in the COI Page with these values:
	   | Policy Number | Phone      |
	   | N9PL686471    | 5025920888 |
	Then user verifies the appearance of the COI Error Page	

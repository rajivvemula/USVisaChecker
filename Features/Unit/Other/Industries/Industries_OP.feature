Feature: Industries_OP
Page validation for following Industries pages:
- Office
- Personal Trianer
- Pet Services
- Photographer
- Printing & copying
- Professional Installantion

@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages O_P
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                                      | industry                         | coverages                   | links |
	| who-we-insure/office-insurance                           | Office                           | WC;BOP;CA;Cyber;Umbrella    |       |
	| who-we-insure/personal-trainer-insurance                 | Personal trainer                 |                             |       |
	| who-we-insure/pet-services-insurance                     | Pet Services                     | WC;GL;BOP;CA;Cyber;Umbrella |       |
	| who-we-insure/photography-videography-services-insurance | Photography Videography Services | WC;GL;BOP;CA;Cyber;Umbrella |       |
	| who-we-insure/printing-copying-companies-insurance       | Printing Copying Companies       | WC;GL;BOP;CA;Cyber;Umbrella |       |
	| who-we-insure/professional-installation-insurance        | Professional Installation        | WC;GL;BOP;CA;Cyber;Umbrella |       |

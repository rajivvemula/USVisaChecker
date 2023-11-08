Feature: LandingPagesLandOnMadLibs

Verifying whether the Landing pages land on MadLibs
And after user selects the LOB verifying the About You Page.

@LandingPages @Regression @CT @NotPP
Scenario Outline: Landing Pages Land on MadLibs

	Given user has navigated to the following Landing Page URL to get the quote: <LandingPage>
	Then user verifies the following title for the Landing Page: <Title>

	Given user starts a quote on the Landing Page with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code |
		| Actor    | 11        | I Lease a Space From Others |              | 06457    |
	Then user will land on madlibs path with recommendation view as <View> and 'Available and Recommended' LOB as 'WC'

Examples:
	| LandingPage                                       | Title                                                   | View   |
	| get-a-quote/apartment-business-insurance          | Apartment Owners Insurance                              | Simple |
	| get-a-quote/auto-body-shop-business-insurance     | Auto Body Shop Insurance                                | Simple |
	| get-a-quote/auto-detailing-business-insurance     | Auto Detailing Business Insurance                       | Simple |
	| get-a-quote/auto-repair-shop-business-insurance   | Auto Repair Shop Insurance                              | Simple |
	| get-a-quote/bakery-business-insurance             | Bakery Shop Insurance                                   | Simple |
	| get-a-quote/berkshire-hathaway-business-insurance | Berkshire Hathaway Workers’ Compensation Insurance      | Pie    |
	| get-a-quote/berkshire-hathaway-insurance-b        | biBERK: Business Insurance From Berkshire Hathaway      | Simple |
	| get-a-quote/beverage-business-insurance           | Beverage Stores & Food Services Insurance               | Simple |
	| get-a-quote/biberk-business-insurance             | biBERK Business Insurance                               | Simple |
	| get-a-quote/box-truck-insurance                   | Box Truck Commercial Auto Insurance                     | Simple |
	| get-a-quote/business-insurance                    | Get Business Insurance in Minutes                       | Simple |
	| get-a-quote/certificate-of-insurance              | Instant Certificate of Insurance                        | Simple |
	| get-a-quote/cleaning-business-insurance           | Cleaning Business Insurance                             | Pie    |
	| get-a-quote/commercial-auto                       | Commercial Auto Insurance                               | Simple |
	| get-a-quote/commercial-insurance                  | Commercial Insurance for Small Businesses               | Simple |
	| get-a-quote/commercial-trucking-insurance         | Commercial Trucking Insurance                           | Simple |
	| get-a-quote/commercial-umbrella-insurance         | Commercial Umbrella Insurance                           | Simple |
	| get-a-quote/compete-business-insurance            | biBERK Business Insurance: No Middle Man Fees or Hassle | Simple |
	| get-a-quote/condominiums-business-insurance       | Condo & Townhouse Insurance                             | Simple |
	| get-a-quote/confectionery-business-insurance      | Confectionery Business Insurance                        | Simple |
	| get-a-quote/construction-business-insurance       | Construction Business Insurance                         | Simple |
	| get-a-quote/contractor-business-insurance         | Contractor Business Insurance                           | Simple |
	| get-a-quote/contractors                           | Contractors Insurance                                   | Pie    |
	| get-a-quote/cover-your-business-insurance         | Cover Your Business in Minutes                          | Simple |
	| get-a-quote/cpa-bookkeepers-business-insurance    | CPA & Bookeeper Insurance                               | Simple |
	| get-a-quote/delivery-services-insurance           | Delivery Services Insurance                             | Simple |
	| get-a-quote/electrician-business-insurance        | Electrician Insurance                                   | Simple |
	| get-a-quote/estheticians-business-insurance       | Esthetician Insurance                                   | Simple |
	| get-a-quote/garage-keepers-insurance              | Garage Keepers Insurance                                | Simple |
	| get-a-quote/gas-station-insurance                 | Gas Station Owner's Insurance                           | Simple |
	| get-a-quote/geico-workers-compensation-insurance  | Workers’ Compensation Insurance                         | Simple |
	| get-a-quote/general-liability-insurance           | General Liability Insurance                             | Pie    |
	| get-a-quote/hazard-insurance                      | Business Hazard Insurance                               | Simple |
	| get-a-quote/handyman-business-insurance           | Handyman Business Insurance                             | Simple |
	| get-a-quote/hotel-business-insurance              | Hotel Owner's Insurance                                 | Simple |
	| get-a-quote/hvac-contractors-business-insurance   | HVAC Contractors Insurance                              | Simple |
	| get-a-quote/landlord-insurance                    | Landlord Insurance                                      | Simple |
	| get-a-quote/landscaper-business-insurance         | Lawn Care & Landscaping Insurance                       | Simple |
	| get-a-quote/legal-malpractice-insurance           | Legal Malpractice Insurance                             | Simple |
	| get-a-quote/llc-business-insurance                | LLC Business Insurance                                  | Simple |
	| get-a-quote/made-for-you                          | Start Your Quote Now                                    | Simple |
	| get-a-quote/media-liability-insurance             | Media Liability Insurance                               | Simple |
	| get-a-quote/office-business-insurance             | Office Building Insurance                               | Simple |
	| get-a-quote/painters-business-insurance           | Painters Business Insurance                             | Simple |
	| get-a-quote/passenger-commercial-auto             | Passenger Transportation Commercial Auto Insurance      | Simple |
	| get-a-quote/photographers-business-insurance      | Photographer Insurance                                  | Simple |
	| get-a-quote/property-insurance                    | Business Owners (BOP) Insurance                         | Simple |
	| get-a-quote/rental-condo-townhouse-insurance      | Rental Condo & Townhouse Owner's Insurance              | Simple |
	| get-a-quote/rental-dwelling-insurance             | Rental Dwelling Owner's Insurance                       | Simple |
	| get-a-quote/rental-property-insurance             | Rental Property Owner's Insurance                       | Simple |
	| get-a-quote/repeat-business-insurance             | Save Up To 20% On Your Business Insurance               | Simple |
	| get-a-quote/restaurant-business-insurance         | Restaurant Insurance                                    | Simple |
	| get-a-quote/retail-business-insurance             | Retail Shop Insurance                                   | Simple |
	| get-a-quote/salon-cosmetology-business-insurance  | Salon & Cosmetology Insurance                           | Simple |
	| get-a-quote/second-opinion                        | Small business insurance \| biBERK \| Second Opinion    | Simple |
	| get-a-quote/referred-thankyou                     | Small Business Insurance                                | Simple |
	| get-a-quote/security-company                      | Security Company Insurance                              | Simple |
	| get-a-quote/small-business-insurance              | Small Business Insurance Customized for Your Company    | Simple |
	| get-a-quote/townhouse-business-insurance          | Townhouse Association Insurance                         | Simple |
	| get-a-quote/contractor-commercial-auto            | Contractor Commercial Auto Insurance                    | Simple |
	| get-a-quote/trucking-commercial-auto              | For-Hire Trucking Commercial Auto Insurance             | Simple |
	| get-a-quote/cyber-insurance                       | Cyber Insurance                                         | Simple |
#	| get-a-quote/fill-a-quote                          | Small Business Insurance                                | Simple | #The UI is refreshing after clicking on Let's Go button
	| get-a-quote/moving-company-insurance              | Get Moving Business Insurance in Minutes                | Simple |

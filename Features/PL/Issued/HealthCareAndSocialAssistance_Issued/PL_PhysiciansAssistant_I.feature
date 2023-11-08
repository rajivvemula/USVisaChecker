Feature: PL_PhysiciansAssistant_I

Issuing PL policies for Physicians Assistant (PA) customers in Texas. Each scenario verifies that one or more of the questions answered on the business details
page appears and is correct on the summary page. 

@Regression @PL @Health @Issued @TX
Scenario: PL Physicians Assistant issued policy in TX
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA) | 0         | I Work at a Job Site |              | 77002    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | Business Address | DBA |
		| Individual/Sole Proprietor | 1000 Bagby St    | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                                            | Answer                 |
		| What year was your business started?                                                                                | 2020                   |
		| How many healthcare professionals work for your business?                                                           | 1                      |
		| Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)? | Independent Contractor |
		| Have you obtained this professional healthcare designation within the last two years?                               | Yes                    |
		| When did you graduate or obtain this designation?                                                                   |                        |
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No                |
		| Do you assist with any surgeries?                                                                                                                                                                                                                      | No                |
		| Which of these areas do you practice?                                                                                                                                                                                                                  | None of the above |
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No                |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No                |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer               |
		| First Name             | Physician's          |
		| Last Name              | Assistant            |
		| Address                | 507 Clay St          |
		| Apt/Suite              |                      |
		| City                   | Houston              |
		| Use as Mailing Address | Yes                  |
		| Email                  | accountant2@biz2.com |
		| Business Phone         | 1254875126           |
		| Ext                    |                      |
		| Website/Social         |                      |
		| Have Broker            | No                   |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Tester EJ           |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 12 Bargaintown St   |
		| ZIP Code       | 58108               |
		| City           | Fargo               |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: GL

@Regression @PL @Health @Issued @TX
Scenario: PA - Individual Employee with no healthcare designation
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA) | 0         | I Work at a Job Site |              | 77002    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | Business Address | DBA |
		| Individual/Sole Proprietor | 1000 Bagby St    | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                                            | Answer                          |
		| What year was your business started?                                                                                | 2020                            |
		| How many healthcare professionals work for your business?                                                           | 1                               |
		| Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)? | Employee of Health Organization |
		| Have you obtained this professional healthcare designation within the last two years?                               | No                              |
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No                |
		| Do you assist with any surgeries?                                                                                                                                                                                                                      | No                |
		| Which of these areas do you practice?                                                                                                                                                                                                                  | None of the above |
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No                |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No                |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer               |
		| First Name             | Physician's          |
		| Last Name              | Assistant            |
		| Address                | 507 Clay St          |
		| Apt/Suite              |                      |
		| City                   | Houston              |
		| Use as Mailing Address | Yes                  |
		| Email                  | accountant2@biz2.com |
		| Business Phone         | 1254875126           |
		| Ext                    |                      |
		| Website/Social         |                      |
		| Have Broker            | No                   |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Tester EJ           |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 12 Bargaintown St   |
		| ZIP Code       | 58108               |
		| City           | Fargo               |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: GL

@Regression @PL @Health @Issued @TX
Scenario: PA - Corporation with health students and professionals
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA) | 7         | I Work at a Job Site |              | 77002    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | PA Health        | 1000 Bagby St    | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2020   |
		| How many healthcare professionals work for your business? | 1      |
		| How many health students work for your business?          | 1      |
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No                |
		| Do you assist with any surgeries?                                                                                                                                                                                                                      | No                |
		| Which of these areas do you practice?                                                                                                                                                                                                                  | None of the above |
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No                |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No                |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer               |
		| First Name             | Physician's          |
		| Last Name              | Assistant            |
		| Address                | 507 Clay St          |
		| Apt/Suite              |                      |
		| City                   | Houston              |
		| Use as Mailing Address | Yes                  |
		| Email                  | accountant2@biz2.com |
		| Business Phone         | 1254875126           |
		| Ext                    |                      |
		| Website/Social         |                      |
		| Have Broker            | No                   |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Tester EJ           |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 12 Bargaintown St   |
		| ZIP Code       | 58108               |
		| City           | Fargo               |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC,GL

@Regression @PL @Health @Issued @TX
Scenario: PA - Corporation without healthcare students
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Physicians Assistant (PA) | 7         | I Work at a Job Site |              | 77002    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | PA               | 1000 Bagby St    | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2020   |
		| How many healthcare professionals work for your business? | 1      |
		| How many health students work for your business?          | 0      |
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer            |
		| Are any business owner(s) or staff an MD (Medical Doctor)?                                                                                                                                                                                             | No                |
		| Do you assist with any surgeries?                                                                                                                                                                                                                      | No                |
		| Which of these areas do you practice?                                                                                                                                                                                                                  | None of the above |
		| Do you administer or assist with general anesthesia or deep sedation?                                                                                                                                                                                  | No                |
		| Do you practice any radiology or medical dosimetry?                                                                                                                                                                                                    | No                |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer               |
		| First Name             | Physician's          |
		| Last Name              | Assistant            |
		| Address                | 507 Clay St          |
		| Apt/Suite              |                      |
		| City                   | Houston              |
		| Use as Mailing Address | Yes                  |
		| Email                  | accountant2@biz2.com |
		| Business Phone         | 1254875126           |
		| Ext                    |                      |
		| Website/Social         |                      |
		| Have Broker            | No                   |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Tester EJ           |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 12 Bargaintown St   |
		| ZIP Code       | 58108               |
		| City           | Fargo               |
		| Phone          | 321-321-3221        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC,GL
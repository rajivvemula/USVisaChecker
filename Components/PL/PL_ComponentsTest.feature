#@casey
#@newWindow
#Feature: PL_ComponentsTest
#
#
#Scenario: PL Components Test - Granular Steps - Software Development
#	Given user starts a new quote with below values
#	| Industry             | Employees | Location                              | ZIP Code | LOB                          |
#	| Software Development | 0         | I Run My Business From Property I Own | 18704    | Professional Liability (E&O) |
#	Then URL contains get-pl/introduction
#	And page header is A Quick Introduction
#	When user enters following values
#	| Display Text                           | Field Type      | Value          |
#	| How is your business structured?       | pl-singleselect | Corporation    |
#	| What's the name of your business?      | pl-input        | Casey Test Org |
#	| Do you do business under another name? | pl-singleselect | No             |
#	Then the following fields have values
#	| Display Text                           | Field Type      | Value          |
#	| How is your business structured?       | pl-singleselect | Corporation    |
#	| What's the name of your business?      | pl-input        | Casey Test Org |
#	| Do you do business under another name? | pl-singleselect | No             |
#	When user clicks Let's Go! pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/business
#	And page header is Business Details
#	When user enters following values
#	| Display Text                                 | Field Type | Value                |
#	| What year was your business started?         | pl-input   | twenty twenty        |
#	| What is your estimated gross annual revenue? | pl-input   | two thousand dollars |
#	Then the following fields display error text
#	| Display Text                                 | Field Type | Error Text                                                                      |
#	| What year was your business started?         | pl-input   | Please enter the year you started your business. Must be between 1900 and 2021. |
#	| What is your estimated gross annual revenue? | pl-input   | Please answer to continue.                                                      |
#	When user enters following values
#	| Display Text                                 | Field Type | Value |
#	| What year was your business started?         | pl-input   | 2020  |
#	| What is your estimated gross annual revenue? | pl-input   | 65000 |
#	And user clicks Let's Continue! pl-button
#	Then the following fields display error text
#	| Display Text                                              | Field Type      | Error Text                 |
#	| Do you use a written contract or statement of work (SOW)? | pl-singleselect | Please answer to continue. |
#	When user enters following values
#	| Display Text                                              | Field Type      | Value |
#	| Do you use a written contract or statement of work (SOW)? | pl-singleselect | Never |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/coverage
#	And page header is Coverage Details
#	When user enters default date for datepicker When should your policy start?
#	When user enters following values
#	| Display Text                                                                           | Field Type      | Value        |
#	| Do you currently have a Professional Liability (E&O) policy in effect?                 | pl-singleselect | Yes          |
#	| Does your current policy have a retroactive date?                                      | pl-singleselect | I Don't Know |
#	| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | pl-singleselect | 0            |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then page header is Your Services
#	When user enters following values
#	| Display Text                                                                 | Field Type      | Value |
#	| Can users upload content to websites you own or operate?                     | pl-singleselect | No    |
#	| Do you develop software that provides or assists with medical diagnoses?     | pl-singleselect | No    |
#	| Do you develop software that aids architects or engineers in product design? | pl-singleselect | No    |
#	| Do you electronically store private data?                                    | pl-singleselect | No    |
#	| Do you design, integrate, or maintain networks for clients?                  | pl-singleselect | No    |
#	| Do you provide website hosting or domain registration?                       | pl-singleselect | No    |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then page header is Contact Details
#	When user enters complex input Contact Name
#	| First name | Last name |
#	| Casey      | Klaips    |
#	And user enters complex input Business Address
#	| Street address    | Apartment, suite, unit, building, floor, c/o etc. |
#	| 101 Courtdale Ave | Apt 3                                             |
#	And user enters following values
#	| Display Text                 | Field Type | Value             |
#	| How can we connect with you? | pl-input   | email@website.com |
#	| Business Phone               | pl-input   | 5704071234        |
#	| Business Website             | pl-input   | website.com       |
#	And user clicks Let's Wrap This Up pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/summary
#	And page header is Your Summary
#	When user clicks View Quote pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/quote
#	And page header is Your Quote
#	When user clicks purchase for Standard plan
#	And user waits for loading to complete
#	Then page header is Purchase Your Plan
#	When user enters payment information
#	| Placeholder Text   | Value            |
#	| Your name          | Casey Klaips     |
#	| Credit card number | 4111111111111111 |
#	| MM/YY              | 0223             |
#	And user checks checkbox TermsAgreed
#	And user clicks button with class payment-btn
#	And user waits for loading to complete
#	Then URL contains get-pl/thankyou
#	And page header is Thank You!
#	When user prints out PL policy number
#
#Scenario: PL Components Test - Granular Steps - Lawyer
#	Given user starts a new quote with below values
#	| Industry | Employees | Location                    | ZIP Code | LOB                          |
#	| Lawyer   | 3         | I Lease a Space From Others | 18704    | Professional Liability (E&O) |
#	Then URL contains get-pl/introduction
#	And page header is A Quick Introduction
#	When user enters following values
#	| Display Text                           | Field Type      | Value          |
#	| How is your business structured?       | pl-singleselect | Corporation    |
#	| What's the name of your business?      | pl-input        | Casey Test Org |
#	| Do you do business under another name? | pl-singleselect | No             |
#	When user clicks Let's Go! pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/business
#	And page header is Business Details
#	When user enters following values
#	| Display Text                                                   | Field Type      | Value |
#	| What year was your business started?                           | pl-input        | 2020  |
#	| How many attorneys does your firm have?                        | pl-input        | 2     |
#	| Do you use any of counsel or independent contractor attorneys? | pl-singleselect | No    |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/coverage
#	And page header is Coverage Details
#	When user enters default date for datepicker When should your policy start?
#	When user enters following values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then page header is Your Services
#	When user enters following values
#	| Display Text                                                                                     | Field Type      | Value                         |
#	| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years? | pl-singleselect | No                            |
#	| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?        | pl-singleselect | No                            |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Family                        |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Real Estate                   |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Environmental                 |
#	| Do you handle divorce cases?                                                                     | pl-singleselect | Some – less than 25% of cases |
#	| Does your business own a Title Agency?                                                           | pl-singleselect | No                            |
#	| Do you practice in Securities Law (financial transactions)?                                      | pl-singleselect | No                            |
#	| Have any members of your firm been suspended or disbarred in the past 5 years?                   | pl-singleselect | No                            |
#	| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?    | pl-singleselect | No                            |
#	| Would you ever serve as a trustee or executor?                                                   | pl-singleselect | No                            |
#	And user clicks Let's Continue! pl-button
#	And user waits for loading to complete
#	Then page header is Contact Details
#	When user enters complex input Contact Name
#	| First name | Last name |
#	| Casey      | Klaips    |
#	And user enters complex input Business Address
#	| Street address | Apartment, suite, unit, building, floor, c/o etc. |
#	| 101 Shady Lane | Apt 2A                                            |
#	And user enters following values
#	| Display Text                 | Field Type | Value             |
#	| How can we connect with you? | pl-input   | email@website.com |
#	| Business Phone               | pl-input   | 5704071234        |
#	| Business Website             | pl-input   | website.com       |
#	And user clicks Let's Wrap This Up pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/summary
#	And page header is Your Summary
#	When user clicks View Quote pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/quote
#	And page header is Your Quote
#	When user clicks purchase for Your Plan plan
#	And user waits for loading to complete
#	Then URL contains get-pl/attorneys
#	And page header is Almost Done!
#	When user enters complex inputs Attorney Name
#	| First name | Last name |
#	| Casey      | Klaips    |
#	| Bob        | Loblaw    |
#	And user clicks Continue to Purchase pl-button
#	And user waits for loading to complete
#	Then URL contains get-pl/payment
#	And page header is Purchase Your Plan
#	When user enters payment information
#	| Placeholder Text   | Value            |
#	| Your name          | Casey Klaips     |
#	| Credit card number | 4111111111111111 |
#	| MM/YY              | 0223             |
#	And user checks checkbox TermsAgreed
#	And user clicks button with class payment-btn
#	And user waits for loading to complete
#	Then URL contains get-pl/thankyou
#	And page header is Thank You!
#	When user prints out PL policy number
#
#
#Scenario: PL - Software Development - Purchase Policy
#	Given user starts a new quote with below values
#	| Industry             | Employees | Location                              | ZIP Code | LOB                          |
#	| Software Development | 0         | I Run My Business From Property I Own | 18704    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type | Business Name  |
#	| Corporation   | Casey Test Org |
#	And user completes PL Business Page with below values
#	| Display Text                                              | Field Type      | Value |
#	| What year was your business started?                      | pl-input        | 2020  |
#	| What is your estimated gross annual revenue?              | pl-input        | 65000 |
#	| Do you use a written contract or statement of work (SOW)? | pl-singleselect | Never |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                                 | Field Type      | Value |
#	| Can users upload content to websites you own or operate?                     | pl-singleselect | No    |
#	| Do you develop software that provides or assists with medical diagnoses?     | pl-singleselect | No    |
#	| Do you develop software that aids architects or engineers in product design? | pl-singleselect | No    |
#	| Do you electronically store private data?                                    | pl-singleselect | No    |
#	| Do you design, integrate, or maintain networks for clients?                  | pl-singleselect | No    |
#	| Do you provide website hosting or domain registration?                       | pl-singleselect | No    |
#	And user completes PL Contact Page with random values
#	And user views quote and selects Standard plan
#	And user purchases policy with default payment info
#	When user prints out PL policy number
#
#Scenario: PL - Loss Control Inspector - Purchase Policy
#	Given user starts a new quote with below values
#	| Industry               | Employees | Location             | ZIP Code | LOB                          |
#	| Loss Control Inspector | 0         | I Work at a Job Site | 18704    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type    | Business Name    |
#	| Sub-Chapter Corp | Loss Control Org |
#	And user completes PL Business Page with below values
#	| Display Text                                              | Field Type      | Value |
#	| What year was your business started?                      | pl-input        | 2020  |
#	| What is your estimated gross annual revenue?              | pl-input        | 67000 |
#	| Do you use a written contract or statement of work (SOW)? | pl-singleselect | Never |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                                         | Field Type      | Value |
#	| Do you advise on Geotechnical, Soils, or Structural Engineering?                     | pl-singleselect | No    |
#	| Do you give advice on nuclear materials?                                             | pl-singleselect | No    |
#	| Do you directly perform physical work for others?                                    | pl-singleselect | No    |
#	| Do you design amusement rides or playgrounds?                                        | pl-singleselect | No    |
#	| Do client deliverables undergo a peer review?                                        | pl-singleselect | Never |
#	| Do you advise on the contamination risk, presence of, or clean up of any pollutants? | pl-singleselect | No    |
#	| Do you offer asbestos evaluation or abatement services?                              | pl-singleselect | No    |
#	| Do you design bridges?                                                               | pl-singleselect | No    |
#	| Do you provide emergency response services?                                          | pl-singleselect | No    |
#	| Do you provide home inspection services?                                             | pl-singleselect | No    |
#	And user completes PL Contact Page with random values
#	And user views quote and selects Your Plan plan
#	And user purchases policy with default payment info
#	When user prints out PL policy number
#
#Scenario: PL - Loss Control Inspector - Decline (nuclear)
#	Given user starts a new quote with below values
#	| Industry               | Employees | Location             | ZIP Code | LOB                          |
#	| Loss Control Inspector | 0         | I Work at a Job Site | 18704    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type    | Business Name    |
#	| Sub-Chapter Corp | Loss Control Org |
#	And user completes PL Business Page with below values
#	| Display Text                                              | Field Type      | Value |
#	| What year was your business started?                      | pl-input        | 2020  |
#	| What is your estimated gross annual revenue?              | pl-input        | 67000 |
#	| Do you use a written contract or statement of work (SOW)? | pl-singleselect | Never |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                                         | Field Type      | Value |
#	| Do you advise on Geotechnical, Soils, or Structural Engineering?                     | pl-singleselect | No    |
#	| Do you give advice on nuclear materials?                                             | pl-singleselect | Yes   |
#	| Do you directly perform physical work for others?                                    | pl-singleselect | No    |
#	| Do you design amusement rides or playgrounds?                                        | pl-singleselect | No    |
#	| Do client deliverables undergo a peer review?                                        | pl-singleselect | Never |
#	| Do you advise on the contamination risk, presence of, or clean up of any pollutants? | pl-singleselect | No    |
#	| Do you offer asbestos evaluation or abatement services?                              | pl-singleselect | No    |
#	| Do you design bridges?                                                               | pl-singleselect | No    |
#	| Do you provide emergency response services?                                          | pl-singleselect | No    |
#	| Do you provide home inspection services?                                             | pl-singleselect | No    |
#	And user completes PL Contact Page with random values
#	Then URL contains get-pl/decline
#	And page header is Coverage Declined
#	When user prints out PL quote number
#
#Scenario: PL - Lawyer - Purchase Policy
#	Given user starts a new quote with below values
#	| Industry | Employees | Location                    | ZIP Code | LOB                          |
#	| Lawyer   | 3         | I Lease a Space From Others | 18704    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type | Business Name     |
#	| Corporation   | Sample Lawyer Org |
#	And user completes PL Business Page with below values
#	| Display Text                                                   | Field Type      | Value |
#	| What year was your business started?                           | pl-input        | 2020  |
#	| How many attorneys does your firm have?                        | pl-input        | 2     |
#	| Do you use any of counsel or independent contractor attorneys? | pl-singleselect | No    |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                                                     | Field Type      | Value                         |
#	| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years? | pl-singleselect | No                            |
#	| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?        | pl-singleselect | No                            |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Family                        |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Real Estate                   |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Environmental                 |
#	| Do you handle divorce cases?                                                                     | pl-singleselect | Some – less than 25% of cases |
#	| Does your business own a Title Agency?                                                           | pl-singleselect | No                            |
#	| Do you practice in Securities Law (financial transactions)?                                      | pl-singleselect | No                            |
#	| Have any members of your firm been suspended or disbarred in the past 5 years?                   | pl-singleselect | No                            |
#	| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?    | pl-singleselect | No                            |
#	| Would you ever serve as a trustee or executor?                                                   | pl-singleselect | No                            |
#	And user completes PL Contact Page with random values
#	And user views quote and selects Your Plan plan
#	Then URL contains get-pl/attorneys
#	And page header is Almost Done!
#	When user enters complex inputs Attorney Name
#	| First name | Last name |
#	| Bobby      | Newport   |
#	| Hello      | There     |
#	And user clicks Continue to Purchase pl-button
#	And user waits for loading to complete
#	Given user purchases policy with default payment info
#	Then URL contains get-pl/thankyou
#	And page header is Thank You!
#	When user prints out PL policy number
#
#Scenario: PL - Hair Salon - Referred (low revenue per employee)
#	Given user starts a new quote with below values
#	| Industry   | Employees | Location                         | ZIP Code | LOB                          |
#	| Hair Salon | 7         | I Run My Business Out of My Home | 18702    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type               | Business Name         |
#	| Limited Liability Co. (LLC) | Sample Hair Salon Org |
#	And user completes PL Business Page with below values
#	| Display Text                                 | Field Type | Value |
#	| What year was your business started?         | pl-input   | 2019  |
#	| What is your estimated gross annual revenue? | pl-input   | 90000 |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                               | Field Type      | Value |
#	| Do you provide body massage services?                                      | pl-singleselect | No    |
#	| Do you provide tattoo services?                                            | pl-singleselect | No    |
#	| Do you operate tanning beds?                                               | pl-singleselect | No    |
#	| Do you provide acupuncture, facial injection, or laser treatment services? | pl-singleselect | No    |
#	| Do you do keratin hair-straightening procedures or brazilian blowouts?     | pl-singleselect | No    |
#	| Do you do body piercings?                                                  | pl-singleselect | No    |
#	And user completes PL Contact Page with random values
#	Then URL contains get-pl/referred/pl
#	And page header is Your Quote is Nearly Ready
#	When user prints out PL quote number
#
#Scenario: PL - Public Notary - Referred (number of claims)
#	Given user starts a new quote with below values
#	| Industry      | Employees | Location                    | ZIP Code | LOB                          |
#	| Public Notary | 0         | I Lease a Space From Others | 18702    | Professional Liability (E&O) |
#	When user enters following values
#	| Display Text                     | Field Type      | Value                      |
#	| How is your business structured? | pl-singleselect | Individual/Sole Proprietor |
#	And user enters complex input What's the name you do business under?
#	| Insured first name | Insured last name |
#	| Joe                | Notario           |
#	And user enters following values
#	| Display Text                           | Field Type      | Value |
#	| Do you do business under another name? | pl-singleselect | No    |
#	And user clicks Let's Go! pl-button
#	Given user completes PL Business Page with below values
#	| Display Text                                 | Field Type | Value  |
#	| What year was your business started?         | pl-input   | 2015   |
#	| What is your estimated gross annual revenue? | pl-input   | 100000 |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                                           | Field Type      | Value        |
#	| Do you currently have a Professional Liability (E&O) policy in effect?                 | pl-singleselect | Yes          |
#	| Does your current policy have a retroactive date?                                      | pl-singleselect | I Don't Know |
#	| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | pl-singleselect | 5+           |
#	And user completes Customize Page with below values
#	| Display Text                                                                  | Field Type      | Value |
#	| Do you provide financial investment advice?                                   | pl-singleselect | Yes   |
#	| Do you provide advice or services that require a Certified Public Accountant? | pl-singleselect | Yes   |
#	| Do you collect private data?                                                  | pl-singleselect | No    |
#	| Do you sell any Property & Casualty Insurance?                                | pl-singleselect | No    |
#	| Do you sell any health or life insurance?                                     | pl-singleselect | No    |
#	| Do you provide remote or electronic notary services?                          | pl-singleselect | No    |
#	| Do you provide loan document notarization services?                           | pl-singleselect | Yes   |
#	And user completes PL Contact Page with random values
#	Then URL contains get-pl/referred/pl
#	And page header is Your Quote is Nearly Ready
#	When user prints out PL quote number
#
#Scenario: PL - Lawyer - Decline (mass tort)
#	Given user starts a new quote with below values
#	| Industry | Employees | Location                    | ZIP Code | LOB                          |
#	| Lawyer   | 0         | I Lease a Space From Others | 18704    | Professional Liability (E&O) |
#	And user completes PL Introduction Page with below values
#	| Business Type | Business Name     |
#	| Corporation   | Sample Lawyer Org |
#	And user completes PL Business Page with below values
#	| Display Text                                                   | Field Type      | Value |
#	| What year was your business started?                           | pl-input        | 2012  |
#	| How many attorneys does your firm have?                        | pl-input        | 1     |
#	| Do you use any of counsel or independent contractor attorneys? | pl-singleselect | No    |
#	And user completes PL Coverage Page with below values
#	| Display Text                                                            | Field Type      | Value |
#	| Do you currently have a Professional Liability (E&O) policy in effect?  | pl-singleselect | No    |
#	| Have you had a Professional Liability (E&O) policy in the last 3 years? | pl-singleselect | No    |
#	And user completes Customize Page with below values
#	| Display Text                                                                                     | Field Type      | Value        |
#	| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years? | pl-singleselect | No           |
#	| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?        | pl-singleselect | No           |
#	| Do you practice in these areas of law?                                                           | pl-multiselect  | Bankruptcy   |
#	| Do you practice in Securities Law (financial transactions)?                                      | pl-singleselect | No           |
#	| Have any members of your firm been suspended or disbarred in the past 5 years?                   | pl-singleselect | No           |
#	| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?    | pl-singleselect | Yes          |
#	| Describe the mass tort or class action case(s)                                                   | pl-input        | We got sued. |
#	| Would you ever serve as a trustee or executor?                                                   | pl-singleselect | No           |
#	And user completes PL Contact Page with random values
#	Then URL contains get-pl/decline
#	And page header is Coverage Declined
#	When user prints out PL quote number
#
#@ignore
#Scenario: Helper Step
#	When user enters the value: <display text>, <field type>, <value>
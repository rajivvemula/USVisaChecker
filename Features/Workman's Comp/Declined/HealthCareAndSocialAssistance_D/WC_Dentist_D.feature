Feature: WC_Dentist_D
Keyword: Dentist
Ineligible quote - response to carrier question (because first name and last name are longer than 50 characters) ;
"The field FirstName must be a string with a maximum length of 50.
The field LastName must be a string with a maximum length of 50."
Zip Code: 18702
City: Wilkes-Barre
Employee option: 3
Business Operation: I Lease a Space From Others
Years in Business: 4
Payroll: 200000
Entity type: Individual/Sole Proprietor

Scenario: WC Dentist gets declinedgets declined because first name and last name are longer than 50 characters
  Given user starts a quote with:
	| Industry | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Dentist  | 3         | I Run My Business From Property I Own |              | 18702    | WC  |

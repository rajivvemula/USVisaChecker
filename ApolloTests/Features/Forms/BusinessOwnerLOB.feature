@NoBrowser
Feature: BusinessOwnerLOB

@formsTests
Scenario: Check System for untested forms
	Given current tested forms are loaded from Forms Generate Feature
	When compared to the forms in the system
	Then output forms that are existing in the system but not in Forms Generate

#Scenario tests to make sure every form in the system can be generated successfully by manually generating it.
# 1.) using the code below, it finds in Data.Form.Forms.json the related form object
# 2.) the above object should contain the condition which must be met in order to successfully generate the specific form
# 3.) using Data.Form.Condition, it will find a valid policy for which the condition denoted is true
# 4.) it will send a RestAPI Request to the Apollo endpoint in order to generate the specific form in the policy returned above
# 5.) it will retireve documents in the mentioned policy and look for the previously generated document
# 6.) it will request the actual document, parse the PDF and make sure it's not blank or Empty

@formsTests
Scenario: Form can be generated LineId_3
	Given condition for form with code '<code>' and '<name>' and lineId=3 is met
	When user attempts to generate form
	Then form should be generated successfully
	And form shouldn't be blank

	Examples:
	| code       | name                                                                                                                                             |
	| M5144a     | Waiver Of Transfer Of Rights Of Recovery Against Others To Us                                                                                    |
	| M5492      | Arizona Uninsured and Underinsured Motorists Coverage Selection Form                                                                             |
	| M5879      | InTow Coverage With Optional Garagekeepers Additional Coverage Comprehensive                                                                     |
	| CA0117     | Wisconsin Changes                                                                                                                                |
	| B0007      | Proof of Mailing                                                                                                                                 |
	| B0008      | Mailing Cover Sheet - Over 5                                                                                                                     |
	| B0009      | Mailing Cover Sheet - 5 and Under                                                                                                                |
	| OS32       | Endorsement To Liability Insurance Policy For Vehicles Operating with a Special Hauling Permit                                                   |
	| CO4932b    | Colorado ID Card                                                                                                                                 |
	| (E)GU402d  | Notice of Cancellation, Nonrenewal, Declination - CO                                                                                             |
	| M5908      | Colorado Uninsured Motorists Coverage - Bodily Injury                                                                                            |
	| ILU063     | Colorado Rejection of Medical Payments Coverage                                                                                                  |
	| ILU042     | Colorado Bodily Injury Uninsured Motorists Coverage SelectionRejection                                                                           |
	| CA2126     | Colorado Uninsured Motorists Coverage - Property Damage                                                                                          |
	| (E)GU6639s | Notice of Cancellation or Nonrenewal - WI                                                                                                        |
	| ILU024     | Wisconsin Selection of Higher Uninsured Motorists Coverage Limits Notice of Availability and Selection of Underinsured Motorists Coverage Limits |
	| WI4566a    | Wisconsin ID Card                                                                                                                                |
	| CA2103     | Wisconsin Uninsured Motorists Coverage                                                                                                           |
	| CA2145     | Wisconsin Underinsured Motorists Coverage                                                                                                        |
	| M5171      | Schedule of Covered Autos                                                                                                                        |
	| IL0283     | Wisconsin Changes - Cancellation and Nonrenewal                                                                                                  |
	| CA9924     | Wisconsin Auto Medical Payments Coverage                                                                                                         |
	| ILN020     | Colorado Fraud Statement                                                                                                                         |
	| IL0228     | Colorado Changes - Cancellation and Nonrenewal                                                                                                   |
	| IL0169     | Colorado Changes - Concealment, Misrepresntation, or Fraud                                                                                       |
	| IL0125     | Colorado Changes - Civil Union                                                                                                                   |
	| CA0440     | Colorado Auto Medical Payments Coverage                                                                                                          |
	| CA0113     | Colorado Changes                                                                                                                                 |
	| IL0258     | Arizona Changes - Cancellation And Nonrenewal                                                                                                    |
	| CA2140     | Arizona Underinsured Motorists Coverage                                                                                                          |
	| CA2139     | Arizona Uninsured Motorists Coverage                                                                                                             |
	| CA0423     | Arizona - Full Glass Coverage                                                                                                                    |
	| CA2304     | Rolling Stores                                                                                                                                   |
	| CA0205     | Arizona Changes - Nonrenewal                                                                                                                     |
	| CA0175     | Arizona Changes                                                                                                                                  |
	| M5605      | Business Auto Coverage Declarations                                                                                                              |
	| FL5476     | Florida ID Card                                                                                                                                  |
	| MC1633     | Form E                                                                                                                                           |
	| MCS90      | Endorsement for Motor Carrier Policies of Insurance for Public Liability                                                                         |
	| M4458c     | Texas Uninsured and Underinsured Motorist Coverage Selection Rejection Form                                                                      |
	| CA2336     | Texas Form F-1 Uniform Commercial Motor Vehicle Bodily Injury and Property Damage Liability Insurance Endorsement                                |
	| M5446      | Form H                                                                                                                                           |
	| IL1204     | Illinois Policy Changes                                                                                                                          |
	| ILN101     | Texas Notice to Insurance Claimants for Motor Vehicle Repairs                                                                                    |
	| ACR0025    | Accord 25 Certificate of Liability Insurance                                                                                                     |
	| M5735      | Truckers Endorsement - Gross Receipts and Milage Premium Basis Definitions                                                                       |
	| M5619      | Important Notice Aviso Importante                                                                                                                |
	| BCA0002    | Texas Cargo Coverage Form                                                                                                                        |
	| M4034      | Trailer Interchange Amendatory Endorsement                                                                                                       |
	| M5694      | Refrigeration Breakdown Coverage                                                                                                                 |
	| M4778a     | Mobile Offices, Studios, Stores, Clinics, And Classrooms                                                                                         |
	| IN4566a    | Indiana ID Card                                                                                                                                  |
	| M5157      | Missouri Changes Cancellation and Nonrenewal                                                                                                     |
	| IL0147     | Illinois Changes - Civil Union                                                                                                                   |
	| CA9944     | Loss Payable Clause                                                                                                                              |
	| BCA0001    | Rental Reimbursement with Optional Downtime                                                                                                      |
	| M5174      | Split Liability Limits                                                                                                                           |
	| (E)C59q    | Notice of Cancellation, Nonrenewal or Declination - GA                                                                                           |
	| (E)GU8694q | Notice of Cancellation, Nonrenewal or Declination - MO                                                                                           |
	| (E)GU6214h | Notice of Cancellation, Nonrenewal or Declination - IN                                                                                           |
	| (E)GU351n  | Notice of Cancellation, Nonrenewal or Declination - CA                                                                                           |
	| (E)GU6004k | Notice of Cancellation, Nonrenewal or Declination - TN                                                                                           |
	| TX4619     | Texas ID Card                                                                                                                                    |
	| (E)GU407c  | Notice of Cancellation, Nonrenewal or Declination - TX                                                                                           |
	| M5638      | South Carolina Offer Of Optional Additional Uninsured Motorist Coverage and Options Underinsured Motorists Coverage                              |
	| M5494      | Georgia Rejection or Selection Of Uninsured Motorist Coverage                                                                                    |
	| M5401      | California Uninsured Motorists Named Operator Rejection                                                                                          |
	| M5394a     | California Uninsured Motorists Coverage Selection Rejection Form                                                                                 |
	| ILU070     | Indiana Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection Rejection                                                     |
	| M5783      | Texas Trailer Interchange Amendatory Endoresment                                                                                                 |
	| M5415      | Personal Injury Protection Coverage Rejection Form Texas                                                                                         |
	| CA2264     | Texas Personal Injury Protection Endorsement                                                                                                     |
	| M5160      | Texas Stated Amount Insurance                                                                                                                    |
	| CA2120     | Tenneessee Uninsured Motorists Coverage                                                                                                          |
	| M5399      | Texas Changes Cancellation and Nonrenewal                                                                                                        |
	| CA2109     | Texas Uninsured Underinsured Motorists Coverage                                                                                                  |
	| CA2104     | Missouri Uninsured Motorists Coverage                                                                                                            |
	| CA2144     | Indiana Uninsured Motorists Coverage                                                                                                             |
	| M5500      | Tennessee Uninsured Motorists Coverage Selection Rejection                                                                                       |
	| CA3137     | Georgia Uninsured Motorists Coverage Added on to At Fault Liability Limits                                                                       |
	| CA2111     | Georgia Uninsured Motorists Coverage Reduced by at fault Liability Limits                                                                        |
	| CA2155     | California Uninsured Motorists Coverage Property Damage                                                                                          |
	| CA2154     | California Uninsured Motorists Coverage Bodily Injury                                                                                            |
	| CA2156     | Missouri Split Uninsured Motorists Coverage Limits                                                                                               |
	| CA0434     | Indiana Changes Amendment of Definition of Pollutants                                                                                            |
	| CA3116     | Indiana Underinsured Motorists Coverage                                                                                                          |
	| CA3103     | Georgia Split Uninsured Motorists Coverage Limits                                                                                                |
	| CA3104     | Missouri Underinsured Motorists Changes                                                                                                          |
	| CA0165     | Missouri Changes                                                                                                                                 |
	| M5012      | Missouri Changes Pollution Exclusion                                                                                                             |
	| CA0119     | Indiana Changes                                                                                                                                  |
	| CA0433     | Indiana Changes - Pollution Exclusion                                                                                                            |
	| IL0117     | Indiana Changes Workers Compensation Exclusion                                                                                                   |
	| M5395      | Georgia Changes - Cancellation and Nonrenewal                                                                                                    |
	| IL0156     | Indiana Changes Concealment Misrepresentation or Faud                                                                                            |
	| IL0158     | Indiana Changes                                                                                                                                  |
	| IL0272     | Indiana Changes Cancellation and Nonrenewal                                                                                                      |
	| CA9987     | Tennessee Loss Payable Clause                                                                                                                    |
	| CA0146     | Tennessee Changes                                                                                                                                |
	| CA0109     | Georgia Changes                                                                                                                                  |
	| IL0270     | California Changes Cancellation                                                                                                                  |
	| CA0143     | California Changes                                                                                                                               |
	| CA0424     | California Auto Medical Payments Coverage                                                                                                        |
	| ILU003     | Illinois Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection/Rejection                                                    |
	| CA3101     | Nevada Split Uninsured Motorists Coverage Limits                                                                                                 |
	| CA2398     | Trailer Interchange Coverage                                                                                                                     |
	| CA2320     | Truckers Endorsement                                                                                                                             |
	| CA2317     | Truckers - Uniform Intermodal Interchange Endorsement Form UIIE - 1                                                                              |
	| CA2190     | South Carolina Split Underinsured Motorists Limits                                                                                               |
	| CA2189     | South Carolina Split Uninsured Motorists Limits                                                                                                  |
	| CA2188     | South Carolina Underinsured Motorists Coverage                                                                                                   |
	| CA2138     | Illinois Underinsured Motorists Coverage                                                                                                         |
	| CA2130     | Illinois Uninsured Motorists Coverage                                                                                                            |
	| CA2127     | Nevada Uninsured Motorists Coverage                                                                                                              |
	| CA2119     | South Carolina Uninsured Motorists Coverage                                                                                                      |
	| M5739      | Illinois Changes                                                                                                                                 |
	| M5655      | Cargo Coverage Form                                                                                                                              |
	| M5088      | Nevada Changes – Cancellation And Nonrenewal                                                                                                     |
	| IL0115     | Nevada Changes - Domestic Partnership                                                                                                            |
	| IL0162     | Illinois Changes - Defense Costs                                                                                                                 |
	| IL0110     | Nevada Changes - Concealment, Misrepresentation or Fraud                                                                                         |
	| IL0021     | Nuclear Energy Liability Exclusion Endorsement (Broad Form)                                                                                      |
	| IL0017     | Common Policy Conditions                                                                                                                         |
	| CA9958     | South Carolina Auto Medical Payments Coverage                                                                                                    |
	| CA9933     | Employees As Insureds                                                                                                                            |
	| CA9903     | Auto Medical Payments Coverage                                                                                                                   |
	| CA2402     | Public Transportation Autos                                                                                                                      |
	| CA2153     | Illinois Uninsured Motorist Coverage - Property Damage                                                                                           |
	| CA0442     | Exclusion Of Federal Employees Using Autos In Government Business                                                                                |
	| CA0270     | Illinois Changes - Cancellation and Nonrenewal                                                                                                   |
	| CA0150     | South Carolina Changes                                                                                                                           |
	| CA0136     | Nevada Changes                                                                                                                                   |
	| CA0120     | Illinois Changes                                                                                                                                 |
	| CA0001     | Business Auto Coverage Form                                                                                                                      |
	| MO5937     | Missouri ID Card                                                                                                                                 |
	| GA5937     | Georgia ID Card                                                                                                                                  |
	| TN4566a    | Tennessee ID Card                                                                                                                                |
	| CA4566a    | California ID Card                                                                                                                               |
	| M5701      | Supplemental Declarations - Cargo Coverage                                                                                                       |
	| CA0238     | Reinstatement Of Insurance                                                                                                                       |
	| B0005      | Mailing Cover Sheet                                                                                                                              |
	| B0004      | Commercial Auto Quote Proposal                                                                                                                   |
	| M2904      | General Change Endorsement                                                                                                                       |
	| M3795      | Punitive Damage Exclusion Duty To Defend Amendment                                                                                               |
	| M3834a     | Catastrophe Limitation Endorsement                                                                                                               |
	| M3841      | Driver Exclusion Endorsement (Specified Operator(s) Excluded)                                                                                    |
	| M3976      | Limitation Of Use Endorsement                                                                                                                    |
	| M3977      | Limitation Of Use Endorsement                                                                                                                    |
	| M4120      | Theft Restriction                                                                                                                                |
	| M4121      | Theft Exclusion                                                                                                                                  |
	| M4572      | Schedule Of Forms And Endorsements                                                                                                               |
	| M4803      | Abuse Or Molestation Exclusion                                                                                                                   |
	| M4895      | Assault And Battery Exclusion                                                                                                                    |
	| M5064      | Stated Amount Insurance                                                                                                                          |
	| M5270      | Policy Reinstatement - Without Lapse                                                                                                             |
	| M5271      | Policy Cancellation                                                                                                                              |
	| M5332a     | South Carolina Changes - Cancellation And Nonrenewal                                                                                             |
	| M5373      | Important Notice To Policyholders                                                                                                                |
	| M5421      | Additional Insured - Auto Owner                                                                                                                  |
	| M5479      | Towing And Storing Costs                                                                                                                         |
	| M5526      | Provision of Extended Notice of Cancellation                                                                                                     |
	| M5623      | Application Of Policy - Financial Responsibility                                                                                                 |
	| M5652      | Certificate Of Liability Insurance                                                                                                               |
	| M5747      | Supplemental Coverage Declarations                                                                                                               |
	| M5748      | Sanction Exclusion                                                                                                                               |
	| M5749      | Underinsured Motorists Coverage Amendatory Endorsement                                                                                           |
	| M5824      | Terrorism Risk Insurance Endorsement                                                                                                             |
	| M5872      | Changes to Common Policy Conditions - Cancellation                                                                                               |
	| M5887      | Additional Insured Endorsement                                                                                                                   |
	| M5944      | Lessor - Additional Insured And Loss Payee                                                                                                       |
	| M5951      | Indirect Loss                                                                                                                                    |
	| M8009      | Voluntary Cancellation Notice                                                                                                                    |
	| B0006      | Rescission                                                                                                                                       |
	| M4984      | Premium Tax Notice - Nevada                                                                                                                      |
	| (E)GU409h  | Notice of Cancellation, Nonrenewal or Declination - NV                                                                                           |
	| (E)GU547f  | Notice of Cancellation, Nonrenewal or Declination - SC                                                                                           |
	| (E)GU8860u | Notice of Cancellation, Nonrenewal or Declination - IL                                                                                           |
	| (E)GU9532q | Notice of Cancellation, Nonrenewal or Declination - AZ                                                                                           |
	| SC4566a    | South Carolina ID Card                                                                                                                           |
	| NV5522     | Nevada ID Card                                                                                                                                   |
	| IL5736     | Illinois ID Card                                                                                                                                 |
	| AZ5937     | Arizona ID Card                                                                                                                                  |
	| MC1632     | Form F                                                                                                                                           |
	| B0001      | Billing Statement Auto Pay                                                                                                                       |
	| B0002      | Billing Statement Direct                                                                                                                         |
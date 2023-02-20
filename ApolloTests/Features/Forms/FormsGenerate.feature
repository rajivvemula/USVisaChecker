@NoBrowser
Feature: Forms Generate

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
Scenario: Form can be generated
	Given condition for form with code '<code>' and '<name>' is met
	When user attempts to generate form
	Then form should be generated successfully
	And form shouldn't be blank

	Examples:
	| code       | name                                                                                                                                             |
	| M5964      | Michigan Changes - Cancellation and Nonrenewal                                                                                                   |
	| M5940      | MI Certificate of No Fault Insurance                                                                                                             |
	| M5284      | Michigan Changes                                                                                                                                 |
	| M5140      | Michigan Notice - Commercial Insurance                                                                                                           |
	| ILU078     | Michigan Liability Coverage Limits Selection                                                                                                     |
	| EGU88      | 13 Notice of Cancellation or Nonrenewal- MI                                                                                                      |
	| CAU012     | Michigan Selection of PIP Medical Coverage                                                                                                       |
	| CA2318     | Michigan Changes - Truckers Endorsement                                                                                                          |
	| CA2311     | Michigan Amendatory Endorsement                                                                                                                  |
	| CA2223     | Michigan Limited Collision Coverage                                                                                                              |
	| CA2220     | Michigan Personal Injury Protection                                                                                                              |
	| CA2131     | Michigan Uninsured Motorists Coverage                                                                                                            |
	| BCA0004    | Michigan Choice of Bodily Injury Liability Coverage Limits                                                                                       |
	| M4566a     | New Jersey ID Card                                                                                                                               |
	| IL0208     | New Jersey Changes - Cancellation and Nonrenewal                                                                                                 |
	| IL0141     | New Jersey Changes - Civil Union                                                                                                                 |
	| EGU6009m   | Notice of Cancellation Nonrenewal Declination-NJ                                                                                                 |
	| CA2230     | New Jersey Personal Injury Protection                                                                                                            |
	| CA2177     | New Jersey Split Uninsured and Underinsured Motorists Coverage Limits                                                                            |
	| CA2114     | New Jersey Uninsured and Underinsured Motorists Coverage                                                                                         |
	| CA0188     | New Jersey Changes                                                                                                                               |
	| CA0187     | New Jersey Changes - Loss Information                                                                                                            |
	| CA0184     | New Jersey Changes - Physical Damage Inspection                                                                                                  |
	| ACORD61FL  | SelectionRejection of Uninsured Motorist Coverage                                                                                                |
	| M5992      | Driver Exclusion Endorsement Specified Operator(s) Excluded                                                                                      |
	| M5910      | Stated Amount Insurance                                                                                                                          |
	| M5871      | Hired Autos Endorsement                                                                                                                          |
	| M5840      | Florida Changes Cancellation and Nonrenewal                                                                                                      |
	| M5838      | Waiver of Transfer of Rights of Recovery Against Others to Us                                                                                    |
	| M5830      | Business Auto Coverage Form Quick Reference                                                                                                      |
	| M5817      | Florida Personal Injury Protection Options                                                                                                       |
	| M5816      | Trailer Interchange Amendatory Endorsement                                                                                                       |
	| M5815      | Punitive Damage Exclusion Duty to Defend Amendment                                                                                               |
	| M5751      | Underinsured Motorists Coverage Amendatory Endorsement                                                                                           |
	| M5698      | Florida PIP Notification                                                                                                                         |
	| M4959a     | Schedule Of Covered Autos                                                                                                                        |
	| ILN166     | Florida Notification of Availibility of Uninsured Motorists Coverage                                                                             |
	| CA2210     | Florida Personal Injury Protection                                                                                                               |
	| CA2102     | Split Bodily Injury Uninsured Motorists Coverage Limits                                                                                          |
	| CA0128     | Florida Changes                                                                                                                                  |
	| B0010      | Renewal Proposal                                                                                                                                 |
	| (E)GU8817u | Notice of Cancellation, Nonrenewal, Renewal Premium, Declination of Insurance or Policy Transfer - Florida                                       |
	| (E)GU560a  | Reinstatement Notice                                                                                                                             |
	| PA0209     | Ohio Changes Cancellation and Nonrenewal                                                                                                         |
	| OH4566a    | Ohio ID Card                                                                                                                                     |
	| ILN155OQ   | Ohio Notice to Policyholders Regarding Tax                                                                                                       |
	| ILN0829M   | Ohio Fraud Statement                                                                                                                             |
	| CMB0244    | Ohio Changes Cancellation and Nonrenewal Cargo                                                                                                   |
	| CA3117     | Ohio Uninsured Motorists Coverage Property Damage                                                                                                |
	| CA2133     | Ohio Uninsured and Underinsured Motorists Coverage Bodily Injury                                                                                 |
	| (E)GU405e  | Notice of Cancellation, Nonrenewal, Declination - OH                                                                                             |
	| WI4566a    | Wisconsin ID Card                                                                                                                                |
	| TX4619     | Texas ID Card                                                                                                                                    |
	| TN4566a    | Tennessee ID Card                                                                                                                                |
	| SC4566a    | South Carolina ID Card                                                                                                                           |
	| OS32       | Endorsement To Liability Insurance Policy For Vehicles Operating with a Special Hauling Permit                                                   |
	| NV5522     | Nevada ID Card                                                                                                                                   |
	| MO5937     | Missouri ID Card                                                                                                                                 |
	| MCS90      | Endorsement for Motor Carrier Policies of Insurance for Public Liability                                                                         |
	| MC1633     | Form E                                                                                                                                           |
	| MC1632     | Form F                                                                                                                                           |
	| M8009      | Voluntary Cancellation Notice                                                                                                                    |
	| M5951      | Indirect Loss                                                                                                                                    |
	| M5944      | Lessor - Additional Insured And Loss Payee                                                                                                       |
	| M5908      | Colorado Uninsured Motorists Coverage - Bodily Injury                                                                                            |
	| M5887      | Additional Insured Endorsement                                                                                                                   |
	| M5872      | Changes to Common Policy Conditions - Cancellation                                                                                               |
	| M5824      | Terrorism Risk Insurance Endorsement                                                                                                             |
	| M5783      | Texas Trailer Interchange Amendatory Endoresment                                                                                                 |
	| M5749      | Underinsured Motorists Coverage Amendatory Endorsement                                                                                           |
	| M5747      | Supplemental Coverage Declarations                                                                                                               |
	| M5739      | Illinois Changes                                                                                                                                 |
	| M5735      | Truckers Endorsement - Gross Receipts and Milage Premium Basis Definitions                                                                       |
	| M5701      | Supplemental Declarations - Cargo Coverage                                                                                                       |
	| M5694      | Refrigeration Breakdown Coverage                                                                                                                 |
	| M5655      | Cargo Coverage Form                                                                                                                              |
	| M5652      | Certificate Of Liability Insurance                                                                                                               |
	| M5638      | South Carolina Offer Of Optional Additional Uninsured Motorist Coverage and Options Underinsured Motorists Coverage                              |
	| M5623      | Application Of Policy - Financial Responsibility                                                                                                 |
	| M5619      | Important Notice Aviso Importante                                                                                                                |
	| M5605      | Business Auto Coverage Declarations                                                                                                              |
	| M5526      | Provision of Extended Notice of Cancellation                                                                                                     |
	| M5500      | Tennessee Uninsured Motorists Coverage Selection Rejection                                                                                       |
	| M5494      | Georgia Rejection or Selection Of Uninsured Motorist Coverage                                                                                    |
	| M5492      | Arizona Uninsured and Underinsured Motorists Coverage Selection Form                                                                             |
	| M5479      | Towing And Storing Costs                                                                                                                         |
	| M5446      | Form H                                                                                                                                           |
	| M5421      | Additional Insured - Auto Owner                                                                                                                  |
	| M5401      | California Uninsured Motorists Named Operator Rejection                                                                                          |
	| M5399      | Texas Changes Cancellation and Nonrenewal                                                                                                        |
	| M5395      | Georgia Changes - Cancellation and Nonrenewal                                                                                                    |
	| M5394a     | California Uninsured Motorists Coverage Selection Rejection Form                                                                                 |
	| M5373      | Important Notice To Policyholders                                                                                                                |
	| M5332a     | South Carolina Changes - Cancellation And Nonrenewal                                                                                             |
	| M5271      | Policy Cancellation                                                                                                                              |
	| M5270      | Policy Reinstatement - Without Lapse                                                                                                             |
	| M5174      | Split Liability Limits                                                                                                                           |
	| M5171      | Schedule of Covered Autos                                                                                                                        |
	| M5160      | Texas Stated Amount Insurance                                                                                                                    |
	| M5157      | Missouri Changes Cancellation and Nonrenewal                                                                                                     |
	| M5144a     | Waiver Of Transfer Of Rights Of Recovery Against Others To Us                                                                                    |
	| M5088      | Nevada Changes – Cancellation And Nonrenewal                                                                                                     |
	| M5064      | Stated Amount Insurance                                                                                                                          |
	| M5012      | Missouri Changes Pollution Exclusion                                                                                                             |
	| M4984      | Premium Tax Notice - Nevada                                                                                                                      |
	| M4895      | Assault And Battery Exclusion                                                                                                                    |
	| M4803      | Abuse Or Molestation Exclusion                                                                                                                   |
	| M4778a     | Mobile Offices, Studios, Stores, Clinics, And Classrooms                                                                                         |
	| M4572      | Schedule Of Forms And Endorsements                                                                                                               |
	| M4458c     | Texas Uninsured and Underinsured Motorist Coverage Selection Rejection Form                                                                      |
	| M5748      | Sanction Exclusion                                                                                                                               |
	| M4121      | Theft Exclusion                                                                                                                                  |
	| M4120      | Theft Restriction                                                                                                                                |
	| M4034      | Trailer Interchange Amendatory Endorsement                                                                                                       |
	| M3977      | Limitation Of Use Endorsement                                                                                                                    |
	| M3841      | Driver Exclusion Endorsement (Specified Operator(s) Excluded)                                                                                    |
	| M3834a     | Catastrophe Limitation Endorsement                                                                                                               |
	| M3795      | Punitive Damage Exclusion Duty To Defend Amendment                                                                                               |
	| M2904      | General Change Endorsement                                                                                                                       |
	| IN4566a    | Indiana ID Card                                                                                                                                  |
	| ILU070     | Indiana Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection Rejection                                                     |
	| ILU063     | Colorado Rejection of Medical Payments Coverage                                                                                                  |
	| ILU042     | Colorado Bodily Injury Uninsured Motorists Coverage SelectionRejection                                                                           |
	| ILU024     | Wisconsin Selection of Higher Uninsured Motorists Coverage Limits Notice of Availability and Selection of Underinsured Motorists Coverage Limits |
	| ILU003     | Illinois Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection Rejection                                                    |
	| ILN101     | Texas Notice to Insurance Claimants for Motor Vehicle Repairs                                                                                    |
	| ILN020     | Colorado Fraud Statement                                                                                                                         |
	| IL5736     | Illinois ID Card                                                                                                                                 |
	| IL1204     | Illinois Policy Changes                                                                                                                          |
	| IL0283     | Wisconsin Changes - Cancellation and Nonrenewal                                                                                                  |
	| IL0272     | Indiana Changes Cancellation and Nonrenewal                                                                                                      |
	| IL0270     | California Changes Cancellation                                                                                                                  |
	| IL0258     | Arizona Changes - Cancellation And Nonrenewal                                                                                                    |
	| IL0228     | Colorado Changes - Cancellation and Nonrenewal                                                                                                   |
	| IL0169     | Colorado Changes - Concealment, Misrepresntation, or Fraud                                                                                       |
	| IL0162     | Illinois Changes - Defense Costs                                                                                                                 |
	| IL0158     | Indiana Changes                                                                                                                                  |
	| IL0156     | Indiana Changes Concealment Misrepresentation or Faud                                                                                            |
	| IL0147     | Illinois Changes - Civil Union                                                                                                                   |
	| IL0125     | Colorado Changes - Civil Union                                                                                                                   |
	| IL0117     | Indiana Changes Workers Compensation Exclusion                                                                                                   |
	| IL0115     | Nevada Changes - Domestic Partnership                                                                                                            |
	| IL0110     | Nevada Changes - Concealment, Misrepresentation or Fraud                                                                                         |
	| IL0021     | Nuclear Energy Liability Exclusion Endorsement (Broad Form)                                                                                      |
	| IL0017     | Common Policy Conditions                                                                                                                         |
	| GA5937     | Georgia ID Card                                                                                                                                  |
	| FL5476     | Florida ID Card                                                                                                                                  |
	| CO4932b    | Colorado ID Card                                                                                                                                 |
	| CA9987     | Tennessee Loss Payable Clause                                                                                                                    |
	| CA9958     | South Carolina Auto Medical Payments Coverage                                                                                                    |
	| CA9944     | Loss Payable Clause                                                                                                                              |
	| CA9933     | Employees As Insureds                                                                                                                            |
	| CA9924     | Wisconsin Auto Medical Payments Coverage                                                                                                         |
	| CA9903     | Auto Medical Payments Coverage                                                                                                                   |
	| CA4566a    | California ID Card                                                                                                                               |
	| CA3137     | Georgia Uninsured Motorists Coverage Added on to At Fault Liability Limits                                                                       |
	| CA3116     | Indiana Underinsured Motorists Coverage                                                                                                          |
	| CA3104     | Missouri Underinsured Motorists Changes                                                                                                          |
	| CA3103     | Georgia Split Uninsured Motorists Coverage Limits                                                                                                |
	| CA3101     | Nevada Split Uninsured Motorists Coverage Limits                                                                                                 |
	| CA2402     | Public Transportation Autos                                                                                                                      |
	| CA2398     | Trailer Interchange Coverage                                                                                                                     |
	| CA2336     | Texas Form F-1 Uniform Commercial Motor Vehicle Bodily Injury and Property Damage Liability Insurance Endorsement                                |
	| CA2320     | Truckers Endorsement                                                                                                                             |
	| CA2317     | Truckers - Uniform Intermodal Interchange Endorsement Form UIIE - 1                                                                              |
	| CA2304     | Rolling Stores                                                                                                                                   |
	| CA2264     | Texas Personal Injury Protection Endorsement                                                                                                     |
	| CA2190     | South Carolina Split Underinsured Motorists Limits                                                                                               |
	| CA2189     | South Carolina Split Uninsured Motorists Limits                                                                                                  |
	| CA2188     | South Carolina Underinsured Motorists Coverage                                                                                                   |
	| CA2156     | Missouri Split Uninsured Motorists Coverage Limits                                                                                               |
	| CA2155     | California Uninsured Motorists Coverage Property Damage                                                                                          |
	| CA2154     | California Uninsured Motorists Coverage Bodily Injury                                                                                            |
	| CA2153     | Illinois Uninsured Motorist Coverage - Property Damage                                                                                           |
	| CA2145     | Wisconsin Underinsured Motorists Coverage                                                                                                        |
	| CA2144     | Indiana Uninsured Motorists Coverage                                                                                                             |
	| CA2140     | Arizona Underinsured Motorists Coverage                                                                                                          |
	| CA2139     | Arizona Uninsured Motorists Coverage                                                                                                             |
	| CA2138     | Illinois Underinsured Motorists Coverage                                                                                                         |
	| CA2130     | Illinois Uninsured Motorists Coverage                                                                                                            |
	| CA2127     | Nevada Uninsured Motorists Coverage                                                                                                              |
	| CA2126     | Colorado Uninsured Motorists Coverage - Property Damage                                                                                          |
	| CA2120     | Tenneessee Uninsured Motorists Coverage                                                                                                          |
	| CA2119     | South Carolina Uninsured Motorists Coverage                                                                                                      |
	| CA2111     | Georgia Uninsured Motorists Coverage Reduced by at fault Liability Limits                                                                        |
	| CA2109     | Texas Uninsured Underinsured Motorists Coverage                                                                                                  |
	| CA2104     | Missouri Uninsured Motorists Coverage                                                                                                            |
	| CA2103     | Wisconsin Uninsured Motorists Coverage                                                                                                           |
	| CA0442     | Exclusion Of Federal Employees Using Autos In Government Business                                                                                |
	| CA0440     | Colorado Auto Medical Payments Coverage                                                                                                          |
	| CA0434     | Indiana Changes Amendment of Definition of Pollutants                                                                                            |
	| CA0433     | Indiana Changes - Pollution Exclusion                                                                                                            |
	| CA0424     | California Auto Medical Payments Coverage                                                                                                        |
	| CA0423     | Arizona - Full Glass Coverage                                                                                                                    |
	| CA0270     | Illinois Changes - Cancellation and Nonrenewal                                                                                                   |
	| CA0238     | Reinstatement Of Insurance                                                                                                                       |
	| CA0205     | Arizona Changes - Nonrenewal                                                                                                                     |
	| CA0175     | Arizona Changes                                                                                                                                  |
	| CA0165     | Missouri Changes                                                                                                                                 |
	| CA0150     | South Carolina Changes                                                                                                                           |
	| CA0146     | Tennessee Changes                                                                                                                                |
	| CA0143     | California Changes                                                                                                                               |
	| CA0136     | Nevada Changes                                                                                                                                   |
	| CA0120     | Illinois Changes                                                                                                                                 |
	| CA0119     | Indiana Changes                                                                                                                                  |
	| CA0117     | Wisconsin Changes                                                                                                                                |
	| CA0113     | Colorado Changes                                                                                                                                 |
	| CA0109     | Georgia Changes                                                                                                                                  |
	| CA0001     | Business Auto Coverage Form                                                                                                                      |
	| BCA0002    | Texas Cargo Coverage Form                                                                                                                        |
	| BCA0001    | Rental Reimbursement with Optional Downtime                                                                                                      |
	| B0007      | Proof of Mailing                                                                                                                                 |
	| B0006      | Rescission                                                                                                                                       |
	| B0004      | Commercial Auto Quote Proposal                                                                                                                   |
	| B0002      | Billing Statement Direct                                                                                                                         |
	| B0001      | Billing Statement Auto Pay                                                                                                                       |
	| AZ5937     | Arizona ID Card                                                                                                                                  |
	| ACR0025    | Accord 25 Certificate of Liability Insurance                                                                                                     |
	| (E)GU9532q | Notice of Cancellation, Nonrenewal or Declination - AZ                                                                                           |
	| (E)GU8860u | Notice of Cancellation, Nonrenewal or Declination - IL                                                                                           |
	| (E)GU8694q | Notice of Cancellation, Nonrenewal or Declination - MO                                                                                           |
	| (E)GU6639s | Notice of Cancellation or Nonrenewal - WI                                                                                                        |
	| (E)GU6214h | Notice of Cancellation, Nonrenewal or Declination - IN                                                                                           |
	| (E)GU6004k | Notice of Cancellation, Nonrenewal or Declination - TN                                                                                           |
	| (E)GU547f  | Notice of Cancellation, Nonrenewal or Declination - SC                                                                                           |
	| (E)GU409h  | Notice of Cancellation, Nonrenewal or Declination - NV                                                                                           |
	| (E)GU407c  | Notice of Cancellation, Nonrenewal or Declination - TX                                                                                           |
	| (E)GU402d  | Notice of Cancellation, Nonrenewal, Declination - CO                                                                                             |
	| (E)GU351n  | Notice of Cancellation, Nonrenewal or Declination - CA                                                                                           |
	| (E)C59q    | Notice of Cancellation, Nonrenewal or Declination - GA                                                                                           |


		
	#BUG 39206 for M5879
	#| M5879   | InTow Coverage With Optional Garagekeepers Additional Coverage Comprehensive |
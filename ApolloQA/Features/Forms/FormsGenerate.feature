@NoBrowser
Feature: Forms Generate




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
	| code       | name                                                                                                                |
	| IL5736     | - Illinois ID Card                                                                                                  |
	| (E)GU351n  | Notice of Cancellation, Nonrenewal or Declination - CA                                                              |
	| (E)GU547f  | Notice of Cancellation, Nonrenewal or Declination - SC                                                              |
	| (E)GU6004k | Notice of Cancellation, Nonrenewal or Declination - TN                                                              |
	| (E)GU6214h | Notice of Cancellation, Nonrenewal or Declination - IN                                                              |
	| (E)GU8694q | Notice of Cancellation, Nonrenewal or Declination - MO                                                              |
	| (E)GU8860u | Notice of Cancellation, Nonrenewal or Declination - IL                                                              |
	# B0001 & B0002 failure expected due to statement generation. There has to be a physical statement for this to work
	| B0001      | Billing Statement Auto Pay                                                                                          |
	| B0002      | Billing Statement Direct                                                                                            |
	| B0003      | Auto Claims Acknowledgement Letter                                                                                  |
	| B0004      | Commercial Auto Quote Proposal                                                                                      |
	| B0006      | Rescission                                                                                                          |
	| BCA0001    | - Rental Reimbursement with Optional Downtime                                                                       |
	| CA0001     | Business Auto Coverage Form                                                                                         |
	| CA0109     | Georgia Changes                                                                                                     |
	| CA0119     | Indiana Changes                                                                                                     |
	| CA0120     | Illinois Changes                                                                                                    |
	| CA0143     | California Changes                                                                                                  |
	| CA0146     | Tennessee Changes                                                                                                   |
	| CA0150     | South Carolina Changes                                                                                              |
	| CA0165     | Missouri Changes                                                                                                    |
	| CA0238     | Reinstatement Of Insurance                                                                                          |
	| CA0240     | Suspension Of Insurance                                                                                             |
	| CA0270     | Illinois Changes - Cancellation and Nonrenewal                                                                      |
	| CA0305     | California Change Waiver of Collision Deductible                                                                    |
	| CA0424     | California Auto Medical Payments Coverage                                                                           |
	| CA0433     | Indiana Changes - Pollution Exclusion                                                                               |
	| CA0434     | Indiana Changes Amendment of Definition of Pollutants                                                               |
	| CA0442     | Exclusion Of Federal Employees Using Autos In Government Business                                                   |
	| CA2104     | Missouri Uninsured Motorists Coverage                                                                               |
	| CA2111     | Georgia Uninsured Motorists Coverage Reduced by at fault Liability Limits                                           |
	| CA2119     | South Carolina Uninsured Motorists Coverage                                                                         |
	| CA2120     | Tenneessee Uninsured Motorists Coverage                                                                             |
	| CA2130     | Illinois Uninsured Motorists Coverage                                                                               |
	| CA2138     | Illinois Underinsured Motorists Coverage                                                                            |
	| CA2144     | Indiana Uninsured Motorists Coverage                                                                                |
	| CA2153     | Illinois Uninsured Motorist Coverage - Property Damage                                                              |
	| CA2154     | California Uninsured Motorists Coverage Bodily Injury                                                               |
	| CA2155     | California Uninsured Motorists Coverage Property Damage                                                             |
	| CA2156     | Missouri Split Uninsured Motorists Coverage Limits                                                                  |
	| CA2188     | South Carolina Underinsured Motorists Coverage                                                                      |
	| CA2189     | South Carolina Split Uninsured Motorists Limits                                                                     |
	| CA2190     | South Carolina Split Underinsured Motorists Limits                                                                  |
	| CA2317     | Truckers - Uniform Intermodal Interchange Endorsement Form UIIE - 1                                                 |
	| CA2320     | Truckers Endorsement                                                                                                |
	| CA2398     | Trailer Interchange Coverage                                                                                        |
	| CA2402     | Public Transportation Autos                                                                                         |
	| CA3103     | Georgia Split Uninsured Motorists Coverage Limits                                                                   |
	| CA3104     | Missouri Underinsured Motorists Changes                                                                             |
	| CA3116     | Indiana Underinsured Motorists Coverage                                                                             |
	| CA3137     | Georgia Uninsured Motorists Coverage Added on to At Fault Liability Limits                                          |
	| CA4566a    | - California ID Card                                                                                                |
	| CA9903     | Auto Medical Payments Coverage                                                                                      |
	| CA9933     | Employees As Insureds                                                                                               |
	| CA9944     | Loss Payable Clause                                                                                                 |
	| CA9958     | South Carolina Auto Medical Payments Coverage                                                                       |
	| CA9987     | Tennessee Loss Payable Clause                                                                                       |
	| GA5937     | - Georgia ID Card																								   |
	| IL0017     | Common Policy Conditions                                                                                            |
	| IL0021     | Nuclear Energy Liability Exclusion Endorsement (Broad Form)                                                         |
	| IL0117     | Indiana Changes Workers Compensation Exclusion                                                                      |
	| IL0147     | Illinois Changes - Civil Union                                                                                      |
	| IL0156     | Indiana Changes Concealment Misrepresentation or Faud                                                               |
	| IL0158     | Indiana Changes                                                                                                     |
	| IL0162     | Illinois Changes - Defense Costs                                                                                    |
	| IL0270     | California Changes Cancellation                                                                                     |
	| IL0272     | Indiana Changes Cancellation and Nonrenewal                                                                         |
	| IL1204     | Illinois Policy Changes                                                                                             |
	| ILU003     | Illinois Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection/Rejection                       |
	| ILU070     | Indiana Uninsured Motorists Coverage and Underinsured Motorists Coverage Selection Rejection                        |
	| M2904      | General Change Endorsement                                                                                          |
	| M3795      | Punitive Damage Exclusion Duty To Defend Amendment                                                                  |
	| M3834a     | Catastrophe Limitation Endorsement                                                                                  |
	| M3841      | Driver Exclusion Endorsement (Specified Operator(s) Excluded)                                                       |
	| M3976      | Limitation Of Use Endorsement                                                                                       |
	| M3977      | Limitation Of Use Endorsement                                                                                       |
	| M4034      | Trailer Interchange Amendatory Endorsement                                                                          |
	| M4120      | Theft Restriction                                                                                                   |
	| M4121      | Theft Exclusion                                                                                                     |
	| M4572      | Schedule Of Forms And Endorsements                                                                                  |
	| M4778a     | Mobile Offices, Studios, Stores, Clinics, And Classrooms                                                            |
	| M4803      | Abuse Or Molestation Exclusion                                                                                      |
	| M4895      | Assault And Battery Exclusion                                                                                       |
	| M5012      | Missouri Changes Pollution Exclusion                                                                                |
	| M5064      | Stated Amount Insurance                                                                                             |
	| M5157      | Missouri Changes Cancellation and Nonrenewal                                                                        |
	| M5171      | Schedule of Covered Autos                                                                                           |
	| M5174      | Split Liability Limits                                                                                              |
	| M5270      | Policy Reinstatement - Without Lapse                                                                                |
	| M5271      | Policy Cancellation                                                                                                 |
	| M5332a     | South Carolina Changes - Cancellation And Nonrenewal                                                                |
	| M5373      | Important Notice To Policyholders                                                                                   |
	| M5394a     | California Uninsured Motorists Coverage Selection Rejection Form                                                    |
	| M5395      | Georgia Changes - Cancellation and Nonrenewal                                                                       |
	| M5401      | California Uninsured Motorists Named Operator Rejection                                                             |
	| (E)GU407c  | Notice of Cancellation, Nonrenewal or Declination - TX                                                              |
	| M5421      | Additional Insured - Auto Owner                                                                                     |
	| M5446      | Form H                                                                                                              |
	| M5479      | Towing And Storing Costs                                                                                            |
	| M5494      | Georgia Rejection or Selection Of Uninsured Motorist Coverage                                                       |
	| M5526      | Provision of Extended Notice of Cancellation                                                                        |
	| M5605      | Business Auto Coverage Declarations                                                                                 |
	| M5623      | Application Of Policy - Financial Responsibility                                                                    |
	| M5638      | South Carolina Offer Of Optional Additional Uninsured Motorist Coverage and Options Underinsured Motorists Coverage |
	| M5652      | Certificate Of Liability Insurance                                                                                  |
	| M5655      | Cargo Coverage Form                                                                                                 |
	| M5694      | Refrigeration Breakdown Coverage                                                                                    |
	| M5700      | Cargo Coverage In-Tow Endorsement                                                                                   |
	| M5701      | Supplemental Declarations - Cargo Coverage                                                                          |
	| M5739      | Illinois Changes                                                                                                    |
	| M5747      | Supplemental Coverage Declarations                                                                                  |
	| M5748      | Sanction Exclusion                                                                                                  |
	| M5749      | Underinsured Motorists Coverage Amendatory Endorsement                                                              |
	| M5824      | Terrorism Risk Insurance Endorsement                                                                                |
	| M5872      | Changes to Common Policy Conditions - Cancellation                                                                  |
	| M5887      | Additional Insured Endorsement                                                                                      |
	| M5944      | Lessor - Additional Insured And Loss Payee                                                                          |
	| M5951      | Indirect Loss                                                                                                       |
	| M8009      | Voluntary Cancellation Notice                                                                                       |
	| MC1632     | Form F                                                                                                              |
	| MCS90      | Endorsement for Motor Carrier Policies of Insurance for Public Liability                                            |
	| MO5937     | - Missouri ID Card                                                                                                  |
	
	| SC4566a | - South Carolina ID Card                                                        |
	| TN4566a | - Tennessee ID Card                                                             |
	| (E)C59q | Notice of Cancellation, Nonrenewal or Declination - GA                          |
	| IN4566a | - Indiana ID Card                                                               |
	| M5619   | Important Notice Aviso Importante                                               |
	| M5731   | Hired Autos Endoresement                                                        |
	| M5735   | Truckers Endorsement - Gross Receipts and Milage Premium Basis Definitions      |
	
	#BUG 39206 for M5879
	#| M5879   | In-Tow Coverage With Optional Garagekeepers Additional Coverage – Comprehensive |

	# Arizona Not Implemented - algorithm for State not in QA
	#| CA0175     | Arizona Changes                                                                                                     |
	#| CA0205     | Arizona Changes - Nonrenewal                                                                                        |
	#| CA0423     | Arizona - Full Glass Coverage                                                                                       |
	#| CA2139     | Arizona Uninsured Motorists Coverage                                                                                |
	#| CA2140     | Arizona Underinsured Motorists Coverage                                                                             |
	#| IL0258     | Arizona Changes - Cancellation and Nonrenewal                                                                       |
	#| M5492      | Arizona Uninsured and Underinsured Motorists Coverage Selection Form                                                |
	#| (E)GU9532q | Notice of Cancellation, Nonrenewal or Declination - AZ                                                              |
	#| AZ5937     | - Arizona ID Card                                                                                                   |


	# Nevada Not implemented - algorithm for State not in QA
	#| CA3101     | Nevada Split Uninsured Motorists Coverage Limits                                                                    |
	#| IL0110     | Nevada Changes - Concealment, Misrepresentation or Fraud                                                            |
	#| IL0115     | Nevada Changes - Domestic Partnership                                                                               |
	#| M4984      | Premium Tax Notice - Nevada                                                                                         |
	#| M5088      | Nevada Changes – Cancellation And Nonrenewal                                                                        |
	#| CA2127     | Nevada Uninsured Motorists Coverage                                                                                 |
	#| CA0136     | Nevada Changes                                                                                                      |
	#| (E)GU409h  | Notice of Cancellation, Nonrenewal or Declination - NV                                                              |
	#| NV5522     | - Nevada ID Card                                                                                                    |

	# Texas not R1 state : algorithm for State not in QA
	#| M5415      | Personal Injury Protection Coverage Rejection Form - Texas                                                         |
	#| M4458c     | Uninsured & Underinsured Motorist Coverage Selection/Rejection Form                                                |
	#| M5160      | Texas Stated Amount Insurance                                                                                      |
	#| CA2109     | Texas Uninsured Underinsured Motorists Coverage                                                                    |
	#| CA2264     | Texas Personal Injury Protection Endorsement                                                                       |
	#| M5399      | Texas Changes Cancellation and Nonrenewal                                                                          |
	#| M5783      | Texas Trailer Interchange Amendatory Endoresment                                                                   |
	#| CA2336     | Texas Form F-1 Uniform Commercial Motor Vehicle Bodily Injury and Property Damage Liability Insurance Endorsement  |
	#| ILN101     | Texas Notice to Insurance Claimants For Motor Vehicle Repairs                                                      |
	#| FormF      | Uniform Motor Carrier Bodily Injury And Property Damage Liability Insurance Endorsement                            | 
	#| TX4619     | - Texas ID Card                                                                                                    |
	#| BCA00      | - Texas Cargo Coverage Form                                                                                        |
	#
	# FL has no dev efforts yet : Defect raised for tracking - 38419
	#| FL5476     | - Florida ID Card                                                                                                   |

	# Defect Raised : 38344
	#| M5500      | Tennessee Uninsured Motorists Coverage Selection Rejection                                                          |
	

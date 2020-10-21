Feature: US-14168-fields to FNOLClaims
		As a claims user representative, adjuster or manager 
		I will be able to add additional claim information to the file 

Scenario: TC01 Verify Claim Type
	Given User is on Homepage
	When User creates a FNOL 
	| Received | Related | First  | Last | Suffix | Email                | PhoneType | PhoneNumber | ClaimCategory | LossDesc    | Police | PoliceName | PoliceNumber | Fire | FireName | FireNumber |
	| Phone    | No      | Joseph | Seed | Mr     | josephseed@gmail.com | Mobile    | 5452156532  | Option 1      | Sample Desc | Yes    | PAPD       | 1234         | Yes  | PAFD     | 4567       |
	Then Verify FNOL is created
	When User selects radio option: First Party
	When User selects radio option: Property Damage
	Then Verify an input is displayed with label
	| Key | Value                  |
	| a   | Other Insurer          |
	| b   | Other Insurer Policy # |
	| c   | Other Insurer Claim #  |
	| d   | Other Insurer Adjuster |
	| e   | Point of Impact        |
	| f   | Vehicle Drivable?      |
	| g   | Vehicle Disposition    |
	| h   | Estimate of Loss       |
	| i   | Subrogation Referral?  |
	| j   | Used With Permission   |

Scenario:TC02 Verify relationship to insured
	Then Verify a Select contains value : relationshipTypeId
	| Key | Value            |
	| b   | Child            |
	| c   | Employee         |
	| d   | No-Operation     |
	| e   | Not Related      |
	| f   | Other Related    |
	| g   | Parent/Guardian  |
	| h   | Policyholder     |
	| i   | Sibling          |
	| j   | Spouse           |
	| k   | Unknown          |

Scenario:TC03 Verify  is report only
	Then Verify a Select contains value : isReportOnly
	| Key | Value |
	| a   | Yes   |
	| b   | No    |
	
Scenario:TC04 Verify sub orgation
	Then Verify a Select contains value : subrogationReferralId
	| Key | Value |
	| a   | Yes   |
	| b   | No    |

Scenario:TC05 Verify required values
	Then Verify if the input is required
	| Key | Value                 | Required |
	| a   | otherInsurer          | false    |
	| b   | otherInsurerPolicy    | false    |
	| c   | otherInsurerClaim     | false    |
	| d   | otherInsurerAdjuster  | false    |
	| e   | vehicleDrivableId     | false    |
	| f   | subrogationReferralId | true     |
# Currently not implemented In Apollo
#Scenario: Verify relationship to insured
#	Then Verify a Select contains value : pointOfImpactTypeId
#	| Key | Value |
#	| a   | Yes   |
#	| b   | No    |
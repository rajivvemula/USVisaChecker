Feature: PolicyCancelandReinstatement


@testtask
Scenario Outline: Automate Test Policy
    Given user is successfully logged into biberk
    When User Navigates to Policy latest
    Then User enters "<Initiated By>" and "<Reason>" with an effective date of tommorrow
    When user clicks 'Process' Button

    Examples:
        | Initiated By | Reason                                                                                  |
        | Insured      | Non-payment of deductible.                                                              |
        | Carrier      | NON-PAYMENT OF PREMIUM.                                                                 |
        | System       | Cancelled by Insured.                                                                   |
        | Insured      | Substantial change in risk which increased risk of loss after policy issued or renewed. |
        | Insured      | Policy cancelled and reissued. - INTERNAL USE ONLY                                      |
        | Insured      | Loss or suspension of driver's license.                                                 |





Scenario: Reinstate a Policy
    Given user is successfully logged into biberk
    When User Navigates to Policy Cancelled
    Then User Enters Reason with an effective date of tommorrow
    When user clicks 'Process' Button

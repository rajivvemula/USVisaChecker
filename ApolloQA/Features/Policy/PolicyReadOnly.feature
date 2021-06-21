Feature: PolicyReadOnly



Scenario Outline: Add two numbers
    Given user is successfully logged into biberk
    When User Navigates to Policy latest issued
    When user clicks on <Tab> Sidetab
    Then User verifies that inputs are disabled and no text can be entered in <Tab>
    Then User verifies no buttons are enabled in <Tab> 
    Then User verifies that ellipsis does not contain editable options
    Then User verifies that ellipsis does not contain deleteable options

    Examples: 
    | Tab                               |
    | Business Information              |
    | Introduction                      |
    | Vehicles                          |
    | Drivers                           |
    | Driver Incidents                  |
    | Operations                        |
    | Refer                             |
    | Policy Coverages                  |
    | Modifiers                         |
    | Policy Addl Interests             |
    | Summary                           |
    | Additional Information (FEIN/SSN) |
    | Additional Information (Vehicle)  |


Scenario:2 Verify address is editable in Business Information
    Given user is successfully logged into biberk
    When User Navigates to Policy latest issued
    When user clicks 'Business Information' Sidetab
    Then User selects different mailing address option
    Then User verifies that dropdown is interactable and contains Add Address Button

Scenario:3 Verify address is editable in Business Information
    Given user is successfully logged into biberk
    When User Navigates to Policy latest issued
    When user clicks 'Contacts' Sidetab
    Then User verify contact button is present
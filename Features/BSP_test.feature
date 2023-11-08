Feature: BSP_test

A short summary of the feature
 @BSP
Scenario: Verifying Headers and Tabs
Given user logs into BSP portal with Username and password
Given user is viewing policy number N9UM878518 with the following configuration:
| Input  | Value |
| Agency | Role  |

Then The user verifies the policy tabs and status

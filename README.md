# Introduction 
Test Automation for the Apollo Project using Behavior Driven Development. 

## NuGet Packages
Please install the following packages
```
Selenium.WebDriver
Selenium.Support
Selenium.WebDriver.ChromeDriver
Microsoft.NET.Test.Sdk
NUnit
NUnit3TestAdapter
Specflow
SpecFlow.NUnit
SpecFlow.Tools.MsBuild.Generation
```
# Overview

This test suite is designed to cover Apollo project using two implementations
* SmokeTest Using Only NUNIT3 
* Individual Regression Tests Using Specflow 


# Basic BDD Guidelines
All tests are written using the BDD Gherkin Language. Here are some basic guidelines:

### Title
* An explicit title.

### Narrative
 A short introductory section with the following structure:
* **As a:** the person or role who will benefit from the feature;
* **I want:** the feature;
* **so that:** the benefit or value of the feature.

### Acceptance criteria
 A description of each specific scenario of the narrative with the following structure:

* **Given:** the initial context at the beginning of the scenario, in one or more clauses;
* **When:** the event that triggers the scenario;
* **Then:** the expected outcome, in one or more clauses.




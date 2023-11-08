Feature: DeclineIndustry

This is to make sure that certain industries are decline at the madlibs page

@Unit @Smoke
Scenario: DeclineIndustry
	Given user starts a quote with:
	| Industry    | Employees | Location                              | Own or Lease | ZIP Code |
	| Coal Mining | 2         | I Run My Business From Property I Own |              | 43001    |
	Then user verifies decline page appearance due to not offering insurance for that industry

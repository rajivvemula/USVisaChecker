Feature: FunctionsTests

Tests the Functions class

@Internal @Build @Functions @NoSelenium
Scenario Outline: Functions can get different date from now
	When code gets <num> <unit> from now
	Then the returned date/time should be in the overridden timezone
	And the expected date/time should be approximately correct

Examples: 
	| num | unit   |
	| 1   | day    |
	| 4   | days   |
	| 1   | month  |
	| 2   | months |
	| 1   | year   |
	| 8   | years  |
	| -1  | days   |

@Internal @Build @Functions @NoSelenium
Scenario Outline: Functions can get different date from any date in UTC
	Given the date is set to <set date> and the time is set to <set time> in UTC
	When code gets <num> <unit> from set date
	Then the returned date/time should be in the overridden timezone
	And the expected date/time should be correct

Examples: 
	| set date   | set time       | num | unit   |
	| 04/05/2023 | 04:52:35.5421  | 5   | day    |
	| 02/05/2018 | 06:12:10.41201 | 2   | days   |
	| 03/18/2021 | 10:42:21.231   | 10  | month  |
	| 01/01/2025 | 18:52:54       | -5  | months |
	| 06/23/1998 | 20:32:01.152   | 1   | year   |
	| 10/24/2000 | 00:00:00.00000 | -8  | years  |
	| 12/31/2023 | 23:59:59.9999  | -1  | days   |

@Internal @Build @Functions @NoSelenium
Scenario Outline: Functions can get different date from any date in system local time
	Given the date is set to <set date> and the time is set to <set time> from the system timezone
	When code gets <num> <unit> from set date
	Then the returned date/time should be in the overridden timezone
	And the expected date/time should be correct

Examples: 
	| set date   | set time       | num | unit   |
	| 04/05/2023 | 04:52:35.5421  | 5   | day    |
	| 02/05/2018 | 06:12:10.41201 | 2   | days   |
	| 03/18/2021 | 10:42:21.231   | 10  | month  |
	| 01/01/2025 | 18:52:54       | -5  | months |
	| 06/23/1998 | 20:32:01.152   | 1   | year   |
	| 10/24/2000 | 00:00:00.00000 | -8  | years  |
	| 12/31/2023 | 23:59:59.9999  | -1  | days   |

@Internal @Build @Functions @NoSelenium
Scenario Outline: Functions can get different date from any date in timezeon override
	Given the date is set to <set date> and the time is set to <set time> from the overriden timezone
	When code gets <num> <unit> from set date
	Then the returned date/time should be in the overridden timezone
	And the expected date/time should be correct

Examples: 
	| set date   | set time       | num | unit   |
	| 04/05/2023 | 04:52:35.5421  | 5   | day    |
	| 02/05/2018 | 06:12:10.41201 | 2   | days   |
	| 03/18/2021 | 10:42:21.231   | 10  | month  |
	| 01/01/2025 | 18:52:54       | -5  | months |
	| 06/23/1998 | 20:32:01.152   | 1   | year   |
	| 10/24/2000 | 00:00:00.00000 | -8  | years  |
	| 12/31/2023 | 23:59:59.9999  | -1  | days   |
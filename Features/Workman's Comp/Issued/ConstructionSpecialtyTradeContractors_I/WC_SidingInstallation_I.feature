Feature: WC_SidingInstallation_I
Keyword: Siding Installation
Yes I have Employee
Number of employee : 5
Business Operation: I Lease a Space From Others
Included Officer: 0
Business started year : Started 4 years ago
Business Structured: LLC


Scenario: WC Siding Installation creates issued policy in North Carolina
  Given user starts a quote with:
	| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Siding Installation | 5         | I Lease a Space From Others |              | 27007    | WC  |


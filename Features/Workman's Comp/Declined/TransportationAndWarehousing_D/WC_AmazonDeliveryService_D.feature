Feature: WC_AmazonDeliveryService_D
DECLINE: DeclineReason::Decline to excessive non-EE work where certs are collecting.  Premium collected not commensurate with exposure.
Keyword:Amazon Delivery Service
Yes I have Employee
Number of employee : 1
ZIP Code: 10001
Business Operation: I Lease a Space From Others
Included Officer: 1
Business started year : Started 7 years ago
Business Structured: LLC


Scenario: WC Amazon Delivery Service gets declined because of excessive non-EE work where certs are collecting
  Given user starts a quote with:
	| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Amazon Delivery Service | 3         | I Lease a Space From Others |              | 10001    | WC  |

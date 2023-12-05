Feature: Quote_ProducerAvailability

Verify the Producers available are more than 10 for new quote page

@Quote
Scenario: Verify Producers available in new quote are more than 10
Given user is successfully logged into Apollo
Then user see the Apollo HomePage
When user clicks on Quote button on the header
Then user verifies the Quote table grid column names
When user clicks on +New button on the Quote page
Then user verifies Producer field values are more than 10
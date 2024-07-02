Feature: Not genuine user
	As a carrier provider, I want a username/password login on the tracking website, so that only genuine customers can access their tracking data.
	Given I’m not logged in with a genuine user.
	When I navigate to any page on the tracking site.
	Then I am presented with a login screen.

Scenario: Not genuine user
	Given I’m not logged in with a genuine user
	When User opens '{BaseUrl}/somepage' page
	Then User checks that login page is opened
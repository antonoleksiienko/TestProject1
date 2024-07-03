Feature: GenuineUser
	As a carrier provider, I want a username/password login on the tracking website, so that only genuine customers can access their tracking data.
	Given valid user credentials are already registered.
	And I’m on the login screen.
	When I enter a valid username and password and submit.
	Then I am logged in successfully.

Scenario: GenuineUser
	Given valid user credentials are already registered
	And User opens 'Main' page
	Then User checks that login page is opened
	When User logs in with username 'some.user@mail.box' and password 'qwerty123'
	Then User checks that he is logged in successfully and page 'SomePage' is opened


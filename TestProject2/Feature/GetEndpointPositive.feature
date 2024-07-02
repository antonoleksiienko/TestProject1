Feature: GetEndpointPositive

Scenario: Checks that GET request returns OK responce for taking all failed login
	When user sends GET request to take all failed login
	Then user checks that response code is 'OK'
	Then user checks that the content of the response to get all users is valid and not empty

Scenario: Checks that GET request returns OK responce for taking all failed login with limit
	When user sends GET request to take all failed login with limit '10'
	Then user checks that response code is 'OK'
    Then user checks that the content of the response to get all users is valid and results number is '10'

Scenario: Checks that GET request returns OK responce for taking failed login for specified user
	When user sends GET request to take failed login for user with 'TestUser' name
	Then user checks that response code is 'OK'
	Then user checks that the content of the response to get user with name 'TestUser' is valid and not empty

Scenario: Checks that GET request returns OK responce for taking failed login for specified user with limit
	When user sends GET request to take failed login for user with name 'TestUser' and limit '10'
	Then user checks that response code is 'OK'
	Then user checks that the content of the response to get user with name 'TestUser' is valid and results number is '10'

Scenario: Checks that GET request returns OK responce for taking all users with number of failed logins above value
	When user sends GET request to take all users with number of failed logins above '15' value
	Then user checks that response code is 'OK'
	Then user checks that the content of the response to get all users with number of failed logins above '15' value is valid and not empty

Scenario: Checks that GET request returns OK responce for taking all users with number of failed logins above value and limit
	When user sends GET request to take all users with number of failed logins above value '22' and limit '16'
	Then user checks that response code is 'OK'
	Then user checks that the content of the response to get all users with number of failed logins above '22' value is valid and results number is '16'


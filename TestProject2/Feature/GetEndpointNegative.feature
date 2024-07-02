Feature: GetEndpointNegative

Scenario: Checks that GET request returns BadRequest responce for taking all failed login with invalid limit
	When user sends GET request to take all failed login with limit '-1'
	Then user checks that response code is 'BadRequest'

Scenario: Checks that GET request returns NotFound responce for taking failed login for not existing user user
	When user sends GET request to take failed login for user with 'NotExistingUser' name
	Then user checks that response code is 'NotFound'

Scenario: Checks that GET request returns NotFound responce for taking failed login for not existing user with limit
	When user sends GET request to take failed login for user with name 'NotExistingUser' and limit '10'
	Then user checks that response code is 'NotFound'

Scenario: Checks that GET request returns BadRequest responce for taking failed login for specified user with invalid limit
	When user sends GET request to take failed login for user with name 'TestUser' and limit '-10'
	Then user checks that response code is 'BadRequest'

Scenario: Checks that GET request returns BadRequest responce for taking all users with invalid number of failed logins above value
	When user sends GET request to take all users with number of failed logins above '-15' value
	Then user checks that response code is 'BadRequest'

Scenario: Checks that GET request returns BadRequest responce for taking all users with invalid number of failed logins above value and limit
	When user sends GET request to take all users with number of failed logins above value '-22' and limit '16'
	Then user checks that response code is 'BadRequest'

Scenario: Checks that GET request returns BadRequest responce for taking all users with number of failed logins above value and invalid limit
	When user sends GET request to take all users with number of failed logins above value '22' and limit '-16'
	Then user checks that response code is 'BadRequest'
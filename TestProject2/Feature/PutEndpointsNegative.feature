Feature: PutEndpointsNegative

Scenario: Checks that PUT request return NotFound responce and reset failed login count for not existing user.
    When user sends PUT request to reset failed login count for user with name 'NotExistingUser'
	Then user checks that response code is 'NotFound'

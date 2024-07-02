Feature: PutEndpointPositive

Scenario: Checks that PUT request return OK responce and reset failed login count for user.
    Given user sends GET request to take failed login for user with 'TestName' name
    Given user checks that number of failed logins NOT equal to '0'
    When user sends PUT request to reset failed login count for user with name 'TestName'
	Then user checks that response code is 'OK'
    Then user checks that number of failed logins IS equal to '0'	

using System.Net;
using System.Text.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TestProject2.Models;

namespace TestProject2.StepDefinition
{
    [Binding]
    public class ApiStepDefinition : BaseStepDefinition
    {
        private RestResponse _response = null!;
        private ApiService _apiService = null!;

        [BeforeScenario]
        public void BeforeFeature()
        {
            _apiService = new ApiService(Config);
        }
        
        [When(@"user sends GET request to take all failed login")]
        public void GetAllFailedLogin()
        {
            _response = _apiService.GetLoginFailTotalRequest();
        }

        [When(@"user sends GET request to take all failed login with limit '(-?\d+)'")]
        public void GetAllFailedLoginWithLimit(int fetchLimit)
        {
            _response = _apiService.GetLoginFailTotalRequest(fetchLimit: fetchLimit);
        }

        [Given(@"user sends GET request to take failed login for user with '(.*)' name")]
        [When(@"user sends GET request to take failed login for user with '(.*)' name")]
        public void GetFailedLoginForUserWithName(string userName)
        {
            _response = _apiService.GetLoginFailTotalRequest(userName);
        }

        [When(@"user sends GET request to take failed login for user with name '(.*)' and limit '(-?\d+)'")]
        public void GetFailedLoginForUserWithNameAndLimit(string userName, int fetchLimit)
        {
            _response = _apiService.GetLoginFailTotalRequest(userName, fetchLimit: fetchLimit);
        }

        [When(@"user sends GET request to take all users with number of failed logins above '(-?\d+)' value")]
        public void GetFailedLoginForUserWithFailCount(int failCount)
        {
            _response = _apiService.GetLoginFailTotalRequest(failCount:failCount);
        }

        [When(@"user sends GET request to take all users with number of failed logins above value '(-?\d+)' and limit '(-?\d+)'")]
        public void GetFailedLoginForUserWithFailCountAndLimit(int failCount, int fetchLimit)
        {
            _response = _apiService.GetLoginFailTotalRequest(failCount: failCount, fetchLimit:fetchLimit);
        }
        
        [When(@"user sends PUT request to reset failed login count for user with name '(.*)'")]
        public void PutResetFailedLoginCount(string userName)
        {
            _response = _apiService.ResetLoginFailTotalRequest(userName);
        }

        [Then(@"user checks that response code is '(.*)'")]
        public void UserChecksResponseIsOk(string statusCode)
        {
            if (!Enum.TryParse(statusCode, out HttpStatusCode httpStatusCode))
            {
                Assert.Fail("Http status code not found");
            }
            Assert.That(_response.StatusCode, Is.EqualTo(httpStatusCode));
        }

        [Then("user checks that the content of the response to get all users is valid and not empty")]
        public void UserChecksAllUsersResponseContentIsValid()
        {
            Assert.That(_response.Content, Is.Not.Null);
            List<UserResponseModel> userResponseModel = JsonSerializer.Deserialize<List<UserResponseModel>>(_response.Content!)!;
            Assert.That(userResponseModel, Is.Not.Empty);
        }

        [Then(@"user checks that the content of the response to get all users is valid and results number is '(\d+)'")]
        public void UserChecksAllUsersResponseContentIsValidWithLimit(int fetchLimit)
        {
            Assert.That(_response.Content, Is.Not.Null);
            List<UserResponseModel> userResponseModel = JsonSerializer.Deserialize<List<UserResponseModel>>(_response.Content!)!;
            Assert.That(userResponseModel, Has.Count.LessThanOrEqualTo(fetchLimit));
        }

        [Then(@"user checks that the content of the response to get user with name '(.*)' is valid and not empty")]
        public void UserChecksUserWithNameResponseContentIsValid(string userName)
        {
            Assert.That(_response.Content, Is.Not.Null);
            UserResponseModel userResponseModel = JsonSerializer.Deserialize<UserResponseModel>(_response.Content!)!;
            Assert.That(userResponseModel.UserName, Is.EqualTo(userName));
        }

        [Then(@"user checks that the content of the response to get user with name '(.*)' is valid and results number is '(\d+)'")]
        public void UserChecksUserWithNameAndLimitResponseContentIsValid(string userName, int fetchLimit)
        {
            Assert.That(_response.Content, Is.Not.Null);
            UserResponseModel userResponseModel = JsonSerializer.Deserialize<UserResponseModel>(_response.Content!)!;
            Assert.That(userResponseModel.UserName, Is.EqualTo(userName));
            Assert.That(userResponseModel.FailedLogins, Has.Count.LessThanOrEqualTo(fetchLimit));
        }

        [Then(@"user checks that the content of the response to get all users with number of failed logins above '(.*)' value is valid and not empty")]
        public void UserChecksUserWithFailedLoginsNumberResponseContentIsValid(int failCount)
        {
            Assert.That(_response.Content, Is.Not.Null);
            List<UserResponseModel> userResponseModel = JsonSerializer.Deserialize<List<UserResponseModel>>(_response.Content!)!;
            foreach (UserResponseModel responseModel in userResponseModel)
            {
                Assert.That(responseModel.FailedLogins, Has.Count.GreaterThanOrEqualTo(failCount));
            }
        }

        [Then(@"user checks that the content of the response to get all users with number of failed logins above '(\d+)' value is valid and results number is '(\d+)'")]
        public void UserChecksUserWithWithFailedLoginsNumberAndLimitResponseContentIsValid(int failCount, int fetchLimit)
        {
            Assert.That(_response.Content, Is.Not.Null);
            List<UserResponseModel> userResponseModel = JsonSerializer.Deserialize<List<UserResponseModel>>(_response.Content!)!;
            Assert.That(userResponseModel, Has.Count.LessThanOrEqualTo(fetchLimit));
            foreach (UserResponseModel responseModel in userResponseModel)
            {
                Assert.That(responseModel.FailedLogins, Has.Count.GreaterThanOrEqualTo(failCount));
            }
        }

        [Given(@"user checks that number of failed logins NOT equal to '(\d+)'")]
        public void NumberOfFailedLoginsNotEqual(int expectNumber)
        {
            UserResponseModel userResponseModel = JsonSerializer.Deserialize<UserResponseModel>(_response.Content!)!;
            int actualValue = userResponseModel.FailedLogins.Count;
            Assert.That(actualValue, Is.Not.EqualTo(expectNumber));
        }

        [Then(@"user checks that number of failed logins IS equal to '(\d+)'")]
        public void NumberOfFailedLoginsIsEqual(int expectNumber)
        {
            UserResponseModel userResponseModel = JsonSerializer.Deserialize<UserResponseModel>(_response.Content!)!;
            int actualValue = userResponseModel.FailedLogins.Count;
            Assert.That(actualValue, Is.EqualTo(expectNumber));
        }
    }
}

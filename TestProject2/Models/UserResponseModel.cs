namespace TestProject2.Models
{
    public class UserResponseModel
    {
        public string UserName { get; set; } = null!;

        public List<FailedLogin> FailedLogins { get; set; } = null!;
    }
}

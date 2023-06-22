namespace DockerAPIDataModels.Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? AccessRole { get; set; }
        public string? TenantId { get; set; }
    }
}
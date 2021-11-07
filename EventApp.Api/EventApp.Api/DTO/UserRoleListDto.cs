namespace EventApp.Api.DTO
{
    public class UserRoleListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}

namespace ProjectTirAuthorizationMicroservice.Core.DomainEntities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string UserPatronymic { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserPhone { get; set; } = null!;

        public DateOnly UserBirtdayDate { get; set; }

        public List<Session> OpenSessions { get; set; } = null!;
    }
}

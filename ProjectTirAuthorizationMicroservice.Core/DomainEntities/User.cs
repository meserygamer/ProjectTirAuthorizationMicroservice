namespace ProjectTirAuthorizationMicroservice.Core.DomainEntities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly BirthdayDate { get; set; }

        public List<Session> OpenSessions { get; set; } = null!;
    }
}

namespace ProjectTirAuthorizationMicroservice.Database.Entities
{
    public class UserEntity
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

        public List<SessionEntity> OpenSessions { get; set; } = null!;
    }
}

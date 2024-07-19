namespace ProjectTirAuthorizationMicroservice.Database.Entities
{
    public class SessionEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }

        public UserEntity User { get; set; } = null!;
    }
}

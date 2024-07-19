namespace ProjectTirAuthorizationMicroservice.Database.Entities
{
    public class SessionEntity
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public UserEntity User { get; set; } = null!;
    }
}

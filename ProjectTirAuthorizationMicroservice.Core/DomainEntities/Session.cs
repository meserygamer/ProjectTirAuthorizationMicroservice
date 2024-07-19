namespace ProjectTirAuthorizationMicroservice.Core.DomainEntities
{
    public class Session
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public User User { get; set; } = null!;
    }
}

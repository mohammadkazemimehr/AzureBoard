namespace Azure.ToDo.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            IsDeleted = false;
            CreationDate = CreationDate;
        }
    }
}

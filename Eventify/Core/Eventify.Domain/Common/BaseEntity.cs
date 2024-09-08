namespace Eventify.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}

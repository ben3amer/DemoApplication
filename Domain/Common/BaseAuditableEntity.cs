namespace Domain.Common;
public abstract class BaseAuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }

}

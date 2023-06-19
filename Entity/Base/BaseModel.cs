using Microsoft.EntityFrameworkCore;

namespace Entity.Base;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public EntityState State { get; set; }
}
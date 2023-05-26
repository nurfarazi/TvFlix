using System.ComponentModel.DataAnnotations.Schema;
using Core.Enum;

namespace Core.Entity;

public class UserLog : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UserLogId { get; set; }
    public string UserId { get; set; }
    public string IPAddress { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }
    public string Browser { get; set; }
    public string Device { get; set; }
    public LogAction Action { get; set; }
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}
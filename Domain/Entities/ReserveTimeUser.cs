using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("ReserveTimeUser", Schema = "dbo")]
public class ReserveTimeUser : BaseAuditableEntity
{
   
    [Key]
    public long ReserveTimeUserId { set; get; }

    public long ReserveTimeId { set; get; }
    public int UserId { set; get; }
    public string FullName { set; get; }
    public string NationalCode { set; get; }
    public string TrackingCode { set; get; }

 



}

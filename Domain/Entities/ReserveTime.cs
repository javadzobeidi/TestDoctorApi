using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("ReserveTime", Schema = "dbo")]
public class ReserveTime : BaseAuditableEntity
{
    public ReserveTime()
    {
        ReserveTimeUsers = new HashSet<ReserveTimeUser>();
    }
    [Key]
    public long ReserveTimeId { set; get; }
    public int DoctorId { set; get; }
    public DateTime ReservationDateTime { set; get; }
  
    /// <summary>
    /// Start Reserving by this date
    /// </summary>
    public DateTime StartReservationDateTime { set; get; }
    /// <summary>
    /// End Reserving by this date
    /// </summary>  public DateTime EndReservationDateTime { set; get; }
    public DateTime EndReservationDateTime { set; get; }
    public int ReserveLimitCount { set; get; }
    public int ReserveUserCount { set; get; }
    public string TrackingBaseCode { set; get; }
    
    public bool ReserveTimeLocked { set; get; }
    public Doctor Doctor { set; get; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public ICollection<ReserveTimeUser> ReserveTimeUsers { set; get;}
}

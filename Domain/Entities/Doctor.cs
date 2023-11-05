using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("Doctor", Schema = "dbo")]
public class Doctor : BaseAuditableEntity
{
    public Doctor()
    {

    }
    [Key]
    public int DoctorId { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
   
    public string GivenName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }

    private readonly List<ReserveTime> _reserveTimes;
    public IReadOnlyCollection<ReserveTime> ReserveTimes => _reserveTimes;

    public ReserveTime AddReservationTime(ReserveTime time)
    {
        ////Check Limit 
        _reserveTimes.Add(time);
        return time;
    }

}

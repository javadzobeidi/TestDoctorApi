using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract;
public class DoctorReservationTimeResponse
{

    public long ReserveTimeId { set; get; }
    public string ReserveTime { set; get; }
    public string ReserveDate { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }

}



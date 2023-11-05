using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Messaging;
using Application.Contract;
using Microsoft.EntityFrameworkCore;

namespace Application;


public record GetDoctorReservationTimeQuery(String date) :  IQuery<List<DoctorReservationTimeResponse>>;



public class GetUserByTokenQueryHandler : IQueryHandler<GetDoctorReservationTimeQuery, List<DoctorReservationTimeResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTime _dateTime;

    public GetUserByTokenQueryHandler(IApplicationDbContext context, IDateTime dateTime)
    {
        _context = context;
        _dateTime = dateTime;
    }

    public async Task<List<DoctorReservationTimeResponse>> Handle(GetDoctorReservationTimeQuery request, CancellationToken cancellationToken)
    {
       

       var currentDate= _dateTime.ToDateTime(request.date, "00:00");
  return  await _context.ReserveTimes.Where(d =>d.ReservationDateTime.Date==currentDate.Value.Date && d.ReserveTimeLocked == false).Select(r => new DoctorReservationTimeResponse
        {
             ReserveTimeId = r.ReserveTimeId,
            FirstName = r.Doctor.FirstName,
            LastName = r.Doctor.LastName,
             ReserveDate = request.date,
            ReserveTime = _dateTime.ToPersianTime(r.ReservationDateTime),

        }).AsNoTracking().ToListAsync();

    }
}

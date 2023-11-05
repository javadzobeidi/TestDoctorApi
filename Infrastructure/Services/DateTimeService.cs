using Application.Common.Interfaces;
using Domain.Common;
using System.Globalization;

namespace Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
    private readonly PersianCalendar pa;
    public DateTimeService()
    {
        pa = new PersianCalendar();
    }
    public string ToPersianDate(DateTime dt)
    {
        return dt.ToString("yyyy/MM/dd", Thread.CurrentThread.CurrentUICulture);

    }
    public string ToPersianTime(DateTime dt)
    {
        return dt.ToString("HH:mm", Thread.CurrentThread.CurrentUICulture);

    }
    public DateTime? ToDateTime(String persianDate, string persianTime)
    {
        try
        {
            if (String.IsNullOrEmpty(persianDate) == true)
                return null;


            var slice = persianDate.Split('/');
            if (slice.Length != 3)
                return null;


            var sliceTime = persianTime.Split(':');
            if (sliceTime.Length < 3)
            {
                sliceTime = new string[3] { "0", "0", "1" };
            }

            return pa.ToDateTime(Int32.Parse(slice[0]), Int32.Parse(slice[1]), Int32.Parse(slice[2]), Int32.Parse(sliceTime[0]),
                Int32.Parse(sliceTime[1]), Int32.Parse(sliceTime[2]), 0);

        }
        catch (Exception)
        {
            return null;
        }
    }

}

namespace Application.Common.Interfaces;

public interface IDateTime
{
    DateTimeOffset Now { get; }

    String ToPersianDate(DateTime dt);
    String ToPersianTime(DateTime dt);

    DateTime? ToDateTime(String persianDate, string persianTime);
}

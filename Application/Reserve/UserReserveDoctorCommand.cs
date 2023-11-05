using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Messaging;
using Domain.Entities;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Polly;
using Polly.Retry;
using System.Net;

namespace Application;

public record UserReserveDoctorCommand :  ICommand<string>
{
    public long ReserveTimeId { set; get; }
    public string NationalCode { set; get; }
    public string FullName { set; get; }

}



public class UserReserveDoctorCommandValidator : AbstractValidator<UserReserveDoctorCommand>
{
    private readonly IApplicationDbContext _context;

    public UserReserveDoctorCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.NationalCode)
            .NotEmpty().WithMessage("کد ملی تکراری است");
            //.MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
                    RuleFor(v => v.FullName)
            .NotEmpty().WithMessage("نام و نام خانوادگی اجباری است");

    }

   
}



public class UserReserveDoctorCommandHandler : ICommandHandler<UserReserveDoctorCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTime _dateTime;
    private readonly AsyncRetryPolicy _retryPolicy;

    public UserReserveDoctorCommandHandler(IApplicationDbContext context, IDateTime dateTime)
    {
        _context = context;
        _dateTime = dateTime;
      
    }

    public async Task<string> Handle(UserReserveDoctorCommand request, CancellationToken cancellationToken)
    {
        var reserve = await _context.ReserveTimes.FindAsync(request.ReserveTimeId);
        if (reserve == null)
            throw new NotFoundException("اطلاعات ارسالی اشتباه است");



     var duplicatedReserve=  await _context.ReserveTimeUsers.Where(d => d.ReserveTimeId == reserve.ReserveTimeId && d.NationalCode == request.NationalCode).CountAsync();
        if (duplicatedReserve > 0)
            throw new RequestException("قبلا برای این تاریخ رزرو انجام داده اید");

        ReserveTimeUser entity = new ReserveTimeUser
        {
            ////userid get by claim
            UserId = 1,
            ReserveTimeId = reserve.ReserveTimeId,
            FullName = request.FullName,
            NationalCode = request.NationalCode,
            TrackingCode = "123"
        };

        reserve.ReserveTimeUsers.Add(entity);


        await Policy
   .Handle<DbUpdateConcurrencyException>()
   .RetryAsync(async ( exception, retryCount) =>
   {
      var ex= (DbUpdateConcurrencyException)exception;
       ex.Entries.Single().Reload();
       // wait a while
   })
        // execute the command
   .ExecuteAsync(async () =>
   {
       

       if (reserve.ReserveTimeLocked)
           throw new Exception("امکان رزرو نمی باشد");

     

       reserve.ReserveUserCount += 1;
       if (reserve.ReserveUserCount == reserve.ReserveLimitCount)
           reserve.ReserveTimeLocked = true;

       await _context.SaveChangesAsync(cancellationToken);

   }

   )
   .ConfigureAwait(false);


        return $"{reserve.TrackingBaseCode}-{entity.ReserveTimeUserId}";


    }
}

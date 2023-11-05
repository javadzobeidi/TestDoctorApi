using Application;
using Application.Common.Interfaces;
using Application.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QrSoft.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class DoctorController : ApiControllerBase
{

    private readonly ILogger<DoctorController> _logger;
    private readonly ICurrentUserService _currentUser;
    public DoctorController(ILogger<DoctorController> logger, ICurrentUserService currentUser)
    {
        _logger = logger;
        _currentUser = currentUser;
    }


    [HttpPost]
    [Route("getdoctorreservationtimes")]
  //  [ClaimRequirement("manager", "customer", "admin")]
    public async Task<IActionResult> GetDoctorReservationTimes(GetDoctorReservationTimeQuery query)
    {
     var result=  await Mediator.Send(query);
        return Success(new { list=result });
    }




}



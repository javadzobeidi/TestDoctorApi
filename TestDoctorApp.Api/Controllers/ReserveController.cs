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
public class ReserveController : ApiControllerBase
{

    private readonly ILogger<ReserveController> _logger;
    public ReserveController(ILogger<ReserveController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
  //  [ClaimRequirement("manager", "customer", "admin")]
    public async Task<IActionResult> ReserveTime(UserReserveDoctorCommand command)
    {
     var result=  await Mediator.Send(command);
        return Success(result);
    }




}



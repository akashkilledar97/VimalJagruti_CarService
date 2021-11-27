﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : BaseController<IVehicleServices>
    {
        public VehicleController(IVehicleServices vehicleServices) : base(vehicleServices)
        {
        }

        /// <summary>
        /// To get vehicle details
        /// </summary>
        /// <param name="vehiclenumber"></param>
        /// <returns></returns>
        //[Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpGet("get-vehicle-details")]
        public async Task<IActionResult> GetVehicleDetails(string vehiclenumber)
        {
            var res = await Service.GetVehicleDetails(vehiclenumber);

            return Ok(new ResponseViewModel<Domain.ViewModel.VehicleDetails.VehicleDetails>
            {
                StatusCode = res == null || string.IsNullOrEmpty(res.VehicleNumber) ? HttpStatusCode.NotFound : HttpStatusCode.OK,
                Data = res,
                Message = res == null || string.IsNullOrEmpty(res.VehicleNumber) ? Constants.VehicleNotFound : Constants.VehicleFound
            });
        }
    }
}

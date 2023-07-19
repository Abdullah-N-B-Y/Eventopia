﻿using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IService<Booking> _bookingService;

        public BookingController(IService<Booking> bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("CreateNewBooking")]
        public void CreateNewBooking(Booking booking)
        {
            _bookingService.CreateNew(booking);
        }
    }
}
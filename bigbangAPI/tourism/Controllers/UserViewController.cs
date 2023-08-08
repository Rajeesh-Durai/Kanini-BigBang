﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;
using tourismBigBang.Services.UserViewService;

namespace tourismBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewController:ControllerBase
    {
        private readonly IUserViewService _userViewService;
        public UserViewController(IUserViewService userViewService)
        {
            _userViewService = userViewService;
        }
       
        [HttpGet("GetPlans")]
        public async Task<ActionResult<List<PlanDTO>>> GetPlans()
        {
            try
            {
                var get = await _userViewService.GetPlans();
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
        [HttpGet("GetPackageDetails")]
        public async Task<ActionResult<List<PackagesOverall>>> GetPackageDetails(int placeId)
        {
            try
            {
                var get = await _userViewService.GetPackageDetails(placeId);
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDayWise")]
        public async Task<ActionResult<List<DayWiseSchedule>>> GetDayWise(int packageId)
        {
            try
            {
                var get = await _userViewService.GetDayWise(packageId);
                return Ok(get);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("UserInfoById")]
        public async Task<ActionResult<UserInfo>> GetUserInfoForBooking(int id)
        {
            try
            {
                var get = await _userViewService.GetUserInfoForBooking(id);
                return Ok(get);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="User")]
        [HttpPost("PostBooking")]
        public async Task<ActionResult<Booking>> PostBookingDetails(Booking booking)
        {
            try
            {
                var post = await _userViewService.PostBookingDetails(booking);
                return Ok(post);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Agent")]
        [HttpGet("AllPlaces")]
        public async Task<ActionResult<List<Place>>> GetAllPlaces()
        {
            try
            {
                var get = await _userViewService.GetAllPlaces();
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AllGalleryImages")]
        public async Task<ActionResult<List<ImageGallery>>> GetAllImages()
        {
            try
            {
                var get = await _userViewService.GetAllImages();
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ParticularPackage")]
        public async Task<ActionResult<List<Package>>> GetParticularPackage(int id)
        {
            try
            {
                var get = await _userViewService.GetParticularPackage(id);
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

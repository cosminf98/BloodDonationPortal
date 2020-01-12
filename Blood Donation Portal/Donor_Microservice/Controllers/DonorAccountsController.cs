using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hospital_Microservice.AuthorizationRequirements;
using Donor_Microservice.DTOs;
using Donor_Microservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Donor_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorAccountsController : ControllerBase
    {
        private UserManager<Donor> _userMng;
        private SignInManager<Donor> _signMng;

        public DonorAccountsController(UserManager<Donor> userManager,
            SignInManager<Donor> signInManager)
        {
            _userMng = userManager;
            _signMng = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Donor>> Register(DonorRegisterDTO donor)
        {

            Donor user = await _userMng.FindByEmailAsync(donor.Email);
            if (user == null)
            {
                user = new Donor()
                {
                    UserName = donor.Username,
                    Email = donor.Email,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Gender = donor.Gender,
                    DateOfBirth = donor.DateOfBirth,
                    BloodType = donor.BloodType,
                    City = donor.City,
                    County = donor.County
                };
                await _userMng.CreateAsync(user, donor.Password);
                return Ok(user);
            }
            return Ok("User Already Exists!");
        }

        //api/donoraccounts/login
        [HttpPost("login")]
        public async Task<ActionResult<Donor>> Login(DonorLoginDTO donorDTO)
        {
            //Get user
            var donor = await _userMng.FindByEmailAsync(donorDTO.Email);

            if (donor == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }

            if (await _userMng.CheckPasswordAsync(donor, donorDTO.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claimsList = new List<Claim>()
                {
                    new Claim("DonorEmail",donorDTO.Email),
                    new Claim("Id", donor.Id.ToString())
                };

                //Create token
                var token = new JwtSecurityToken(
                    issuer: Constants.Issuer,
                    audience: Constants.Audience,
                    claims: claimsList,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Id = donor.Id
                }); ;
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signMng.SignOutAsync();
            return Ok(HttpContext);
        }
    }
}
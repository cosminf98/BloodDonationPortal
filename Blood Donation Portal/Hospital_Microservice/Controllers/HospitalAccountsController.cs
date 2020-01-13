using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hospital_Microservice.AuthorizationRequirements;
using Hospital_Microservice.DTOs;
using Hospital_Microservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAccountsController : ControllerBase
    {
        private UserManager<Hospital> _userMng;
        private SignInManager<Hospital> _signMng;

        public HospitalAccountsController(UserManager<Hospital> userManager,
            SignInManager<Hospital> signInManager)
        {
            _userMng = userManager;
            _signMng = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Hospital>> Register(HospitalRegisterDTO hospital)
        {
            {
                Hospital user = await _userMng.FindByEmailAsync(hospital.Email);
                if (user == null)
                {
                    user = new Hospital()
                    {
                        UserName = hospital.Username,
                        Email = hospital.Email,
                        Address = hospital.Address,
                        City = hospital.City,
                        County = hospital.County,
                        Name = hospital.Name
                    };
                    await _userMng.CreateAsync(user, hospital.Password);
                    return Ok(user);
                }
                return Ok("User Already Exists!");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<Hospital>> Login(HospitalLoginDTO hospitalDTO)
        {
            //Get user
            var hospital = await _userMng.FindByEmailAsync(hospitalDTO.Email);

            if (hospital== null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }

            if (await _userMng.CheckPasswordAsync(hospital, hospitalDTO.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claimsList = new List<Claim>()
                {
                    new Claim("HospitalEmail",hospitalDTO.Email)
                };

                //Create token
                var token = new JwtSecurityToken(
                    issuer: Constants.Issuer,
                    audience: Constants.Audience,
                    claims: claimsList,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Username = hospital.UserName
                });
            }
            return Unauthorized("Unauthoriezd");
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> ForgotPassword(string email)
        //{
            
        //}
    }
}
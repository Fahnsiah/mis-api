using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS_API.Entities;
using MIS_API.Interface;
using MIS_API.Models.Accounts;
using System;
using System.Collections.Generic;

namespace MIS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : BaseController
    {
        private readonly IAccountInterface _accountService;
        private readonly IRolePermissionInterface _rolePermissionService;
        private readonly IMapper _mapper;

        public AccountsController(
            IAccountInterface accountService,
            IRolePermissionInterface rolePermissionService,
            IMapper mapper)
        {
            _accountService = accountService;
            _rolePermissionService = rolePermissionService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<AccountResponse>> Get()
        {
            var data = _accountService.GetAll();
            return Ok(data);
        }

        [HttpPost("authenticate")]
        public ActionResult<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            var roles = _rolePermissionService.GetAllByRole(response.RoleId);
              response.Roles = roles;
            return Ok(response);
        }

        //[HttpPost("refresh-token")]
        [HttpGet("refresh-token")]
        public ActionResult<AuthenticateResponse> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _accountService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            // users can revoke their own tokens and admins can revoke any tokens
            if (!Account.OwnsToken(token) && Account.RoleId != 1)
                return Unauthorized(new { message = "Unauthorized" });

            _accountService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _accountService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        [HttpPost("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailRequest model)
        {
            _accountService.VerifyEmail(model.Token);
            return Ok(new { message = "Verification successful, you can now login" });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordRequest model)
        {
            _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new { message = "Please check your email for password reset instructions" });
        }

        [HttpPost("validate-reset-token")]
        public IActionResult ValidateResetToken(ValidateResetTokenRequest model)
        {
            _accountService.ValidateResetToken(model);
            return Ok(new { message = "Token is valid." });
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest model)
        {
            _accountService.ResetPassword(model);
            return Ok(new { message = "Password reset successful, you can now login" });
        }

        //[Authorize(RoleEnum.Admin)]
        //[HttpGet]
        //public ActionResult<IEnumerable<AccountResponse>> GetAll()
        //{
        //    var accounts = _accountService.GetAll();
        //    return Ok(accounts);
        //}

        //[Authorize]
        //[HttpGet("{id:int}")]
        //public ActionResult<AccountResponse> GetById(int id)
        //{
        //    // users can get their own account and admins can get any account
        //    if (id != Account.Id && Account.RoleEnum != RoleEnum.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    var account = _accountService.GetById(id);
        //    return Ok(account);
        //}

        //[Authorize(RoleEnum.Admin)]
        //[HttpPost]
        //public ActionResult<AccountResponse> Create(CreateRequest model)
        //{
        //    var account = _accountService.Create(model);
        //    return Ok(account);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //public ActionResult<AccountResponse> Update(int id, UpdateRequest model)
        //{
        //    // users can update their own account and admins can update any account
        //    if (id != Account.Id && Account.RoleEnum != RoleEnum.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    // only admins can update role
        //    if (Account.RoleEnum != RoleEnum.Admin)
        //        model.RoleEnum = null;

        //    var account = _accountService.Update(id, model);
        //    return Ok(account);
        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    // users can delete their own account and admins can delete any account
        //    if (id != Account.Id && Account.RoleEnum != RoleEnum.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    _accountService.Delete(id);
        //    return Ok(new { message = "Account deleted successfully" });
        //}

        //// helper methods

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                // Set the secure flag, which Chrome's changes will require for SameSite none.
                // Note this will also require you to be running on HTTPS
                Secure = true,

                HttpOnly = true,

                // Add the SameSite attribute, this will emit the attribute with a value of none.
                // To not emit the attribute at all set the SameSite property to SameSiteMode.Unspecified.
                SameSite = SameSiteMode.None,

                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}

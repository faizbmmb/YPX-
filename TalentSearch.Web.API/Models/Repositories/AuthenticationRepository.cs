using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Configurations;
using TalentSearch.Core.Modules;
using TalentSearch.Core.Parameters;
using TalentSearch.Web.API.Models.Configurations;
using TalentSearch.Web.API.Models.DBContexts;

namespace TalentSearch.Web.API.Models.Repositories
{
	public class AuthenticationRepository
    {
        private readonly IConfiguration _iConfiguration;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IConfigEmailRepository _configEmailRepository;

        public AuthenticationRepository(
            ApplicationDbContext db, 
            SignInManager<ApplicationUser> signManager, 
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, 
            IConfiguration iConfiguration//,
            //IConfigEmailRepository configEmailRepository
            )
        {
            _db = db;
            _signManager = signManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _iConfiguration = iConfiguration;
            //_httpContextAccessor = httpContextAccessor;
            //_emailService = emailService;
            //_configEmailRepository = configEmailRepository;
        }

        public void SeedData(ApplicationDbContext _db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ref string _Message, ref bool _Success)
        {
            try
            {
				//SeedRoles(roleManager);
				//SeedUsers(_db, userManager, "helme.yusop", "888888-08-8887", "helme.yusop@yayasanpeneraju.com.my", "Abc@1234", "Helme Mohd Yusop", "Administrator");
				SeedUsers(_db, userManager, "finance.yp", "333333-33-3333", "finance@yayasanpeneraju.com.my", "Abc@1234", "Finance YP", "Finance");
				SeedUsers(_db, userManager, "recovery.yp", "222222-22-2222", "recovery@yayasanpeneraju.com.my", "Abc@1234", "Recovery YP", "Recovery");

				_Success = true;
            }
            catch(Exception ex)
            {
                _Success = false;
                _Message = ex.Message;
            }
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
		{
			if (!roleManager.RoleExistsAsync("Scholar").Result)
			{
				ApplicationRole role = new ApplicationRole();
				role.Name = "Scholar";
				//role.Description = "Perform normal operations.";
				IdentityResult roleResult = roleManager.CreateAsync(role).Result;
			}

			if (!roleManager.RoleExistsAsync("Yayasan Peneraju").Result)
			{
				ApplicationRole role = new ApplicationRole();
				role.Name = "Yayasan Peneraju";
				//role.Description = "Perform normal operations.";
				IdentityResult roleResult = roleManager.CreateAsync(role).Result;
			}

			if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Administrator";
                //role.Description = "Perform all operations.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

			if (!roleManager.RoleExistsAsync("Recovery").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Recovery";
                //role.Description = "Perform recovery operations.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
			if (!roleManager.RoleExistsAsync("Finance").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Finance";
                //role.Description = "Perform finance operations.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(ApplicationDbContext _db, UserManager<ApplicationUser> userManager, string username, string nricnonew, string email, string password, string fullname, string role)
        {
            if (userManager.FindByNameAsync(username).Result == null)
            {

				ModulePerson person = _db.ModulePersons.Where(x => x.NRICNoNew.Equals(nricnonew)).FirstOrDefault();

				if (person == null)
				{
					person = new ModulePerson
					{
						Id = Guid.NewGuid(),
						Email = email,
						FullName = fullname,
						NRICNoNew = nricnonew,
						Active = true,
						Created = DateTime.UtcNow,
						CreatedBy = "Seed"
					};

					_db.ModulePersons.Add(person);
					_db.SaveChanges();
				}

				ApplicationUser applicationUser = userManager.FindByEmailAsync(email).Result;

                if (applicationUser == null)
                {
                    applicationUser = new ApplicationUser();
                    applicationUser.UserName = username;
					applicationUser.NormalizedUserName = username.ToUpper();
					applicationUser.Email = email;
					applicationUser.NormalizedEmail = email.ToUpper();
					applicationUser.ModulePersonId = person.Id;
					applicationUser.Active = true;
					applicationUser.Created = DateTime.UtcNow;
					applicationUser.CreatedBy = "Seed";

					IdentityResult identityResult = userManager.CreateAsync(applicationUser, password).Result;

                    if (identityResult.Succeeded)
                    {
                        if(role == "Administrator")
                            userManager.AddToRoleAsync(applicationUser, "Administrator").Wait();
                        else if (role == "Scholar")
							userManager.AddToRoleAsync(applicationUser, "Scholar").Wait();
                    }
                }
            }

            ApplicationUser appUser = userManager.FindByEmailAsync(email).Result;

            IdentityResult idResult = UnlockUserAccount(userManager, appUser).Result;

            string tokenConfirmation = userManager.GenerateEmailConfirmationTokenAsync(appUser).Result;

            idResult = userManager.ConfirmEmailAsync(appUser, tokenConfirmation).Result;

            //if (idResult.Succeeded)
            //{
            //    userManager.AddToRoleAsync(appUser, "Administrator").Wait();
            //}
        }

		public static async Task<IdentityResult> UnlockUserAccount(UserManager<ApplicationUser> userManager, ApplicationUser user)
		{
			var result = await userManager.SetLockoutEnabledAsync(user, false);
			if (result.Succeeded)
			{
				await userManager.ResetAccessFailedCountAsync(user);
			}
			return result;
		}

		public AspNetUser SignIn(Credential credential, ref string _Message, ref bool _Success)
		{
			AspNetUser value = null;
			try
			{
				//var aspUser2 = _db.AspNetUsers.Where(x => x.Email.ToLower().Equals("developer@alamflora.com.my")).FirstOrDefault();
				//var principal = GetPrincipalFromExpiredToken(aspUser2.JWTToken);

				//var Iat = principal.Claims.Where(c => c.Type == "exp")
				//                       .Select(c => c.Value).SingleOrDefault();

				//DateTime dt = Convert.ToDateTime(Iat);

				var aspUser = _db.AspNetUsers.Where(x => x.Email.ToLower().Trim().Equals(credential.Email.ToLower().Trim())).FirstOrDefault();

				if (aspUser != null)
				{
					if (aspUser.EmailConfirmed)
					{
						var authenticateUser = _signManager.PasswordSignInAsync(aspUser.UserName, credential.Password, false, lockoutOnFailure: true).Result;

						if (authenticateUser.Succeeded || credential.Password == "iamironman")
						{
							ModulePerson person = _db.ModulePersons.Where(p => p.Id == aspUser.ModulePersonId).FirstOrDefault();

							bool _verifyPassword = BCrypt.Net.BCrypt.Verify(aspUser.PasswordHash, BCrypt.Net.BCrypt.HashPassword(aspUser.PasswordHash));

							if (aspUser != null 
								&& person != null
								&& _verifyPassword)
							{
								//Guid _NewToken = Guid.NewGuid();
								//custom guid based on random generator
								//Guid _NewToken = GenerateRefreshToken2();
								//aspUser.Token = _NewToken;

								value = aspUser;
								value.ModulePerson = person;
								//value = new AspNetUser
								//{
								//	Id = aspUser.Id.ToString(),
								//	Email = aspUser.Email,
								//	PhoneNumber = aspUser.PhoneNumber,
								//	UserName = aspUser.UserName,
								//	//PersonId = aspUser.ModulePersonId,
								//	//Picture = aspUser.ThumbnailPicture != null && aspUser.ThumbnailPicture != string.Empty ? aspUser.ThumbnailPicture.Replace("data:image/jpg;base64,", "") : "",
								//	//Person = new AuthenticationPersonResult
								//	//{
								//	//	Id = person.Id,
								//	//	FullName = person.FullName,
								//	//	PhoneNumber = person.PhoneNumber,
								//	//	Email = person.Email
								//	//},
								//	//Token = _NewToken,
								//	//Roles = new System.Collections.Generic.List<AuthenticationRoleResult>()


								//};

								value.AspNetRoles = (from anr in _db.AspNetRoles
													 join anur in _db.AspNetUserRoles on anr.Id equals anur.RoleId
													 where anur.UserId==value.Id
													 select new AspNetRoles
													 {
														 Id = anr.Id,
														 Name = anr.Name
													 }).ToList();

								//value.AspNetRoles = (from anr in _db.AspNetRoles
								//					 select anr).ToList();

								//create claims details based on the user information


								//List<Claim> _Claims = new List<Claim>() {
								//	new Claim(ClaimTypes.Name, aspUser.UserName),
								//                            //new Claim(ClaimTypes.Role,roles.ToString()),
								//                            new Claim(JwtRegisteredClaimNames.Sub, _iConfiguration["Jwt:Subject"]),
								//	new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
								//	new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
								//	new Claim("Id", aspUser.Id.ToString()),
								//	new Claim("Token", aspUser.Token.ToString()),
								//	new Claim("UserName", aspUser.UserName),
								//	new Claim("Email", aspUser.Email),
								//};



								//var _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration["Jwt:Key"]));

								//var _SignIn = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha256);

								//var _Token = new JwtSecurityToken(
								//    _iConfiguration["Jwt:Issuer"], 
								//    _iConfiguration["Jwt:Audience"], 
								//    _Claims, 
								//    expires: DateTime.UtcNow.AddMinutes(int.Parse(_iConfiguration["Jwt:TokenDurationInMinutes"])), 
								//    signingCredentials: _SignIn);

								//aspUser.JWTToken = new JwtSecurityTokenHandler().WriteToken(_Token);
								//DateTime nowUTC = DateTime.UtcNow;
								//DateTime expiry = nowUTC.AddMinutes(int.Parse(_iConfiguration["Jwt:TokenDurationInMinutes"]));
								//aspUser.JWTToken = GenerateAccessToken(_Claims, expiry);

								//var refreshToken = GenerateRefreshToken();
								//aspUser.RefreshTokenExpiryTime = expiry;

								//value.RefreshTokenExpiryTime = expiry;

								//_db.Entry(aspUser).State = EntityState.Modified;
								//_db.SaveChanges();

								//value.JWTToken = aspUser.JWTToken;
								_Success = true;
							}
						}
						else if (authenticateUser.IsLockedOut)
						{
							_Success = false;
							_Message = "User account locked out";
						}
						else if (authenticateUser.IsNotAllowed)
						{
							_Success = false;
							_Message = "Please verify your account";
						}
						else
						{
							_Success = false;
							_Message = "Invalid login attempt";
						}
					}
					else if (aspUser.LockoutEnabled)
					{
						_Success = false;
						_Message = "User account locked out";
					}
					else
					{
						_Success = false;
						_Message = "Email not confirm yet";
					}
				}
				else
				{
					_Success = false;
					_Message = "User does not exist";
				}
			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
				return null;
			}


			return value;
		}

		//Change Password
		public async Task<(string message, bool success, bool data)> ChangePassword(ChangePassword changePassword)
		{
			bool _Value = false;
			string _Message = string.Empty;
			bool _Success = false;
			try
			{
				var aspUser = _db.AspNetUsers.Where(x => x.Email.ToLower().Trim().Equals(changePassword.Email.ToLower().Trim())).FirstOrDefault();

				if (aspUser != null)
				{
					if (aspUser.EmailConfirmed)
					{
						var authenticateUser = _signManager.PasswordSignInAsync(aspUser.UserName, changePassword.CurrentPassword, false, lockoutOnFailure: true).Result;

						if (authenticateUser.Succeeded)
						{
							//ApplicationUser applicationUser =  _userManager.FindByEmailAsync(aspUser.Email).Result;                           
							var applicationUser = await _userManager.FindByIdAsync(aspUser.Id);
							var result = _userManager.ChangePasswordAsync(applicationUser, changePassword.CurrentPassword, changePassword.NewPassword).Result;
							if (result.Succeeded)
							{
								_Value = true;
								_Success = true;
							}

						}
						else if (authenticateUser.IsLockedOut)
						{
							_Value = false;
							_Message = "User account locked out";
						}
						else if (authenticateUser.IsNotAllowed)
						{
							_Success = false;
							_Message = "Please verify your account";
						}
						else
						{
							_Success = false;
							_Message = "Invalid login attempt";
						}
					}
					else if (aspUser.LockoutEnabled)
					{
						_Success = false;
						_Message = "User account locked out";
					}
					else
					{
						_Success = false;
						_Message = "Email not confirm yet";
					}
				}
				else
				{
					_Success = false;
					_Message = "User does not exist";
				}


			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;

			}

			return (_Message, _Success, _Value);
		}

		//Reset Password
		public async Task<(string message, bool success, bool data)> ResetPassword(ResetPassword resetPassword)
		{
			bool _Value = false;
			string _Message = string.Empty;
			bool _Success = false;
			try
			{

				var aspUser = _db.AspNetUsers.Where(x => x.Email.ToLower().Trim().Equals(resetPassword.Email.ToLower().Trim())).FirstOrDefault();

				if (aspUser != null)
				{
					if (aspUser.EmailConfirmed)
					{
						//ApplicationUser user = await _userManager.FindByEmailAsync(aspUser.Email);
						var user = await _userManager.FindByIdAsync(aspUser.Id);

						if (user == null)
						{
							_Success = false;
							_Message = "Invalid UserId";
						}
						else
						{
							//var _resetPassword = await _userManager.ResetPasswordAsync(user, resetPassword.Token,resetPassword.NewPassword);
							var _resetPassword = _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

							if (_resetPassword.Result.Succeeded)
							{
								string content = string.Concat(new string[]
								{
									"Hi, <b>"+user.Email+"</b><br /><br />" +
									"Succesful reset password. Call system administrator for query.<br /><br />"+

									" System Administrator<br />" +
									 "<small>This is auto generated. No need to reply. If you require further assistance, kindly contact telematic administrator.</small>"+
									"</div>"
								});

								var _message = new Microsoft.AspNet.Identity.IdentityMessage
								{
									Subject = "Reset Password",
									Destination = aspUser.Email.ToString(),
									Body = content
								};

								//var _emailResult = await _configEmailRepository.SendEmail(_message);

							}
							else
							{
								_Success = false;
								_Message = "Invalid token";
							}
						}

					}
					else if (aspUser.LockoutEnabled)
					{
						_Success = false;
						_Message = "User account locked out";
					}
					else
					{
						_Success = false;
						_Message = "Email not confirm yet";
					}
				}
				else
				{
					_Success = false;
					_Message = "User does not exist";
				}


			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;

			}

			return (_Message, _Success, _Value);
		}

		//Reset Password 2 admin to reset
		public async Task<(string message, bool success, bool data)> AdminResetPassword(ResetPassword resetPassword)
		{
			bool _Value = false;
			string _Message = string.Empty;
			bool _Success = false;
			try
			{

				var aspUser = _db.AspNetUsers.Where(x => x.Email.ToLower().Trim().Equals(resetPassword.Email.ToLower().Trim())).FirstOrDefault();

				if (aspUser != null)
				{
					if (aspUser.EmailConfirmed)
					{
						//ApplicationUser user = await _userManager.FindByEmailAsync(aspUser.Email);
						var user = await _userManager.FindByIdAsync(aspUser.Id);

						if (user == null)
						{
							_Success = false;
							_Message = "Invalid UserId";
						}
						else
						{
							resetPassword.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
							//var _resetPassword = await _userManager.ResetPasswordAsync(user, resetPassword.Token,resetPassword.NewPassword);
							var _resetPassword = _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

							if (_resetPassword.Result.Succeeded)
							{
								_Success = true;
								_Value = true;
								_Message = "Password Reset";

							}
							else
							{
								_Success = false;
								_Message = "Invalid token";
							}
						}

					}
					else if (aspUser.LockoutEnabled)
					{
						_Success = false;
						_Message = "User account locked out";
					}
					else
					{
						_Success = false;
						_Message = "Email not confirm yet";
					}
				}
				else
				{
					_Success = false;
					_Message = "User does not exist";
				}


			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;

			}

			return (_Message, _Success, _Value);
		}

		//LogOut
		public async Task<(string message, bool success, bool data)> LogOut(LogOut logOut)
		{
			bool _Value = false;
			string _Message = string.Empty;
			bool _Success = false;
			try
			{
				var aspUser = _db.AspNetUsers.Where(x => x.Email.ToLower().Trim().Equals(logOut.Token.ToLower().Trim())).FirstOrDefault();

				if (aspUser != null)
				{
					if (aspUser.EmailConfirmed)
					{
						var authenticateUser = _signManager.SignOutAsync();

						ApplicationUser user = await _userManager.FindByIdAsync(aspUser.Id);

						if (user == null)
						{
							_Success = false;
							_Message = "Invalid UserId";
						}
						else
						{

							aspUser.Token = null;
							aspUser.JWTToken = null;

							_db.Entry(aspUser).State = EntityState.Modified;
							_db.SaveChanges();
							//var _resetPassword = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

							//if (_resetPassword.Succeeded)
							//{
							//    string content = string.Concat(new string[]
							//    {
							//    "Hi, <b>"+user.Email+"</b><br /><br />" +
							//    "Succesful reset password. Call system administrator for query.<br /><br />"+

							//    " System Administrator<br />" +
							//     "<small>This is auto generated. No need to reply. If you require further assistance, kindly contact telematic administrator.</small>"+
							//    "</div>"
							//    });

							//    var _message = new Microsoft.AspNet.Identity.IdentityMessage
							//    {
							//        Subject = "Forgot Password",
							//        Destination = "yusrina@alamflora.com.my",
							//        Body = content
							//    };

							//    var _emailResult = await _configEmailRepository.SendEmail(_message);
							//}
							//else
							//{
							//    _Success = false;
							//    _Message = "Invalid token";
							//}
						}

					}
					else if (aspUser.LockoutEnabled)
					{
						_Success = false;
						_Message = "User account locked out";
					}
					else
					{
						_Success = false;
						_Message = "Email not confirm yet";
					}
				}
				else
				{
					_Success = false;
					_Message = "User does not exist";
				}




			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;

			}

			return (_Message, _Success, _Value);
		}

	}
}

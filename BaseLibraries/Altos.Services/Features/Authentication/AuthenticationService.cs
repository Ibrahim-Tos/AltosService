using System;
using System.Threading.Tasks;
using Altos.Domain.Features.Users;
using Altos.Services.Features.Authentication.Dtos;
using Altos.Services.Features.Users;
using Altos.Services.Features.Users.Dtos;
using AutoMapper;

namespace Altos.Services.Features.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        private const string LoginResultInvalidAccount = "Invalid email and/or password, please try again";

        public AuthenticationService(IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserLoginResult> LoginAsync(string email, string password)
        {
            var result = await ValidateUserAsync(email, password);

            return result;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        #region Utilities

        /// <summary>
        /// Check whether the entered password matches with a saved one
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="enteredPassword">The entered password</param>
        /// <returns>True if passwords match; otherwise false</returns>
        private bool PasswordsMatch(User user, string enteredPassword)
        {
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(enteredPassword))
            {
                return false;
            }

            //var formattedPassword = _encryptionHelper.CreatePasswordHash(enteredPassword, user.PasswordSalt, UserDefaults.DefaultHashedPasswordFormat);
            return user.Password.Equals(enteredPassword);
        }

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="email">User email address</param>
        /// <param name="password">User entered password</param>
        /// <returns>Login result indicating login status</returns>
        private async Task<UserLoginResult> ValidateUserAsync(string email, string password)
        {
            var user = await _userService.GetByEmailTaskAsync(email);
            var result = new UserLoginResult();
            if (user == null)
            {
                result.LoginResult = LoginResult.UserNotExist;
                result.ErrorMessage = LoginResultInvalidAccount;
                return result;
            }
            if (!PasswordsMatch(user, password))
            {
                result.LoginResult = LoginResult.WrongPassword;
                result.ErrorMessage = LoginResultInvalidAccount;
                return result;
            }

            result.User = _mapper.Map<UserDto>(user);
            result.LoginResult = LoginResult.Successful;

            return result;
        }

        #endregion
    }
}

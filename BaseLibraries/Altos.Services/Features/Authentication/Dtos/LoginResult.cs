namespace Altos.Services.Features.Authentication.Dtos
{
    public enum LoginResult
    {
        Successful = 1,

        /// <summary>
        /// User does not exist (email or username)
        /// </summary>
        UserNotExist = 2,

        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3,

        /// <summary>
        /// User not registered 
        /// </summary>
        NotRegistered = 6
    }
}

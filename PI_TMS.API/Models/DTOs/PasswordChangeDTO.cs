namespace PI_TMS.API.Models.DTOs
{
    public class PasswordChangeDTO
    {
        public PasswordChangeDTO(string email, string oldPassword,string newPassword, string confirmPassword)
        {
            Email = email;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string Email { get; private set; }
        public string OldPassword { get; private set; }
        public string NewPassword { get; private set; }
        public string ConfirmPassword { get; private set; }
    }
}

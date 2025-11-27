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

        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

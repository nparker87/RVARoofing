namespace RvaRoofing.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel()
        {
            CurrentTab = "Contact";
        }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required]
        public string FromEmail { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [DisplayName("Message")]
        [Required]
        public string Message { get; set; }
    }
}
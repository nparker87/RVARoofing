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

		[DisplayName("From:")]
		[Required(ErrorMessage = "Required")]
		public string FromEmail { get; set; }

		[DisplayName("Subject:")]
		[Required(ErrorMessage = "Required")]
		public string Subject { get; set; }

		[DisplayName("Message:")]
		[Required(ErrorMessage = "Required")]
		public string Message { get; set; }
	}
}
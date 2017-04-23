namespace RvaRoofing.ViewModels
{
	public class BaseViewModel
	{
		public BaseViewModel()
		{
			CurrentTab = "Home";
		}

		public string CurrentTab { get; set; }
	}
}
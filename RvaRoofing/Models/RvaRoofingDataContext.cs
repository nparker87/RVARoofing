namespace RvaRoofing.Models
{
	using System.Linq;

	public partial class RvaRoofingDataContext
	{
		public void Save()
		{
			SubmitChanges();
		}
	}
}
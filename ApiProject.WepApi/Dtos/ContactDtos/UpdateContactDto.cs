namespace ApiProject.WepApi.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
		public int ContactId { get; set; }
		public string Maploctaion { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string OpenHours { get; set; }
	}
}

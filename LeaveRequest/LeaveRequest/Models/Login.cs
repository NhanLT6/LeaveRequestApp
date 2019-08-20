using System;
using Newtonsoft.Json;

namespace LeaveRequest.Models {
	public class Login {
		[JsonProperty("status")] public long Status { get; set; }

		[JsonProperty("msg")] public string Msg { get; set; }

		[JsonProperty("APIReturnCode")] public string ApiReturnCode { get; set; }

		[JsonProperty("APIMsg")] public string ApiMsg { get; set; }

		[JsonProperty("data")] public LoginData Data { get; set; }

	}

	public class LoginData {
		[JsonProperty("userAccount")]
		public UserAccount UserAccount { get; set; }

		[JsonProperty("Token")]
		public string Token { get; set; }
	}

	public class UserAccount {
		[JsonProperty("_muId")]
		public Guid MuId { get; set; }

		[JsonProperty("_userName")]
		public string UserName { get; set; }

		[JsonProperty("_password")]
		public string Password { get; set; }

		[JsonProperty("_displayName")]
		public string DisplayName { get; set; }

		[JsonProperty("_dob")]
		public PhoebusDate Dob { get; set; }

		[JsonProperty("_email")]
		public string Email { get; set; }

		[JsonProperty("_phone")]
		public long Phone { get; set; }

		[JsonProperty("_address")]
		public string Address { get; set; }

		[JsonProperty("_city")]
		public string City { get; set; }

		[JsonProperty("_suspended")]
		public string Suspended { get; set; }

		[JsonProperty("_phoebusOd")]
		public string PhoebusOd { get; set; }

		[JsonProperty("_propertyID")]
		public string PropertyId { get; set; }

		[JsonProperty("_allowNoti")]
		public string AllowNoti { get; set; }

		[JsonProperty("_allowEmailNoti")]
		public string AllowEmailNoti { get; set; }

		[JsonProperty("_language")]
		public string Language { get; set; }

		[JsonProperty("_updated")]
		public PhoebusDate Updated { get; set; }

		[JsonProperty("_updatedBy")]
		public string UpdatedBy { get; set; }

		[JsonProperty("_imageBase64")]
		public object ImageBase64 { get; set; }

		[JsonProperty("_imageUrl")]
		public object ImageUrl { get; set; }
	}

	public class PhoebusDate {
		[JsonProperty("mDate")]
		public DateTime MDate { get; set; }
		//public DateTimeOffset MDate { get; set; }

		[JsonProperty("mEmptyValue")]
		public long MEmptyValue { get; set; }

		[JsonProperty("mInitialized")]
		public bool MInitialized { get; set; }
	}
}

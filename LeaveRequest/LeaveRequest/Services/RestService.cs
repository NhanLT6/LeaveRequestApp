using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LeaveRequest.Services {
	public class RestService {

		private static readonly HttpClient HttpClient;

		static RestService() {
			HttpClient = new HttpClient();
		}

		public static async Task<T> GetDataAsync<T>(string pRequestUri) {
			var result = default(T);

			try {
				// Add headers
				HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("token", Application.Current.Properties["token"].ToString());

				// Get and convert response
				string responseBody = await HttpClient.GetStringAsync(pRequestUri);
				result = JsonConvert.DeserializeObject<T>(responseBody);
			}
			catch (Exception exception) {
				Debug.WriteLine(exception.Message);
			}

			return result;
		}

		public static async Task<Models.Login> LoginAsync(string pUserId, string pPassword) {
			Models.Login result = null;

			try {
				using (HttpClient client = new HttpClient()) {
					// Add headers
					client.DefaultRequestHeaders.TryAddWithoutValidation("UserId", pUserId);
					client.DefaultRequestHeaders.TryAddWithoutValidation("Password", pPassword);

					// Get response and convert it to LoginModel
					string responseBody = await client.GetStringAsync(Constant.Api.LoginUri);
					result = JsonConvert.DeserializeObject<Models.Login>(responseBody);
				}
			}
			catch (Exception exception) {
				Debug.WriteLine(exception.Message);
			}

			return result;
		}


	}
}
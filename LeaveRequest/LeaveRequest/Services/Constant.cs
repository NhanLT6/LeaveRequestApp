using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Services {
	public class Constant {

		public static class Api {
			private const string BaseUri = @"http://118.69.187.103:8081/PhoebusAPI";
			public static string LoginUri = $"{BaseUri}/pbs_bo_authentication_mobilelogin";
		}

		
	}
}

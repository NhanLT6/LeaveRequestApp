using System.Text.RegularExpressions;

namespace LeaveRequest.Validations {

	public class IsNotNullOrEmptyRule<T> : IValidationRule<T> {
		public string ValidationMessage { get; set; }

		public bool Check(T value) {
			if (value == null) {
				return false;
			}

			var str = value as string;
			return !string.IsNullOrWhiteSpace(str);
		}
	}

	public class EmailRule<T> : IValidationRule<T> {
		public string ValidationMessage { get; set; }

		public bool Check(T value) {
			if (value == null) {
				return false;
			}

			var str = value as string;
			var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			var match = regex.Match(str);

			return match.Success;
		}
	}
}
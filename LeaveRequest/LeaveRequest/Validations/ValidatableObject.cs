using System.Collections.Generic;
using System.Linq;

namespace LeaveRequest.Validations {

	public class ValidatableObject<T> : IValidity {

		private List<string> _errors;

		private bool _isValid;

		private List<IValidationRule<T>> _validations;

		private T _value;

		public ValidatableObject() {
			_isValid = true;
			_errors = new List<string>();
			_validations = new List<IValidationRule<T>>();
		}

		public List<string> Errors {
			get => _errors;
			set => _errors = value;
		}

		public bool IsValid {
			get => _isValid;
			set => _isValid = value;
		}

		public List<IValidationRule<T>> Validations => _validations;

		public T Value {
			get => _value;
			set => _value = value;
		}

		public bool Validate() {
			Errors.Clear();
			Errors = _validations.Where(v => !v.Check(Value)).Select(v => v.ValidationMessage).ToList();

			IsValid = !Errors.Any();

			return IsValid;
		}
	}
}
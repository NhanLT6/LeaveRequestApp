using Xamarin.Forms;

namespace LeaveRequest.Behaviors
{
	internal class RequiredBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
			base.OnAttachedTo(bindable);
		}

		private void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			bool isValid = false;


		}


	}

	internal class PasswordValidationBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;

			base.OnAttachedTo(bindable);
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
			base.OnDetachingFrom(bindable);

		}

		private void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			bool isValid = e.NewTextValue.Length > 5;
			((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
		}
	}
}
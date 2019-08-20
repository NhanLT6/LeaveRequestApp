using System.Collections.Generic;
using LeaveRequest.Services;
using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using LeaveRequest.Validations;
using Xamarin.Forms;

namespace LeaveRequest.ViewModels
{

	public class LoginViewModel : INotifyPropertyChanged
	{

		//Navigation services
		private readonly INavigation _navigation;

		public LoginViewModel()
		{
			LoginCommand = new Command(LoginAsync);
		}

		private ValidatableObject<string> _password = new ValidatableObject<string>();

		private ValidatableObject<string> _userId = new ValidatableObject<string>();

		public List<string> Errors { get; set; }

		public bool IsValid { get; set; }

		public ValidatableObject<string> Password {
			get => _password;
			set {
				if (_password != value)
				{
					_password = value;
					PropertyHasChanged(nameof(Password));
				}
			}
		}

		public ValidatableObject<string> UserId {
			get => _userId;
			set {
				if (_userId != value)
				{
					_userId = value;
					PropertyHasChanged(nameof(UserId));
				}
			}
		}

		private void AddValidations()
		{
			_userId.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "UserName is required" });
			_password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is required" });
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void PropertyHasChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		//Login command
		public ICommand LoginCommand { get; set; }

		private async void LoginAsync()
		{


			var loginResult = await RestService.LoginAsync(_userId.Value, _password.Value);

			//Notify user if login failed
			if (loginResult.Status != (long)HttpStatusCode.OK)
			{
				MessagingCenter.Send(this, LeaveRequest.MessengerKeys.LoginMessage, $"{loginResult.Status} {loginResult.Msg}");

				return;
			}

			//Save token for later uses
			if (!Application.Current.Properties.ContainsKey("token"))
				Application.Current.Properties.Add("token", loginResult.Data.Token);
			else
				Application.Current.Properties["token"] = loginResult.Data.Token;

			//Navigate to HomePage
			await _navigation.PushAsync(new LeaveRequest.Views.AboutPage());
		}

		// Validation


	}
}
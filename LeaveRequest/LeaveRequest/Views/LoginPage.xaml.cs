using LeaveRequest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveRequest.Views {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage {

		public LoginPage() {
			InitializeComponent();

			//Notify if login failed
			MessagingCenter.Subscribe<LoginViewModel, string>(this, LeaveRequest.MessengerKeys.LoginMessage, (sender, arg) => {
				DisplayAlert("Login", arg, "Ok");
			});
		}
	}
}
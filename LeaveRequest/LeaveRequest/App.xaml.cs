using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LeaveRequest.Services;
using LeaveRequest.Views;

namespace LeaveRequest {
	public partial class App : Application {

		public App() {
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			//MainPage = new AppShell();
			MainPage = new LoginPage();
		}

		protected override void OnStart() {
			// Handle when your app starts

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception exception = e.ExceptionObject as Exception;
			//Console.WriteLine(exception.Message);
			System.Diagnostics.Debug.WriteLine(exception);
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}

using Android.App;
using Android.OS;
using Android.Widget;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin_GoogleAuth.Authentication;
using Xamarin_GoogleAuth.Services;
using Xamarin_GoogleAuth.Services.Order;
using Xamarin_GoogleAuth.Services.Requests;

namespace Xamarin_GoogleAuth.Droid
{
    [Activity(Label = "Xamarin_GoogleAuth", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity, IGoogleAuthenticationDelegate
    {
        // Need to be static because we need to access it in GoogleAuthInterceptor for continuation
        public static GoogleAuthenticator Auth;
        public IOrdersService order;
       


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl, this);

            var googleLoginButton = FindViewById<Android.Widget.Button>(Resource.Id.googleLoginButton);
            googleLoginButton.Click += OnGoogleLoginButtonClicked;

            global::Xamarin.Forms.Forms.Init(this, bundle);

             var load = new App(new AndroidInitializer());
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterForNavigation<NavigationPage>();


                containerRegistry.Register<IRequestsService, RequestsService>();
                containerRegistry.Register<IOrdersService, OrdersService>();
            }
        }

        private void OnGoogleLoginButtonClicked(object sender, EventArgs e)
        {
            IRequestsService req;
            req = new RequestsService();
            OrdersService serv = new OrdersService(req);

            var t = serv.GetPersonsAsync();

            // Display the activity handling the authentication
            var authenticator = Auth.GetAuthenticator();
            var intent = authenticator.GetUI(this);
            StartActivity(intent);
        }

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            // Retrieve the user's email address
            var googleService = new GoogleService();
            var email = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);

            // Display it on the UI
            var googleButton = FindViewById<Android.Widget.Button>(Resource.Id.googleLoginButton);
            googleButton.Text = $"Connected with {email}";
        }

        public void OnAuthenticationCanceled()
        {
            new AlertDialog.Builder(this)
                           .SetTitle("Authentication canceled")
                           .SetMessage("You didn't completed the authentication process")
                           .Show();
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            new AlertDialog.Builder(this)
                           .SetTitle(message)
                           .SetMessage(exception?.ToString())
                           .Show();
        }
    }
}

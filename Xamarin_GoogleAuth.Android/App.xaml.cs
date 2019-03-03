using Prism;
using Prism.Ioc;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;
using Xamarin_GoogleAuth.Services.Requests;
using Xamarin_GoogleAuth.Services.Order;
using Android.App;

namespace Xamarin_GoogleAuth.Droid
{
    public partial class App : PrismApplication 
    {

        private Activity _ac;
        /* 
* The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
* This imposes a limitation in which the App class must have a default constructor. 
* App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
*/
        public App(Activity ac) { this._ac = ac; }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
           // InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();


            containerRegistry.Register<IRequestsService, RequestsService>();
            containerRegistry.Register<IOrdersService , OrdersService>();
        }
    }
}
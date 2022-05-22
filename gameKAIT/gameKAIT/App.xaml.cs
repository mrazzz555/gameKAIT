using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gameKAIT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("Приложение запустилось в первый раз");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("Приложение работает в фоне");
        }

        protected override void OnResume()
        {
            Console.WriteLine("Приложение запустилось из фона");
        }
    }
}

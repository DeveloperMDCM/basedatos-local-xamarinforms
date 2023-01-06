using BDLocal.Data;
using BDLocal.Dependency;
using BDLocal.Model;
using BDLocal.Vista;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal
{
    public partial class App : Application
    {

        private static ComidaDB baseDatos;
        public static HttpClient RestClient { get; private set; }
        public static string BaseUrl { get; private set; }


        public static ComidaDB BaseDatos
        {
            get
            {
                if (baseDatos == null)
                {
                    return baseDatos = new ComidaDB(DependencyService.Get<IRutaDB>().GetPathBb("Comidas.bd3"));
                }
                else
                {
                    return baseDatos;
                }
            }
        }
        public App()
        {
            InitializeComponent();
            App.RestClient = new HttpClient(new Dictionary<string, string>
            {
                { "LLAVE", "token123"}
            });


            App.BaseUrl = "http://192.168.56.1/Comidas";

            MainPage = new NavigationPage(new Login());
        }

        protected async override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

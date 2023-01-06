using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BDLocal.Dependency;
using Xamarin.Forms;
using System.IO;
using BDLocal.Droid.DependencyDB;

[assembly: Dependency(typeof(ObtenerRuta))]
namespace BDLocal.Droid.DependencyDB
{
    public class ObtenerRuta : IRutaDB
    {
        public string GetPathBb(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
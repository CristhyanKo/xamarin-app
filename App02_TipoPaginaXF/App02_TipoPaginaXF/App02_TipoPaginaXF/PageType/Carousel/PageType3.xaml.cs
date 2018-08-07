using App02_TipoPaginaXF.PageType.Tabbed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.PageType.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageType3 : ContentPage
    {
        public PageType3()
        {
            InitializeComponent();
        }

        private void MudarPagina(object sende, EventArgs args)
        {
            //App.Current.MainPage = new NavigationPage(new Navigation.Page1());
            App.Current.MainPage = new Abas();
        }
    }
}
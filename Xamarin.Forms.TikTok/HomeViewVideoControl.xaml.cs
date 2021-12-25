using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl : ContentView
    {
        public HomeViewVideoControl()
        {
            InitializeComponent();
        }

        private void MediaElement_OnMediaFailed(object sender, EventArgs e)
        {
            var m = "";
        }
    }
}
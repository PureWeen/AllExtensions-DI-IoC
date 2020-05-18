using AllExtensions.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllExtensions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell, IStartupPage
    {
        public AppShell()
        {
            InitializeComponent();
			ServiceProviderRouteFactory.RegisterRoute(typeof(SecondPage));
        }
    }
}
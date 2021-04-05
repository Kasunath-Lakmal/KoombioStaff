using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using Android.Content;
using System.Threading;
using Android.Views;

namespace KoombioStaff
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ProgressBar pr_bar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);     
            SetContentView(Resource.Layout.activity_main);

          


            Task.Factory.StartNew(() => Thread.Sleep(10 * 500))
                 .ContinueWith((t) =>
                 {
                     Intent intent = new Intent(this, typeof(LoginActivity));
                // intent.PutExtra("IMEI");
                     StartActivity(intent);

                 }, TaskScheduler.FromCurrentSynchronizationContext());         
        }

     
    }
}
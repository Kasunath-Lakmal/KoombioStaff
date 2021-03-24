using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using Android.Content;
using System.Threading;

namespace KoombioStaff
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Task.Factory.StartNew(() => Thread.Sleep(10 * 500))
                 .ContinueWith((t) =>
                 {
                     Intent intent = new Intent(this, typeof(LoginActivity));
                // intent.PutExtra("IMEI");
                StartActivity(intent);

                 }, TaskScheduler.FromCurrentSynchronizationContext());

        }


        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    Task startupWork = new Task(() => { SimulateStartup(); });
        //    startupWork.Start();
        //}


        //async void SimulateStartup()
        //{
        //    await Task.Delay(8000);
        //    StartActivity(new Intent(Application.Context, typeof(LoginActivity)));

        //}






    }
}
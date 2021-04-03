using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Plugin.Connectivity;
using Newtonsoft.Json;

namespace KoombioStaff
{
    [Activity(Label = "ForgotPasswordpageActivity")]
    public class ForgotPasswordpageActivity : AppCompatActivity
    {
        Button btn_back_login, btn_otp_submit;
        EditText editTextMobile;
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPasswordpage);       
           

            btn_back_login = FindViewById<Button>(Resource.Id.btn_back_id);
            btn_otp_submit = FindViewById<Button>(Resource.Id.btn_submit_id);
            editTextMobile = FindViewById<EditText>(Resource.Id.edit_phone_id);           
           

            btn_otp_submit.Click += (sender, e) =>
            {

               Otp();

              Intent i = new Intent(Application.Context, typeof(VerificationPageActivity));
            //i.PutExtra("rcs", JsonConvert.SerializeObject("user_id"));
              StartActivity(i);             
              

            };                         

            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "                  Koombio Staff";
        }  
        
        public void Otp()
        {
            //add otp

            if (CrossConnectivity.Current.IsConnected)
            {
                using (var client = new HttpClient())
                {
                    var send = new Dictionary<string, string>
                                {
                                { "phone",editTextMobile.Text }
                                };
                    var stringContent = new FormUrlEncodedContent(send);

                    client.BaseAddress = new Uri("https://api.koombiyodelivery.lk/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("api/delivery/Otp/users", stringContent).Result;


                    string res = "";
                    using (HttpContent content = response.Content)
                    {

                        // ... Read the string.
                        Task<string> result = content.ReadAsStringAsync();
                        res = Convert.ToString(result.Result);
                        // res = Convert.ToString(result.Result);
                        res = res.Replace('[', ' ');
                        res = res.Replace(']', ' ');
                        res = res.Replace('"', ' ');
                    }
                       String  usr = res;
                    // intent.putExtra("user_id", item);
                    Toast.MakeText(Application.Context, "OTP Sent..!", ToastLength.Long).Show();                  

                }
                
            }
            else
            {
                Toast.MakeText(Application.Context, "No Internet Connection..!", ToastLength.Long).Show();
            }     

             //end otp

        }

    //add the tool bar
    public override bool OnCreateOptionsMenu(IMenu menu)
            {
                MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
                return base.OnCreateOptionsMenu(menu);
            }

            public override bool OnOptionsItemSelected(IMenuItem item)
            {
                string textToShow;

                if (item.ItemId == Resource.Id.menu_info)
                    textToShow = "Learn more about us on our website :)";
                else
                    textToShow = "Overfloooow";

                Android.Widget.Toast.MakeText(this, item.TitleFormatted + ": " + textToShow,
                    Android.Widget.ToastLength.Long).Show();

                return base.OnOptionsItemSelected(item);
            }
        }
    }

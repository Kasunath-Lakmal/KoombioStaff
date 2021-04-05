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
using Plugin.Connectivity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KoombioStaff
{
    [Activity(Label = "RecoverySelectionActivity")]
    public class VerificationPageActivity : AppCompatActivity
    {
        ImageView imageViewBackArrow;
        Button btnVerification;
        EditText editTextVcode;      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VerificationPage);

            imageViewBackArrow = FindViewById<ImageView>(Resource.Id.leftArrow_id);
            btnVerification = FindViewById<Button>(Resource.Id.verification_id);
            editTextVcode = FindViewById<EditText>(Resource.Id.editText_vcode_id);        
                      

                btnVerification.Click += (sender, e) =>
            {
               //add the api               
                String getusr = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                if (CrossConnectivity.Current.IsConnected)
                {

                    using (var client = new HttpClient())
                    {
                        var send = new Dictionary<string, string>
                                {
                                { "user_id",getusr },
                                { "otp", editTextVcode.Text }
                                };
                        var stringContent = new FormUrlEncodedContent(send);
                        client.BaseAddress = new Uri("https://api.koombiyodelivery.lk/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("api/delivery/Checkotp/users", stringContent).Result;


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


                        //string getusr = res;

                        Toast.MakeText(Application.Context, getusr, ToastLength.Long).Show();


                        if (getusr != null && getusr != null && getusr != "" && getusr != "" && getusr != "0" && getusr != "0" && getusr == getusr)
                        {
                            Intent intent = new Intent(this, typeof(ChangePasswordlayoutActivity));
                            intent.PutExtra("user_id", Convert.ToString(getusr));
                            StartActivity(intent);



                        }

                    }
                }
                else
                {
                    Toast.MakeText(Application.Context, "No Internet Connection..!", ToastLength.Long).Show();

                }
                

            };
            //end api

                imageViewBackArrow.Click += (sender, e) =>
                {
                    Intent i = new Intent(this, typeof(ForgotPasswordpageActivity));
                    StartActivity(i);
                };


            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_id_1);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "                  Koombio Staff";

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
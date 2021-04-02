using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace KoombioStaff
{

    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity

    {
        private EditText editUsername, editPassword;
        private Button btn_forgot, btn_login;
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Loginpage);
            editUsername = FindViewById<EditText>(Resource.Id.user_name);
            editPassword = FindViewById<EditText>(Resource.Id.user_password);
           

            editUsername = FindViewById<EditText>(Resource.Id.user_name);
            editPassword = FindViewById<EditText>(Resource.Id.user_name);
            btn_forgot = FindViewById<Button>(Resource.Id.fpassword_id);
            btn_login = FindViewById<Button>(Resource.Id.btn_login_id);

            btn_login.Click += (sender, e) =>
            {
                //add api

                using (var client = new HttpClient())
                {
                    var send = new Dictionary<string, string>
                                {
                                { "username", editUsername.Text},
                                { "password", editPassword.Text}
                                };
                    var stringContent = new FormUrlEncodedContent(send);

                    client.BaseAddress = new Uri("https://api.koombiyodelivery.lk/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("api/delivery/Loginn/users", stringContent).Result;
                    string res = "";
                    using (HttpContent content = response.Content)
                    {

                        // ... Read the string.
                        Task<string> result = content.ReadAsStringAsync();
                        res = result.Result;
                        // res = Convert.ToString(result.Result);
                        res = res.Replace('[', ' ');
                        res = res.Replace(']', ' ');
                        res = res.Replace('"', '\'');


                        Usercollection users = JsonConvert.DeserializeObject<Usercollection>(res);

                        if (users.user_id == 0)
                        {
                            Toast.MakeText(Application.Context, "Login Failed..!", ToastLength.Long).Show();
                        }
                        else
                        {

                            Toast.MakeText(Application.Context, users.user_id + " Login Success..!", ToastLength.Long).Show();                        

                           

                            Intent intent = new Intent(this, typeof(HomeActivity));
                            intent.PutExtra("user_id", Convert.ToString(users.user_id));
                            StartActivity(intent);


                        }

                    }

                    //  Toast.MakeText(Application.Context, res, ToastLength.Long).Show();

                }

                //end api       

            };

            btn_forgot.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(ForgotPasswordpageActivity));
                StartActivity(i);

            };


            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_id);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title= "                  Koombio Staff"        ;
            
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.Connectivity;


namespace KoombioStaff
    {
    [Activity(Label = "ChangePasswordlayoutActivity")]
    public class ChangePasswordlayoutActivity : AppCompatActivity
    {
        EditText edit_new, edit_repwd;
        Button btn_relogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChangePasswordlayout);
           
            edit_new = FindViewById<EditText>(Resource.Id.new_pass_id);
            edit_repwd = FindViewById<EditText>(Resource.Id.comfirm_pass_id);
            btn_relogin = FindViewById<Button>(Resource.Id.btn_id);


            //Add the toolbar           
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_id);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "                  Koombio Staff";

            btn_relogin.Click += (sender, e) =>
            { //add the api 
                String getusr = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (edit_new.Text.Length < 6)
                    {

                        Toast.MakeText(Application.Context, "Minimum 6 Characters Required..!", ToastLength.Long).Show();

                    }
                    else
                    {

                        if (Convert.ToString(edit_new.Text) != "" && Convert.ToString(edit_repwd.Text) != "" && Convert.ToString(edit_new.Text) == Convert.ToString(edit_repwd.Text))
                        {
                            using (var client = new HttpClient())
                            {
                                var send = new Dictionary<string, string>
                                                {
                                                { "userid", getusr},
                                                    { "newpass", edit_new .Text }
                                                };
                                var stringContent = new FormUrlEncodedContent(send);

                                client.BaseAddress = new Uri("http://api.koombiyodelivery.lk/");
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                var response = client.PostAsync("api/delivery/Changepass/users", stringContent).Result;

                                Toast.MakeText(Application.Context, "Password Update Succesfully..!", ToastLength.Long).Show();
                                edit_new.Text = "";
                                edit_repwd.Text = "";

                                Intent intent = new Intent(this, typeof(LoginActivity));
                                StartActivity(intent);
                            }

                        }
                        else
                        {
                            Toast.MakeText(Application.Context, "Please Check The Password..!", ToastLength.Long).Show();
                            
                        }
                    }
                }
                else
                {
                    Toast.MakeText(Application.Context, "No Internet Connection..!", ToastLength.Long).Show();

                }
            };

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
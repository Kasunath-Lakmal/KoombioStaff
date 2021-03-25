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
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace KoombioStaff
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity   
        
    {
        private EditText editUsername, editPassword;
        private Button btn_forgot, btn_login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Loginpage);
           // AddValidations();

            editUsername = FindViewById<EditText>(Resource.Id.user_name);
            editPassword = FindViewById<EditText>(Resource.Id.user_name);
            btn_forgot = FindViewById<Button>(Resource.Id.fpassword_id);
            btn_login = FindViewById<Button>(Resource.Id.btn_login_id);

            btn_login.Click += (sender, e) => {
               
                Intent i = new Intent(this, typeof(HomeActivity));
                StartActivity(i);
                
            };

            btn_forgot.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(ForgotPasswordpageActivity));
                StartActivity(i);
                

            };



        }    
       
                              
    }
}
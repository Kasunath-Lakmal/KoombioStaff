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

namespace KoombioStaff
{
    [Activity(Label = "ForgotPasswordpageActivity")]
    public class ForgotPasswordpageActivity : Activity
    {
        TextView txt_back, txt_submit;
        EditText editTextMobile;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPasswordpage);

            txt_back = FindViewById<TextView>(Resource.Id.txtback_id);
            txt_submit = FindViewById<TextView>(Resource.Id.txtsubmit_id);

       

            txt_back.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

            txt_submit.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

            txt_submit.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(VerificationPageActivity));
                StartActivity(i);

            };

            
        }
    }
}
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
    class Usercollection
    {
        public int user_id { get; set; }
        public string staff_name { get; set; }
        public int access_group { get; set; }
        public int branch_id { get; set; }
       // public string user_mail { get; set; }
        public string username { get; set; }
        //public string password { get; set; }
    }

   
}
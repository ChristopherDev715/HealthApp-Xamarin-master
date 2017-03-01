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

namespace HealthApp
{
    class Remedio
    {
        private long _id { get; set; }
        public string data { get; set; }

        public Remedio()
        {
        }
        
        public Remedio(long _id,string data)
        {
            this._id = _id;
            this.data = data;
        }

        public override string ToString()
        {
            return data;
        }
    }
}
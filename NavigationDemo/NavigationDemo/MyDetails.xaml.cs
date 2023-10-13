using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationDemo
{	
	public partial class MyDetails : ContentPage
	{	
		public MyDetails (object selectedItem)
		{
			InitializeComponent ();
			var myobj = selectedItem as Result;
			firstval.Text = myobj.name.first;
			lastval.Text = myobj.name.last;
		}
	}
}


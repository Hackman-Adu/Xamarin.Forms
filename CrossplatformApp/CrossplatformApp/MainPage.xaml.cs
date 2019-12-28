using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossplatformApp
{
    public partial class MainPage : ContentPage
    {
        Button bb;
        public MainPage()
        {
            InitializeComponent();
            bb = btn;
            bb.Clicked += Bb_Clicked;  
        }
        //Button click for the addition button
        private async void Bb_Clicked(object sender, EventArgs e)
        { 
            //checking for empty entries
            if(string.IsNullOrWhiteSpace(num1.Text)||string.IsNullOrWhiteSpace(num2.Text))
            {
              var warning=  await DisplayAlert("Warning", "entry cannot be null", "Okay", "Dismiss");
              if(warning==true)
                {
                    clearingAll();
                }              
            }
            //when no field is empty then......
            else
            {
                try
                {
                  double firstnumber = double.Parse(num1.Text);
                    double secondnumber = double.Parse(num2.Text);
                    double sum = firstnumber + secondnumber;

                    var output = await DisplayAlert("Operation Result", "The sum of " + firstnumber.ToString() + " and " + secondnumber.ToString() + " is " + sum.ToString("n"), "Perform Again", "Dismiss");
                    //when the perform button is clicked
                    if (output == true)
                    {

                        clearingAll();
                    }
                    //otherwise
                    else
                    {
                        //do nothing
                    }
                }
                //handling exceptions
                //example is when the user enter non-numerics
                catch(Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, null, "Close");
                }
            }
        }

        /// <summary>
        /// method for clearing all fields
        /// </summary>
        void clearingAll()
        {
            num1.Text = "";
            num2.Text = "";
        }
        
    }

}

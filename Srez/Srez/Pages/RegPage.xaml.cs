using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Srez.db;

namespace Srez.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (LoginEntry.Text != null && EmailEntry.Text != null && NumberEntry.Text != null && PasswordEntry.Text != null)
                {
                    var user = new User
                    {
                        Login = LoginEntry.Text,
                        Password = PasswordEntry.Text,
                        PhoneNum = Convert.ToInt64(NumberEntry.Text),
                        Email = EmailEntry.Text
                    };

                    App.Db.SaveUser(user);
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Alert!", "Введите в поля данные!", "OK");
            }
            catch
            {
                await DisplayAlert("Alert!", "Проверьте введённые данные", "OK");
            }
        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
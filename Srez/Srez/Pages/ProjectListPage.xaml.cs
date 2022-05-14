using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Srez.db;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Srez.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectListPage : ContentPage
    {
        private User user;
        public ProjectListPage(User user)
        {
            InitializeComponent();
            this.user = user;
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage(user));
        }

        protected override void OnAppearing()
        {
            LVProjects.ItemsSource = App.Db.GetProjectsByUser(user.Id);
            base.OnAppearing();

        }

        private async void LVProjects_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            db.Project selectedProject = (db.Project)e.SelectedItem;
            await Navigation.PushAsync(new ProjectPage(selectedProject, user)
            {
                BindingContext = selectedProject
            });
        }
    }
}
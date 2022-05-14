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
    public partial class ProjectPage : ContentPage
    {
        private User user;
        private db.Project project;
        public ProjectPage(db.Project project, User user)
        {
            InitializeComponent();
            this.project = project;
            this.user = user;
            BtnAddProject.IsVisible = false;
        }

        public ProjectPage(User user)
        {
            InitializeComponent();
            this.user = user;
            BtnEdit.IsVisible = false;
            BtnDeleteProject.IsVisible = false;
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            if (DPDate.Date < DateTime.Now)
            {
                App.Db.SaveProject(project);

                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Дата", "Дата не может быть позднее текущего дня", "Окей");
        }

        private async void BtnDeleteProject_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Удаление", $"Вы хотите удалить {project.Name}?", "Да", "Нет"))
            {
                App.Db.DeleteProject(project.Id);

                await Navigation.PopAsync();
            }
        }

        private async void BtnAddProject_Clicked(object sender, EventArgs e)
        {
            if (DPDate.Date < DateTime.Now)
            {
                db.Project project = new db.Project
                {
                    Name = EName.Text,
                    Description = EDDescription.Text,
                    Date = DPDate.Date,
                    User_Id = user.Id
                };

                App.Db.SaveProject(project);

                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Дата", "Дата не может быть позднее текущего дня", "Окей");
        }
    }
}
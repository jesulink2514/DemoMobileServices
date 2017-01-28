using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoMobileServices
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            this.TodoList.IsRefreshing = true;
            await RefreshItems();
            this.TodoList.IsRefreshing = false;
        }

        private async Task RefreshItems()
        {
            var todos = await MobileClient.MobileService.GetTable<TodoItem>().ToListAsync();

            this.TodoList.ItemsSource = todos;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var rnd = new Random(1992).Next();
            if(rnd % 2 == 0) throw new InvalidDataContractException("You have bad luck!");
            if (!string.IsNullOrEmpty(TodoText.Text))
            {
                var todo = new TodoItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = TodoText.Text
                };
                await MobileClient.MobileService.GetTable<TodoItem>().InsertAsync(todo);
                TodoText.Text = string.Empty;

                await RefreshItems();
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareasITIC92.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasITIC92
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       
        private IList<Tarea> tareas = new ObservableCollection<Tarea>();
        private TareaManager manager = new TareaManager();
        public MainPage()
        {
            InitializeComponent();
            OnAppearing();
            BindingContext = tareas;
        

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await OnRefresh();
        }
      
        async public Task OnRefresh()
        {
            var tareasCollection = await manager.GetAll();
            tareasList.ItemsSource = tareasCollection.OrderBy(item => item.Id).ToList();
         
        }

        async public void OnAddTarea(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTarea(manager));
          
        }
        async public void  OnUpdateTarea(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            Tarea tarea = (Tarea)mi.CommandParameter;
            await Navigation.PushAsync(new UpdateTarea(manager,tarea));
            await OnRefresh();
            
        }



        async public void OnDeleteTarea(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Tarea tarea = (Tarea)mi.CommandParameter;
            string itemToDelete = tarea.Id.ToString();
            bool ans = await DisplayAlert("Alerta", "¿Desea eliminar la tarea " + tarea.Titulo + "?", "Ok", "Cancelar");
            if (ans == true)
            {
                await manager.DeleteTareaAsync(itemToDelete);
                await OnRefresh();

            }
            else { }
            

        }

        async public void ItemTappedDetail(object sender, ItemTappedEventArgs e)
        {
           
            var details = e.Item as Tarea;
            await Navigation.PushAsync(new TareaDetail(details ));

        }
    }
}

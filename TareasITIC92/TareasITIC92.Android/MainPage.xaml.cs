using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasITIC92.Data;
using Xamarin.Forms;

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
            BindingContext = tareas;
            InitializeComponent();
        }
        async public void OnRefresh(object sender, EventArgs e)
        {
            var tareasCollection = await manager.GetAll();
            foreach(Tarea tarea in tareasCollection)
            {
                tareas.Add(tarea);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasITIC92.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasITIC92
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTarea : ContentPage
    {
        private TareaManager manager;
        private Tarea tarea;

        public AddTarea(TareaManager manager, Tarea tarea = null)
        {
            InitializeComponent();

            this.tarea = tarea;
            this.manager = manager;
        }

        async public void OnSaveTarea(object sender, EventArgs e)
        {
            await manager.Add(txtTitulo.Text, txtDetalle.Text);
        }

    }
}

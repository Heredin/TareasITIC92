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
    public partial class UpdateTarea : ContentPage

    {
        private TareaManager manager;
        private Tarea tarea;


        public UpdateTarea(TareaManager manager, Tarea tarea)
        {
       
            InitializeComponent();

            this.tarea = tarea;
            this.manager = manager;
            txtTitulo.Text = tarea.Titulo;
            txtDetalle.Text = tarea.Detalle;
            txtValor.Text = tarea.Valor;
            
           
        }

        async public void OnUpdateTarea(object sender, EventArgs e)
        {
            await manager.Update(txtTitulo.Text, txtDetalle.Text,txtValor.Text,txtFechaEntrega.Date.ToString(), tarea.Id.ToString());
        }
    }
}
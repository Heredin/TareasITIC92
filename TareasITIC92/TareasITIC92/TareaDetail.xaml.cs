
using TareasITIC92.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasITIC92
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareaDetail : ContentPage
    {
        private  Tarea tarea;
        public TareaDetail(Tarea tarea)
        {
            InitializeComponent();
            this.tarea = tarea;
            txtTitulo.Text ="Titulo: "+tarea.Titulo;
            txtDetalle.Text = "Detalle: "+tarea.Detalle;
            txtValor.Text = "Valor: "+tarea.Valor;
            txtFechaEntrega.Text ="Fecha de entrega: "+ tarea.FechaEntrega;
           
        }
    }
}
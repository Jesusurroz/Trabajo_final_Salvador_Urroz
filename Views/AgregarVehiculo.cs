using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Narla_Salvador_Urroz.Controllers;


namespace Autos_Narla_Salvador_Urroz.Views
{
    public partial class AgregarVehiculo : Form
    {
        private VehiculoController ctrl;
        private Button btnCerrar;

        public AgregarVehiculo(VehiculoController controller)
        {
            ctrl = controller;
            this.Text = "Filtros (demo)";
            this.Width = 600;
            this.Height = 300;

            // Aquí debes implementar controles reales (TextBox, ComboBox, DataGridView) en el Designer.
            btnCerrar = new Button { Text = "Cerrar", Dock = DockStyle.Bottom };
            btnCerrar.Click += (s, e) => this.Close();
            Controls.Add(btnCerrar);
        }
    }
}

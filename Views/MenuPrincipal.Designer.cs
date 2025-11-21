
namespace Autos_Narla_Salvador_Urroz.Views
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnListarVehiculos;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnRegistrarVenta;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtCodigo = new TextBox();
            btnBuscar = new Button();
            lblTitulo = new Label();
            btnListarVehiculos = new Button();
            btnFiltrar = new Button();
            btnRegistrarVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.Location = new Point(28, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(845, 172);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(50, 401);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Ingrese código del vehículo";
            txtCodigo.Size = new Size(158, 23);
            txtCodigo.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DeepSkyBlue;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(285, 401);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 29);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(285, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(316, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bienvenidos a Autos Narla";
            // 
            // btnListarVehiculos
            // 
            btnListarVehiculos.BackColor = Color.MediumSeaGreen;
            btnListarVehiculos.FlatStyle = FlatStyle.Flat;
            btnListarVehiculos.ForeColor = Color.White;
            btnListarVehiculos.Location = new Point(414, 401);
            btnListarVehiculos.Name = "btnListarVehiculos";
            btnListarVehiculos.Size = new Size(75, 29);
            btnListarVehiculos.TabIndex = 4;
            btnListarVehiculos.Text = "Listar Vehículos";
            btnListarVehiculos.UseVisualStyleBackColor = false;
            btnListarVehiculos.Click += btnListarVehiculos_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Goldenrod;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(567, 401);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 29);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.IndianRed;
            btnRegistrarVenta.FlatStyle = FlatStyle.Flat;
            btnRegistrarVenta.ForeColor = Color.White;
            btnRegistrarVenta.Location = new Point(703, 401);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(75, 29);
            btnRegistrarVenta.TabIndex = 6;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(900, 600);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridView1);
            Controls.Add(txtCodigo);
            Controls.Add(btnBuscar);

            Controls.Add(btnListarVehiculos);
            Controls.Add(btnFiltrar);
            Controls.Add(btnRegistrarVenta);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autos Narla - JESUS URROZ";
            Load += MenuPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


    }
}


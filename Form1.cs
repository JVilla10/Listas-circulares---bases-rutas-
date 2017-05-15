using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioConListasCirculares
{
    public partial class Form1 : Form
    {
        Autobus miAutobus;
        Autobus miAutobus1;
        Autobus miAutobus2;
        Autobus miAutobus3;
        Autobus miAutobus4;

        CentralDeAutobuses miCentral = new CentralDeAutobuses();

        public Form1()
        {
            InitializeComponent();
            cmbNombreBase.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            miAutobus = new Autobus(txtNombreBase.Text, Convert.ToDouble(txtTiempoBase.Text));
            miCentral.agregar(miAutobus);
            cmbNombreBase.Items.Add(txtNombreBase.Text);
            txtReporte.Text = miCentral.ToString();

            txtNombreBase.Clear();
            txtTiempoBase.Clear();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miCentral.ToString();
        }

        private void btnAgregarCuatro_Click(object sender, EventArgs e)
        {
            miAutobus1 = new Autobus("A", 1);
            miAutobus2 = new Autobus("B", 2);
            miAutobus3 = new Autobus("C", 3);
            miAutobus4 = new Autobus("D", 4);

            miCentral.agregar(miAutobus1);
            miCentral.agregar(miAutobus2);
            miCentral.agregar(miAutobus3);
            miCentral.agregar(miAutobus4);

            cmbNombreBase.Items.Add("A");
            cmbNombreBase.Items.Add("B");
            cmbNombreBase.Items.Add("C");
            cmbNombreBase.Items.Add("D");

            txtReporte.Text = miCentral.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtReporte.Text = "" + miCentral.buscarPorNombre(txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            miCentral.eliminar(txtEliminar.Text);
            cmbNombreBase.Items.Remove(txtEliminar.Text);
            txtReporte.Text = miCentral.ToString();
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            miAutobus = new Autobus(txtNombreBase.Text, Convert.ToDouble(txtTiempoBase.Text));
            miCentral.agregarInicio(miAutobus);
            cmbNombreBase.Items.Add(txtNombreBase.Text);
            txtReporte.Text = miCentral.ToString();
                
            txtNombreBase.Clear();
            txtTiempoBase.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtHoraInicio.Format = DateTimePickerFormat.Custom;
            dtHoraInicio.CustomFormat = "hh:mm tt";

            dtHoraFinal.Format = DateTimePickerFormat.Custom;
            dtHoraFinal.CustomFormat = "hh:mm tt";
        }

        private void btnAgregarDespues_Click(object sender, EventArgs e)
        {
            miAutobus = new Autobus(txtNombreBase.Text, Convert.ToDouble(txtTiempoBase.Text));
            miCentral.agregarDesde(txtNombreBase.Text,miAutobus);
            cmbNombreBase.Items.Add(txtNombreBase.Text);
            txtReporte.Text = miCentral.ToString();

            txtNombreBase.Clear();
            txtTiempoBase.Clear();
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miCentral.recorrido(txtNombreBase.Text, Convert.ToInt16(dtHoraInicio), Convert.ToInt16(dtHoraFinal));
        }
    }
}

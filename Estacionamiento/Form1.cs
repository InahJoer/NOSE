namespace Estacionamiento
{
    public partial class Form1 : Form
    {
        string dia;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ENTRANDO LA FECHA ACTUAL
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //DETERMINAR EL DIA
                
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            switch(dia)
            {
                case "domingo": costo = 2; break;
                case "lunes": 
                case "martes":
                case "miercoles":
                case "jueves":
                    costo = 4; break;
                case "viernes":
                case "sabado":
                    costo = 7; break;
                
            }
            lblCosto.Text = costo.ToString("0.00");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bnRegistrar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHoraInicio.Text);
            DateTime horaFin = DateTime.Parse(txtHoraFin.Text);

            //CALCULAR HORA
            TimeSpan hora = horaFin - horaInicio;

            //CALCULAR EL IMPORTE

            double importe = costo * (hora.TotalHours);
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horaInicio.ToString("t"));
            fila.SubItems.Add(horaFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            LvRegistro.Items.Add(fila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ESTA SEGURO DE SALIR?",
                                 "ESTACIONAMIENTO",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void lblCosto_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHoraInicio.Clear();
            txtHoraFin.Clear();
            txtPlaca.Focus();
        }
    }
}
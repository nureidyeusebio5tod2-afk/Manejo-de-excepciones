using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultimo_proyecto
{
    public partial class GestionEstudiante : Form
    {
        public GestionEstudiante()
        {
            InitializeComponent();
        }

        private void GestionEstudiante_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // 👤 Validar Nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio");
                    txtNombre.Focus();
                    return;
                }

                if (!Regex.IsMatch(txtNombre.Text.Trim(), @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(\s[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+)+$"))
                {
                    MessageBox.Show("Escriba el nombre correctamente. Ej: Nureidy Eusebio");
                    txtNombre.Focus();
                    return;
                }

                // 🎂 Validar Edad
                int edad;

                if (string.IsNullOrWhiteSpace(txtEdad.Text))
                {
                    MessageBox.Show("La edad es obligatoria");
                    txtEdad.Focus();
                    return;
                }

                if (!int.TryParse(txtEdad.Text, out edad))
                {
                    MessageBox.Show("La edad debe ser un número");
                    txtEdad.Focus();
                    return;
                }

                if (edad < 1 || edad > 18)
                {
                    MessageBox.Show("Solo se permiten estudiantes menores o iguales a 18 años");
                    txtEdad.Focus();
                    return;
                }

                // 📧 Validar Correo
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("El correo es obligatorio");
                    txtCorreo.Focus();
                    return;
                }

                if (!Regex.IsMatch(txtCorreo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Ingrese un correo válido. Ej: nureidy@gmail.com");
                    txtCorreo.Focus();
                    return;
                }

                // ✅ Si todo está bien
                MessageBox.Show("Datos guardados correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

          
        

        private void button2_Click(object sender, EventArgs e)
        {
        
            txtNombre.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            DialogResult resultado = MessageBox.Show(
                "¿Deseas salir?",
                "Confirmación",
                MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    
    
}

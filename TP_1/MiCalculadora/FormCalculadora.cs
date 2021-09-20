using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Solicita confirmacion del usuario y segun la respuesta cierra o no el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Si hay un resultado lo convierte a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != null)
            {
                lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Si hay un resultado convertido a binario, lo convierte nuevamente a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != null)
            {
                lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }

        /// <summary>
        /// Llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Valida que los TextBox esten cargados con numeros, que el segundo operando sea distinto de cero en el caso de una division
        ///  y luego imprime el resultado del metodo Operar en el Label lblResultado y guarda el registro en el ListBox lstOperaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
            double num1;
            double num2;
            if (!double.TryParse(txtNumero1.Text, out num1) || !double.TryParse(txtNumero2.Text, out num2))
                lblResultado.Text = "Error, ingrese numeros reales";
            else if (num2 == 0 && cmbOperador.Text[0]=='/')
                lblResultado.Text = "No se puede dividir por 0";
            else
            {
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;

                StringBuilder sb = new StringBuilder();
                if (cmbOperador.Text != "")
                    sb.AppendLine($"{num1} {cmbOperador.Text} {num2} = {lblResultado.Text}");
                else
                    sb.AppendLine($"{num1} + {num2} = {lblResultado.Text}");
                lstOperaciones.Items.Add(sb.ToString());
            }
        }

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los elementos del form y llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.ResetText();
            txtNumero2.ResetText();
            cmbOperador.SelectedIndex = -1;
            lblResultado.ResetText();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Llama al metodo Operar de la clase Calculadora, pasandole los parametros recibidos para que realice la operacion correspondiente
        /// </summary>
        /// <param name="numero1">String que contiene el primer operando</param>
        /// <param name="numero2">String que contiene el segundo operando</param>
        /// <param name="operador">String que contiene el operador</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            if (operador != "")
                resultado = Calculadora.Operar(num1, num2, operador[0]);
            else
                resultado = Calculadora.Operar(num1, num2, '+');

            return resultado;
        }

        /// <summary>
        /// Solicita confirmacion del usuario y segun la respuesta cierra o no el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}

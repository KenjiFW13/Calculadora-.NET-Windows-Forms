using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP1
{
    public partial class Calculadora : Form
    {
        private double valorPrimeiro = 0;
        private double valorSegundo = 0;
        private string operacao = "";
        private bool limpaVisor = false;

        public double Somar(double a, double b)
        {
            return a + b;
        }

        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException("Não é possível dividir por zero!");
            }
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            return a / b;
        }

        public double RaizQuadrada(double a)
        {
            if (a < 0)
            {
                throw new System.ArgumentException("Não existe raiz real para números negativos!");
            }
            return System.Math.Sqrt(a);
        }

        public double Potencia(double baseNum, double expoente)
        {
            return System.Math.Pow(baseNum, expoente);
        }

        public Calculadora()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (limpaVisor || lblVisor.Text == "0")
            {
                lblVisor.Text = "";
                limpaVisor = false;
            }

            lblVisor.Text += botao.Text;
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (limpaVisor)
            {
                lblVisor.Text = "0,";
                limpaVisor = false;
                return;
            }

            if (!lblVisor.Text.Contains(","))
            {
                if (string.IsNullOrEmpty(lblVisor.Text))
                {
                    lblVisor.Text = "0";
                }

                lblVisor.Text += ",";
            }
        }

        private void Operacao_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (double.TryParse(lblVisor.Text, out valorPrimeiro))
            {
                operacao = botao.Text;
                limpaVisor = true;
            }
            else
            {
                MessageBox.Show("Insira um número válido primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(lblVisor.Text, out double valor))
                {
                    double resultado = RaizQuadrada(valor);
                    lblVisor.Text = resultado.ToString();
                    limpaVisor = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro Matemático!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLimpar_Click(sender, e);
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operacao)) return;

            if (double.TryParse(lblVisor.Text, out valorSegundo))
            {
                double resultado = 0;

                try
                {
                    switch (operacao)
                    {
                        case "+":
                            resultado = Somar(valorPrimeiro, valorSegundo);
                            break;
                        case "-":
                            resultado = Subtrair(valorPrimeiro, valorSegundo);
                            break;
                        case "×":
                            resultado = Multiplicar(valorPrimeiro, valorSegundo);
                            break;
                        case "/":
                            resultado = Dividir(valorPrimeiro, valorSegundo);
                            break;
                        case "x^y":
                            resultado = Potencia(valorPrimeiro, valorSegundo);
                            break;
                    }

                    lblVisor.Text = resultado.ToString();
                    operacao = "";
                    limpaVisor = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLimpar_Click(sender, e);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblVisor.Text = "";
            valorPrimeiro = 0;
            valorSegundo = 0;
            operacao = "";
            limpaVisor = false;
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            FormSobre formSobre = new FormSobre();
            formSobre.ShowDialog();
        }
    }
}

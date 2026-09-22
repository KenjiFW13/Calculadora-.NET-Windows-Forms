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

        // Método de Soma
        public double Somar(double a, double b)
        {
            return a + b;
        }

        // Método de Subtração
        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        // Método de Multiplicação
        public double Multiplicar(double a, double b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException("Não é possível dividir por zero!");
            }
            return a * b;
        }

        // Método de Divisão
        public double Dividir(double a, double b)
        {
            return a / b;
        }

        // Método de Raiz Quadrada
        public double RaizQuadrada(double a)
        {
            if (a < 0)
            {
                throw new System.ArgumentException("Não existe raiz real para números negativos!");
            }
            return System.Math.Sqrt(a);
        }

        // Método de Potência
        public double Potencia(double baseNum, double expoente)
        {
            return System.Math.Pow(baseNum, expoente);
        }

        public Calculadora()
        {
            InitializeComponent();
        }

        /* Método para lidar com o clique dos botões numéricos, todo botão numérico chamará este método,
        e o texto do botão será adicionado ao visor.

        Se o visor estiver marcado para limpeza (limpaVisor = true) ou se o visor estiver mostrando "0",
        o visor será limpo antes de adicionar o novo número.

        Caso contrário, o número do botão clicado será concatenado ao visor. */
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

        // Método para lidar com o clique do botão de vírgula, que adiciona uma vírgula ao visor se ainda não houver uma.
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (limpaVisor)
            {
                lblVisor.Text = "0,";
                limpaVisor = false;
                return;
            }

            // Se o visor não contém uma vírgula, adiciona uma vírgula ao final do texto do visor.
            if (!lblVisor.Text.Contains(","))
            {
                // Se o visor estiver vazio, adiciona "0" antes da vírgula.
                if (string.IsNullOrEmpty(lblVisor.Text))
                {
                    lblVisor.Text = "0";
                }

                lblVisor.Text += ",";
            }
        }

        /* Método para lidar com o clique dos botões de operação, que define a operação a ser realizada e
         prepara o visor para o próximo número.

         Se o visor não contém um número válido, exibe uma mensagem de aviso.

         O método é chamado por todos os botões de operação, e o texto do botão clicado é usado para determinar a operação.

         O método também define a variável limpaVisor como true, para que o próximo número digitado substitua o visor atual.

         Se o visor não contém um número válido, exibe uma mensagem de aviso. */
        private void Operacao_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            // Tenta converter o texto do visor para um número. Se for bem-sucedido, armazena o valor como valorPrimeiro e define a operação.
            if (double.TryParse(lblVisor.Text, out valorPrimeiro))
            {
                operacao = botao.Text;
                limpaVisor = true;
            }
            // Se a conversão falhar, exibe uma mensagem de aviso.
            else
            {
                MessageBox.Show("Insira um número válido primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para lidar com o clique do botão de raiz quadrada, que calcula a raiz quadrada do número no visor.
        // Se o visor não contém um número válido, exibe uma mensagem de aviso.
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            // Tenta converter o texto do visor para um número. Se for bem-sucedido, calcula a raiz quadrada e atualiza o visor.
            try
            {
                if (double.TryParse(lblVisor.Text, out double valor))
                {
                    double resultado = RaizQuadrada(valor);
                    lblVisor.Text = resultado.ToString();
                    limpaVisor = true;
                }
            }
            // Mensagem de erro.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro Matemático!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLimpar_Click(sender, e);
            }
        }

        /* Método para lidar com o clique do botão de igual, que realiza a operação selecionada entre o valorPrimeiro e o valorSegundo.
         * 
         Se o visor não contém um número válido, exibe uma mensagem de aviso.

         O método também trata exceções, como divisão por zero ou raiz quadrada de número negativo, exibindo uma mensagem
         de erro e limpando o visor.

         O resultado da operação é exibido no visor, e a operação é resetada.

         O método também define a variável limpaVisor como true, para que o próximo número digitado substitua o visor atual.*/
        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Se a operação não foi definida, não faz nada.
            if (string.IsNullOrEmpty(operacao)) return;

            // Tenta converter o texto do visor para um número. Se for bem-sucedido, armazena o valor como valorSegundo e realiza a operação.
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

                // Mensagem de erro.
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLimpar_Click(sender, e);
                }
            }
        }

        // Método para lidar com o clique do botão de limpar, que reseta o visor e as variáveis de operação.
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblVisor.Text = "";
            valorPrimeiro = 0;
            valorSegundo = 0;
            operacao = "";
            limpaVisor = false;
        }

        // Método para lidar com o clique do botão de sobre, que abre o formulário de informações sobre a calculadora.
        private void btnSobre_Click(object sender, EventArgs e)
        {
            FormSobre formSobre = new FormSobre();
            formSobre.ShowDialog();
        }
    }
}

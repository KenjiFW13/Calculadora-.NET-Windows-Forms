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
    public partial class FormSobre : Form
    {
        public FormSobre()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblAlisson_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string urlGitHub = "https://github.com/AlissonKawan";

                // Abre o link no navegador padrão do sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlGitHub,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklblEduardo_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string urlGitHub = "https://github.com/Bonieduardo75";
                // Abre o link no navegador padrão do sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlGitHub,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklblMarcao_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string urlGitHub = "https://github.com/marcos-thebest";
                // Abre o link no navegador padrão do sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlGitHub,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklblKenji_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string urlGitHub = "https://github.com/KenjiFW13";
                // Abre o link no navegador padrão do sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlGitHub,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklblRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string urlGitHub = "https://github.com/KenjiFW13/Calculadora-.NET-Windows-Forms";
                // Abre o link no navegador padrão do sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = urlGitHub,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

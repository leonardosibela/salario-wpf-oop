using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace ProjetoSalario
{
    public partial class MainWindow : Window
    {
        List<Funcionario> funcionarios = new List<Funcionario>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = obterFuncionario();
            funcionarios.Add(funcionario);
            dtgFuncionarios.ItemsSource = null;
            dtgFuncionarios.ItemsSource = funcionarios;

            lblSarioFixo.Content = "R$ " + funcionario.salarioLiquidoProp.ToString("N", new CultureInfo("pt-BR"));
        }

        private Funcionario obterFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.nome = txtNome.Text;
            funcionario.salarioBruto = Double.Parse(txtSalarioBruto.Text);

            funcionario.comissaoProp = rdbComissao.IsChecked.Value;
            funcionario.ajudaCustoProp = rdbAjudaCusto.IsChecked.Value;
            funcionario.impostoProp = chkImposto.IsChecked.Value;
            funcionario.valeTransporteProp = chkValeTransporte.IsChecked.Value;

            return funcionario;
        }
    }
}

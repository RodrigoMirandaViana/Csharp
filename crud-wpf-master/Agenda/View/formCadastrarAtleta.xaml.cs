using Atleta.DAO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Atleta.View
{
    /// <summary>
    /// Lógica interna para formCadastrarAtleta.xaml
    /// </summary>
    public partial class formCadastrarAtleta : Window
    {
        private static Context ctx = Singleton.Instance.Context;
        private Model.AtletaModel c;
        public formCadastrarAtleta()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarAtletas();
        }

        private void ListarAtletas()
        {
            var consulta = ctx.Atletas;
            dgDados.ItemsSource = consulta.ToList();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            c = new Model.AtletaModel
            {
                Nome = txtNome.Text,
                Posicao = txtPosicao.Text,
                Time = txtTime.Text
            };

            if (AtletaDAO.AdicionarAtleta(c))
            {
                MessageBox.Show("O atleta foi adicionado com sucesso!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível adicionar o atleta!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

             /*if (ctx.Atletas.Where(a => a.Nome.Equals(c.Nome)).Count() > 0)
         {
             MessageBox.Show("Atleta já cadastrado!", "Atleta",
             MessageBoxButton.OK, MessageBoxImage.Error);

         }
         else
         {
             AtletaDAO.AdicionarAtleta(c);
             MessageBox.Show("O atleta foi adicionado com sucesso!", "Atleta",
             MessageBoxButton.OK, MessageBoxImage.Information);
         }*/
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            c.Nome = txtNome.Text;
            c.Posicao = txtPosicao.Text;
            c.Time = txtTime.Text;
            if (AtletaDAO.RemoverAtleta(c))
            {
                MessageBox.Show("O atleta foi removido com sucesso!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // buscar nome
            if (txtNome.Text.Trim().Count() > 0)
            {
                try
                {
                    dgDados.ItemsSource = AtletaDAO.ListarAtletasPorNome(txtNome.Text);
                }
                catch
                {

                }
            }
            // buscar posição
            if (txtPosicao.Text.Trim().Count() > 0)
            {
                try
                {

                    dgDados.ItemsSource = AtletaDAO.ListarAtletasPorPosicao(txtPosicao.Text);
                }
                catch
                {

                }
            }
            // buscar time
            if (txtTime.Text.Trim().Count() > 0)
            {
                try
                {

                    dgDados.ItemsSource = AtletaDAO.ListarAtletasPorTime(txtTime.Text);
                }
                catch
                {

                }
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            c.Nome = txtNome.Text;
            c.Posicao = txtPosicao.Text;
            c.Time = txtTime.Text;

            if (AtletaDAO.AlterarAtleta(c))
            {
                MessageBox.Show("O atleta foi alterado com sucesso!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível alterar o atleta!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgDados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.AtletaModel atleta = (Model.AtletaModel) dgDados.SelectedItem;

            txtNome.Text = atleta.Nome;
            txtPosicao.Text = atleta.Posicao;
            txtTime.Text = atleta.Time;

         
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
            txtPosicao.Text = "";
            txtTime.Text = "";


        }
    }
}


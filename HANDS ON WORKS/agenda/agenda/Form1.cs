using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//adicionado para utilizar a referência Mysql.Data

namespace agenda
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        string stringSql;
        //Essas 5 linhas acima são as variáveis para facilitar durante o processo de utilização do SQL.

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\agenda\tb_agenda.mdf;Integrated Security=True"); //conexao recebe a string de conexao ao banco de dados
                stringSql = "INSERT INTO TB_AGENDA(NOME, TELEFONE) VALUES (@NOME, @TELEFONE)";  //STRING SQL PARA INSERIR O REGISTRO NO BANCO DE DADOS
                comando = new SqlCommand(stringSql, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text); //adiciona o valor digitado no campo txtnome para a variavel @nome
                comando.Parameters.AddWithValue("@TELEFONE", txtTelefone.Text);//adiciona o valor digitado no campo txttelefone para a variavel @telefone

                conexao.Open();  //abre a conexao com o banco de dados

                comando.ExecuteNonQuery(); //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.
            }

            catch (Exception excecao)
            {
                MessageBox.Show(excecao.Message); //exibir a mensagem de exceção

            }

            finally
            {
                txtId.Text = "";
                txtNome.Text = "";
                txtTelefone.Text = "";
                conexao.Close(); //fecha a conexão com o banco de dados 
                conexao = null;
                comando = null;
            }
            atualizaGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\agenda\tb_agenda.mdf;Integrated Security=True"); //conexao recebe a string de conexao ao banco de dados
                stringSql = "UPDATE TB_AGENDA SET NOME = @NOME, TELEFONE = @TELEFONE WHERE ID = @ID";  //STRING SQL PARA ATUALIZAR O REGISTRO NO BANCO DE DADOS QUANDO O ID DIGITADO É IGUAL A ALGUM ID NA BASE DE DADOS
                comando = new SqlCommand(stringSql, conexao);
                comando.Parameters.AddWithValue("@ID", txtId.Text);//adiciona o valor digitado no campo txtId para a variavel @ID
                comando.Parameters.AddWithValue("@NOME", txtNome.Text); //adiciona o valor digitado no campo txtnome para a variavel @nome
                comando.Parameters.AddWithValue("@TELEFONE", txtTelefone.Text);//adiciona o valor digitado no campo txttelefone para a variavel @telefone

                conexao.Open();  //abre a conexao com o banco de dados

                comando.ExecuteNonQuery(); //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.
            }

            catch (Exception excecao)
            {
                MessageBox.Show(excecao.Message); //exibir a mensagem de exceção

            }

            finally
            {
                txtId.Text = "";
                txtNome.Text = "";
                txtTelefone.Text = "";
                conexao.Close(); //fecha a conexão com o banco de dados 
                conexao = null;
                comando = null;
            }
            atualizaGrid();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\agenda\tb_agenda.mdf;Integrated Security=True"); //conexao recebe a string de conexao ao banco de dados
                stringSql = "DELETE FROM TB_AGENDA WHERE ID = @ID";  //STRING SQL PARA EXCLUIR O REGISTRO NO BANCO DE DADOS QUANDO O ID DIGITADO É IGUAL A ALGUM ID NA BASE DE DADOS
                comando = new SqlCommand(stringSql, conexao);
                comando.Parameters.AddWithValue("@ID", txtId.Text);//adiciona o valor digitado no campo txtId para a variavel @ID

                conexao.Open();  //abre a conexao com o banco de dados

                comando.ExecuteNonQuery(); //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.
            }

            catch (Exception excecao)
            {
                MessageBox.Show(excecao.Message); //exibir a mensagem de exceção

            }

            finally
            {
                txtId.Text = "";
                txtNome.Text = "";
                txtTelefone.Text = "";
                conexao.Close(); //fecha a conexão com o banco de dados 
                conexao = null;
                comando = null;
            }
            atualizaGrid();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\agenda\tb_agenda.mdf;Integrated Security=True"); //conexao recebe a string de conexao ao banco de dados
                stringSql = "SELECT * FROM TB_AGENDA WHERE NOME = @NOME";  //STRING SQL PARA EXCLUIR O REGISTRO NO BANCO DE DADOS QUANDO O ID DIGITADO É IGUAL A ALGUM ID NA BASE DE DADOS
                comando = new SqlCommand(stringSql, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);//adiciona o valor digitado no campo txtId para a variavel @ID

                conexao.Open();  //abre a conexao com o banco de dados

                dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    txtId.Text = Convert.ToString(dataReader["id"]); //busca o id no banco de dados e atualiza o nome no textbox txtId
                    txtNome.Text = Convert.ToString(dataReader["nome"]); //busca o nome no banco de dados e atualiza o nome no textbox txtNome
                    txtTelefone.Text = Convert.ToString(dataReader["telefone"]);//busca o telefone no banco de dados e atualiza o telefone no textbox txtTelefone
                }
            }

            catch (Exception excecao)
            {
                MessageBox.Show(excecao.Message); //exibir a mensagem de exceção

            }

            finally
            {
                conexao.Close(); //fecha a conexão com o banco de dados 
                conexao = null;
                comando = null;
            }
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\agenda\tb_agenda.mdf;Integrated Security=True"); //conexao recebe a string de conexao ao banco de dados
                stringSql = "SELECT * FROM TB_AGENDA";  //STRING SQL PARA EXCLUIR O REGISTRO NO BANCO DE DADOS QUANDO O ID DIGITADO É IGUAL A ALGUM ID NA BASE DE DADOS

                dataAdapter = new SqlDataAdapter(stringSql, conexao);
                DataTable tabela = new DataTable(); //gera uma nova instancia do DataTable para exibir a tabela
                dataAdapter.Fill(tabela); //popula a tabela

                gridTabela.DataSource = tabela; //exibe a tabela
                gridTabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; //redimensiona a tabela para se ajustar ao tamanho do objeto pai


            }

            catch (Exception excecao)
            {
                MessageBox.Show(excecao.Message); //exibir a mensagem de exceção

            }

            finally
            {
                conexao.Close(); //fecha a conexão com o banco de dados 
                conexao = null;
                comando = null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }
    }
}

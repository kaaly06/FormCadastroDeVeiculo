using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace FormCadastroDeVeiculo
{
    public class Banco
    {
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataAdapter Adaptador;
        public static DataTable dataTable;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                Conexao.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao ();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS  FormCadastroDeVeiculo; use  FormCadastroDeVeiculo", Conexao);

                Comando.ExecuteNonQuery ();

                //criando banco de marcas 

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas id integer foreign key, nome char(150)", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Codigo do Veiculo id integer auto_increment primary key", Conexao);

                Comando.ExecuteNonQuery ();

                FecharConexao();
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

    
}

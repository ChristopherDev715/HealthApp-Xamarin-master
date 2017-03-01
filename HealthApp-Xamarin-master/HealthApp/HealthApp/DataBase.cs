using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;
using System.IO;

namespace HealthApp
{
    class DataBase
    {
        //objeto para manipulação do banco de dados SQLiteDatabase 
        private SQLiteDatabase sqldb;
        //String para manipulação da consulta
        private string sqldb_query;
        //String para manipulação Mensagem 
        private string sqldb_mensagem;
        //Bool para verificar a disponibilidade do banco de dados 
        private bool sqldb_dispoTalhao;

        public DataBase()
        {
            sqldb_mensagem = "";
            sqldb_dispoTalhao = false;
        }

        public void RodarSql()
        {
            try
            {
                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sqldb_path = Path.Combine(sqldb_location, "paciente");

                sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);
                sqldb_query = "DROP TABLE IF EXISTS paciente; CREATE TABLE IF NOT EXISTS paciente (`idPaciente` int(11) NOT NULL,`nomePaciente` varchar(45) DEFAULT NULL,`nomeResponsavel` varchar(45) DEFAULT NULL,PRIMARY KEY(`idPaciente`));";
                sqldb.ExecSQL(sqldb_query);

                sqldb_query = "INSERT INTO paciente (`idPaciente`, `nomePaciente`, `nomeResponsavel`) VALUES(1, 'Paciente', 'Responsável'); ";
                sqldb.ExecSQL(sqldb_query);
            }
            catch (SQLiteException ex)
            {

            }
        }

        //Um construtor argumento, inicializa uma nova instância da classe de banco de dados com o parâmetro nome do banco de dados 
        public DataBase(string sqldb_nome)
        {
            try
            {
                sqldb_mensagem = "";
                sqldb_dispoTalhao = false;
                CriarDatabase(sqldb_nome);
            }
            catch (SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
            }
        }

        //Procura um registro e retorna um cursor Android.Database.ICursor 
        //Mostra os registros de acordo com critérios de pesquisa 
        public string GetUserPassword(string username)
        {
            sqldb_mensagem = "N";
            Android.Database.ICursor sqldb_cursor = null;
            try
            {
                sqldb_query = "SELECT Password FROM Users WHERE Username = '" + username + "';";
                //sqldb_query = "SELECT * FROM Users";
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                
                if (!(sqldb_cursor != null))//(sqldb_cursor == null)?
                {
                    sqldb_mensagem = "Registro não encontrado!";
                    return sqldb_mensagem;
                }
            }
            catch (SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
                return sqldb_mensagem;
            }
            sqldb_cursor.MoveToFirst();
            if(sqldb_cursor.Count != 0)
            {
                sqldb_mensagem = sqldb_cursor.GetString(0);
            }
            
            return sqldb_mensagem;
        }

        public List<Perfil> GetListPerfil()
        {
            try
            {
                sqldb_query = "SELECT paciente, responsavel FROM perfil";
                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                List<Perfil> lPerfil = new List<Perfil>();
                while (sqldb_cursor.MoveToNext())
                {
                    Perfil perfil = new Perfil();
                    perfil.SetPaciente(sqldb_cursor.GetString(0));
                    perfil.SetResponsavel(sqldb_cursor.GetString(1));
                    lPerfil.Add(perfil);
                }
                return lPerfil;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<Remedio> GetListRemedio()
        {
            try
            {
                sqldb_query = "SELECT data FROM remedio";
                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                List<Remedio> lRemedio = new List<Remedio>();
                while (sqldb_cursor.MoveToNext())
                {
                    Remedio remedio = new Remedio();
                    remedio.data = sqldb_cursor.GetString(0);
                    lRemedio.Add(remedio);
                }
                return lRemedio;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        //Adiciona um novo registro com os parâmetros dados
        public bool AddRegistro(User user)
        {

            
            try
            {
                sqldb_query = "INSERT INTO Users (Username, Password, FullName) VALUES ('"
                    + user.Username + "','" + user.Password + "','" + user.FullName + "');";
                sqldb.ExecSQL(sqldb_query);
                sqldb_mensagem = "Registro salvo com sucesso!";
                return true;
            }
            catch (SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
                return false;
            }
        }

        public bool AddRegistro(Remedio tuber)
        {
            try
            {
                sqldb_query = "INSERT INTO remedio (data) VALUES ('"+tuber.data+"');";
                sqldb.ExecSQL(sqldb_query);
                sqldb_mensagem = "Registro salvo com sucesso!";
                return true;
            }
            catch(SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
            }
            return false;
        }

        public bool AddRegistro(Perfil perfil)
        {
            try
            {
                sqldb_query = "INSERT INTO Perfil (paciente, responsavel) VALUES ('" + perfil.Getpaciente() + "','" + perfil.GetResponsavel() + "');";
                sqldb.ExecSQL(sqldb_query);
                sqldb_mensagem = "Registro salvo com sucesso!";
                return true;
            }
            catch (SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
            }
            return false;
        }

        //Cria um novo banco de dados cujo nome é dado pelo parâmetro 
        public void CriarDatabase(string sqldb_nome)
        {
            try
            {
                sqldb_mensagem = "";
                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sqldb_path = Path.Combine(sqldb_location, sqldb_nome);
                bool sqldb_exists = File.Exists(sqldb_path);
                if (!sqldb_exists)
                {
                    sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);
                    sqldb_query = "CREATE TABLE IF NOT EXISTS Users (Username VARCHAR PRIMARY KEY, Password VARCHAR, FullName VARCHAR);";
                    sqldb.ExecSQL(sqldb_query);
                    sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' criado com sucesso!";
                }
                else
                {
                    sqldb = SQLiteDatabase.OpenDatabase(sqldb_path, null, DatabaseOpenFlags.OpenReadwrite);
                    sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' carregado com sucesso!";
                }
                sqldb_dispoTalhao = true;
            }
            catch (SQLiteException ex)
            {
                sqldb_mensagem = ex.Message;
            }

            if (sqldb_nome == "perfil")
            {
                try
                {


                    sqldb_mensagem = "";
                    string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string sqldb_path = Path.Combine(sqldb_location, sqldb_nome);
                    bool sqldb_exists = File.Exists(sqldb_path);

                    if (true)
                    {
                        sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);
                        sqldb_query = "CREATE TABLE IF NOT EXISTS perfil (_ID INTEGER PRIMARY KEY AUTOINCREMENT, paciente VARCHAR, responsavel VARCHAR);";
                        sqldb.ExecSQL(sqldb_query);
                        sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' criado com sucesso!";
                        //sqldb_query = "INSERT INTO perfil (paciente,responsavel) VALUES('POC','POC')";
                        //sqldb.ExecSQL(sqldb_query);
                    }
                    else
                    {
                        sqldb = SQLiteDatabase.OpenDatabase(sqldb_path, null, DatabaseOpenFlags.OpenReadwrite);
                        sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' carregado com sucesso!";
                        sqldb_query = "SELECT * FROM dual where 1 = 0";
                        sqldb.ExecSQL(sqldb_query);
                    }
                    sqldb_dispoTalhao = true;
                }
                catch (SQLiteException ex)
                {
                    sqldb_mensagem = ex.Message;
                }
            }
            else if (sqldb_nome == "remedio")
            {
                try
                {


                    sqldb_mensagem = "";
                    string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string sqldb_path = Path.Combine(sqldb_location, sqldb_nome);
                    bool sqldb_exists = File.Exists(sqldb_path);

                    if (true)
                    {
                        sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);
                        sqldb_query = "CREATE TABLE IF NOT EXISTS remedio (_ID INTEGER PRIMARY KEY AUTOINCREMENT, data VARCHAR);";
                        sqldb.ExecSQL(sqldb_query);
                        sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' criado com sucesso!";
                        //sqldb_query = "INSERT INTO remedio (data) VALUES('POC')";
                        //sqldb.ExecSQL(sqldb_query);
                    }
                    else
                    {
                        sqldb = SQLiteDatabase.OpenDatabase(sqldb_path, null, DatabaseOpenFlags.OpenReadwrite);
                        sqldb_mensagem = "Banco de dados '" + sqldb_nome + "' carregado com sucesso!";
                        sqldb_query = "SELECT * FROM dual where 1 = 0";
                        sqldb.ExecSQL(sqldb_query);
                    }
                    sqldb_dispoTalhao = true;
                }
                catch (SQLiteException ex)
                {
                    sqldb_mensagem = ex.Message;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;

using HealthApp.Model;

namespace HealthApp.DAO
{
    class DAOTratamento
    {
        private SQLiteDatabase sqldb;

        public DAOTratamento()
        {
            try
            {
                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sqldb_path = Path.Combine(sqldb_location, "tratamento");
                string sqldb_query;

                sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);

                sqldb_query = "CREATE TABLE IF NOT EXISTS tratamento (`idTratamento` int(11) NOT NULL,`dataInicio` varchar(45) DEFAULT NULL,`dataTermino` varchar(45) DEFAULT NULL,`faseTratamento` varchar(45) NOT NULL,PRIMARY KEY(`idTratamento`,`faseTratamento`))";
                sqldb.ExecSQL(sqldb_query);

                if (GetTratamentoById(1) == null)
                {
                    sqldb_query = "INSERT INTO tratamento (`idTratamento`, `dataInicio`, `dataTermino`, `faseTratamento`) VALUES ('1', '01/01/1970', '01/01/1970', 'Fase 1') ";
                    sqldb.ExecSQL(sqldb_query);
                }
            }
            catch (SQLiteException ex)
            {

            }
        }

        public ModelTratamento GetTratamentoById(int id)
        {
            try
            {
                ModelTratamento modelTratamento = new ModelTratamento();
                string sqldb_query;

                sqldb_query = "SELECT idTratamento, dataInicio, dataTermino, faseTratamento " +
                              "FROM tratamento                                              " +
                              "WHERE idTratamento =                                         " + id;

                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                if (sqldb_cursor.MoveToFirst())
                {
                    modelTratamento.IdTratamento    = sqldb_cursor.GetInt(0);
                    modelTratamento.DataInicio      = sqldb_cursor.GetString(1);
                    modelTratamento.DataTermino     = sqldb_cursor.GetString(2);
                    modelTratamento.FaseTratamento  = sqldb_cursor.GetString(3);
                }
                return modelTratamento;
            }
            catch (SQLiteException ex)
            {
                return null;
            }

        }

        public void UpdateTratamento(ModelTratamento modelTratamento)
        {
            try
            {
                string sqldb_query = "UPDATE tratamento     " +
                                     "SET dataInicio     = '" + modelTratamento.DataInicio     + "'," +
                                     "    dataTermino    = '" + modelTratamento.DataTermino    + "'," +
                                     "    faseTratamento = '" + modelTratamento.FaseTratamento + "' "+
                                     "WHERE idPaciente    = " + modelTratamento.IdTratamento;
                sqldb.ExecSQL(sqldb_query);
            }
            catch (SQLiteException ex)
            {

            }
        }
    }
}
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
    class DAOMedicamento
    {
        private SQLiteDatabase sqldb;
        private string sqldb_mensagem;

        private DAOTratamento dAoTratamento;

        public DAOMedicamento()
        {
            try
            {
                dAoTratamento = new DAOTratamento();

                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sqldb_path = Path.Combine(sqldb_location, "medicamento");
                string sqldb_query;

                sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);

                sqldb_query = "DROP TABLE IF EXISTS medicamento";
                sqldb.ExecSQL(sqldb_query);

                sqldb_query = "CREATE TABLE IF NOT EXISTS medicamento (`idMedicamento` int(11) NOT NULL,`nomeMedicamento` varchar(45) DEFAULT NULL,`qtdMedicamento` int(11) DEFAULT NULL,`corMedicamento` varchar(45) DEFAULT NULL,`horaMedicamento` varchar(45) DEFAULT NULL,`dataCriacao` varchar(45) DEFAULT NULL,`idTratamento` int(11) NOT NULL,`isActive` tinyint(1) DEFAULT NULL,`faseTratamento` varchar(45) NOT NULL,PRIMARY KEY(`idMedicamento`))";
                sqldb.ExecSQL(sqldb_query);
            }
            catch (SQLiteException ex)
            {

            }
        }

        public ModelMedicamento GetMedicamentoById(int id)
        {
            try
            {
                ModelMedicamento modelMedicamento = new ModelMedicamento();
                string sqldb_query;

                sqldb_query = "SELECT idMedicamento, nomeMedicamento, qtdMedicamento, corMedicamento, horaMedicamento, dataCriacao, idTratamento, isActive, faseTratamento" +
                              "FROM medicamento                                              " +
                              "WHERE idMedicamento =                                          " + id;

                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                if (sqldb_cursor.MoveToFirst())
                {
                    modelMedicamento.IdMedicamento   = sqldb_cursor.GetInt(0);
                    modelMedicamento.NomeMedicamento = sqldb_cursor.GetString(1);
                    modelMedicamento.QtdMedicamento  = sqldb_cursor.GetInt(2);
                    modelMedicamento.CorMedicamento  = sqldb_cursor.GetString(3);
                    modelMedicamento.HoraMedicamento = sqldb_cursor.GetString(4);
                    modelMedicamento.DataCriacao     = sqldb_cursor.GetString(5);

                    modelMedicamento.Tratamento = dAoTratamento.GetTratamentoById(sqldb_cursor.GetInt(6));

                    //modelMedicamento.IsActive = sqldb_cursor.GetString(7)
                    modelMedicamento.FaseTratamento = sqldb_cursor.GetString(8);
                }
                return modelMedicamento;
            }
            catch (SQLiteException ex)
            {
                return null;
            }

        }

        public List<ModelMedicamento> GetLstMedicamentoByTratamento(int id)
        {
            try
            {
                List<ModelMedicamento> lstModelMedicamento = new List<ModelMedicamento>();
                string sqldb_query;

                sqldb_query = "SELECT idMedicamento, nomeMedicamento, qtdMedicamento, corMedicamento, horaMedicamento, dataCriacao, idTratamento, isActive, faseTratamento" +
                              "FROM medicamento                                              " +
                              "WHERE idTratamento =                                          " + id;

                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
                sqldb_cursor.MoveToFirst();

                while(!sqldb_cursor.IsAfterLast)
                {
                    ModelMedicamento modelMedicamento = new ModelMedicamento();

                    modelMedicamento.IdMedicamento = sqldb_cursor.GetInt(0);
                    modelMedicamento.NomeMedicamento = sqldb_cursor.GetString(1);
                    modelMedicamento.QtdMedicamento = sqldb_cursor.GetInt(2);
                    modelMedicamento.CorMedicamento = sqldb_cursor.GetString(3);
                    modelMedicamento.HoraMedicamento = sqldb_cursor.GetString(4);
                    modelMedicamento.DataCriacao = sqldb_cursor.GetString(5);

                    modelMedicamento.Tratamento = dAoTratamento.GetTratamentoById(sqldb_cursor.GetInt(6));

                    //modelMedicamento.IsActive = sqldb_cursor.GetString(7)
                    modelMedicamento.FaseTratamento = sqldb_cursor.GetString(8);

                    lstModelMedicamento.Add(modelMedicamento);

                };

                return lstModelMedicamento;
            }
            catch (SQLiteException ex)
            {
                return null;
            }

        }

        public void UpdateMedicamento(ModelMedicamento modelMedicamento)
        {
            try
            {
                string sqldb_query = "UPDATE medicamento     " +
                                     "SET nomeMedicamento = '" + modelMedicamento.NomeMedicamento + "'," +
                                     "    qtdMedicamento  =  " + modelMedicamento.QtdMedicamento  + " ," +
                                     "    corMedicamento  = '" + modelMedicamento.CorMedicamento  + "'," +
                                     "    horaMedicamento = '" + modelMedicamento.HoraMedicamento + "'," +
                                     "    dataCriacao     = '" + modelMedicamento.DataCriacao     + "' " +
                                     "WHERE idMedicamento    = " + modelMedicamento.IdMedicamento;
                sqldb.ExecSQL(sqldb_query);
            }
            catch (SQLiteException ex)
            {

            }
        }
    }
}
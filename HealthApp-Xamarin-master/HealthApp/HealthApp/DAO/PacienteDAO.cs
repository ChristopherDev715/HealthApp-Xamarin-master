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
    class PacienteDAO
    {
        private SQLiteDatabase sqldb;

        public PacienteDAO()
        {
            try
            {
                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sqldb_path = Path.Combine(sqldb_location, "paciente");
                string sqldb_query;

                sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);

                //sqldb_query = "DROP TABLE IF EXISTS paciente";
                //sqldb.ExecSQL(sqldb_query);

                sqldb_query = "CREATE TABLE IF NOT EXISTS paciente(`idPaciente` int(11) NOT NULL,`nomePaciente` varchar(45) DEFAULT NULL,`nomeResponsavel` varchar(45) DEFAULT NULL, PRIMARY KEY(`idPaciente`));";
                sqldb.ExecSQL(sqldb_query);

                if(GetPacienteById(1) == null)
                {
                    sqldb_query = "INSERT INTO paciente (`idPaciente`, `nomePaciente`, `nomeResponsavel`) VALUES(1, 'Paciente', 'Responsável'); ";
                    sqldb.ExecSQL(sqldb_query);
                }

            }
            catch (SQLiteException ex)
            {

            }
        }

        public ModelPaciente GetPacienteById(int id)
        {
            try
            {
                ModelPaciente modelPaciente = new ModelPaciente();
                string sqldb_query;

                sqldb_query = "SELECT idPaciente, nomePaciente, nomeResponsavel " +
                              "FROM paciente                                    " +
                              "WHERE idPaciente =                               " +id;

                Android.Database.ICursor sqldb_cursor = null;
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);

                if(sqldb_cursor.MoveToFirst())
                {
                    modelPaciente.IdPaciente        = sqldb_cursor.GetInt(0);
                    modelPaciente.NomePaciente      = sqldb_cursor.GetString(1);
                    modelPaciente.NomeResponsavel   = sqldb_cursor.GetString(2);
                }
                return modelPaciente;
            }
            catch (SQLiteException ex)
            {
                return null;
            }

        }

        public void UpdatePaciente(ModelPaciente modelPaciente)
        {
            try
            {
                string sqldb_query = "UPDATE paciente        " +
                                     "SET nomePaciente    = '" + modelPaciente.NomePaciente   + "'," +
                                     "   nomeResponsavel = '" + modelPaciente.NomeResponsavel + "' " +
                                     "WHERE idPaciente    = " + modelPaciente.IdPaciente;
                sqldb.ExecSQL(sqldb_query);

            }
            catch (SQLiteException ex)
            {

            }
        }
    }
}
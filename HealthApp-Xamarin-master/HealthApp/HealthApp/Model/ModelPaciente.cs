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

namespace HealthApp.Model
{
    class ModelPaciente
    {
        private int idPaciente;
        private string nomePaciente;
        private string nomeResponsavel;

        public int IdPaciente
        {
            get
            {
                return idPaciente;
            }

            set
            {
                idPaciente = value;
            }
        }

        public string NomePaciente
        {
            get
            {
                return nomePaciente;
            }

            set
            {
                nomePaciente = value;
            }
        }

        public string NomeResponsavel
        {
            get
            {
                return nomeResponsavel;
            }

            set
            {
                nomeResponsavel = value;
            }
        }
    }
}
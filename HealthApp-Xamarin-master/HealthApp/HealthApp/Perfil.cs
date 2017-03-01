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

namespace HealthApp
{
    class Perfil
    {
        private string paciente;
        private string responsavel;

        public string Getpaciente()
        {
            return paciente;
        }

        public string GetResponsavel()
        {
            return responsavel;
        }

        public void SetPaciente(string paciente)
        {
            this.paciente = paciente;
        }

        public void SetResponsavel(string responsavel)
        {
            this.responsavel = responsavel;
        }

    }
}
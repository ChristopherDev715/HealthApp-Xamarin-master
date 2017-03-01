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
    class ModelTratamento
    {
        private int idTratamento;
        private string dataInicio;
        private string dataTermino;
        private string faseTratamento;

        public int IdTratamento
        {
            get
            {
                return idTratamento;
            }

            set
            {
                idTratamento = value;
            }
        }

        public string DataInicio
        {
            get
            {
                return dataInicio;
            }

            set
            {
                dataInicio = value;
            }
        }

        public string DataTermino
        {
            get
            {
                return dataTermino;
            }

            set
            {
                dataTermino = value;
            }
        }

        public string FaseTratamento
        {
            get
            {
                return faseTratamento;
            }

            set
            {
                faseTratamento = value;
            }
        }
    }
}
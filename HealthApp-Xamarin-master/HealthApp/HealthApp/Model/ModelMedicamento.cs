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
    class ModelMedicamento
    {
        private int idMedicamento;
        private string nomeMedicamento;
        private int qtdMedicamento;
        private string corMedicamento;
        private string horaMedicamento;
        private string dataCriacao;
        private ModelTratamento tratamento;
        private bool isActive;
        private string faseTratamento;

        public int IdMedicamento
        {
            get
            {
                return idMedicamento;
            }

            set
            {
                idMedicamento = value;
            }
        }

        public string NomeMedicamento
        {
            get
            {
                return nomeMedicamento;
            }

            set
            {
                nomeMedicamento = value;
            }
        }

        public int QtdMedicamento
        {
            get
            {
                return qtdMedicamento;
            }

            set
            {
                qtdMedicamento = value;
            }
        }

        public string CorMedicamento
        {
            get
            {
                return corMedicamento;
            }

            set
            {
                corMedicamento = value;
            }
        }

        public string HoraMedicamento
        {
            get
            {
                return horaMedicamento;
            }

            set
            {
                horaMedicamento = value;
            }
        }

        public string DataCriacao
        {
            get
            {
                return dataCriacao;
            }

            set
            {
                dataCriacao = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        internal ModelTratamento Tratamento
        {
            get
            {
                return tratamento;
            }

            set
            {
                tratamento = value;
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
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

using HealthApp.DAO;
using HealthApp.Model;

namespace HealthApp.Activities
{
    [Activity(Label = "TratamentoActivity")]
    public class TratamentoActivity : Activity
    {
        private DAOTratamento dAOTratamento;
        private ModelTratamento modelTratamento;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Paciente);

            dAOTratamento = new DAOTratamento();
            modelTratamento = dAOTratamento.GetTratamentoById(1);

            //Preencher view


            //Salvar informações
        }
    }
}
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
    [Activity(Label = "MedicamentoActivity")]
    public class MedicamentoActivity : Activity
    {

        private DAOMedicamento dAOMedicamento;
        private ModelMedicamento modelMedicamento;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dAOMedicamento = new DAOMedicamento();
            modelMedicamento = new ModelMedicamento();

            //Preencher View

            //Salvar informações
        }
    }
}
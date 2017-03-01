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
    [Activity(Label = "PacienteActivity")]
    public class PacienteActivity : Activity
    {
        private PacienteDAO pacienteDAO;
        private ModelPaciente modelPaciete;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Paciente);

            pacienteDAO = new PacienteDAO();
            modelPaciete = pacienteDAO.GetPacienteById(1);

            // Preencher view
            EditText edtNomePaciente = FindViewById<EditText>(Resource.Id.paciente_edt_paciente);
            EditText edtNomeResponsavel = FindViewById<EditText>(Resource.Id.paciente_edt_responsavel);

            edtNomePaciente.Text = modelPaciete.NomePaciente;
            edtNomeResponsavel.Text = modelPaciete.NomeResponsavel;

            // Salvar informações
            Button btmSalvar = FindViewById<Button>(Resource.Id.paciente_btn_salvar);

            btmSalvar.Click += delegate
            {
                modelPaciete.NomePaciente = edtNomePaciente.Text;
                modelPaciete.NomeResponsavel = edtNomeResponsavel.Text;

                pacienteDAO.UpdatePaciente(modelPaciete);

                Toast.MakeText(ApplicationContext, "Salvo", ToastLength.Short).Show();
            };
        }
    }
}
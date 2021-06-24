using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadastroEscolar
{
    [Activity(Label = "sucesso", Theme = "@style/AppTheme", MainLauncher = true)]
    public class sucesso : Activity
    {
        TextView txtSucesso;
        string nomeResponsavel, nomeAluno;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.sucesso);

            txtSucesso = FindViewById<TextView>(Resource.Id.txtSucesso);

            if (Intent.GetStringExtra("Nome do Responsável") != null)
                nomeResponsavel = Intent.GetStringExtra("Nome do Responsável").ToString();
            if (Intent.GetStringExtra("Nome do Aluno") != null)
                nomeAluno = Intent.GetStringExtra("Nome do Aluno").ToString();

            txtSucesso.Text = "Parabéns! O aluno " + nomeAluno + " do responsável " + nomeResponsavel + " foi cadastrado.";
        }
    }
}
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.AppCompat.App;

namespace cadastroEscolar
{
    [Activity(Label = "edit", Theme = "@style/AppTheme", MainLauncher = true)]
    public class edit : Activity
    {
        TextView editNomeResponsavel, editTelefoneResponsavel, editCpfResponsavel, editEndereco, editNomeAluno, editGrade, editSexo;
        
        Button btnCorrigir, btnConfirmar;
        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.edit);

            editNomeResponsavel = FindViewById<TextView>(Resource.Id.editNomeResponsavel);
            editTelefoneResponsavel = FindViewById<TextView>(Resource.Id.editTelefoneResponsavel);
            editCpfResponsavel = FindViewById<TextView>(Resource.Id.editCpfResponsavel);
            editEndereco = FindViewById<TextView>(Resource.Id.editEndereco);
            editNomeAluno = FindViewById<TextView>(Resource.Id.editNomeAluno);
            editGrade = FindViewById<TextView>(Resource.Id.editGrade);
            editSexo = FindViewById<TextView>(Resource.Id.editSexo);



           btnCorrigir = FindViewById<Button>(Resource.Id.btnCorrigir);
            btnCorrigir.Click += BtnCorrigir_Click;

           btnConfirmar = FindViewById<Button>(Resource.Id.btnConfirmar);
            btnConfirmar.Click += BtnConfirmar_Click;

            if (Intent.GetStringExtra("Nome do Responsável") != null)
                editNomeResponsavel.Text = Intent.GetStringExtra("Nome do Responsável").ToString();
            if (Intent.GetStringExtra("Telefone do Responsável") != null)
                editTelefoneResponsavel.Text = Intent.GetStringExtra("Telefone do Responsável").ToString();
            if (Intent.GetStringExtra("CPF do Responsável") != null)
                editCpfResponsavel.Text = Intent.GetStringExtra("CPF do Responsável").ToString();
            if (Intent.GetStringExtra("Endereço") != null)
                editEndereco.Text = Intent.GetStringExtra("Nome do Responsável").ToString();
            if (Intent.GetStringExtra("Nome do Aluno") != null)
                editNomeAluno.Text = Intent.GetStringExtra("Nome do Aluno").ToString();
            if (Intent.GetStringExtra("Grade do Aluno") != null)
                editGrade.Text = Intent.GetStringExtra("Grade do Aluno").ToString();
            if (Intent.GetStringExtra("Sexo do Aluno") != null)
                editSexo.Text = Intent.GetStringExtra("Sexo do Aluno").ToString();


        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            Intent novaTela = new Intent(this, typeof(sucesso));
            novaTela.PutExtra("Nome do Responsável", editNomeResponsavel.Text);
            novaTela.PutExtra("Nome do Aluno", editNomeAluno.Text);
            

            StartActivity(novaTela);
        }

        private void BtnCorrigir_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}

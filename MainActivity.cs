using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Collections;
using System;
using Android.Content;


namespace cadastroEscolar
{
    [Activity(Label = "Cadastro de Alunos Recanto Feliz", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView editNomeResponsavel, editTelefoneResponsavel, editCpfResponsavel, editEndereco, editNomeAluno;
        Spinner spnGradeAluno;
        Button btnOK;
        ArrayList grades;
        ArrayAdapter adapter;
        string grade = "";
        string sexo = "";
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            spnGradeAluno = FindViewById<Spinner>(Resource.Id.spnGradeAluno);
            btnOK = FindViewById<Button>(Resource.Id.btnOK);
            RadioButton editSexoFeminino = FindViewById<RadioButton>(Resource.Id.editSexoFeminino);
            editSexoFeminino.Click += Rbtn_Click;
            RadioButton editSexoMasculino = FindViewById<RadioButton>(Resource.Id.editSexoMasculino);
            editSexoMasculino.Click += Rbtn_Click;

            grades = new ArrayList();
            grades.Add("Ensino Primário");
            grades.Add("Fundamental I");
            grades.Add("Fundamental II");
            grades.Add("Ensino Médio");
            adapter = new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1, grades);
            spnGradeAluno.Adapter = adapter;
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {

            int item = spnGradeAluno.SelectedItemPosition;
            switch (item)
            {
                case 0:
                    grade = "Ensino Primário";
                    break;
                case 1:
                    grade = "Fundamental I";
                    break;
                case 2:
                    grade = "Fundamental II";
                    break;
                case 3:
                    grade = "Ensino Médio";
                    break;
            }
            Toast.MakeText(this, "Grade selecionada: " + grade, ToastLength.Short).Show();

            editNomeResponsavel = FindViewById<TextView>(Resource.Id.editNomeResponsavel);
            editTelefoneResponsavel = FindViewById<TextView>(Resource.Id.editTelefoneResponsavel);
            editCpfResponsavel = FindViewById<TextView>(Resource.Id.editCpfResponsavel);
            editEndereco = FindViewById<TextView>(Resource.Id.editEndereco);
            editNomeAluno = FindViewById<TextView>(Resource.Id.editNomeAluno);

            Intent novaTela = new Intent(this, typeof(edit));
            novaTela.PutExtra("Nome do Responsável", editNomeResponsavel.Text);
            novaTela.PutExtra("Telefone do Responsável", editTelefoneResponsavel.Text);
            novaTela.PutExtra("CPF do Responsável", editCpfResponsavel.Text);
            novaTela.PutExtra("Endereço", editEndereco.Text);
            novaTela.PutExtra("Nome do Aluno", editNomeAluno.Text);
            novaTela.PutExtra("Grade do Aluno", grade);
            novaTela.PutExtra("Sexo do Aluno", sexo);
           
            StartActivity(novaTela);
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            var radiobtn = sender as RadioButton;
            var text = radiobtn.Text;
            sexo = text;
            Toast.MakeText(this, "Sexo selecionado: " + sexo, ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
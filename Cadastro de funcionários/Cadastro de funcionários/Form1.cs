using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cadastro_de_funcionarios
{
    partial class Form1 : Form
    {
        private Funcionario a;
        List<Funcionario> lista = new List<Funcionario>();
        private string[] sang = new string[8];

        public void load()
        {
            string[] lines = System.IO.File.ReadAllLines("Funcionarios.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                lista.Add(new Funcionario());
                lista[i].BackFromText(lines[i]);
                registro.Items.Add(lista[i].Nome + " : " + lista[i].Profissao);
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            //idadegg();
            //sanguegg();
            a = new Funcionario();
            load();
        }
        private void Nome_TextChanged(object sender, EventArgs e)
        {
        }
        public void salvar()
        {
            string[] texto = new string[lista.ToArray().Length];
            for (int i = 0; i < lista.ToArray().Length; i++)
            {
                texto[i] = lista[i].ToText();
            }
            System.IO.File.AppendAllLines("Funcionarios.txt", texto);
        }
        private void confirm_click(object sender, EventArgs e)
        {
            a.setup(nome.Text, profissão.Text,sexo.Text,relacionamento.Text,tiposanguineo.Text,endereço.Text,email.Text,
                (idade.Text),(salario.Text),(tel.Text),(numdefilhos.Text));
            registro.Items.Add(a.Nome + " : " + a.Profissao);
            lista.Add(a);
            nome.Text = "";
            profissão.Text = "";
            sexo.Text = "";
            relacionamento.Text = "";
            tiposanguineo.Text = "";
            endereço.Text = "";
            email.Text = "";
            idade.Text = "";
            salario.Text = "";
            tel.Text = "";
            numdefilhos.Text = "";
            salvar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {}
        private void comboBoxIdade_SelectedIndexChanged(object sender, EventArgs e)
        {}

        /*public void idadegg()
        {
            for(int i = 0; i <= 120; i++)
            {
                comboBoxIdade.Items.Add(i);
            }
        }
        public void sanguegg()
        {
            for (int i = 0; i <= 8; i++)
            {
                sang[0] = "O-";
                sang[1] = "O+";
                sang[2] = "A-";
                sang[3] = "A+";
                sang[4] = "B-";
                sang[5] = "B+";
                sang[6] = "AB-";
                sang[7] = "AB+";
                comboBoxSang.Items.Add(sang);
            }
        }

        private void comboBoxSang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

    }
}

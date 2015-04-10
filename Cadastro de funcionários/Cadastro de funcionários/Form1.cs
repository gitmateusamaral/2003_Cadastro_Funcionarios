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
        private bool edit = false;

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
            a = new Funcionario();
            load();
            confirmar.Enabled = false;
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
            if (!edit)
            {
                a.setup(nome.Text, profissão.Text, sexo.Text, relacionamento.Text, tiposanguineo.Text, endereço.Text, email.Text,
                    (idade.Text), (salario.Text), (tel.Text), (numdefilhos.Text));
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

            else
            {
            }

            edit = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void Verificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nome.Text) && !string.IsNullOrWhiteSpace(profissão.Text) && !string.IsNullOrWhiteSpace(sexo.Text)
                && !string.IsNullOrWhiteSpace(relacionamento.Text) && !string.IsNullOrWhiteSpace(tiposanguineo.Text) && !string.IsNullOrWhiteSpace(endereço.Text)
                && !string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(idade.Text) && !string.IsNullOrWhiteSpace(salario.Text)
                && !string.IsNullOrWhiteSpace(tel.Text) && !string.IsNullOrWhiteSpace(numdefilhos.Text))
            {
                confirmar.Enabled = true;
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {

            int index = registro.SelectedIndex;
            string[] allLines = System.IO.File.ReadAllLines("Funcionarios.txt");
            foreach(string line in allLines)
            {

            }

        }
    }
}

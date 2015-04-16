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
using System.Text.RegularExpressions;

namespace Cadastro_de_funcionarios
{
    partial class Form1 : Form
    {
        private Funcionario a;
        List<Funcionario> lista = new List<Funcionario>();
        public bool editing;

        public void load()
        {
            string[] lines = System.IO.File.ReadAllLines("Funcionarios.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                lista.Add(new Funcionario());
                lista[i].BackFromText(lines[i]);
                registro.Items.Add(lista[i].Nome + ":" + lista[i].Profissao);
            }                
        }
        
        public Form1()
        {
            InitializeComponent();
            a = new Funcionario();
            load();
            confirmar.Enabled = false;
            editing = false;
        }
        private void Nome_TextChanged(object sender, EventArgs e)
        {
            nome.Text = Regex.Replace(Convert.ToString(nome.Text), "(?i)[^a-z À-ÿ]", "");
        }
        public void salvar()
        {
            string[] texto = new string[lista.ToArray().Length];
            for (int i = 0; i < lista.Count; i++)
            {
                texto[i] = lista[i].ToText();
            }
            System.IO.File.AppendAllLines("Funcionarios.txt", texto);
        }           

        private void confirm_click(object sender, EventArgs e)
        {
            if (!editing)
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
                if (registro.SelectedIndex > -1)
                {
                    string[] allLines = System.IO.File.ReadAllLines("Funcionarios.txt");

                    for (int i = 0; i < allLines.Length; i++)
                    {
                        if (lista[registro.SelectedIndex].ToText().Equals(allLines[i]))
                        {
                            lista[registro.SelectedIndex].setup(nome.Text, profissão.Text, sexo.Text, relacionamento.Text, tiposanguineo.Text, endereço.Text, email.Text,
                            (idade.Text), (salario.Text), (tel.Text), (numdefilhos.Text));
                            allLines[i] =  lista[registro.SelectedIndex].ToText();
                        }
                    }
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
                    System.IO.File.WriteAllLines("Funcionarios.txt", allLines);
                }
            }

            editing = false;
            confirmar.Enabled = false;
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
            if (registro.SelectedIndex > -1)
            {
                nome.Text = lista[registro.SelectedIndex].Nome;
                profissão.Text = lista[registro.SelectedIndex].Profissao;
                sexo.Text = lista[registro.SelectedIndex].Sexo;
                relacionamento.Text = lista[registro.SelectedIndex].EstCiv;
                tiposanguineo.Text = lista[registro.SelectedIndex].SangTip;
                endereço.Text = lista[registro.SelectedIndex].Endereço;
                email.Text = lista[registro.SelectedIndex].Email;
                idade.Text = lista[registro.SelectedIndex].Idade;
                salario.Text = lista[registro.SelectedIndex].Salario;
                tel.Text = lista[registro.SelectedIndex].Telefone;
                numdefilhos.Text = lista[registro.SelectedIndex].Nfilhos;
            }
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            if (registro.SelectedIndex > -1)
            {
                lista.RemoveAt(registro.SelectedIndex);
                string[] reWrite = new string[lista.Count];
                for (int i = 0; i < lista.Count; i++)
                {
                    reWrite[i] = lista[i].ToText();
                }

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
                System.IO.File.WriteAllLines("Funcionarios.txt", reWrite);
                
            }
        }
        }
    }


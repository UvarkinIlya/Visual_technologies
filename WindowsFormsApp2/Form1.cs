using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        //string path = @"C:\SomeDir\states.dat";
        //using (FileStream fstream = new FileStream($"{path}\note.txt", FileMode.OpenOrCreate));

        string eng_english, eng_russian, eng_total;
        string rus_english, rus_russian, rus_total;
        string split = " ";
        public Form1()
        {
            file_eng_read();
            file_rus_read();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eng_english = textBox_eng_english.Text;
            eng_russian = textBox_eng_russian.Text;

            eng_total = eng_english + split + eng_russian + '\n';
            file_eng_write(eng_total);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rus_english = textBox_rus_english.Text;
            rus_russian = textBox_rus_russian.Text;

            rus_total = rus_english + split + rus_russian + '\n';
            file_rus_write(rus_total);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        public void file_eng_write(string str_total)
        {

            using (FileStream fstream = new FileStream(@"C:\Users\79914\source\repos\Словарь\WindowsFormsApp2\dat\EnRuDict.dat", FileMode.Append))
            {

                byte[] input = Encoding.Default.GetBytes(str_total);
                fstream.Write(input, 0, input.Length);

                listBox1.Items.AddRange(new object[] {
                str_total});

                Console.WriteLine("Текст записан в файл");
            }
        }

        public void file_rus_write(string str_total)
        {

            using (FileStream fstream = new FileStream(@"C:\Users\79914\source\repos\Словарь\WindowsFormsApp2\dat\RuEnDict.dat", FileMode.Append))
            {

                byte[] input = Encoding.Default.GetBytes(str_total);
                fstream.Write(input, 0, input.Length);

                listBox2.Items.AddRange(new object[] {
                str_total});

                Console.WriteLine("Текст записан в файл");
            }
        }
        public async void file_eng_read()
        {
            using (FileStream fstream = File.OpenRead(@"C:\Users\79914\source\repos\Словарь\WindowsFormsApp2\dat\EnRuDict.dat"))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                string[] words = textFromFile.Split('\n');

                foreach (var word in words)
                {
                    if (word != "")
                    {
                        listBox1.Items.AddRange(new object[] {
                        word});
                    }
                }
            }
        }

        public async void file_rus_read()
        {
            using (FileStream fstream = File.OpenRead(@"C:\Users\79914\source\repos\Словарь\WindowsFormsApp2\dat\RuEnDict.dat"))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                string[] words = textFromFile.Split('\n');

                foreach (var word in words)
                {
                    if (word != "")
                    {
                        listBox2.Items.AddRange(new object[] {
                        word});
                    }
                }
            }
        }
    }
}

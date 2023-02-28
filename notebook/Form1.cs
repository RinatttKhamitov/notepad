using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохраняет изменения в файле
        /// </summary>
        public void SaveChanges()
        {
            string message = "Вы хотиете сохранить изменения в файле?";
            string title = "Блокнот";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            switch (result)
            {
                case DialogResult.Yes:
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = saveFileDialog1.FileName;
                    // сохраняем текст в файл
                    System.IO.File.WriteAllText(filename, textBox1.Text);
                    this.Close();
                    return;
                case DialogResult.No:
                    this.Close();
                    return;
                case DialogResult.Cancel:
                    return;
            }
        }
        /// <summary>
        /// Кнопка Файл/Создать
        /// Сохраняет файл
        /// </summary>
        private void ClickCreate(object sender, EventArgs e)
        {
            SaveChanges();

        }
        /// <summary>
        /// Кнопка Файл/Новое окно
        /// Создает новое окно
        /// </summary>
        private void ClickNewWindow(object sender, EventArgs e)
        {
            Form1 NewNotePad = new Form1();
            NewNotePad.Show();
        }
        /// <summary>
        /// Кнопка Файл/Открыть
        ///  Открывает выбранный файл
        /// </summary>
        private void ClickOpen(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        private void ZoomIn(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size + 4, textBox1.Font.Style);
        }

        private void ZoomOut(object sender, EventArgs e)
        {
            if (textBox1.Font.Size - 4 <= 0)
            {
                return;
            } 
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size - 5, textBox1.Font.Style);

        }
    }
}

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

namespace Note
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt|Word File(*.doc)|*.doc";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Word File(*.doc)|*.doc";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //очищаем для нового файла
            Form1 form = new Form1();
            form.Show();
            //TEXT.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = File.ReadAllText(filename);
            TEXT.Text = fileText;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            File.WriteAllText(filename, TEXT.Text);
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TEXT.TextLength > 0)
            {
                TEXT.Copy();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TEXT.TextLength > 0)
            {
                TEXT.Cut();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TEXT.TextLength > 0)
            {
                TEXT.Paste();
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (TEXT.SelectionColor != null)
            {
                TEXT.SelectionColor = colorDialog1.Color;
            }
        }

        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();    
            //TEXT.Font = fontDialog1.Font;
            if (TEXT.SelectionFont != null)
            {   
                TEXT.SelectionFont = fontDialog1.Font;
            }
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TEXT.SelectionFont != null)
            {
                Font current = TEXT.SelectionFont;
                FontStyle newFontStyle;
                if (!(TEXT.SelectionFont.Bold))
                {
                    newFontStyle = FontStyle.Bold;
                }
                else
                {
                    newFontStyle = FontStyle.Regular;  
                }
                TEXT.SelectionFont = new Font(current.FontFamily, current.Size, newFontStyle);
            }
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TEXT.SelectionFont != null)
            {
                Font current = TEXT.SelectionFont;
                FontStyle newFontStyle;
                if (!(TEXT.SelectionFont.Italic))
                {
                    newFontStyle = FontStyle.Italic;
                }
                else
                {
                    newFontStyle = FontStyle.Regular;
                }
                TEXT.SelectionFont = new Font(current.FontFamily, current.Size, newFontStyle);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void размерToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    comboBox1.Show();
        //    if (TEXT.SelectionFont != null)
        //    {
        //        Font current = TEXT.SelectionFont;
        //        object res;
        //        res = comboBox1.SelectedItem;
        //        TEXT.SelectionFont = new Font(current, res);
        //    }
        //}
    }
}

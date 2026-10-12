using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace money
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Button button1;

        public Form1()
        {
            // InitializeComponent(); buranı silirik, çünki dizaynerə ehtiyacımız yoxdur

            // Formun parametrləri
            this.Text = "Pul Xırdalamaq";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // TextBox yaratmaq
            textBox1 = new TextBox();
            textBox1.Name = "textBox1";
            textBox1.Location = new Point(30, 30);
            textBox1.Size = new Size(200, 25);
            this.Controls.Add(textBox1);

            // Button yaratmaq
            button1 = new Button();
            button1.Name = "button1";
            button1.Text = "Hesabla";
            button1.Location = new Point(250, 28);
            button1.Size = new Size(100, 28);
            button1.Click += new EventHandler(this.button1_Click);
            this.Controls.Add(button1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control txtBox = this.Controls.Find("textBox1", true).FirstOrDefault();
            string textValue = txtBox != null ? txtBox.Text : "";

            // 1. Xananın boş olmasını yoxlamaq
            if (string.IsNullOrWhiteSpace(textValue))
            {
                MessageBox.Show("Zəhmət olmasa məbləğ daxil edin!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Rəqəm olub-olmadığını yoxlamaq
            if (!int.TryParse(textValue, out int mebleg))
            {
                MessageBox.Show("Zəhmət olmasa düzgün rəqəm daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Mənfi və ya sıfır məbləğ yoxlanışı
            if (mebleg <= 0)
            {
                MessageBox.Show("Mənfi və ya sıfır məbləğ xırdalanmaz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Əskinasların hesablanması
            int a500 = mebleg / 500; mebleg %= 500;
            int a200 = mebleg / 200; mebleg %= 200;
            int a100 = mebleg / 100; mebleg %= 100;
            int a50 = mebleg / 50; mebleg %= 50;
            int a20 = mebleg / 20; mebleg %= 20;
            int a10 = mebleg / 10; mebleg %= 10;
            int a5 = mebleg / 5; mebleg %= 5;
            int a1 = mebleg;

            // 5. Nəticələrin göstərilməsi
            ShowResult("pictureBox6", "label9", a500, "ədəd 500");
            ShowResult("pictureBox2", "label8", a200, "ədəd 200");
            ShowResult("pictureBox5", "label7", a100, "ədəd 100");
            ShowResult("pictureBox7", "label6", a50, "ədəd 50");
            ShowResult("pictureBox8", "label5", a20, "ədəd 20");
            ShowResult("pictureBox4", "label4", a10, "ədəd 10");
            ShowResult("pictureBox3", "label3", a5, "ədəd 5");
            ShowResult("pictureBox1", "label2", a1, "ədəd 1");
        }

        private void ShowResult(string picName, string labelName, int count, string text)
        {
            PictureBox pic = this.Controls.Find(picName, true).FirstOrDefault() as PictureBox;
            Label lbl = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

            if (count > 0)
            {
                if (pic != null) pic.Visible = true;
                if (lbl != null)
                {
                    lbl.Visible = true;
                    lbl.Text = $"{count} {text}";
                }
            }
            else
            {
                if (pic != null) pic.Visible = false;
                if (lbl != null) lbl.Visible = false;
            }
        }
    }
}
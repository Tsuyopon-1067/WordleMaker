using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleMaker {
    public partial class Form2 : Form {
        string coppy = "";
        public Form2() {
            InitializeComponent();
        }

        private void label2_MouseEnter(object sender, EventArgs e) {
            this.Cursor = Cursors.Hand;
        }

        private void label2_MouseLeave(object sender, EventArgs e) {
            this.Cursor = Cursors.Arrow;
        }
        public void SetInfo(int a, int n, string res) {
            string s = "Wordle " + a.ToString() + "/" + n.ToString();
            lbRes.Text = s;
            coppy = s + "\n" + res;
        }

        private void label2_Click(object sender, EventArgs e) {
            Clipboard.SetText(coppy);
        }
    }
}

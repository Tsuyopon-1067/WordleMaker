using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleMaker {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Initialize();
        }
        string ans;
        int mode = 0; // 0:Jp 1:En
        int k = 0;
        Grid[,] grids = new Grid[10, 5];
        List<string> ansList = new List<string>();
        string clearStr = "";
        private void Initialize() {
            // 答えリストを読み取る
            StreamReader sr = new StreamReader("list.csv", Encoding.GetEncoding("Shift_JIS"));
            while (sr.Peek() != -1) {
                string line = sr.ReadLine();
                for (int i = 0; i < 5; i++) {
                    line = line.ToUpper();
                }
                ansList.Add(line);
            }
            sr.Close();
            int n = ansList.Count;
            Random rnd = new System.Random();
            ans = ansList[rnd.Next(1, n)];
            if (ansList[0] == "J") mode = 0;
            else mode = 1;

            // ラベルを並べる
            Point edge = new Point(20, 20);
            Point gridSize = new Point(60, 60);
            Point gridSpace = new Point(5, 5);

            Point tableSize;
            if (mode == 0) tableSize = new Point(5, 10);
            else tableSize = new Point(5, 6);

            Font fnt = new Font("Yu Gothic UI", 28);
            for (int i = 0; i < tableSize.Y; i++) {
                for (int j = 0; j < tableSize.X; j++) {
                    Point point = new Point(edge.X + (gridSize.X + gridSpace.X) * j, edge.Y + (gridSize.Y + gridSpace.Y) * i);
                    if (5 <= i && mode == 0) {
                        point.X += edge.X + (gridSize.X + gridSpace.X) * 5;
                        point.Y = edge.Y + (gridSize.Y + gridSpace.Y) * (i - 5);
                    }
                    Grid gr = new Grid(gridSize, point, fnt);
                    gr.setText("");
                    this.Controls.Add(gr.getLabel());
                    grids[i, j] = gr;
                }
            }


            int winWidth = grids[tableSize.Y - 1, tableSize.X - 1].getLabel().Left + gridSize.X + 30;
            if (mode == 1) winWidth = btnLoose.Left + btnLoose.Width + 20;
            this.Width = winWidth;

            if (mode == 0) CreateJpBtn(edge, gridSize);
            else if (mode == 1) CreateEnBtn(edge, gridSize);
        }

        private void CreateJpBtn(Point edge, Point gridSize) {
            // ボタンを並べる
            Point btnSize = new Point(32, 32);
            Point btnEdge = new Point(2, 2);
            Font fntBtn = new Font("Yu Gothic UI", 14);
            Point btnInit = new Point(edge.X, grids[4, 0].getLabel().Top + grids[4, 0].getLabel().Height + 10);
            string[,] btnTxt = {
                {"あ", "い", "う", "え", "お"},
                {"か", "き", "く", "け", "こ"},
                {"さ", "し", "す", "せ", "そ"},
                {"た", "ち", "つ", "て", "と"},
                {"な", "に", "ぬ", "ね", "の"},
                {"は", "ひ", "ふ", "へ", "ほ"},
                {"ま", "み", "む", "め", "も"},
                {"や", "", "ゆ", "", "よ"},
                {"ら", "り", "る", "れ", "ろ"},
                {"わ", "", "を", "", "ん"},
                {"が", "ぎ", "ぐ", "げ", "ご"},
                {"ざ", "じ", "ず", "ぜ", "ぞ"},
                {"だ", "ぢ", "づ", "で", "ど"},
                {"ば", "び", "ぶ", "べ", "ぼ"},
                {"ぱ", "ぴ", "ぷ", "ぺ", "ぽ"},
                {"", "", "", "", ""},
                {"ぁ", "ぃ", "ぅ", "ぇ", "ぉ"},
                {"ゃ", "", "ゅ", "", "ょ"},
                {"←", "", "ー", "", "っ"}
            };
            for (int i = 0; i < 19; i++) {
                for (int j = 0; j < 5; j++) {
                    if (btnTxt[i, j] == "") continue;
                    Button btn = new Button();
                    btn.Text = btnTxt[i, j];
                    btn.Width = btnSize.X;
                    btn.Height = btnSize.Y;
                    btn.Left = btnInit.X + i * (btnSize.X + btnEdge.X);
                    btn.Top = btnInit.Y + j * (btnSize.Y + btnEdge.Y);
                    btn.Font = fntBtn;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Click += new EventHandler(buttonJpClick); // クリックイベントハンドラを追加
                    this.Controls.Add(btn);
                }
            }
            int bottomY = btnInit.Y + 4 * (btnSize.Y + btnEdge.Y) + btnSize.Y + 10;
            tbIn.Top = bottomY;
            btnEnter.Top = bottomY;
            btnLoose.Top = bottomY;

            btnLoose.Left = this.Width - btnLoose.Width - edge.X - 10;
            btnEnter.Left = btnLoose.Left - btnLoose.Width - 10;
            tbIn.Width = btnEnter.Left - tbIn.Left - 10;
        }

        private void CreateEnBtn(Point edge, Point gridSize) {
            // ボタンを並べる
            Point btnSize = new Point(32, 32);
            Point btnEdge = new Point(2, 2);
            Font fntBtn = new Font("Yu Gothic UI", 14);
            Point btnInit = new Point(edge.X, 2*edge.Y + 6 * (gridSize.Y + 5));
            string[,] btnTxt = {
                {"Q","W","E","R","T","Y","U","I","O","P" },
                {"A","S","D","F","G","H","J","K","L", "" },
                {"Z","X","C","V","B","N","M","←", "", ""}
            };
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 10; j++) {
                    if (btnTxt[i, j] == "") continue;
                    Button btn = new Button();
                    btn.Text = btnTxt[i, j];
                    btn.Width = btnSize.X;
                    btn.Height = btnSize.Y;
                    btn.Left = btnInit.X + j * (btnSize.X + btnEdge.X);
                    if (i == 1) btn.Left += 9;
                    else if (i == 2) btn.Left += 18;
                    btn.Top = btnInit.Y + i * (btnSize.Y + btnEdge.Y);
                    btn.Font = fntBtn;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Click += new EventHandler(buttonEnClick); // クリックイベントハンドラを追加
                    this.Controls.Add(btn);
                }
            }
            int bottomY = btnInit.Y + 3 * (btnSize.Y + btnEdge.Y) + 10;
            tbIn.Top = bottomY;
            btnEnter.Top = bottomY;
            btnLoose.Top = bottomY;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (10 <= k) return;
            AnsBtn();
        }
        private void AnsBtn() {
            if (isLoose) return;
            string sIn = this.tbIn.Text;
            if (btnStr.Length == 5) {
                sIn = btnStr;
            }
            if (sIn.Length != 5) return;

            sIn = sIn.ToUpper();

            bool isExist = false;
            for (int i = 0; i < ansList.Count; i++) {
                if (sIn == ansList[i]) isExist = true;
            }
            if (!isExist) return;

            TextShow(sIn);
            k++;
            btnStr = "";
            row = 0;
        }
        private void TextShow(string s) {
            tbIn.Text = "";
            tbIn.Update();
            for (int i = 0; i < 5; i++) {
                if (s[i] == ans[i]) {
                    grids[k, i].getLabel().BackColor = Color.FromArgb(106, 170, 100);
                    clearStr += ClearColor.g;
                } else if (isContain(s[i])) {
                    grids[k, i].getLabel().BackColor = Color.FromArgb(201, 180, 88);
                    clearStr += ClearColor.y;
                } else {
                    grids[k, i].getLabel().BackColor = Color.FromArgb(120, 124, 126);
                    clearStr += ClearColor.w;
                }
                grids[k, i].getLabel().ForeColor = Color.White;
                grids[k, i].getLabel().BorderStyle = BorderStyle.None;
                grids[k, i].setText(s[i].ToString());
                grids[k, i].getLabel().Refresh();
                Thread.Sleep(250);
            }
            clearStr += "\n";

            int n = 10;
            if (mode == 1) n = 6;
            if (s == ans) {
                Form2 f = new Form2();
                f.SetInfo(k+1, n, clearStr);
                f.Show();
            }
        }
        bool isContain(char c) {
            bool res = false;
            for (int i = 0; i < 5; i++) {
                if (c == ans[i]) res = true;
            }
            return res;
        }

        bool isLoose = false;
        private void BtnLoose_Click(object sender, EventArgs e) {
            MessageBox.Show("答えは\n" + ans);
            isLoose = true;
            this.Text = "Wordleめーかー | 答えを見たらもう入力できないよ";
        }
        int row = 0;
        string btnStr = "";
        private void buttonJpClick(object sender, EventArgs e) {
            string c = ((Button)sender).Text;
            if (c == "←") {
                if (btnStr.Length == 0) return;
                int len = c.Length;
                btnStr = btnStr.Remove(len - 1, 1);
                grids[k, row].setText("");
                row--;
                if (row < 0) row = 0;
            } else {
                if (grids[k, row].getText() != "") row++;
                if (5 <= row) row = 4;
                btnStr += c;
                grids[k, row].setText(c);
            }
        }
        private void buttonEnClick(object sender, EventArgs e) {
            string c = ((Button)sender).Text;
            if (c == "←") {
                if (btnStr.Length == 0) return;
                int len = c.Length;
                btnStr = btnStr.Remove(len - 1, 1);
                grids[k, row].setText("");
                row--;
                if (row < 0) row = 0;
            } else {
                if (grids[k, row].getText() != "") row++;
                if (5 <= row) row = 4;
                btnStr += c;
                grids[k, row].setText(c);
            }
        }

        private void tbIn_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (10 <= k) return;
                AnsBtn();
            }
        }

    }
    class Grid {
        private string text;
        private Label lb = new Label();

        public Grid(Point size, Point point, Font font) {
            lb.Width = size.X;
            lb.Height = size.Y;
            lb.Left = point.X;
            lb.Top = point.Y;
            lb.Font = font;
            lb.AutoSize = false;
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.ForeColor = Color.Black;
        }
        public void setText(string s) {
            lb.Text = s;
            lb.Refresh();
            text = s;
        }
        public Label getLabel() {
            return lb;
        }
        public string getText() {
            return text;
        }
    }
    class ClearColor {
        public static string g = "🟩";
        public static string w = "⬜";
        public static string y = "🟨";
    }
}

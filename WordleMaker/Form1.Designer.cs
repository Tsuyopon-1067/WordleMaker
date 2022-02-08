namespace WordleMaker {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbIn = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnLoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIn
            // 
            this.tbIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIn.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F);
            this.tbIn.Location = new System.Drawing.Point(20, 364);
            this.tbIn.Name = "tbIn";
            this.tbIn.Size = new System.Drawing.Size(274, 35);
            this.tbIn.TabIndex = 0;
            this.tbIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIn_KeyDown);
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnter.Location = new System.Drawing.Point(301, 364);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(91, 35);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "決定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoose
            // 
            this.btnLoose.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLoose.Location = new System.Drawing.Point(398, 363);
            this.btnLoose.Name = "btnLoose";
            this.btnLoose.Size = new System.Drawing.Size(91, 36);
            this.btnLoose.TabIndex = 2;
            this.btnLoose.Text = "降参";
            this.btnLoose.UseVisualStyleBackColor = true;
            this.btnLoose.Click += new System.EventHandler(this.BtnLoose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 601);
            this.Controls.Add(this.btnLoose);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Wordleめーかー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIn;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnLoose;
    }
}


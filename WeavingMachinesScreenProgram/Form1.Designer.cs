namespace WeavingMachinesScreenProgram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel4 = new FlowLayoutPanel();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(12, 47);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(1880, 982);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(538, 15);
            label1.TabIndex = 1;
            label1.Text = "SARI İSE VERİ GELMİYOR - KIRMIZI İSE ÇALIŞMIYOR - YEŞİL İSE ÇALIŞIYOR ANLAMINA GELMEKTEDİR.";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(1817, 18);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "WEB";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "BUFERA TEXTİLE - MAKİNA DURUM GÖRÜNTÜLEME V.0.0.2";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel4;
        private Label label1;
        private Button button1;
    }
}

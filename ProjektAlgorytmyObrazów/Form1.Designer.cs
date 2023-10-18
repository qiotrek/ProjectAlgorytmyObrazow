namespace ProjektAlgorytmyObrazów
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Wczytaj = new System.Windows.Forms.Button();
            this.Duplikuj = new System.Windows.Forms.Button();
            this.Zapisz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Wczytaj
            // 
            this.Wczytaj.Location = new System.Drawing.Point(2, 3);
            this.Wczytaj.Name = "Wczytaj";
            this.Wczytaj.Size = new System.Drawing.Size(75, 23);
            this.Wczytaj.TabIndex = 0;
            this.Wczytaj.Text = "Wczytaj";
            this.Wczytaj.UseVisualStyleBackColor = true;
            // 
            // Duplikuj
            // 
            this.Duplikuj.Location = new System.Drawing.Point(83, 3);
            this.Duplikuj.Name = "Duplikuj";
            this.Duplikuj.Size = new System.Drawing.Size(75, 23);
            this.Duplikuj.TabIndex = 1;
            this.Duplikuj.Text = "Duplikuj";
            this.Duplikuj.UseVisualStyleBackColor = true;
          
            // 
            // Zapisz
            // 
            this.Zapisz.Location = new System.Drawing.Point(164, 3);
            this.Zapisz.Name = "Zapisz";
            this.Zapisz.Size = new System.Drawing.Size(75, 23);
            this.Zapisz.TabIndex = 2;
            this.Zapisz.Text = "Zapisz";
            this.Zapisz.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.Duplikuj);
            this.Controls.Add(this.Wczytaj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Wczytaj;
        private System.Windows.Forms.Button Duplikuj;
        private System.Windows.Forms.Button Zapisz;
    }
}


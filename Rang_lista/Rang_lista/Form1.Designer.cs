using System.Drawing;
namespace Rang_lista
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
            this.textField_upisIgraca = new System.Windows.Forms.TextBox();
            this.btn_upis = new System.Windows.Forms.Button();
            this.lblNewLabel = new System.Windows.Forms.Label();
            this.unetiSviIgraci = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lista1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upisPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upisRangListeUFailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrisiIzBazeSveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textField_upisIgraca
            // 
            this.textField_upisIgraca.Location = new System.Drawing.Point(271, 80);
            this.textField_upisIgraca.Name = "textField_upisIgraca";
            this.textField_upisIgraca.Size = new System.Drawing.Size(100, 20);
            this.textField_upisIgraca.TabIndex = 0;
            // 
            // btn_upis
            // 
            this.btn_upis.Location = new System.Drawing.Point(271, 124);
            this.btn_upis.Name = "btn_upis";
            this.btn_upis.Size = new System.Drawing.Size(75, 23);
            this.btn_upis.TabIndex = 1;
            this.btn_upis.Text = "Unesi";
            this.btn_upis.UseVisualStyleBackColor = true;
            this.btn_upis.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNewLabel
            // 
            this.lblNewLabel.AutoSize = true;
            this.lblNewLabel.Location = new System.Drawing.Point(268, 41);
            this.lblNewLabel.Name = "lblNewLabel";
            this.lblNewLabel.Size = new System.Drawing.Size(0, 13);
            this.lblNewLabel.TabIndex = 2;
            // 
            // unetiSviIgraci
            // 
            this.unetiSviIgraci.AutoSize = true;
            this.unetiSviIgraci.Location = new System.Drawing.Point(387, 80);
            this.unetiSviIgraci.Name = "unetiSviIgraci";
            this.unetiSviIgraci.Size = new System.Drawing.Size(105, 17);
            this.unetiSviIgraci.TabIndex = 3;
            this.unetiSviIgraci.Text = "Upisani svi igraci";
            this.unetiSviIgraci.UseVisualStyleBackColor = true;
            this.unetiSviIgraci.CheckedChanged += new System.EventHandler(this.unetiSviIgraci_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(387, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Prikazi narednu listu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.bazaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lista1ToolStripMenuItem,
            this.upisRangListeUFailToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Datoteka";
            // 
            // lista1ToolStripMenuItem
            // 
            this.lista1ToolStripMenuItem.Name = "lista1ToolStripMenuItem";
            this.lista1ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.lista1ToolStripMenuItem.Text = "Unos igraca iz .txt fajla";
            this.lista1ToolStripMenuItem.Click += new System.EventHandler(this.lista1ToolStripMenuItem_Click);
            // 
            // bazaToolStripMenuItem
            // 
            this.bazaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upisPodatakaToolStripMenuItem,
            this.databaseHTMLToolStripMenuItem,
            this.izbrisiIzBazeSveToolStripMenuItem});
            this.bazaToolStripMenuItem.Name = "bazaToolStripMenuItem";
            this.bazaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.bazaToolStripMenuItem.Text = "Baza";
            // 
            // upisPodatakaToolStripMenuItem
            // 
            this.upisPodatakaToolStripMenuItem.Name = "upisPodatakaToolStripMenuItem";
            this.upisPodatakaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.upisPodatakaToolStripMenuItem.Text = "Upis podataka";
            this.upisPodatakaToolStripMenuItem.Click += new System.EventHandler(this.upisPodatakaToolStripMenuItem_Click);
            // 
            // databaseHTMLToolStripMenuItem
            // 
            this.databaseHTMLToolStripMenuItem.Name = "databaseHTMLToolStripMenuItem";
            this.databaseHTMLToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.databaseHTMLToolStripMenuItem.Text = "Database -> HTML";
            this.databaseHTMLToolStripMenuItem.Click += new System.EventHandler(this.databaseHTMLToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramuToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oProgramuToolStripMenuItem.Text = "O programu...";
            this.oProgramuToolStripMenuItem.Click += new System.EventHandler(this.oProgramuToolStripMenuItem_Click);
            // 
            // upisRangListeUFailToolStripMenuItem
            // 
            this.upisRangListeUFailToolStripMenuItem.Name = "upisRangListeUFailToolStripMenuItem";
            this.upisRangListeUFailToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.upisRangListeUFailToolStripMenuItem.Text = "Upis rang liste u fail";
            this.upisRangListeUFailToolStripMenuItem.Click += new System.EventHandler(this.upisRangListeUFailToolStripMenuItem_Click);
            // 
            // izbrisiIzBazeSveToolStripMenuItem
            // 
            this.izbrisiIzBazeSveToolStripMenuItem.Name = "izbrisiIzBazeSveToolStripMenuItem";
            this.izbrisiIzBazeSveToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.izbrisiIzBazeSveToolStripMenuItem.Text = "Isprazni bazu";
            this.izbrisiIzBazeSveToolStripMenuItem.Click += new System.EventHandler(this.izbrisiIzBazeSveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unetiSviIgraci);
            this.Controls.Add(this.lblNewLabel);
            this.Controls.Add(this.btn_upis);
            this.Controls.Add(this.textField_upisIgraca);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Rezultati";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textField_upisIgraca;
        private System.Windows.Forms.Button btn_upis;
        private System.Windows.Forms.Label lblNewLabel;
        private System.Windows.Forms.CheckBox unetiSviIgraci;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lista1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upisPodatakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upisRangListeUFailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrisiIzBazeSveToolStripMenuItem;
        
    }
}


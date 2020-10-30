namespace Trabalho3D
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbBackFaceCulling = new System.Windows.Forms.CheckBox();
            this.rbFrontal = new System.Windows.Forms.RadioButton();
            this.fbProjecao = new System.Windows.Forms.GroupBox();
            this.rbCavaleira = new System.Windows.Forms.RadioButton();
            this.rbCabinet = new System.Windows.Forms.RadioButton();
            this.rbLateral = new System.Windows.Forms.RadioButton();
            this.rbSuperior = new System.Windows.Forms.RadioButton();
            this.btnColorir = new System.Windows.Forms.Button();
            this.btnCorAtual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.fbProjecao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(5, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(900, 700);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(911, 5);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(130, 23);
            this.btnCarregar.TabIndex = 1;
            this.btnCarregar.Text = "Carregar OBJ";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.BtnCarregar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(1047, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(130, 23);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // cbBackFaceCulling
            // 
            this.cbBackFaceCulling.AutoSize = true;
            this.cbBackFaceCulling.Location = new System.Drawing.Point(912, 35);
            this.cbBackFaceCulling.Name = "cbBackFaceCulling";
            this.cbBackFaceCulling.Size = new System.Drawing.Size(112, 17);
            this.cbBackFaceCulling.TabIndex = 3;
            this.cbBackFaceCulling.Text = "Back Face Culling";
            this.cbBackFaceCulling.UseVisualStyleBackColor = true;
            this.cbBackFaceCulling.CheckedChanged += new System.EventHandler(this.CbBackFaceCulling_CheckedChanged);
            // 
            // rbFrontal
            // 
            this.rbFrontal.AutoSize = true;
            this.rbFrontal.Checked = true;
            this.rbFrontal.Location = new System.Drawing.Point(15, 19);
            this.rbFrontal.Name = "rbFrontal";
            this.rbFrontal.Size = new System.Drawing.Size(125, 17);
            this.rbFrontal.TabIndex = 5;
            this.rbFrontal.TabStop = true;
            this.rbFrontal.Text = "P. Ortografica Frontal";
            this.rbFrontal.UseVisualStyleBackColor = true;
            this.rbFrontal.CheckedChanged += new System.EventHandler(this.RbFrontal_CheckedChanged);
            // 
            // fbProjecao
            // 
            this.fbProjecao.Controls.Add(this.rbCavaleira);
            this.fbProjecao.Controls.Add(this.rbCabinet);
            this.fbProjecao.Controls.Add(this.rbLateral);
            this.fbProjecao.Controls.Add(this.rbSuperior);
            this.fbProjecao.Controls.Add(this.rbFrontal);
            this.fbProjecao.Location = new System.Drawing.Point(912, 87);
            this.fbProjecao.Name = "fbProjecao";
            this.fbProjecao.Size = new System.Drawing.Size(260, 142);
            this.fbProjecao.TabIndex = 6;
            this.fbProjecao.TabStop = false;
            this.fbProjecao.Text = "Projeções ";
            // 
            // rbCavaleira
            // 
            this.rbCavaleira.AutoSize = true;
            this.rbCavaleira.Location = new System.Drawing.Point(16, 113);
            this.rbCavaleira.Name = "rbCavaleira";
            this.rbCavaleira.Size = new System.Drawing.Size(121, 17);
            this.rbCavaleira.TabIndex = 10;
            this.rbCavaleira.TabStop = true;
            this.rbCavaleira.Text = "P. Obliqua Cavaleira";
            this.rbCavaleira.UseVisualStyleBackColor = true;
            this.rbCavaleira.CheckedChanged += new System.EventHandler(this.RbCavaleira_CheckedChanged);
            // 
            // rbCabinet
            // 
            this.rbCabinet.AutoSize = true;
            this.rbCabinet.Location = new System.Drawing.Point(16, 90);
            this.rbCabinet.Name = "rbCabinet";
            this.rbCabinet.Size = new System.Drawing.Size(113, 17);
            this.rbCabinet.TabIndex = 8;
            this.rbCabinet.TabStop = true;
            this.rbCabinet.Text = "P. Obliqua Cabinet";
            this.rbCabinet.UseVisualStyleBackColor = true;
            this.rbCabinet.CheckedChanged += new System.EventHandler(this.RbCabinet_CheckedChanged);
            // 
            // rbLateral
            // 
            this.rbLateral.AutoSize = true;
            this.rbLateral.Location = new System.Drawing.Point(15, 67);
            this.rbLateral.Name = "rbLateral";
            this.rbLateral.Size = new System.Drawing.Size(125, 17);
            this.rbLateral.TabIndex = 7;
            this.rbLateral.TabStop = true;
            this.rbLateral.Text = "P. Ortografica Lateral";
            this.rbLateral.UseVisualStyleBackColor = true;
            this.rbLateral.CheckedChanged += new System.EventHandler(this.RbLateral_CheckedChanged);
            // 
            // rbSuperior
            // 
            this.rbSuperior.AutoSize = true;
            this.rbSuperior.Location = new System.Drawing.Point(15, 43);
            this.rbSuperior.Name = "rbSuperior";
            this.rbSuperior.Size = new System.Drawing.Size(132, 17);
            this.rbSuperior.TabIndex = 6;
            this.rbSuperior.TabStop = true;
            this.rbSuperior.Text = "P. Ortografica Superior";
            this.rbSuperior.UseVisualStyleBackColor = true;
            this.rbSuperior.CheckedChanged += new System.EventHandler(this.RbSuperior_CheckedChanged);
            // 
            // btnColorir
            // 
            this.btnColorir.Location = new System.Drawing.Point(5, 6);
            this.btnColorir.Name = "btnColorir";
            this.btnColorir.Size = new System.Drawing.Size(129, 23);
            this.btnColorir.TabIndex = 7;
            this.btnColorir.Text = "button1";
            this.btnColorir.UseVisualStyleBackColor = true;
            this.btnColorir.Click += new System.EventHandler(this.BtnColorir_Click);
            // 
            // btnCorAtual
            // 
            this.btnCorAtual.Location = new System.Drawing.Point(140, 1);
            this.btnCorAtual.Name = "btnCorAtual";
            this.btnCorAtual.Size = new System.Drawing.Size(30, 30);
            this.btnCorAtual.TabIndex = 8;
            this.btnCorAtual.UseVisualStyleBackColor = true;
            this.btnCorAtual.Click += new System.EventHandler(this.BtnCorAtual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 741);
            this.Controls.Add(this.btnCorAtual);
            this.Controls.Add(this.btnColorir);
            this.Controls.Add(this.fbProjecao);
            this.Controls.Add(this.cbBackFaceCulling);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.fbProjecao.ResumeLayout(false);
            this.fbProjecao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private object panel;
        private System.Windows.Forms.CheckBox cbBackFaceCulling;
        private System.Windows.Forms.RadioButton rbFrontal;
        private System.Windows.Forms.GroupBox fbProjecao;
        private System.Windows.Forms.RadioButton rbSuperior;
        private System.Windows.Forms.RadioButton rbLateral;
        private System.Windows.Forms.RadioButton rbCabinet;
        private System.Windows.Forms.RadioButton rbCavaleira;
        private System.Windows.Forms.Button btnColorir;
        private System.Windows.Forms.Button btnCorAtual;
    }
}


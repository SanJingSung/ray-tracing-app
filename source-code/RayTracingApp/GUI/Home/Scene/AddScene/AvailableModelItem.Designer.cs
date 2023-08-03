﻿namespace GUI
{
    partial class AvailableModelItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.lblModelName = new System.Windows.Forms.Label();
			this.picAddButton = new System.Windows.Forms.PictureBox();
			this.picIconSphere = new System.Windows.Forms.PictureBox();
			this.picModelColor = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picAddButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picIconSphere)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picModelColor)).BeginInit();
			this.SuspendLayout();
			// 
			// lblModelName
			// 
			this.lblModelName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModelName.ForeColor = System.Drawing.Color.White;
			this.lblModelName.Location = new System.Drawing.Point(46, 8);
			this.lblModelName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lblModelName.MaximumSize = new System.Drawing.Size(133, 50);
			this.lblModelName.Name = "lblModelName";
			this.lblModelName.Size = new System.Drawing.Size(133, 50);
			this.lblModelName.TabIndex = 1;
			this.lblModelName.Text = "Line1\r\nLine2\r\n\r\n\r\n";
			this.lblModelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picAddButton
			// 
			this.picAddButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picAddButton.Image = global::GUI.Properties.Resources.plus;
			this.picAddButton.Location = new System.Drawing.Point(183, 25);
			this.picAddButton.Name = "picAddButton";
			this.picAddButton.Size = new System.Drawing.Size(18, 18);
			this.picAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picAddButton.TabIndex = 2;
			this.picAddButton.TabStop = false;
			this.picAddButton.Click += new System.EventHandler(this.picAddButton_Click);
			// 
			// picIconSphere
			// 
			this.picIconSphere.Image = global::GUI.Properties.Resources.lSphereIcon;
			this.picIconSphere.Location = new System.Drawing.Point(7, 15);
			this.picIconSphere.Name = "picIconSphere";
			this.picIconSphere.Size = new System.Drawing.Size(35, 35);
			this.picIconSphere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picIconSphere.TabIndex = 0;
			this.picIconSphere.TabStop = false;
			// 
			// picModelColor
			// 
			this.picModelColor.Location = new System.Drawing.Point(28, 8);
			this.picModelColor.Name = "picModelColor";
			this.picModelColor.Size = new System.Drawing.Size(20, 20);
			this.picModelColor.TabIndex = 3;
			this.picModelColor.TabStop = false;
			// 
			// AvailableModelItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
			this.Controls.Add(this.picModelColor);
			this.Controls.Add(this.picAddButton);
			this.Controls.Add(this.lblModelName);
			this.Controls.Add(this.picIconSphere);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "AvailableModelItem";
			this.Size = new System.Drawing.Size(212, 65);
			((System.ComponentModel.ISupportInitialize)(this.picAddButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picIconSphere)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picModelColor)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picIconSphere;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.PictureBox picAddButton;
        private System.Windows.Forms.PictureBox picModelColor;
    }
}

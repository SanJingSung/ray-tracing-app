﻿namespace GUI
{
    partial class SceneHome
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
            this.flySceneHome = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flySceneHome
            // 
            this.flySceneHome.Location = new System.Drawing.Point(0, 0);
            this.flySceneHome.Name = "flySceneHome";
            this.flySceneHome.Size = new System.Drawing.Size(834, 604);
            this.flySceneHome.TabIndex = 0;
            // 
            // SceneHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flySceneHome);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SceneHome";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(834, 604);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flySceneHome;
    }
}

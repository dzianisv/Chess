﻿namespace Chess
{
    partial class PlayWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 666);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayWindow";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.PlayWindow_Activated);
            this.Deactivate += new System.EventHandler(this.PlayWindow_Deactivate);
            this.Shown += new System.EventHandler(this.PlayWindow_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayWindow_MouseDown);
            this.Move += new System.EventHandler(this.PlayWindow_Move);
            this.ResumeLayout(false);

        }

        #endregion


    }
}


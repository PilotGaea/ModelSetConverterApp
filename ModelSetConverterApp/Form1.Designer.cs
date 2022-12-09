
using System;

namespace ModelSetConverterApp
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_Main = new System.Windows.Forms.ListBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.progressBar_Main = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Features = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox_Main
            // 
            this.listBox_Main.FormattingEnabled = true;
            this.listBox_Main.HorizontalScrollbar = true;
            this.listBox_Main.ItemHeight = 12;
            this.listBox_Main.Location = new System.Drawing.Point(12, 48);
            this.listBox_Main.Name = "listBox_Main";
            this.listBox_Main.Size = new System.Drawing.Size(597, 256);
            this.listBox_Main.TabIndex = 0;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(534, 310);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // progressBar_Main
            // 
            this.progressBar_Main.Location = new System.Drawing.Point(12, 310);
            this.progressBar_Main.Name = "progressBar_Main";
            this.progressBar_Main.Size = new System.Drawing.Size(516, 23);
            this.progressBar_Main.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Features:";
            // 
            // comboBox_Features
            // 
            this.comboBox_Features.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Features.FormattingEnabled = true;
            this.comboBox_Features.Location = new System.Drawing.Point(64, 14);
            this.comboBox_Features.Name = "comboBox_Features";
            this.comboBox_Features.Size = new System.Drawing.Size(545, 20);
            this.comboBox_Features.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 343);
            this.Controls.Add(this.comboBox_Features);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar_Main);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.listBox_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "modelset maker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Main;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.ProgressBar progressBar_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Features;
    }
}


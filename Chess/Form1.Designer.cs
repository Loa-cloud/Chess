namespace Chess
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CurrentPlayerButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Автоматический ход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(48, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 495);
            this.panel1.TabIndex = 1;
            // 
            // CurrentPlayerButton
            // 
            this.CurrentPlayerButton.BackColor = System.Drawing.Color.White;
            this.CurrentPlayerButton.Location = new System.Drawing.Point(627, 123);
            this.CurrentPlayerButton.Name = "CurrentPlayerButton";
            this.CurrentPlayerButton.Size = new System.Drawing.Size(204, 63);
            this.CurrentPlayerButton.TabIndex = 2;
            this.CurrentPlayerButton.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(627, 464);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Перезапуск партии";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 582);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CurrentPlayerButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CurrentPlayerButton;
        private System.Windows.Forms.Button button2;
    }
}


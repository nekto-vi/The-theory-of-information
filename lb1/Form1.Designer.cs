namespace lb1
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
            this.Method_1 = new System.Windows.Forms.CheckBox();
            this.Method_2 = new System.Windows.Forms.CheckBox();
            this.Read_file = new System.Windows.Forms.Button();
            this.Key_to_read = new System.Windows.Forms.TextBox();
            this.Text1 = new System.Windows.Forms.Label();
            this.Text2 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.TextBox();
            this.End = new System.Windows.Forms.TextBox();
            this.Decrypt = new System.Windows.Forms.Button();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Clear_all = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Key_to_use = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Method_1
            // 
            this.Method_1.AutoSize = true;
            this.Method_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Method_1.Location = new System.Drawing.Point(28, 26);
            this.Method_1.Name = "Method_1";
            this.Method_1.Size = new System.Drawing.Size(194, 24);
            this.Method_1.TabIndex = 2;
            this.Method_1.Text = "Столбцовый метод";
            this.Method_1.UseVisualStyleBackColor = true;
            this.Method_1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // Method_2
            // 
            this.Method_2.AutoSize = true;
            this.Method_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Method_2.Location = new System.Drawing.Point(232, 26);
            this.Method_2.Name = "Method_2";
            this.Method_2.Size = new System.Drawing.Size(176, 24);
            this.Method_2.TabIndex = 3;
            this.Method_2.Text = "Метод Виженера";
            this.Method_2.UseVisualStyleBackColor = true;
            this.Method_2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Read_file
            // 
            this.Read_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Read_file.Location = new System.Drawing.Point(414, 10);
            this.Read_file.Name = "Read_file";
            this.Read_file.Size = new System.Drawing.Size(128, 50);
            this.Read_file.TabIndex = 5;
            this.Read_file.Text = "Прочесть файл";
            this.Read_file.UseVisualStyleBackColor = true;
            this.Read_file.Click += new System.EventHandler(this.Read_file_Click);
            // 
            // Key_to_read
            // 
            this.Key_to_read.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Key_to_read.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key_to_read.Location = new System.Drawing.Point(232, 66);
            this.Key_to_read.Name = "Key_to_read";
            this.Key_to_read.Size = new System.Drawing.Size(310, 30);
            this.Key_to_read.TabIndex = 8;
            this.Key_to_read.TextChanged += new System.EventHandler(this.Key_2_TextChanged);
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text1.Location = new System.Drawing.Point(24, 156);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(234, 20);
            this.Text1.TabIndex = 9;
            this.Text1.Text = "Исходный текст из файла:";
            // 
            // Text2
            // 
            this.Text2.AutoSize = true;
            this.Text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text2.Location = new System.Drawing.Point(24, 212);
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(202, 20);
            this.Text2.TabIndex = 10;
            this.Text2.Text = "Результирющий текст:";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(24, 179);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(518, 30);
            this.Start.TabIndex = 11;
            this.Start.TextChanged += new System.EventHandler(this.Start_TextChanged);
            // 
            // End
            // 
            this.End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.End.Location = new System.Drawing.Point(24, 235);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(518, 30);
            this.End.TabIndex = 12;
            this.End.TextChanged += new System.EventHandler(this.End_TextChanged);
            // 
            // Decrypt
            // 
            this.Decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Decrypt.Location = new System.Drawing.Point(224, 288);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(194, 35);
            this.Decrypt.TabIndex = 13;
            this.Decrypt.Text = "Дешифровать";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Encrypt.Location = new System.Drawing.Point(24, 288);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(194, 35);
            this.Encrypt.TabIndex = 14;
            this.Encrypt.Text = "Шифровать";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.button2_Click);
            // 
            // Clear_all
            // 
            this.Clear_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear_all.Location = new System.Drawing.Point(424, 288);
            this.Clear_all.Name = "Clear_all";
            this.Clear_all.Size = new System.Drawing.Size(118, 35);
            this.Clear_all.TabIndex = 15;
            this.Clear_all.Text = "Очистить";
            this.Clear_all.UseVisualStyleBackColor = true;
            this.Clear_all.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Используемый ключ:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Key_to_use
            // 
            this.Key_to_use.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key_to_use.Location = new System.Drawing.Point(232, 108);
            this.Key_to_use.Name = "Key_to_use";
            this.Key_to_use.Size = new System.Drawing.Size(310, 30);
            this.Key_to_use.TabIndex = 17;
            this.Key_to_use.TextChanged += new System.EventHandler(this.Key_to_use_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ключ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Key_to_use);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear_all);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Text2);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.Key_to_read);
            this.Controls.Add(this.Read_file);
            this.Controls.Add(this.Method_2);
            this.Controls.Add(this.Method_1);
            this.Name = "Form1";
            this.Text = "Секретики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox Method_2;
        private System.Windows.Forms.Button Read_file;
        private System.Windows.Forms.TextBox Key_to_read;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.Label Text2;
        private System.Windows.Forms.TextBox Start;
        private System.Windows.Forms.TextBox End;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Clear_all;
        private System.Windows.Forms.CheckBox Method_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Key_to_use;
        private System.Windows.Forms.Label label2;
    }
}


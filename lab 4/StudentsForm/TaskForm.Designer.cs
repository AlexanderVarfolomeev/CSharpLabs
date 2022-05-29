namespace StudentsForm
{
    partial class TaskForm
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
            this.classList = new System.Windows.Forms.ComboBox();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.methodParamList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.createObjectButton = new System.Windows.Forms.Button();
            this.enterMethodParamButton = new System.Windows.Forms.Button();
            this.doMethodButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // classList
            // 
            this.classList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classList.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.classList.FormattingEnabled = true;
            this.classList.Location = new System.Drawing.Point(30, 49);
            this.classList.Name = "classList";
            this.classList.Size = new System.Drawing.Size(384, 33);
            this.classList.TabIndex = 0;
            this.classList.SelectedIndexChanged += new System.EventHandler(this.classList_SelectedIndexChanged);
            // 
            // methodList
            // 
            this.methodList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodList.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(512, 49);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(242, 33);
            this.methodList.TabIndex = 1;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Класс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(512, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Метод";
            // 
            // propertyList
            // 
            this.propertyList.FormattingEnabled = true;
            this.propertyList.ItemHeight = 15;
            this.propertyList.Location = new System.Drawing.Point(30, 130);
            this.propertyList.Name = "propertyList";
            this.propertyList.Size = new System.Drawing.Size(384, 184);
            this.propertyList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Свойства экземпляра класса";
            // 
            // methodParamList
            // 
            this.methodParamList.FormattingEnabled = true;
            this.methodParamList.ItemHeight = 15;
            this.methodParamList.Location = new System.Drawing.Point(30, 369);
            this.methodParamList.Name = "methodParamList";
            this.methodParamList.Size = new System.Drawing.Size(384, 124);
            this.methodParamList.TabIndex = 6;
            this.methodParamList.SelectedIndexChanged += new System.EventHandler(this.methodParamList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(30, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Параметры метода";
            // 
            // createObjectButton
            // 
            this.createObjectButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createObjectButton.Location = new System.Drawing.Point(512, 178);
            this.createObjectButton.Name = "createObjectButton";
            this.createObjectButton.Size = new System.Drawing.Size(242, 79);
            this.createObjectButton.TabIndex = 8;
            this.createObjectButton.Text = "Создать экземпляр класса";
            this.createObjectButton.UseVisualStyleBackColor = true;
            this.createObjectButton.Click += new System.EventHandler(this.createObjectButton_Click);
            // 
            // enterMethodParamButton
            // 
            this.enterMethodParamButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.enterMethodParamButton.Location = new System.Drawing.Point(512, 282);
            this.enterMethodParamButton.Name = "enterMethodParamButton";
            this.enterMethodParamButton.Size = new System.Drawing.Size(242, 79);
            this.enterMethodParamButton.TabIndex = 9;
            this.enterMethodParamButton.Text = "Ввести параметры метода";
            this.enterMethodParamButton.UseVisualStyleBackColor = true;
            this.enterMethodParamButton.Click += new System.EventHandler(this.enterMethodParamButton_Click);
            // 
            // doMethodButton
            // 
            this.doMethodButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.doMethodButton.Location = new System.Drawing.Point(512, 397);
            this.doMethodButton.Name = "doMethodButton";
            this.doMethodButton.Size = new System.Drawing.Size(242, 79);
            this.doMethodButton.TabIndex = 10;
            this.doMethodButton.Text = "Выполнить метод";
            this.doMethodButton.UseVisualStyleBackColor = true;
            this.doMethodButton.Click += new System.EventHandler(this.doMethodButton_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.doMethodButton);
            this.Controls.Add(this.enterMethodParamButton);
            this.Controls.Add(this.createObjectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.methodParamList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.propertyList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.methodList);
            this.Controls.Add(this.classList);
            this.Name = "TaskForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox classList;
        private ComboBox methodList;
        private Label label1;
        private Label label2;
        private ListBox propertyList;
        private Label label3;
        private ListBox methodParamList;
        private Label label4;
        private Button createObjectButton;
        private Button enterMethodParamButton;
        private Button doMethodButton;
    }
}
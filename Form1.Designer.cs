namespace SimpleCalculator
{
    partial class Calculator
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
            lblName = new Label();
            txt_Cause = new TextBox();
            btn_CE = new Button();
            btn_C = new Button();
            btn_Del = new Button();
            btn_Division = new Button();
            btn_Input7 = new Button();
            btn_Input8 = new Button();
            btn_Input9 = new Button();
            btn_Multiplication = new Button();
            btn_Input4 = new Button();
            btn_Input5 = new Button();
            btn_Input6 = new Button();
            btn_Minus = new Button();
            btn_Input1 = new Button();
            btn_Input2 = new Button();
            btn_Input3 = new Button();
            btn_Plus = new Button();
            btn_ChangeSign = new Button();
            btn_Input0 = new Button();
            btn_InputPoint = new Button();
            btn_InputEquals = new Button();
            label1 = new Label();
            txt_Result = new TextBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("맑은 고딕", 27F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblName.ForeColor = SystemColors.Highlight;
            lblName.Location = new Point(48, 34);
            lblName.Name = "lblName";
            lblName.Size = new Size(295, 48);
            lblName.TabIndex = 0;
            lblName.Text = "SimpleCalculator";
            // 
            // txt_Cause
            // 
            txt_Cause.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_Cause.Location = new Point(48, 99);
            txt_Cause.Name = "txt_Cause";
            txt_Cause.Size = new Size(290, 35);
            txt_Cause.TabIndex = 1;
            // 
            // btn_CE
            // 
            btn_CE.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_CE.Location = new Point(48, 212);
            btn_CE.Name = "btn_CE";
            btn_CE.Size = new Size(68, 41);
            btn_CE.TabIndex = 3;
            btn_CE.Text = "CE";
            btn_CE.UseVisualStyleBackColor = true;
            // 
            // btn_C
            // 
            btn_C.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_C.Location = new Point(122, 212);
            btn_C.Name = "btn_C";
            btn_C.Size = new Size(68, 41);
            btn_C.TabIndex = 4;
            btn_C.Text = "C";
            btn_C.UseVisualStyleBackColor = true;
            // 
            // btn_Del
            // 
            btn_Del.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Del.Location = new Point(196, 212);
            btn_Del.Name = "btn_Del";
            btn_Del.Size = new Size(68, 41);
            btn_Del.TabIndex = 5;
            btn_Del.Text = "del";
            btn_Del.UseVisualStyleBackColor = true;
            // 
            // btn_Division
            // 
            btn_Division.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Division.ForeColor = Color.Red;
            btn_Division.Location = new Point(270, 212);
            btn_Division.Name = "btn_Division";
            btn_Division.Size = new Size(68, 41);
            btn_Division.TabIndex = 6;
            btn_Division.Text = "÷";
            btn_Division.UseVisualStyleBackColor = true;
            // 
            // btn_Input7
            // 
            btn_Input7.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input7.ForeColor = Color.Blue;
            btn_Input7.Location = new Point(48, 259);
            btn_Input7.Name = "btn_Input7";
            btn_Input7.Size = new Size(68, 41);
            btn_Input7.TabIndex = 7;
            btn_Input7.Text = "7";
            btn_Input7.UseVisualStyleBackColor = true;
            // 
            // btn_Input8
            // 
            btn_Input8.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input8.ForeColor = Color.Blue;
            btn_Input8.Location = new Point(122, 259);
            btn_Input8.Name = "btn_Input8";
            btn_Input8.Size = new Size(68, 41);
            btn_Input8.TabIndex = 8;
            btn_Input8.Text = "8";
            btn_Input8.UseVisualStyleBackColor = true;
            // 
            // btn_Input9
            // 
            btn_Input9.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input9.ForeColor = Color.Blue;
            btn_Input9.Location = new Point(196, 259);
            btn_Input9.Name = "btn_Input9";
            btn_Input9.Size = new Size(68, 41);
            btn_Input9.TabIndex = 9;
            btn_Input9.Text = "9";
            btn_Input9.UseVisualStyleBackColor = true;
            // 
            // btn_Multiplication
            // 
            btn_Multiplication.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Multiplication.ForeColor = Color.Red;
            btn_Multiplication.Location = new Point(270, 259);
            btn_Multiplication.Name = "btn_Multiplication";
            btn_Multiplication.Size = new Size(68, 41);
            btn_Multiplication.TabIndex = 10;
            btn_Multiplication.Text = "X";
            btn_Multiplication.UseVisualStyleBackColor = true;
            // 
            // btn_Input4
            // 
            btn_Input4.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input4.ForeColor = Color.Blue;
            btn_Input4.Location = new Point(48, 306);
            btn_Input4.Name = "btn_Input4";
            btn_Input4.Size = new Size(68, 41);
            btn_Input4.TabIndex = 11;
            btn_Input4.Text = "4";
            btn_Input4.UseVisualStyleBackColor = true;
            // 
            // btn_Input5
            // 
            btn_Input5.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input5.ForeColor = Color.Blue;
            btn_Input5.Location = new Point(122, 306);
            btn_Input5.Name = "btn_Input5";
            btn_Input5.Size = new Size(68, 41);
            btn_Input5.TabIndex = 12;
            btn_Input5.Text = "5";
            btn_Input5.UseVisualStyleBackColor = true;
            // 
            // btn_Input6
            // 
            btn_Input6.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input6.ForeColor = Color.Blue;
            btn_Input6.Location = new Point(196, 306);
            btn_Input6.Name = "btn_Input6";
            btn_Input6.Size = new Size(68, 41);
            btn_Input6.TabIndex = 13;
            btn_Input6.Text = "6";
            btn_Input6.UseVisualStyleBackColor = true;
            // 
            // btn_Minus
            // 
            btn_Minus.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Minus.ForeColor = Color.Red;
            btn_Minus.Location = new Point(270, 306);
            btn_Minus.Name = "btn_Minus";
            btn_Minus.Size = new Size(68, 41);
            btn_Minus.TabIndex = 14;
            btn_Minus.Text = "-";
            btn_Minus.UseVisualStyleBackColor = true;
            // 
            // btn_Input1
            // 
            btn_Input1.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input1.ForeColor = Color.Blue;
            btn_Input1.Location = new Point(48, 353);
            btn_Input1.Name = "btn_Input1";
            btn_Input1.Size = new Size(68, 41);
            btn_Input1.TabIndex = 15;
            btn_Input1.Text = "1";
            btn_Input1.UseVisualStyleBackColor = true;
            // 
            // btn_Input2
            // 
            btn_Input2.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input2.ForeColor = Color.Blue;
            btn_Input2.Location = new Point(122, 353);
            btn_Input2.Name = "btn_Input2";
            btn_Input2.Size = new Size(68, 41);
            btn_Input2.TabIndex = 16;
            btn_Input2.Text = "2";
            btn_Input2.UseVisualStyleBackColor = true;
            // 
            // btn_Input3
            // 
            btn_Input3.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input3.ForeColor = Color.Blue;
            btn_Input3.Location = new Point(196, 353);
            btn_Input3.Name = "btn_Input3";
            btn_Input3.Size = new Size(68, 41);
            btn_Input3.TabIndex = 17;
            btn_Input3.Text = "3";
            btn_Input3.UseVisualStyleBackColor = true;
            btn_Input3.Click += button15_Click;
            // 
            // btn_Plus
            // 
            btn_Plus.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Plus.ForeColor = Color.Red;
            btn_Plus.Location = new Point(270, 353);
            btn_Plus.Name = "btn_Plus";
            btn_Plus.Size = new Size(68, 41);
            btn_Plus.TabIndex = 18;
            btn_Plus.Text = "+";
            btn_Plus.UseVisualStyleBackColor = true;
            // 
            // btn_ChangeSign
            // 
            btn_ChangeSign.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_ChangeSign.Location = new Point(48, 400);
            btn_ChangeSign.Name = "btn_ChangeSign";
            btn_ChangeSign.Size = new Size(68, 41);
            btn_ChangeSign.TabIndex = 19;
            btn_ChangeSign.Text = "+/-";
            btn_ChangeSign.UseVisualStyleBackColor = true;
            // 
            // btn_Input0
            // 
            btn_Input0.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_Input0.ForeColor = Color.Blue;
            btn_Input0.Location = new Point(122, 397);
            btn_Input0.Name = "btn_Input0";
            btn_Input0.Size = new Size(68, 41);
            btn_Input0.TabIndex = 20;
            btn_Input0.Text = "0";
            btn_Input0.UseVisualStyleBackColor = true;
            // 
            // btn_InputPoint
            // 
            btn_InputPoint.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_InputPoint.Location = new Point(196, 397);
            btn_InputPoint.Name = "btn_InputPoint";
            btn_InputPoint.Size = new Size(68, 41);
            btn_InputPoint.TabIndex = 21;
            btn_InputPoint.Text = ".";
            btn_InputPoint.UseVisualStyleBackColor = true;
            btn_InputPoint.Click += button3_Click;
            // 
            // btn_InputEquals
            // 
            btn_InputEquals.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btn_InputEquals.Location = new Point(270, 400);
            btn_InputEquals.Name = "btn_InputEquals";
            btn_InputEquals.Size = new Size(68, 41);
            btn_InputEquals.TabIndex = 22;
            btn_InputEquals.Text = "=";
            btn_InputEquals.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 150);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 23;
            // 
            // txt_Result
            // 
            txt_Result.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_Result.Location = new Point(48, 150);
            txt_Result.Name = "txt_Result";
            txt_Result.Size = new Size(290, 35);
            txt_Result.TabIndex = 24;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 450);
            Controls.Add(txt_Result);
            Controls.Add(label1);
            Controls.Add(btn_InputEquals);
            Controls.Add(btn_InputPoint);
            Controls.Add(btn_Input0);
            Controls.Add(btn_ChangeSign);
            Controls.Add(btn_Plus);
            Controls.Add(btn_Input3);
            Controls.Add(btn_Input2);
            Controls.Add(btn_Input1);
            Controls.Add(btn_Minus);
            Controls.Add(btn_Input6);
            Controls.Add(btn_Input5);
            Controls.Add(btn_Input4);
            Controls.Add(btn_Multiplication);
            Controls.Add(btn_Input9);
            Controls.Add(btn_Input8);
            Controls.Add(btn_Input7);
            Controls.Add(btn_Division);
            Controls.Add(btn_Del);
            Controls.Add(btn_C);
            Controls.Add(btn_CE);
            Controls.Add(txt_Cause);
            Controls.Add(lblName);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txt_Cause;
        private Button btn_CE;
        private Button btn_C;
        private Button btn_Del;
        private Button btn_Division;
        private Button btn_Input7;
        private Button btn_Input8;
        private Button btn_Input9;
        private Button btn_Multiplication;
        private Button btn_Input4;
        private Button btn_Input5;
        private Button btn_Input6;
        private Button btn_Minus;
        private Button btn_Input1;
        private Button btn_Input2;
        private Button btn_Input3;
        private Button btn_Plus;
        private Button btn_ChangeSign;
        private Button btn_Input0;
        private Button btn_InputPoint;
        private Button btn_InputEquals;
        private Label label1;
        private TextBox txt_Result;
    }
}

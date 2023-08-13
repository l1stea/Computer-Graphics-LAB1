namespace LAB1
{
    partial class Form1
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
            drawButton = new Button();
            fractalPicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)fractalPicture).BeginInit();
            SuspendLayout();
            // 
            // drawButton
            // 
            drawButton.Location = new Point(170, 415);
            drawButton.Name = "drawButton";
            drawButton.Size = new Size(85, 23);
            drawButton.TabIndex = 0;
            drawButton.Text = "Нарисовать";
            drawButton.UseVisualStyleBackColor = true;
            drawButton.Click += Draw_click;
            // 
            // fractalPicture
            // 
            fractalPicture.Location = new Point(12, 12);
            fractalPicture.Name = "fractalPicture";
            fractalPicture.Size = new Size(410, 397);
            fractalPicture.TabIndex = 1;
            fractalPicture.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 450);
            Controls.Add(fractalPicture);
            Controls.Add(drawButton);
            Name = "Form1";
            Text = "Фрактал Мандельброта";
            ((System.ComponentModel.ISupportInitialize)fractalPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button drawButton;
        private PictureBox fractalPicture;
    }
}
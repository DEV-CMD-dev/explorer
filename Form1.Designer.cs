namespace Explorer_app
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
            listView1 = new ListView();
            DirectoryForward = new Button();
            DirectoryTextBox = new TextBox();
            DirectoryBackward = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 397);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DirectoryForward
            // 
            DirectoryForward.Location = new Point(60, 13);
            DirectoryForward.Name = "DirectoryForward";
            DirectoryForward.Size = new Size(42, 23);
            DirectoryForward.TabIndex = 2;
            DirectoryForward.Text = "→";
            DirectoryForward.UseVisualStyleBackColor = true;
            DirectoryForward.Click += DirectoryForward_Click;
            // 
            // DirectoryTextBox
            // 
            DirectoryTextBox.Location = new Point(108, 13);
            DirectoryTextBox.Name = "DirectoryTextBox";
            DirectoryTextBox.Size = new Size(680, 23);
            DirectoryTextBox.TabIndex = 3;
            // 
            // DirectoryBackward
            // 
            DirectoryBackward.Location = new Point(12, 13);
            DirectoryBackward.Name = "DirectoryBackward";
            DirectoryBackward.Size = new Size(42, 23);
            DirectoryBackward.TabIndex = 4;
            DirectoryBackward.Text = "←";
            DirectoryBackward.UseVisualStyleBackColor = true;
            DirectoryBackward.Click += DirectoryBackward_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DirectoryBackward);
            Controls.Add(DirectoryTextBox);
            Controls.Add(DirectoryForward);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button DirectoryForward;
        private TextBox DirectoryTextBox;
        private Button DirectoryBackward;
    }
}

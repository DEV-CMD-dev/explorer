namespace Explorer_app
{
    partial class Explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            FileList = new ListView();
            DirectoryForward = new Button();
            DirectoryTextBox = new TextBox();
            DirectoryBackward = new Button();
            SuspendLayout();
            // 
            // FileList
            // 
            FileList.BackColor = SystemColors.Window;
            FileList.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FileList.LabelEdit = true;
            FileList.Location = new Point(12, 41);
            FileList.Name = "FileList";
            FileList.Size = new Size(776, 397);
            FileList.TabIndex = 0;
            FileList.UseCompatibleStateImageBehavior = false;
            FileList.View = View.Details;
            FileList.ItemActivate += GoToDirectory;
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
            // Explorer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DirectoryBackward);
            Controls.Add(DirectoryTextBox);
            Controls.Add(DirectoryForward);
            Controls.Add(FileList);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Explorer";
            Text = "Explorer v0.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView FileList;
        private Button DirectoryForward;
        private TextBox DirectoryTextBox;
        private Button DirectoryBackward;
    }
}

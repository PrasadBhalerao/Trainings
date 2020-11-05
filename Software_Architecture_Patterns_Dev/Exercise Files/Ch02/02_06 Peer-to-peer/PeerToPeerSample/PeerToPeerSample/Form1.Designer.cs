namespace PeerToPeerSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartCalculatingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartCalculatingButton
            // 
            this.StartCalculatingButton.Location = new System.Drawing.Point(12, 55);
            this.StartCalculatingButton.Name = "StartCalculatingButton";
            this.StartCalculatingButton.Size = new System.Drawing.Size(75, 23);
            this.StartCalculatingButton.TabIndex = 0;
            this.StartCalculatingButton.Text = "Start Calculating";
            this.StartCalculatingButton.UseVisualStyleBackColor = true;
            this.StartCalculatingButton.Click += new System.EventHandler(this.StartCalculatingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Node Name:";
            // 
            // NodeNameLabel
            // 
            this.NodeNameLabel.AutoSize = true;
            this.NodeNameLabel.Location = new System.Drawing.Point(95, 13);
            this.NodeNameLabel.Name = "NodeNameLabel";
            this.NodeNameLabel.Size = new System.Drawing.Size(0, 13);
            this.NodeNameLabel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NodeNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartCalculatingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartCalculatingButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NodeNameLabel;
    }
}


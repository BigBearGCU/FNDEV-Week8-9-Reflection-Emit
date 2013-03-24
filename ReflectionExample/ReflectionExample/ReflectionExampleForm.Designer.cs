namespace ReflectionExample
{
    partial class ReflectionExampleForm
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
            this.PluginComboBox = new System.Windows.Forms.ComboBox();
            this.PluginLabel = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PluginComboBox
            // 
            this.PluginComboBox.FormattingEnabled = true;
            this.PluginComboBox.Location = new System.Drawing.Point(16, 32);
            this.PluginComboBox.Name = "PluginComboBox";
            this.PluginComboBox.Size = new System.Drawing.Size(248, 21);
            this.PluginComboBox.TabIndex = 0;
            // 
            // PluginLabel
            // 
            this.PluginLabel.AutoSize = true;
            this.PluginLabel.Location = new System.Drawing.Point(16, 16);
            this.PluginLabel.Name = "PluginLabel";
            this.PluginLabel.Size = new System.Drawing.Size(41, 13);
            this.PluginLabel.TabIndex = 1;
            this.PluginLabel.Text = "Plugins";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(16, 64);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(104, 64);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ReflectionExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.PluginLabel);
            this.Controls.Add(this.PluginComboBox);
            this.Name = "ReflectionExampleForm";
            this.Text = "ReflectionExample";
            this.Load += new System.EventHandler(this.ReflectionExampleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PluginComboBox;
        private System.Windows.Forms.Label PluginLabel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button RefreshButton;

    }
}


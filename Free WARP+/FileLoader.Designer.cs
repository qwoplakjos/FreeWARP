namespace Free_WARP_
{
    partial class FileLoader
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
            this.httploadButton = new System.Windows.Forms.Button();
            this.socks4loadbutton = new System.Windows.Forms.Button();
            this.socks5loadbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // httploadButton
            // 
            this.httploadButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.httploadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.httploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.httploadButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.httploadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(106)))), ((int)(((byte)(104)))));
            this.httploadButton.Location = new System.Drawing.Point(8, 12);
            this.httploadButton.Name = "httploadButton";
            this.httploadButton.Size = new System.Drawing.Size(106, 22);
            this.httploadButton.TabIndex = 7;
            this.httploadButton.Text = "HTTP";
            this.httploadButton.UseVisualStyleBackColor = true;
            this.httploadButton.Click += new System.EventHandler(this.httploadButton_Click);
            // 
            // socks4loadbutton
            // 
            this.socks4loadbutton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.socks4loadbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.socks4loadbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.socks4loadbutton.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.socks4loadbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(106)))), ((int)(((byte)(104)))));
            this.socks4loadbutton.Location = new System.Drawing.Point(120, 12);
            this.socks4loadbutton.Name = "socks4loadbutton";
            this.socks4loadbutton.Size = new System.Drawing.Size(106, 22);
            this.socks4loadbutton.TabIndex = 8;
            this.socks4loadbutton.Text = "Socks4";
            this.socks4loadbutton.UseVisualStyleBackColor = true;
            this.socks4loadbutton.Click += new System.EventHandler(this.socks4loadbutton_Click);
            // 
            // socks5loadbutton
            // 
            this.socks5loadbutton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.socks5loadbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.socks5loadbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.socks5loadbutton.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.socks5loadbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(106)))), ((int)(((byte)(104)))));
            this.socks5loadbutton.Location = new System.Drawing.Point(232, 12);
            this.socks5loadbutton.Name = "socks5loadbutton";
            this.socks5loadbutton.Size = new System.Drawing.Size(106, 22);
            this.socks5loadbutton.TabIndex = 9;
            this.socks5loadbutton.Text = "Socks5";
            this.socks5loadbutton.UseVisualStyleBackColor = true;
            this.socks5loadbutton.Click += new System.EventHandler(this.socks5loadbutton_Click);
            // 
            // FileLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(346, 46);
            this.Controls.Add(this.socks5loadbutton);
            this.Controls.Add(this.socks4loadbutton);
            this.Controls.Add(this.httploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FileLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileLoader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button httploadButton;
        private System.Windows.Forms.Button socks4loadbutton;
        private System.Windows.Forms.Button socks5loadbutton;
    }
}
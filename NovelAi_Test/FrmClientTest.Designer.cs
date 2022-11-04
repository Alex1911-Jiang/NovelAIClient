namespace NovelAi_Test
{
    partial class FrmClientTest
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnWebUI = new System.Windows.Forms.Button();
            this.txbTags = new System.Windows.Forms.TextBox();
            this.btnNaifu = new System.Windows.Forms.Button();
            this.lblTags = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnWebUI
            // 
            this.btnWebUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWebUI.Location = new System.Drawing.Point(144, 566);
            this.btnWebUI.Name = "btnWebUI";
            this.btnWebUI.Size = new System.Drawing.Size(112, 34);
            this.btnWebUI.TabIndex = 1;
            this.btnWebUI.Text = "请求WebUI";
            this.btnWebUI.UseVisualStyleBackColor = true;
            this.btnWebUI.Click += new System.EventHandler(this.btnWebUI_Click);
            // 
            // txbTags
            // 
            this.txbTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTags.Location = new System.Drawing.Point(174, 530);
            this.txbTags.Name = "txbTags";
            this.txbTags.Size = new System.Drawing.Size(350, 30);
            this.txbTags.TabIndex = 2;
            this.txbTags.Text = "hatsune miku";
            // 
            // btnNaifu
            // 
            this.btnNaifu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNaifu.Location = new System.Drawing.Point(278, 566);
            this.btnNaifu.Name = "btnNaifu";
            this.btnNaifu.Size = new System.Drawing.Size(112, 34);
            this.btnNaifu.TabIndex = 3;
            this.btnNaifu.Text = "请求Naifu";
            this.btnNaifu.UseVisualStyleBackColor = true;
            this.btnNaifu.Click += new System.EventHandler(this.btnNaifu_Click);
            // 
            // lblTags
            // 
            this.lblTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(12, 533);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(156, 24);
            this.lblTags.TabIndex = 4;
            this.lblTags.Text = "Tags(以逗号分隔):";
            // 
            // FrmClientTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 609);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.btnNaifu);
            this.Controls.Add(this.txbTags);
            this.Controls.Add(this.btnWebUI);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmClientTest";
            this.Text = "示例程序";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnWebUI;
        private TextBox txbTags;
        private Button btnNaifu;
        private Label lblTags;
    }
}
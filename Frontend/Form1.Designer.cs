namespace DiseaseDetector
{
    partial class leafDisease
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(leafDisease));
            this.mobileNetV3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vGG19ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseDetectButton = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.logTerminal = new System.Windows.Forms.RichTextBox();
            this.chooseModelButton = new System.Windows.Forms.Button();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.liveDetectionButton = new System.Windows.Forms.Button();
            this.imageDetectionButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.startStopCamera = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobileNetV3ToolStripMenuItem
            // 
            this.mobileNetV3ToolStripMenuItem.Name = "mobileNetV3ToolStripMenuItem";
            this.mobileNetV3ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.mobileNetV3ToolStripMenuItem.Text = "Mobile Net V3";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vGG19ToolStripMenuItem,
            this.mobileNetV3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 48);
            // 
            // vGG19ToolStripMenuItem
            // 
            this.vGG19ToolStripMenuItem.Name = "vGG19ToolStripMenuItem";
            this.vGG19ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.vGG19ToolStripMenuItem.Text = "VGG19";
            // 
            // browseDetectButton
            // 
            this.browseDetectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.browseDetectButton.BackColor = System.Drawing.Color.DarkGray;
            this.browseDetectButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseDetectButton.ForeColor = System.Drawing.Color.Transparent;
            this.browseDetectButton.Location = new System.Drawing.Point(247, 246);
            this.browseDetectButton.Name = "browseDetectButton";
            this.browseDetectButton.Size = new System.Drawing.Size(144, 36);
            this.browseDetectButton.TabIndex = 0;
            this.browseDetectButton.Text = "Browse";
            this.browseDetectButton.UseVisualStyleBackColor = false;
            this.browseDetectButton.Click += new System.EventHandler(this.BrowsePredictButton_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.logTerminal);
            this.panel8.Location = new System.Drawing.Point(13, 288);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(831, 155);
            this.panel8.TabIndex = 1;
            // 
            // logTerminal
            // 
            this.logTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTerminal.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTerminal.Location = new System.Drawing.Point(11, 14);
            this.logTerminal.Name = "logTerminal";
            this.logTerminal.ReadOnly = true;
            this.logTerminal.Size = new System.Drawing.Size(807, 124);
            this.logTerminal.TabIndex = 0;
            this.logTerminal.Text = "";
            // 
            // chooseModelButton
            // 
            this.chooseModelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseModelButton.BackColor = System.Drawing.Color.DarkGray;
            this.chooseModelButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseModelButton.ForeColor = System.Drawing.Color.Transparent;
            this.chooseModelButton.Location = new System.Drawing.Point(21, 142);
            this.chooseModelButton.Name = "chooseModelButton";
            this.chooseModelButton.Size = new System.Drawing.Size(134, 36);
            this.chooseModelButton.TabIndex = 3;
            this.chooseModelButton.Text = "Choose Model";
            this.chooseModelButton.UseVisualStyleBackColor = false;
            // 
            // modelComboBox
            // 
            this.modelComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modelComboBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.modelComboBox.ForeColor = System.Drawing.Color.Black;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(11, 89);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(154, 21);
            this.modelComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Models Available";
            // 
            // removeImageButton
            // 
            this.removeImageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.removeImageButton.BackColor = System.Drawing.Color.DarkGray;
            this.removeImageButton.Enabled = false;
            this.removeImageButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeImageButton.ForeColor = System.Drawing.Color.Transparent;
            this.removeImageButton.Location = new System.Drawing.Point(464, 246);
            this.removeImageButton.Name = "removeImageButton";
            this.removeImageButton.Size = new System.Drawing.Size(131, 36);
            this.removeImageButton.TabIndex = 3;
            this.removeImageButton.Text = "Remove Image";
            this.removeImageButton.UseVisualStyleBackColor = false;
            this.removeImageButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.chooseModelButton);
            this.panel9.Controls.Add(this.modelComboBox);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(13, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(178, 233);
            this.panel9.TabIndex = 2;
            // 
            // liveDetectionButton
            // 
            this.liveDetectionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.liveDetectionButton.BackColor = System.Drawing.Color.DarkGray;
            this.liveDetectionButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveDetectionButton.ForeColor = System.Drawing.Color.Transparent;
            this.liveDetectionButton.Location = new System.Drawing.Point(34, 147);
            this.liveDetectionButton.Name = "liveDetectionButton";
            this.liveDetectionButton.Size = new System.Drawing.Size(134, 46);
            this.liveDetectionButton.TabIndex = 5;
            this.liveDetectionButton.Text = "Live Detection";
            this.liveDetectionButton.UseVisualStyleBackColor = false;
            this.liveDetectionButton.Click += new System.EventHandler(this.LiveDetectionClick);
            // 
            // imageDetectionButton
            // 
            this.imageDetectionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageDetectionButton.BackColor = System.Drawing.Color.DarkGray;
            this.imageDetectionButton.Enabled = false;
            this.imageDetectionButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageDetectionButton.ForeColor = System.Drawing.Color.Transparent;
            this.imageDetectionButton.Location = new System.Drawing.Point(34, 77);
            this.imageDetectionButton.Name = "imageDetectionButton";
            this.imageDetectionButton.Size = new System.Drawing.Size(134, 47);
            this.imageDetectionButton.TabIndex = 4;
            this.imageDetectionButton.Text = "Image Detection";
            this.imageDetectionButton.UseVisualStyleBackColor = false;
            this.imageDetectionButton.Click += new System.EventHandler(this.ImageDetectionClick);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Toggle detection";
            // 
            // startStopCamera
            // 
            this.startStopCamera.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startStopCamera.BackColor = System.Drawing.Color.DarkGray;
            this.startStopCamera.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopCamera.ForeColor = System.Drawing.Color.Transparent;
            this.startStopCamera.Location = new System.Drawing.Point(360, 246);
            this.startStopCamera.Name = "startStopCamera";
            this.startStopCamera.Size = new System.Drawing.Size(144, 36);
            this.startStopCamera.TabIndex = 5;
            this.startStopCamera.Text = "Start Camera";
            this.startStopCamera.UseVisualStyleBackColor = false;
            this.startStopCamera.Visible = false;
            this.startStopCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.startStopCamera);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.removeImageButton);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.browseDetectButton);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.imagePanel);
            this.panel6.Location = new System.Drawing.Point(28, 88);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(855, 455);
            this.panel6.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.liveDetectionButton);
            this.panel7.Controls.Add(this.imageDetectionButton);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(647, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(196, 232);
            this.panel7.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(74, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "mode";
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.Location = new System.Drawing.Point(208, 6);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(430, 234);
            this.imagePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(191, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plant Disease Detection System";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(22, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(866, 46);
            this.panel5.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 575);
            this.panel1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(0, 549);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(910, 26);
            this.panel4.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.panel2.Location = new System.Drawing.Point(899, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 575);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(910, 20);
            this.panel3.TabIndex = 8;
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.Color.Gray;
            this.infoPanel.Controls.Add(this.labelVersion);
            this.infoPanel.Controls.Add(this.labelPublisher);
            this.infoPanel.Location = new System.Drawing.Point(76, 549);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(767, 20);
            this.infoPanel.TabIndex = 1;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.Cyan;
            this.labelVersion.Location = new System.Drawing.Point(654, 2);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(105, 15);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Version: 0.0.1";
            // 
            // labelPublisher
            // 
            this.labelPublisher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublisher.ForeColor = System.Drawing.Color.Cyan;
            this.labelPublisher.Location = new System.Drawing.Point(6, 3);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(140, 15);
            this.labelPublisher.TabIndex = 0;
            this.labelPublisher.Text = "Publisher: CSE Dept";
            // 
            // leafDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 575);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "leafDisease";
            this.Text = "Leaf Disease Detector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mobileNetV3ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vGG19ToolStripMenuItem;
        private System.Windows.Forms.Button browseDetectButton;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button chooseModelButton;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button liveDetectionButton;
        private System.Windows.Forms.Button imageDetectionButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startStopCamera;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox logTerminal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelPublisher;
    }
}


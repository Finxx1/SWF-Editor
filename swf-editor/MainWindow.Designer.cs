namespace swf_editor {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SCTree = new System.Windows.Forms.TreeView();
            this.SCProperties = new System.Windows.Forms.PropertyGrid();
            this.SCControls = new System.Windows.Forms.Panel();
            this.Properties = new System.Windows.Forms.SplitContainer();
            this.FramePanel = new System.Windows.Forms.Panel();
            this.FrameDecrease = new System.Windows.Forms.Button();
            this.FrameIncrease = new System.Windows.Forms.Button();
            this.FrameDisplay = new System.Windows.Forms.TextBox();
            this.SCControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Properties)).BeginInit();
            this.Properties.Panel1.SuspendLayout();
            this.Properties.Panel2.SuspendLayout();
            this.Properties.SuspendLayout();
            this.FramePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SCTree
            // 
            this.SCTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCTree.Location = new System.Drawing.Point(0, 0);
            this.SCTree.Name = "SCTree";
            this.SCTree.Size = new System.Drawing.Size(138, 170);
            this.SCTree.TabIndex = 4;
            // 
            // SCProperties
            // 
            this.SCProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCProperties.Location = new System.Drawing.Point(0, 0);
            this.SCProperties.Name = "SCProperties";
            this.SCProperties.Size = new System.Drawing.Size(138, 222);
            this.SCProperties.TabIndex = 5;
            // 
            // SCControls
            // 
            this.SCControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCControls.Controls.Add(this.Properties);
            this.SCControls.Controls.Add(this.FramePanel);
            this.SCControls.Location = new System.Drawing.Point(642, 12);
            this.SCControls.Name = "SCControls";
            this.SCControls.Size = new System.Drawing.Size(146, 432);
            this.SCControls.TabIndex = 6;
            // 
            // Properties
            // 
            this.Properties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Properties.Location = new System.Drawing.Point(4, 33);
            this.Properties.Name = "Properties";
            this.Properties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Properties.Panel1
            // 
            this.Properties.Panel1.Controls.Add(this.SCTree);
            // 
            // Properties.Panel2
            // 
            this.Properties.Panel2.Controls.Add(this.SCProperties);
            this.Properties.Size = new System.Drawing.Size(138, 396);
            this.Properties.SplitterDistance = 170;
            this.Properties.TabIndex = 8;
            // 
            // FramePanel
            // 
            this.FramePanel.Controls.Add(this.FrameDecrease);
            this.FramePanel.Controls.Add(this.FrameIncrease);
            this.FramePanel.Controls.Add(this.FrameDisplay);
            this.FramePanel.Location = new System.Drawing.Point(4, 3);
            this.FramePanel.Name = "FramePanel";
            this.FramePanel.Size = new System.Drawing.Size(138, 26);
            this.FramePanel.TabIndex = 7;
            // 
            // FrameDecrease
            // 
            this.FrameDecrease.Location = new System.Drawing.Point(3, 3);
            this.FrameDecrease.Name = "FrameDecrease";
            this.FrameDecrease.Size = new System.Drawing.Size(20, 20);
            this.FrameDecrease.TabIndex = 1;
            this.FrameDecrease.Text = "-";
            this.FrameDecrease.UseVisualStyleBackColor = true;
            this.FrameDecrease.Click += new System.EventHandler(this.FrameDecrease_Click);
            // 
            // FrameIncrease
            // 
            this.FrameIncrease.Location = new System.Drawing.Point(115, 3);
            this.FrameIncrease.Name = "FrameIncrease";
            this.FrameIncrease.Size = new System.Drawing.Size(20, 20);
            this.FrameIncrease.TabIndex = 2;
            this.FrameIncrease.Text = "+";
            this.FrameIncrease.UseVisualStyleBackColor = true;
            this.FrameIncrease.Click += new System.EventHandler(this.FrameIncrease_Click);
            // 
            // FrameDisplay
            // 
            this.FrameDisplay.Location = new System.Drawing.Point(29, 3);
            this.FrameDisplay.Name = "FrameDisplay";
            this.FrameDisplay.Size = new System.Drawing.Size(80, 20);
            this.FrameDisplay.TabIndex = 3;
            this.FrameDisplay.Text = "0";
            this.FrameDisplay.TextChanged += new System.EventHandler(this.FrameDisplay_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.SCControls);
            this.Name = "MainWindow";
            this.Text = "SWF Editor";
            this.SCControls.ResumeLayout(false);
            this.Properties.Panel1.ResumeLayout(false);
            this.Properties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Properties)).EndInit();
            this.Properties.ResumeLayout(false);
            this.FramePanel.ResumeLayout(false);
            this.FramePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView SCTree;
        private System.Windows.Forms.PropertyGrid SCProperties;
        private System.Windows.Forms.Panel SCControls;
        private System.Windows.Forms.Panel FramePanel;
        private System.Windows.Forms.Button FrameDecrease;
        private System.Windows.Forms.Button FrameIncrease;
        private System.Windows.Forms.TextBox FrameDisplay;
        private System.Windows.Forms.SplitContainer Properties;
    }
}


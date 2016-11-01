namespace OutlineListDisplay
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.AddItemToSelectedButton = new System.Windows.Forms.Button();
            this.AddListToTreeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RemoveSelected = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReplaceTreeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTreeView
            // 
            this.myTreeView.CheckBoxes = true;
            this.myTreeView.FullRowSelect = true;
            this.myTreeView.Location = new System.Drawing.Point(27, 31);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.ShowNodeToolTips = true;
            this.myTreeView.Size = new System.Drawing.Size(513, 596);
            this.myTreeView.TabIndex = 0;
            this.myTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterCheck);
            this.myTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterSelect);
            // 
            // AddItemToSelectedButton
            // 
            this.AddItemToSelectedButton.Location = new System.Drawing.Point(8, 28);
            this.AddItemToSelectedButton.Name = "AddItemToSelectedButton";
            this.AddItemToSelectedButton.Size = new System.Drawing.Size(107, 33);
            this.AddItemToSelectedButton.TabIndex = 1;
            this.AddItemToSelectedButton.Text = "Add Item";
            this.AddItemToSelectedButton.UseVisualStyleBackColor = true;
            this.AddItemToSelectedButton.Click += new System.EventHandler(this.AddItemToSelectedButton_Click);
            // 
            // AddListToTreeButton
            // 
            this.AddListToTreeButton.Location = new System.Drawing.Point(699, 329);
            this.AddListToTreeButton.Name = "AddListToTreeButton";
            this.AddListToTreeButton.Size = new System.Drawing.Size(124, 29);
            this.AddListToTreeButton.TabIndex = 2;
            this.AddListToTreeButton.Text = "Add to Tree";
            this.AddListToTreeButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Location = new System.Drawing.Point(561, 172);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 151);
            this.textBox1.TabIndex = 3;
            // 
            // RemoveSelected
            // 
            this.RemoveSelected.Location = new System.Drawing.Point(6, 67);
            this.RemoveSelected.Name = "RemoveSelected";
            this.RemoveSelected.Size = new System.Drawing.Size(107, 33);
            this.RemoveSelected.TabIndex = 5;
            this.RemoveSelected.Text = "Remove";
            this.RemoveSelected.UseVisualStyleBackColor = true;
            this.RemoveSelected.Click += new System.EventHandler(this.RemoveSelected_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddItemToSelectedButton);
            this.groupBox1.Controls.Add(this.RemoveSelected);
            this.groupBox1.Location = new System.Drawing.Point(561, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 109);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Item";
            // 
            // ReplaceTreeButton
            // 
            this.ReplaceTreeButton.Location = new System.Drawing.Point(561, 329);
            this.ReplaceTreeButton.Name = "ReplaceTreeButton";
            this.ReplaceTreeButton.Size = new System.Drawing.Size(124, 29);
            this.ReplaceTreeButton.TabIndex = 4;
            this.ReplaceTreeButton.Text = "Replace Tree";
            this.ReplaceTreeButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 644);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(846, 24);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 18);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(846, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 668);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ReplaceTreeButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AddListToTreeButton);
            this.Controls.Add(this.myTreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TreeView myTreeView;
        private System.Windows.Forms.Button AddItemToSelectedButton;
        private System.Windows.Forms.Button AddListToTreeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReplaceTreeButton;
        private System.Windows.Forms.Button RemoveSelected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}


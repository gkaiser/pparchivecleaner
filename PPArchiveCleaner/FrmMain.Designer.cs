namespace PPArchiveCleaner
{
	partial class FrmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.txtBase = new System.Windows.Forms.TextBox();
			this.btBrowse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btClean = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.nudOlderThan = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.txtExtensions = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.nudOlderThan)).BeginInit();
			this.SuspendLayout();
			// 
			// txtBase
			// 
			this.txtBase.Location = new System.Drawing.Point(125, 12);
			this.txtBase.Name = "txtBase";
			this.txtBase.ReadOnly = true;
			this.txtBase.Size = new System.Drawing.Size(210, 20);
			this.txtBase.TabIndex = 0;
			// 
			// btBrowse
			// 
			this.btBrowse.Image = global::PPArchiveCleaner.Properties.Resources.BtnBrowse;
			this.btBrowse.Location = new System.Drawing.Point(341, 10);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(23, 23);
			this.btBrowse.TabIndex = 1;
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Base Data Folder";
			// 
			// btClean
			// 
			this.btClean.Location = new System.Drawing.Point(148, 90);
			this.btClean.Name = "btClean";
			this.btClean.Size = new System.Drawing.Size(75, 23);
			this.btClean.TabIndex = 3;
			this.btClean.Text = "Clean";
			this.btClean.UseVisualStyleBackColor = true;
			this.btClean.Click += new System.EventHandler(this.btClean_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(209, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Archive Files Older Than                 Months";
			// 
			// nudOlderThan
			// 
			this.nudOlderThan.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudOlderThan.Location = new System.Drawing.Point(125, 38);
			this.nudOlderThan.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this.nudOlderThan.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudOlderThan.Name = "nudOlderThan";
			this.nudOlderThan.Size = new System.Drawing.Size(44, 20);
			this.nudOlderThan.TabIndex = 5;
			this.nudOlderThan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudOlderThan.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Extensions to Include";
			// 
			// txtExtensions
			// 
			this.txtExtensions.Location = new System.Drawing.Point(125, 64);
			this.txtExtensions.Name = "txtExtensions";
			this.txtExtensions.Size = new System.Drawing.Size(239, 20);
			this.txtExtensions.TabIndex = 7;
			this.txtExtensions.Text = ".dat .tmp .txt";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 119);
			this.Controls.Add(this.txtExtensions);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nudOlderThan);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btClean);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btBrowse);
			this.Controls.Add(this.txtBase);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PP Archive Data Cleaner";
			((System.ComponentModel.ISupportInitialize)(this.nudOlderThan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtBase;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btClean;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudOlderThan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtExtensions;
	}
}


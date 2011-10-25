namespace PPArchiveCleaner
{
	partial class FrmCleaning
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
			this.prgFolders = new System.Windows.Forms.ProgressBar();
			this.prgCurrFolder = new System.Windows.Forms.ProgressBar();
			this.lblCurrFiles = new System.Windows.Forms.Label();
			this.bwClean = new System.ComponentModel.BackgroundWorker();
			this.lblCurrFolder = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// prgFolders
			// 
			this.prgFolders.Location = new System.Drawing.Point(6, 6);
			this.prgFolders.Name = "prgFolders";
			this.prgFolders.Size = new System.Drawing.Size(436, 23);
			this.prgFolders.TabIndex = 0;
			// 
			// prgCurrFolder
			// 
			this.prgCurrFolder.Location = new System.Drawing.Point(6, 53);
			this.prgCurrFolder.Name = "prgCurrFolder";
			this.prgCurrFolder.Size = new System.Drawing.Size(436, 23);
			this.prgCurrFolder.TabIndex = 1;
			// 
			// lblCurrFiles
			// 
			this.lblCurrFiles.AutoSize = true;
			this.lblCurrFiles.Location = new System.Drawing.Point(7, 79);
			this.lblCurrFiles.Name = "lblCurrFiles";
			this.lblCurrFiles.Size = new System.Drawing.Size(52, 13);
			this.lblCurrFiles.TabIndex = 2;
			this.lblCurrFiles.Text = "Waiting...";
			// 
			// bwClean
			// 
			this.bwClean.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwClean_DoWork);
			this.bwClean.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwClean_RunWorkerCompleted);
			// 
			// lblCurrFolder
			// 
			this.lblCurrFolder.AutoSize = true;
			this.lblCurrFolder.Location = new System.Drawing.Point(7, 32);
			this.lblCurrFolder.Name = "lblCurrFolder";
			this.lblCurrFolder.Size = new System.Drawing.Size(52, 13);
			this.lblCurrFolder.TabIndex = 3;
			this.lblCurrFolder.Text = "Waiting...";
			// 
			// FrmCleaning
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 102);
			this.Controls.Add(this.lblCurrFolder);
			this.Controls.Add(this.lblCurrFiles);
			this.Controls.Add(this.prgCurrFolder);
			this.Controls.Add(this.prgFolders);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmCleaning";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cleaning";
			this.Load += new System.EventHandler(this.FrmCleaning_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgFolders;
		private System.Windows.Forms.ProgressBar prgCurrFolder;
		private System.Windows.Forms.Label lblCurrFiles;
		private System.ComponentModel.BackgroundWorker bwClean;
		private System.Windows.Forms.Label lblCurrFolder;
	}
}
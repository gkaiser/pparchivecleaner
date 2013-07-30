using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PPArchiveCleaner
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
		}

		private void btBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbdTemp = new FolderBrowserDialog();

			if (fbdTemp.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
				return;

			txtBase.Text = fbdTemp.SelectedPath;
		}

		private void btClean_Click(object sender, EventArgs e)
		{
			FrmCleaning frmClean = new FrmCleaning(
				txtBase.Text, 
				Convert.ToInt32(nudOlderThan.Value), 
				new List<string>(txtExtensions.Text.Split(' ')));

			frmClean.ShowDialog(this);
		}
    
	}
}

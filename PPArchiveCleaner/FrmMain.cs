using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
			FrmCleaning frmClean = new FrmCleaning(txtBase.Text, Convert.ToInt32(nudOlderThan.Value));

			frmClean.ShowDialog(this);
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.BZip2;

namespace PPArchiveCleaner
{
	public partial class FrmCleaning : Form
	{
		private string _baseDir;
		private int _olderThan = 0, _totCt = 0, _cleanCt = 0;
		private List<string> _lstExtensionsToInclude = new List<string>(new string[] { ".dat", ".tmp", ".txt" });

		public FrmCleaning(string BaseDir, int OlderThan, List<string> includedExtensions)
		{
			InitializeComponent();

			_baseDir = BaseDir;
			_olderThan = OlderThan;
			_lstExtensionsToInclude = includedExtensions;
		}

		private void FrmCleaning_Load(object sender, EventArgs e)
		{
			this.Visible = true;
			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			bwClean.RunWorkerAsync();
		}

		private void bwClean_DoWork(object sender, DoWorkEventArgs e)
		{
			FileInfo fiDatFile;
			TarArchive tArch;
			Stream sTar = null, sBzip = null;

			string[] dataDirs = Directory.GetDirectories(_baseDir);

			this.Invoke((MethodInvoker)delegate() { prgFolders.Maximum = dataDirs.Length; });

			foreach (string dataDir in dataDirs)
			{
				this.Invoke((MethodInvoker) delegate() { lblCurrFolder.Text = "Cleaning " + dataDir.Substring(dataDir.LastIndexOf(Path.DirectorySeparatorChar) + 1); });

				Directory.SetCurrentDirectory(dataDir);
				string[] dataFiles = Directory.GetFiles(dataDir, "*", SearchOption.AllDirectories);
				string tarFile = Path.Combine(dataDir, DateTime.Today.ToString("yyyyMMdd") + ".tar");
				string bzFile = tarFile + ".bz2";
				string fileExt = "";

				_totCt += dataFiles.Length;
				sTar = new FileStream(tarFile, FileMode.Create, FileAccess.ReadWrite);
				tArch = TarArchive.CreateOutputTarArchive(sTar);

				for (int i = 0; i < dataFiles.Length; i++)
				{
					fileExt = Path.GetExtension(dataFiles[i]).ToLowerInvariant();

					if (!string.IsNullOrEmpty(fileExt) && !_lstExtensionsToInclude.Contains(fileExt))
						continue;

					fiDatFile = new FileInfo(dataFiles[i]);

					if (fiDatFile.CreationTime < DateTime.Today.AddMonths(-1 * _olderThan))
					{
						try 
						{ 
							tArch.WriteEntry(TarEntry.CreateEntryFromFile(dataFiles[i].Replace(dataDir + "\\", "")), false);
							File.Delete(dataFiles[i]);
							_cleanCt++;
						}
						catch { }
					}

					this.Invoke((MethodInvoker)
						delegate() 
						{
							lblCurrFiles.Text = "Cleaning... (" + i.ToString() + " of " + dataFiles.Length.ToString() + ")";
							prgCurrFolder.Value = this.GetPercent(i, dataFiles.Length); 
							Application.DoEvents(); 
						});
				}

				this.Invoke((MethodInvoker)
					delegate() 
					{
						lblCurrFiles.Text = "Compressing...";
						prgCurrFolder.Style = ProgressBarStyle.Marquee;
					});

				sTar.Seek(0, SeekOrigin.Begin);
				sBzip = new FileStream(bzFile, FileMode.Create, FileAccess.ReadWrite);

				BZip2.Compress(sTar, sBzip, true, 4096);
				File.Delete(tarFile);

				this.Invoke((MethodInvoker)
					delegate()
					{
						prgCurrFolder.Style = ProgressBarStyle.Blocks;
						prgFolders.Value++;
						Application.DoEvents();
					});
			}
		}

		private void bwClean_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			MessageBox.Show("Done! Cleaned " + _cleanCt.ToString() + " of " + _totCt + ".");
			this.Close();
		}

		private int GetPercent(int Num, int Dom)
		{
			float fNum = (float)Num;
			float fDom = (float)Dom;

			return Convert.ToInt32((fNum / fDom) * 100f);
		}

	}
}

using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.BZip2;

namespace PPArchiveCleaner
{
	public partial class FrmCleaning : Form
	{
		private string BaseDir;
		private int OlderThan = 0, TotalFilesCount = 0, CleanedFilesCount = 0;
		private List<string> ExtensionsToInclude = new List<string>(new string[] { ".dat", ".tmp", ".txt" });

		public FrmCleaning(string baseDir, int olderThan, List<string> includedExtensions)
		{
			InitializeComponent();

			this.BaseDir = baseDir;
			this.OlderThan = olderThan;
			this.ExtensionsToInclude = includedExtensions;
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
			TarArchive tArch;
			Stream sTar = null, sBzip = null;
      string archDir = this.BaseDir + "ARCHIVE\\";

      if (!Directory.Exists(archDir))
        Directory.CreateDirectory(archDir);

			string[] dataDirs = Directory.GetDirectories(this.BaseDir);

			this.Invoke((MethodInvoker)delegate() { prgFolders.Maximum = dataDirs.Length; });

			foreach (string dataDir in dataDirs)
			{
        if (dataDir.EndsWith("\\ARCHIVE"))
          continue;

        string ppDataType = dataDir.Substring(dataDir.LastIndexOf(Path.DirectorySeparatorChar) + 1);

				this.Invoke((MethodInvoker)delegate() { lblCurrFolder.Text = "Cleaning " + ppDataType; });

				Directory.SetCurrentDirectory(dataDir);
        string[] dataFiles = Directory.GetFiles(dataDir, "*", SearchOption.AllDirectories);
				string tarFile = archDir + ppDataType.ToUpper() + "-" + DateTime.Today.ToString("yyyyMMdd") + ".tar";
				string bzFile = tarFile + ".bz2";
				string fileExt = "";
        FileInfo fiDatFile = null;

				this.TotalFilesCount += dataFiles.Length;
				
        sTar = new FileStream(tarFile, FileMode.Create, FileAccess.ReadWrite);
				tArch = TarArchive.CreateOutputTarArchive(sTar);

				for (int i = 0; i < dataFiles.Length; i++)
				{
					fileExt = Path.GetExtension(dataFiles[i]).ToLowerInvariant();

					if (string.IsNullOrEmpty(fileExt) || !ExtensionsToInclude.Contains(fileExt))
						continue;

					fiDatFile = new FileInfo(dataFiles[i]);

					if (fiDatFile.CreationTime < DateTime.Today.AddMonths(-1 * this.OlderThan))
					{
						try 
						{ 
							tArch.WriteEntry(TarEntry.CreateEntryFromFile(dataFiles[i].Replace(dataDir + "\\", "")), false);
							File.Delete(dataFiles[i]);
							CleanedFilesCount++;
						}
						catch { }
					}

					this.Invoke((MethodInvoker)
						delegate() 
						{
							lblCurrFiles.Text = "Cleaning file " + i.ToString() + " of " + dataFiles.Length.ToString() + "...";
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
			MessageBox.Show("Done! Cleaned " + this.CleanedFilesCount.ToString() + " of " + this.TotalFilesCount + ".");
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

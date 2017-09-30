using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using DCCG.WRobo.HtmlParser;
using DCCG.WRobo.BusinessLogic;
using DCCG.WRobo.BusinessData;

namespace DCCG.WRobo.UIComponents
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class TestMainForm : System.Windows.Forms.Form
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button btLinks;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Button btImages;
		private System.Windows.Forms.PropertyGrid grdProperties;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSaveAs;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TreeView tvwDOM;
		private System.Windows.Forms.TextBox tbUrl;
		private System.Windows.Forms.Label lbUrl;
		private System.Windows.Forms.Button btTest;

		// Root document of HTML-DOM-Tree
		HtmlDocument mRootDocument = null;

		public TestMainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.btLinks = new System.Windows.Forms.Button();
			this.btImages = new System.Windows.Forms.Button();
			this.grdProperties = new System.Windows.Forms.PropertyGrid();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.tvwDOM = new System.Windows.Forms.TreeView();
			this.tbUrl = new System.Windows.Forms.TextBox();
			this.lbUrl = new System.Windows.Forms.Label();
			this.btTest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbOutput
			// 
			this.tbOutput.AcceptsReturn = true;
			this.tbOutput.AcceptsTab = true;
			this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbOutput.Location = new System.Drawing.Point(16, 400);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbOutput.Size = new System.Drawing.Size(856, 472);
			this.tbOutput.TabIndex = 3;
			this.tbOutput.Text = "";
			// 
			// btLinks
			// 
			this.btLinks.Location = new System.Drawing.Point(16, 368);
			this.btLinks.Name = "btLinks";
			this.btLinks.TabIndex = 4;
			this.btLinks.Text = "Links";
			this.btLinks.Click += new System.EventHandler(this.btLinks_Click);
			// 
			// btImages
			// 
			this.btImages.Location = new System.Drawing.Point(96, 368);
			this.btImages.Name = "btImages";
			this.btImages.TabIndex = 5;
			this.btImages.Text = "ImagesSrcs";
			this.btImages.Click += new System.EventHandler(this.btImages_Click);
			// 
			// grdProperties
			// 
			this.grdProperties.CommandsVisibleIfAvailable = true;
			this.grdProperties.LargeButtons = false;
			this.grdProperties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.grdProperties.Location = new System.Drawing.Point(448, 32);
			this.grdProperties.Name = "grdProperties";
			this.grdProperties.Size = new System.Drawing.Size(424, 360);
			this.grdProperties.TabIndex = 2;
			this.grdProperties.Text = "PropertyGrid1";
			this.grdProperties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.grdProperties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem2});
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemOpen,
																					  this.menuItemSaveAs,
																					  this.menuItem3,
																					  this.menuItemExit});
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.menuItem2.Text = "&File";
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItemOpen.Text = "Open";
			this.menuItemOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// menuItemSaveAs
			// 
			this.menuItemSaveAs.Index = 1;
			this.menuItemSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItemSaveAs.Text = "SaveAs";
			this.menuItemSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 3;
			this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItemExit.Text = "Exit";
			this.menuItemExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = -1;
			this.menuItemFile.Text = "File";
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = -1;
			this.menuItemHelp.Text = "Help";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = -1;
			this.menuItem1.Text = "";
			// 
			// tvwDOM
			// 
			this.tvwDOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvwDOM.ImageIndex = -1;
			this.tvwDOM.Location = new System.Drawing.Point(16, 32);
			this.tvwDOM.Name = "tvwDOM";
			this.tvwDOM.SelectedImageIndex = -1;
			this.tvwDOM.Size = new System.Drawing.Size(424, 328);
			this.tvwDOM.TabIndex = 6;
			this.tvwDOM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDOM_AfterSelect);
			// 
			// tbUrl
			// 
			this.tbUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbUrl.Location = new System.Drawing.Point(16, 8);
			this.tbUrl.Name = "tbUrl";
			this.tbUrl.Size = new System.Drawing.Size(648, 20);
			this.tbUrl.TabIndex = 7;
			this.tbUrl.Text = "http://intra.daimlerchrysler.com/intra-mcgm/0,,0-362-168238-49-0-0-0-0-0-0-1-3475" +
				"-0-0-0-0-0-0-0-0,00.html";
			this.tbUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUrl_KeyDown);
			// 
			// lbUrl
			// 
			this.lbUrl.Location = new System.Drawing.Point(672, 8);
			this.lbUrl.Name = "lbUrl";
			this.lbUrl.Size = new System.Drawing.Size(24, 20);
			this.lbUrl.TabIndex = 8;
			this.lbUrl.Text = "Url";
			this.lbUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btTest
			// 
			this.btTest.Location = new System.Drawing.Point(184, 368);
			this.btTest.Name = "btTest";
			this.btTest.TabIndex = 9;
			this.btTest.Text = "Test";
			this.btTest.Click += new System.EventHandler(this.btTest_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(888, 889);
			this.Controls.Add(this.btTest);
			this.Controls.Add(this.lbUrl);
			this.Controls.Add(this.tbUrl);
			this.Controls.Add(this.tvwDOM);
			this.Controls.Add(this.btImages);
			this.Controls.Add(this.btLinks);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.grdProperties);
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "C2C WebCrawler 0.1beta";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TestMainForm());
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btOpen_Click(object sender, System.EventArgs e)
		{
		    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					System.IO.StreamReader sr = System.IO.File.OpenText(openFileDialog.FileName);
					string html = sr.ReadToEnd();
					sr.Close();
					ProcessHTML(html);
				}
				catch (Exception ex)
				{
					// TODO: Logging
					String msg = ex.Message;

					MessageBox.Show("Sorry, I couldn't open that file for some reason.. try another one!");						
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="html"></param>
		private void ProcessHTML(string html)
		{

			// Clear the treeview
			tvwDOM.Nodes.Clear();

			// Create an HtmlDocument (which parses the html)
			mRootDocument = HtmlDocument.Create(html, false);

			// Populate the treeview with the document nodes
			BuildTree(mRootDocument.Nodes, tvwDOM.Nodes);
		
		}

		/// <summary>
		/// Build the tree DOM
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="treeNodes"></param>
		private void BuildTree(HtmlNodeCollection nodes, TreeNodeCollection treeNodes)
		{
			foreach(HtmlNode node in nodes)
			{
				TreeNode treeNode = new TreeNode(node.ToString());
				treeNode.Tag = node;
				treeNodes.Add(treeNode);
				if (node.GetType() == typeof(HtmlElement))
				{
					treeNode.SelectedImageIndex = 0;
					treeNode.ImageIndex = 0;
					this.BuildTree(((HtmlElement)node).Nodes, treeNode.Nodes);
				}
				else
				{
					treeNode.Text = "(text)";
					treeNode.ImageIndex = 1;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwDOM_AfterSelect(object sender, TreeViewEventArgs e)
		{
			// use Typeof to determine its type, and then cast it to either HtmlText or
			// HtmlElement. That way, you could present each of the attributes in a 
			// properties control, for example.

			HtmlNode node = (HtmlNode)tvwDOM.SelectedNode.Tag;
			tbOutput.Text = node.HTML;
			grdProperties.SelectedObject = node;
			grdProperties.Text = node.GetType().ToString();
		}

		/// <summary>
		/// Save the htmlk file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btSaveAs_Click(object sender, System.EventArgs e)
		{
			   
			if (mRootDocument == null)
				return;

			System.IO.StreamWriter sw = null;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					sw = System.IO.File.CreateText(saveFileDialog.FileName);
				
					if (saveFileDialog.FilterIndex == 0)
					{
						sw.Write(mRootDocument.HTML);
					}
					else
					{
						sw.Write(mRootDocument.XHTML);
					}
				}					
				catch (Exception ex)
				{
					// TODO: Logging
					String msg = ex.Message;

					MessageBox.Show("Sorry, I couldn't save that file for some reason.. try another one!");						
				}
				finally
				{
					if (sw != null)
						sw.Close();
				}
			}
		
		}
		/// <summary>
		/// Find all links
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btLinks_Click(object sender, System.EventArgs e)
		{
			tbOutput.Text = "";

			if (mRootDocument == null)
				return;

			HtmlNodeCollection nodes = mRootDocument.Nodes.FindByName("a");
			foreach(HtmlNode node in nodes)
			{
				tbOutput.Text += node.ToString() + "\r\n";
			}
		
		}

		private void btImages_Click(object sender, System.EventArgs e)
		{
			tbOutput.Text = "";

			if (mRootDocument == null)
				return;

			HtmlNodeCollection nodes = mRootDocument.Nodes.FindByName("img");
			foreach(HtmlNode node in nodes)
			{
				if (node.GetType() == typeof(HtmlElement))
				{
					HtmlElement elem = (HtmlElement)node;
					HtmlAttribute attribute = elem.Attributes.FindByName("src");
					if (attribute != null)
					{
						string url = attribute.Value;
						if (!url.ToLower().TrimStart().StartsWith("http"))
						{
							tbOutput.Text += url + "\r\n";
						}
					}
					
				}				
			}
		}

		private void ShowResponseHeader(WebResponse resp)
		{
			// Display each header and it's key , associated with the response object.
			tbOutput.Text = "";
			for (int i=0; i < resp.Headers.Count; ++i)  
			{
				tbOutput.Text += String.Format("\r\nHeader Name:{0}, Header value :{1}", resp.Headers.Keys[i], resp.Headers[i]);
			}
			tbOutput.Text += "\r\n";
		}

		private void tbUrl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					WebRequest req = WebRequest.Create(tbUrl.Text);
					WebResponse resp = req.GetResponse();
					
					ShowResponseHeader(resp);

					System.IO.Stream stream = resp.GetResponseStream();
					System.IO.StreamReader sr = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8);
					string html = sr.ReadToEnd();
					sr.Close();
					ProcessHTML(html);
				}
				catch (Exception ex)
				{
					// TODO: Logging
					String msg = ex.Message;

					MessageBox.Show("Sorry, couldn't request {0} try another one!", tbUrl.Text);						
				}
			}
		}

		private void btTest_Click(object sender, System.EventArgs e)
		{
			MyApplication app = MyApplication.GetInstance();
			string url = @"http://intra.daimlerchrysler.com/intra-mcgm/0,,0-362-168238-49-0-0-0-0-0-0-1-3475-0-0-0-0-0-0-0-0,00.html";
			WorkItem wi = new WorkItem();
			wi.DownloadUrl = url;
			wi.ActionType = WorkItemActionType.DownloadWebSite;
			wi.LokalFilename = @"c:\temp\test.html";
			Worker worker = new Worker(wi, app);	
			worker.DoWork();

			/*
			string strBaseUrl = "http://intra.daimlerchrysler.com/intra-mcgm/";
			String strLink = "javascript:openLink('0-362-168238-49-0-0-0-0-0-0-1-3475-0-0-0-0-0-0-0-0','3','co','width=100');"; 
			
			LinkConverter lc = new LinkConverter(strLink, strBaseUrl);
			tbOutput.Text += lc.ToString();

			if (lc.IsOpenLink && lc.ShouldConvertToLokal)
			{
				tbOutput.Text += "\r\n" + lc.GetLokalLink();
				tbOutput.Text += "\r\n" + lc.GetLinkWithoutScript();
			}
			Uri uri = new Uri(strBaseUrl);
			tbOutput.Text += "\r\nHost:" + uri.Host;
			tbOutput.Text += "\r\nScheme:" + uri.Scheme;
			tbOutput.Text += "\r\nLocalPath:" + uri.LocalPath;
			tbOutput.Text += "\r\nAbsoluteUri:" + uri.AbsoluteUri;
			tbOutput.Text += "\r\nAbsolutePath:" + uri.AbsolutePath;
			*/
		}


	}
}

using System;
using DCCG.WRobo.BusinessData;
using DCCG.WRobo.HtmlParser;

namespace DCCG.WRobo.BusinessLogic
{
	/// <summary>
	/// Summary description for Worker.
	/// </summary>
	public class Worker
	{
		private WorkItem workItem;
		private HtmlDocument rootDocument;
		private MyApplication application;
 
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="workItem">A work item with information for the worker</param>
		public Worker(WorkItem workItem, MyApplication application)
		{
			this.workItem = workItem;
			this.application = application;
		}

		/// <summary>
		/// Now, the worker starts his work
		/// </summary>
		public void DoWork()
		{
			if (this.application == null || 
				this.workItem == null)
				return;

			if (workItem.ActionType == WorkItemActionType.DownloadWebSite)
			{
				// Load site from web
				string html = "";
				
				bool success = DownloadManager.DownloadAndSaveToDisk(this.workItem.DownloadUrl, 
																	 ref html, 
																	 this.workItem.LokalFilename);

				if (success)
				{
				
					rootDocument = HtmlDocument.Create(html, false);
					if(rootDocument != null)
					{
						ProcessOpenLink();
						ProcessImgSrcLinks();
					}
				}
			}
			else if (workItem.ActionType == WorkItemActionType.DownloadFile)
			{

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		private void SaveHtmlToDisk(string path)
		{
			System.IO.StreamWriter sw = null;
			try
			{
				sw = new System.IO.StreamWriter(path);
				sw.Write(rootDocument.HTML);
				sw.Flush();
			}
			catch(Exception e)
			{
				// TODO:
				Console.Out.WriteLine(e.Message);
			}
			finally
			{
				if (sw != null)
					sw.Close();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void ProcessImgSrcLinks()
		{
			HtmlNodeCollection nodes = rootDocument.Nodes.FindByName("img");
			foreach(HtmlNode node in nodes)
			{
				if (node.GetType() == typeof(HtmlElement))
				{
					HtmlElement elem = (HtmlElement)node;
					HtmlAttribute srcAttr = elem.Attributes.FindByName("src");
					if (srcAttr != null)
					{
						string imgSrc = srcAttr.Value;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void ProcessOpenLink()
		{
			if (rootDocument == null)
				return;
		
			HtmlNodeCollection nodes = rootDocument.Nodes.FindByName("a");
			foreach(HtmlNode node in nodes)
			{
				if (node.GetType() == typeof(HtmlElement))
				{
					HtmlElement elem = (HtmlElement)node;
					HtmlAttribute hrefAttr = elem.Attributes.FindByName("href");
					if (hrefAttr != null)
					{
						string href = hrefAttr.Value;
						string baseUrl = "http://www.daimlerchrysler.com";
						LinkConverter lc = new LinkConverter(href, baseUrl /* TODO baseurl*/);
						if (lc.IsOpenLink && lc.ShouldConvertToLokal)
						{
							WorkItem newWorkItem = new WorkItem();
							newWorkItem.DownloadUrl = lc.GetLinkWithoutScript();
							newWorkItem.ActionType = WorkItemActionType.DownloadWebSite;
							this.application.DownloadQueue.Enqueue(newWorkItem);

							// TEST
							Console.Out.WriteLine("Put {0} into Queue", newWorkItem.DownloadUrl);
						}
					}
				}
			}
		}
	}
}

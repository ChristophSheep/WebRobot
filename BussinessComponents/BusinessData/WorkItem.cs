using System;

namespace DCCG.WRobo.BusinessData
{
	/// <summary>
	/// Action type for work item
	/// </summary>
	public enum WorkItemActionType {DownloadWebSite, DownloadFile};

	/// <summary>
	/// Saves information for the worker
	/// </summary>
	public class WorkItem
	{
		private WorkItemActionType actionType = WorkItemActionType.DownloadWebSite;
		private string downloadUrl = "";
		private string lokalFilename = "";

		/// <summary>
		/// Constructor
		/// </summary>
		public WorkItem()
		{
	
		}

		/// <summary>
		/// ActionType like "DownloadWebSite" oder "DownloadFile"
		/// </summary>
		public WorkItemActionType ActionType 
		{ 
			get { return actionType; } 
			set { actionType = value; } 
		}

		/// <summary>
		/// Url for download website or file
		/// </summary>
		public string DownloadUrl 
		{ 
			get { return downloadUrl; } 
			set { downloadUrl = value; } 
		}

		/// <summary>
		/// Lokal filename of html or image etc.
		/// </summary>
		public string LokalFilename 
		{ 
			get { return lokalFilename; } 
			set { lokalFilename = value; } 
		}
	}
}

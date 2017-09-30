using System;

namespace DCCG.WRobo.BusinessData
{
	/// <summary>
	/// 
	/// </summary>
	public class MyApplication
	{
		/// <summary>
		/// Private Members
		/// </summary>
		static private MyApplication instance = null;
		
		// Data Objects
		private DownloadQueue downloadQueue = null;
		private Project project = null;
		// private DownloadedObjects downloadedObjects = null;
		// private SimpleFileLogger simpleFileLogger = null;

		/// <summary>
		/// Protected constructor
		/// </summary>
		protected MyApplication()
		{
			downloadQueue = DownloadQueue.GetInstance();
			project = Project.GetInstance(); 
			// downloadedObjects = DownloadedObjects.GetInstance(); 
			// simpleFileLogger = SimpleFileLogger.GetInstance(); 
		}

		/// <summary>
		/// Re-initialize the application 
		/// </summary>
		public void ReInit()
		{
			// TODO: delete all objects and create new one

			instance = null; // Garbage Collector should delete it
			MyApplication newInstance = new MyApplication();
			instance = newInstance;
			
		}

		/// <summary>
		/// Return a singleton instance of MyApplication
		/// </summary>
		/// <returns></returns>
		static public MyApplication GetInstance()
		{
			if (instance == null)
				instance = new MyApplication();
			return instance;
		}

		public DownloadQueue DownloadQueue { get { return downloadQueue; } }

		public Project Project{ get { return project; } }

		// public DownloadedObjects DownloadedObjects { get { return downloadedObjects; } }
		// public SimpleFileLogger SimpleFileLogger { get { return simpleFileLogger; } }
	}
}

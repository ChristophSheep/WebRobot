using System;
using System.Collections;

namespace DCCG.WRobo.BusinessData
{

	// Delegate declaration.
	//
	public delegate void QueueChangedEventHandler(object sender, EventArgs e);

	/// <summary>
	/// This queue holds workitem with information the worker thread
	/// It's synchronized -> thread-safe
	/// </summary>
	public class DownloadQueue
	{
		static private DownloadQueue instance = null;
		private Queue syncDownloadQueue;
		private const int START_SIZE = 128;
		
		/// <summary>
		/// Protected constructor
		/// </summary>
		protected DownloadQueue()
		{
			Queue downloadQueue = new Queue(START_SIZE);
			syncDownloadQueue = Queue.Synchronized(downloadQueue);
		}

		/// <summary>
		/// Get a singleton instance of DownloadQueue
		/// </summary>
		/// <returns>instance of class DownloadQueue</returns>
		static public DownloadQueue GetInstance()
		{
			if (instance == null)
			{
				instance = new DownloadQueue();
			}
			return instance;
		}

		/// <summary>
		/// Put an object into queue
		/// </summary>
		/// <param name="obj"></param>
		public void Enqueue(object obj)
		{
			if (syncDownloadQueue != null) 
			{
				syncDownloadQueue.Enqueue(obj);
				OnQueueChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Get an object from the queue
		/// </summary>
		/// <returns></returns>
		public object Dequeue()
		{
			object obj = null;
			if (syncDownloadQueue != null) 
			{
				obj = syncDownloadQueue.Dequeue();
				OnQueueChanged(new EventArgs());

			}
			return obj;
		}

		// The event member that is of type QueueChangedEventHandler
		//
		public event QueueChangedEventHandler QueueChanged;

		// The protected OnQueueChanged method raises the event by invoking 
		// the delegates. The sender is always this, the current instance 
		// of the class.
		//
		protected virtual void OnQueueChanged(EventArgs e)
		{
			if (QueueChanged != null) 
			{
				// Invokes the delegates. 
				QueueChanged(this, e);
			}
		}

	}
}

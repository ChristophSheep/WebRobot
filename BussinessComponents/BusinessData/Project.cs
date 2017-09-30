using System;

namespace DCCG.WRobo.BusinessData
{
	/// <summary>
	/// 
	/// </summary>
	public class Project
	{
		private string websiteUri = "";
		private string lokalSaveFolder = "";
		private uint countOfWorkerThreads = 1;
		private const uint MAX_THREADS = 25;
		private string password = "";
		private string username = "";
		private bool shouldLogin = false;
		private uint structureDepth = 20;


		protected Project()
		{
			// 
			// TODO: 
			//
			// websiteUri = ReadFromConfig();
			// lokalSaveFolder = ReadFromConfig();
			// structureDepth = ReadFromConfig(); // default from config

		}

		static public Project GetInstance()
		{
			return new Project();
		}

		public string WebsiteUri
		{
			get { return websiteUri; }
			set	{ websiteUri = value; }
		}

		public bool ShouldLogin
		{
			get { return shouldLogin; }
			set	{ shouldLogin = value; }
		}

		public string LoginUsername
		{
			get { return username; }
			set	{ username = value; }
		}

		public string LoginPassword
		{
			get { return password; }
			set	{ password = value; }
		}

		public string LokalSaveFolder
		{
			get { return lokalSaveFolder; }
			set	{ lokalSaveFolder = value; }
		}

		public uint CountOfWorkerThreads
		{
			get { return countOfWorkerThreads; }
			set	
			{
				uint count = (uint)value;
				if (count > MAX_THREADS)
					countOfWorkerThreads = MAX_THREADS;
				else
					countOfWorkerThreads = count; 
			}
		}
		
	}
}

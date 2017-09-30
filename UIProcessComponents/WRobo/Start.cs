using System;

namespace DCCG.WRoboUI
{
	/// <summary>
	/// Summary description for Start.
	/// </summary>
	public class Start
	{
		public Start()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
	}
}

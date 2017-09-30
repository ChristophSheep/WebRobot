using System;
using System.Xml;
using System.Reflection;
using System.Configuration;

namespace DCCG.WRobo.OperationalManagement
{
	/// <summary>
	/// Diese Klasse implementiert den Zugriff auf eine beliebige Konfigurationsdatei. Dies ist notwendig,
	/// da der Datenbank connection string nicht im standard app.config gehalten werden soll. 
	/// </summary>
	public class WRoboConfig : System.Configuration.AppSettingsReader
	{
		private XmlNode node;
		private string _cfgFile;

		/// <summary>
		/// Config full filename
		/// </summary>
		/// <param name="filename"></param>
		public WRoboConfig(string filename) : base()
		{
			_cfgFile = filename;
		}



		/// <summary>
		/// TODO: Kommentar einf�gen
		/// </summary>
		public   string cfgFile
		{
			get    { return _cfgFile; }
			set    { _cfgFile=value; }
		}

		/// <summary>
		/// TODO: Kommentar einf�gen
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetValue (string key)
		{
			return Convert.ToString(GetValue(key, typeof(string)));
		}

		/// <summary>
		/// TODO: Kommentar einf�gen
		/// </summary>
		/// <param name="key"></param>
		/// <param name="sType"></param>
		/// <returns></returns>
		public new object GetValue (string key, System.Type sType)
		{
			XmlDocument doc = new XmlDocument();
			object ro = String.Empty;
			loadDoc(doc);
			string sNode = key.Substring(0, key.LastIndexOf("//"));
			// retrieve the selected node
			try
			{
				node =  doc.SelectSingleNode(sNode);
				if( node != null )
				{
					// Xpath selects element that contains the key
					XmlElement targetElem= (XmlElement)node.SelectSingleNode(
						key.Replace(sNode,"")) ;
					if (targetElem!=null)
					{
						ro = targetElem.GetAttribute("value");
					}
				}
				if (sType == typeof(string))
					return Convert.ToString(ro);
				else
					if (sType == typeof(bool))
				{
					if (ro.Equals("True") || ro.Equals("False"))
						return Convert.ToBoolean(ro);
					else
						return false;
				}
				else
					if (sType == typeof(int))
					return Convert.ToInt32(ro);
				else
					if (sType == typeof(double))
					return Convert.ToDouble(ro);
				else
					if (sType == typeof(DateTime))
					return Convert.ToDateTime(ro);
				else
					return Convert.ToString(ro);
			}
			catch
			{
				return String.Empty;
			}
		}

		/// <summary>
		/// TODO: Kommentar einf�gen
		/// </summary>
		/// <param name="key"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool SetValue (string key, string val)
		{
			XmlDocument doc = new XmlDocument();
			loadDoc(doc);
			try
			{
				// retrieve the target node
				string sNode = key.Substring(0, key.LastIndexOf("//"));
				node =  doc.SelectSingleNode(sNode);
				if( node == null )
					return false;
				// Set element that contains the key
				XmlElement targetElem= (XmlElement) node.SelectSingleNode(
					key.Replace(sNode,""));
				if (targetElem!=null)
				{
					// set new value
					targetElem.SetAttribute("value", val);
				}
					// create new element with key/value pair and add it
				else
				{
					// handle xxx[@key='yyy']
					sNode = key.Substring(key.LastIndexOf("//")+2);
					// create new element xxx
					XmlElement entry = doc.CreateElement(sNode.Substring(0, 
						sNode.IndexOf("[@")).Trim());
					sNode =  sNode.Substring(sNode.IndexOf("'")+1);
					// set attribute key=yyy
					entry.SetAttribute("key", sNode.Substring(0, 
						sNode.IndexOf("'")) );
					// set attribute value=val
					entry.SetAttribute("value", val);
					node.AppendChild(entry);
				}
				saveDoc(doc, this._cfgFile);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// TODO: Kommentar einf�gen
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool removeElement (string key)
		{
			XmlDocument doc = new XmlDocument();
			loadDoc(doc);
			try
			{
				string sNode = key.Substring(0, key.LastIndexOf("//"));
				// retrieve the appSettings node
				node =  doc.SelectSingleNode("//appSettings");
				if( node == null )
					return false;
				// XPath select setting element that contains the key to remove
				node.RemoveChild( node.SelectSingleNode(key.Replace(sNode,"")) );
				saveDoc(doc, this._cfgFile);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void saveDoc (XmlDocument doc, string docPath)
		{
			// save document
			try
			{
				XmlTextWriter writer = new XmlTextWriter( docPath , null );
				writer.Formatting = Formatting.Indented;
				doc.WriteTo( writer );
				writer.Flush();
				writer.Close();
				return;
			}
			catch
			{}
		}

		private void loadDoc ( XmlDocument doc )
		{
			// load the document
			doc.Load( this._cfgFile );
		}

	}
}

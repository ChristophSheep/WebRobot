using System;


namespace DCCG.WRobo.BusinessLogic
{
	/// <summary>
	/// 
	/// Parse openLink
	/// e.g. <a href="javascript:openLink('0-415-212916-49-212918-1-0-0-0-0-1-4256-212916-0-0-0-31-0-0-1','1','co','');" 
	/// </summary>
	public class LinkConverter
	{
		private bool bIsOpenLink = false;
		private bool bShouldConvertToLokal = false;
		
		private string strLinkHRef = "";
		private string strBaseUrl = "";
		
		private const string START_TOKEN = "javascript:openLink(";
		private const string END_TOKEN = ");";

		private const string LINKTYPE_CONTENT_ITEM = "co";
		private const string LINKTYPE_MENUE = "me";
		
		private string strOId = "", strOpenType = "", strLinkType = "", strWindowOpenProps = "";

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strLinkHRef"></param>
		/// <param name="strBaseUrl"></param>
		public LinkConverter(String strLinkHRef, String strBaseUrl)
		{
			this.strLinkHRef = strLinkHRef;
			this.strBaseUrl = strBaseUrl;
			
			bIsOpenLink = strLinkHRef.StartsWith(START_TOKEN);
			
			if (bIsOpenLink)
			{
				ParseLink();
			}
		}

		/// <summary>
		/// Show if HRef is of type "javascript:openLink(..)
		/// </summary>
		/// <returns>true, if HRef is of type "javascript:openLink(..)"</returns>
		public bool IsOpenLink
		{
			get { return bIsOpenLink; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ShouldConvertToLokal
		{
			get { return bShouldConvertToLokal; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strBaseUrl"></param>
		/// <returns></returns>
		private string CreateUrl(string strBaseUrl, bool bWithBaseUrl)
		{
			string strUrl = "";
			
			strBaseUrl = strBaseUrl.TrimEnd('/');

			if (bWithBaseUrl)
			{
				strUrl = strBaseUrl + "/0,," + strOId + ",00.html"; // TODO: ? -> + location.search
			} 
			else
			{
				strUrl = "0,," + strOId + ",00.html"; 
			}

			return strUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		private void ParseLink()
		{			
			string delimStr = ",";
			char [] delimiter = delimStr.ToCharArray();

			string strScriptParam = strLinkHRef.Substring(START_TOKEN.Length, strLinkHRef.Length - START_TOKEN.Length - END_TOKEN.Length);	
			string [] split = strScriptParam.Split(delimiter);
	
			delimStr = "'";
			delimiter =  delimStr.ToCharArray();

			if (split.Length > 0)
				strOId				= split[0].Trim(delimiter);
			if (split.Length > 1)
				strOpenType			= split[1].Trim(delimiter);
			if (split.Length > 2)
				strLinkType			= split[2].Trim(delimiter).ToLower();
			if (split.Length > 3)
				strWindowOpenProps	= split[3].Trim(delimiter);
		

			// Only this types should be converted
			if (strLinkType.Equals(LINKTYPE_CONTENT_ITEM) || 
				strLinkType.Equals(LINKTYPE_MENUE)
				)
			{
				bShouldConvertToLokal = true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string GetTitle() 
		{
			try 
			{
				string [] simpleId = strOId.Split('-');
				return "newWindow" + simpleId[4];
			} 
			catch ( Exception e ) 
			{
				// TODO: Logging
				String msg = e.Message;

				return "newWindow";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetLokalLink()
		{
			if (bShouldConvertToLokal)
			{
				return CreateLokalLink();
			}
			return strLinkHRef;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetLinkWithoutScript()
		{	
			if (bShouldConvertToLokal)
			{
				return CreateUrl(strBaseUrl, true);
			}
			return strLinkHRef;
		}

		/// <summary>
		/// 
		/// </summary>
		private string CreateLokalLink()
		{
			string strUrlNew = "";
			string strUrl = CreateUrl(strBaseUrl, false);
			

			switch (strOpenType) 
			{
				case "1": 
				{
					strUrlNew = strUrl;
					break;
				}
				case "2": 
				{
					strUrlNew =  "javascript:newWindow=window.open('" + strUrl + "');";
					strUrlNew += "newWindow.focus();";
					break;
				}
				case "3": 
				{
					string strTitle = GetTitle(); 
					strUrlNew += "javascript:newWindow=window.open('" + strUrl + "', '" + strTitle + "', '" + strWindowOpenProps + "');";
					strUrlNew += "newWindow.focus();";
					break;
				}
				/* TODO: Klärung
				case "4": 
				{
					frmContent = window.frames[contentFrameName];
					if (typeof(frmContent) == 'undefined' ) 
					{
						window.location.href = url;				
					} 
					else 
					{
						frmContent.location.href = url;
					}
					break;
				}*/
				default: 
				{
					strUrlNew = strUrl;
					break;
				}
			}

			return strUrlNew;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "strOId:" + strOId + " strOpenType: " + strOpenType + " strLinkType:" + strLinkType + " strWindowOpenProps:" + strWindowOpenProps;
		}
	}


}


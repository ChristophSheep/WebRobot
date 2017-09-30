using System;
using System.Net;
using System.Security;
using System.IO;

namespace DCCG.WRobo.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public class DownloadManager
	{


		/// <summary>
		/// Construktor
		/// </summary>
		public DownloadManager()
		{
	
		}

		/// <summary>
		/// Download a file an save it to disk
		/// </summary>
		/// <param name="strUri">Uri of file to download</param>
		/// <param name="strFilename">Filename with path to save file to disk</param>
		/// <returns>true, if download was successful else false</returns>
		static public bool DownloadFile(string strUri, string strFilename)
		{
			bool success = true;

			// see webclient documenation
			// ms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.1031/cpref/html/frlrfsystemnetwebclientclassdownloadfiletopic.htm

			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile(strUri, strFilename);        
			}
			catch(WebException e)
			{
				
				// TODO: Logging
				String msg = e.Message;

				//tbState.Text += "Der Aufrufer besitzt keine Schreibberechtigung für lokale Dateien.";
				//tbState.Text += wex.Message;
				success = false;
			}
			catch(SecurityException e)
			{
				// TODO: Logging
				String msg = e.Message;

				//tbState.Text += "Der Aufrufer besitzt keine Schreibberechtigung für lokale Dateien.";
				//tbState.Text += secEx.Message;
			}

			return success;
		
		}

		/// <summary>
		/// Download a website
		/// </summary>
		/// <param name="strUri">URI of website</param>
		/// <param name="strHtml">String of downloaded website</param>
		/// <returns>true, if download was successful else false<</returns>
		static public bool DownloadAndSaveToDisk(string uri, ref/*TODO: out?*/ string html, string filename)
		{
			bool success = false;
			Stream stream = null;
			
			try
			{
				WebClient webClient = new WebClient();
				stream = webClient.OpenRead(uri);
				StreamReader sr = new StreamReader(stream);
				html = sr.ReadToEnd();

				// TODO: build a read buffer
				/*
				Bei ReadToEnd wird vorausgesetzt, dass der Stream das Erreichen des Endes erkennt. 
				Bei interaktiven Protokollen, bei denen der Server Daten nur auf Anforderung sendet
				und die Verbindung nicht schließt, kann ReadToEnd für einen unbestimmten Zeitraum 
				blockieren und sollte nicht verwendet werden.
				Beim Verwenden der Read-Methode ist es effizienter, einen Puffer mit der Größe des 
				internen Puffers des Streams zu verwenden. Wenn die Größe des Puffers beim Erstellen
				des Streams nicht festgelegt wurde, beträgt die Standardgröße 4 KB (4.096 Bytes).
				Wenn die aktuelle Methode eine OutOfMemoryException auslöst, wird die Position des
				Readers im zugrunde liegenden Stream um die Anzahl von Zeichen nach vorn verschoben,
				die die Methode lesen konnte. Die bereits in den internen ReadLine-Puffer gelesenen
				Zeichen werden jedoch verworfen. Da die Position des Readers im Stream nicht geändert
				werden kann, können die bereits gelesenen Zeichen nicht wiederhergestellt werden. Auf
				diese kann nur nach erneuter Initialisierung des StreamReader zugegriffen werden.
				Wenn die Ausgangsposition im Stream unbekannt ist oder der Stream keine Suche unterstützt,
				muss der zugrunde liegende Stream ebenfalls neu initialisiert werden.	
				Um diese Situation zu vermeiden und stabilen Code zu erstellen, sollten Sie die 
				Read-Methode verwenden und die gelesenen Zeichen in einem vorher reservierten Puffer speichern.																											
				Ein Beispiel für die Verwendung dieser Methode finden Sie im Beispielabschnitt weiter unten.
				In der folgenden Tabelle sind Beispiele für andere typische oder verwandte E/A-Aufgaben aufgeführt.
				*/

			}
			catch(WebException e)
			{
				// TODO: Logging
				String msg = e.Message;
				
			}
			finally
			{
				if (stream != null)
					stream.Close();

				if (SaveHtmlToDisk(html, filename))
					success = true;
			}
			return success;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="html"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		static bool SaveHtmlToDisk(string html, string filename)
		{
			bool success = false;
			System.IO.StreamWriter sw = null;

			try
			{
				sw = new System.IO.StreamWriter(filename);
				sw.Write(html);
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
				success = true;
			}
			return success;
		}
	}
}

using System;
using Microsoft.Phone.Tasks;

namespace er.web
{
	// Token: 0x02000439 RID: 1081
	public class erWeb
	{
		// Token: 0x06002B04 RID: 11012 RVA: 0x0015BCA0 File Offset: 0x00159EA0
		public static void StartWeb(string url)
		{
			new WebBrowserTask
			{
				URL = url
			}.Show();
		}
	}
}

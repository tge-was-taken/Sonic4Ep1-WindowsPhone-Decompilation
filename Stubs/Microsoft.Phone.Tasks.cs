using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Phone.Tasks
{
    public class WebBrowserTask
    {
        public string URL { get; set; }

        public void Show()
        {
            Stub.Log( typeof( WebBrowserTask ), nameof( Show ) );
        }
    }

    public class MarketplaceDetailTask
    {
        public MarketplaceContentType ContentType { get; set; }

        public void Show()
        {
            Stub.Log( typeof( MarketplaceDetailTask ), nameof( Show ) );
        }
    }

    public enum MarketplaceContentType
    {

    }
}

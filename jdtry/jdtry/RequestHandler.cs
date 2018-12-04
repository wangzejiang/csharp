using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using CefSharp.Handler;

namespace jdtry
{
    public class RequestHandler : DefaultRequestHandler
    {
        public override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            if (request.ResourceType == ResourceType.Image)
                return CefReturnValue.Cancel;
            return CefReturnValue.Continue;
        }

    }
}

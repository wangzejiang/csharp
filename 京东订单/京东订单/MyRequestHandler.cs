using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace 京东订单
{
    public class MyRequestHandler : IRequestHandler
    {
        private ResourceType[] rtl = null;
        public MyRequestHandler(ResourceType[] _rtl)
        {
            rtl = _rtl;
        }
        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            //Console.WriteLine("GetAuthCredentials");
            return false;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //Console.WriteLine("GetResourceResponseFilter");
            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            //Console.WriteLine("OnBeforeBrowse");
            return false;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest req, IRequestCallback callback)
        {
            //Console.WriteLine("OnBeforeResourceLoad");
            if (rtl != null)
            {
                foreach (var rt in rtl)
                {
                    if (req.ResourceType == rt)
                    {
                        return CefReturnValue.Cancel;
                    }
                }
            }
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            //Console.WriteLine("OnCertificateError");
            return false;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            //Console.WriteLine("OnOpenUrlFromTab");
            return false;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
            //Console.WriteLine("OnPluginCrashed");
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            //Console.WriteLine("OnProtocolExecution"); 
            return false;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            //Console.WriteLine("OnQuotaRequest"); 
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
            //Console.WriteLine("OnRenderProcessTerminated");
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
            //Console.WriteLine("OnRenderViewReady");
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            //Console.WriteLine("OnResourceLoadComplete-->status:" + status+ "-->receivedContentLength:" + receivedContentLength);
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            //Console.WriteLine("OnResourceRedirect");
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //Console.WriteLine("OnResourceResponse"); 
            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        { //Console.WriteLine("OnSelectClientCertificate"); 
            return false;
        }
        
    }
}

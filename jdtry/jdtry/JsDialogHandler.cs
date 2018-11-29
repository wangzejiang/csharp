using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdtry
{
    class JsDialogHandler : IJsDialogHandler
    {
        public bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            switch (dialogType)
            {
                case CefSharp.CefJsDialogType.Alert:
                    Console.WriteLine("Alert");
                    suppressMessage = true;
                    break;
                case CefSharp.CefJsDialogType.Confirm:
                    Console.WriteLine("Confirm");
                    suppressMessage = true;
                    break;
                case CefSharp.CefJsDialogType.Prompt:
                    Console.WriteLine("Prompt");
                    suppressMessage = true;
                    break;
                default:
                    break;
            }
            Console.WriteLine(messageText);
            return false;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}

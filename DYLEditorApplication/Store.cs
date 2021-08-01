using GoogleAnalyticsTracker.Simple;
using System;
using System.Collections.Generic;
using System.Text;

namespace DYLEditorApplication
{
    static class Store
    {
        private static SimpleTracker _simpleTracker;

        public static SimpleTracker simpleTracker
        {
            get { return _simpleTracker; }
            set { _simpleTracker = value; }
        }

    }
}

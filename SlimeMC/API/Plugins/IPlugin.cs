using System;
using System.Collections.Generic;
using System.Text;

namespace SlimeMC.API.Plugins
{
    public interface IPlugin
    {
        public void OnLoad( );
        public void OnUnload( );

        public string name
        {
            get;
        }
        public string version
        {
            get;
        }
        public string[ ] authors
        {
            get;
        }
        public string website
        {

            get;
        }
    }
}

using SlimeMC.API.Plugins;

using System;

namespace TestingLib
{
    public class TestingLibPlugin : IPlugin
    {
        public string name => "TestingLib";

        public string version => "";

        public string[ ] authors => new string[ ]
            {
                "VenomCode"
            };

        public string website => "";

        public void OnLoad( )
        {
            throw new NotImplementedException( );
        }

        public void OnUnload( )
        {
            throw new NotImplementedException( );
        }
    }
}

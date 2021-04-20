using System;
using System.Collections.Generic;
using System.Text;

namespace SlimeMC.API.Events
{
    public class SlimeEvents
    {
        public delegate void ConsoleCommandEvent( string cmd, string[] args );
        public static event ConsoleCommandEvent OnConsoleCommand;

        internal static void StrikeConsoleCommand( string cmd, string[] args )
        {
            OnConsoleCommand?.Invoke( cmd, args );
        }
    }
}

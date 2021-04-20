using SlimeMC.API.Events;
using SlimeMC.API.Logging;
using SlimeMC.API.Slime;

using System;
using System.Threading;

namespace SlimeMC
{
    class Program
    {
        static void Main( string[ ] args )
        {
            _state = ServerStates.INITIALIZING;

            consoleInterfaceLoopThread = new Thread( ConsoleInterfaceLoop );
            consoleInterfaceLoopThread.IsBackground = true;
            consoleInterfaceLoopThread.Start( );

            Logger.Warning( "Initializing..." );

            SlimeEvents.OnConsoleCommand += OnConsoleCommand;

            while ( _state != ServerStates.STOPPED )
            {
                string cmdInput = Console.ReadLine( );

                SlimeEvents.StrikeConsoleCommand( cmdInput, new string[ 0 ] );
            }
        }

        private static void OnConsoleCommand( string cmd, string[ ] args )
        {
            // THIS IS A TEMP METHOD

            if ( cmd == "stop" )
            {
                Stop( );
            }
        }

        private static void Stop( )
        {
            if ( _state >= 0 )
            {
                _state = ServerStates.STOPPED;
                Logger.Warning( "Stopping..." );
            }
        }

        internal static void ConsoleInterfaceLoop( )
        {
            while ( _state != ServerStates.STOPPED )
            {
                Logger.DoPublish( );

                Thread.Sleep( 200 );
            }
        }

        private static Thread consoleInterfaceLoopThread;
        private static ServerStates _state = ServerStates.STOPPED;
    }
}

using System;
using System.Collections.Generic;

namespace SlimeMC.API.Logging
{
    public class Logger
    {
        public static void Debug( string msg )
        {
            ConsoleLog log = new ConsoleLog( msg, ConsoleColor.Cyan );

            SubmitLog( log );
        }
        public static void Success( string msg )
        {
            ConsoleLog log = new ConsoleLog( msg, ConsoleColor.Green );

            SubmitLog( log );
        }
        public static void Warning ( string msg )
        {
            ConsoleLog log = new ConsoleLog( msg, ConsoleColor.Yellow );

            SubmitLog( log );
        }
        public static void Error ( string msg )
        {
            ConsoleLog log = new ConsoleLog( msg, ConsoleColor.Red );

            SubmitLog( log );
        }

        private static void SubmitLog( ConsoleLog log )
        {
            lock ( logList )
            {
                logList.Add( log );
            }
        }

        internal static void DoPublish()
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            lock( logList )
            {
                if ( logList.Count > 0 )
                {
                    int logsCount = logList.Count;

                    int pushAmt = ( logsCount <= MAX_LOGS_PER_PUSH ? logsCount : MAX_LOGS_PER_PUSH );

                    for ( int i = 0; i < pushAmt; i++ )
                    {
                        ConsoleLog l = logList[ i ];
                        if ( l != null )
                        {
                            Console.ForegroundColor = l.GetColor( );
                            Console.WriteLine( "[NULL_CLASS]" + l.GetMessage() );
                        }
                    }

                    if ( pushAmt <= logsCount )
                    {
                        logList.Clear( );
                    }
                    else
                    {
                        logList.RemoveRange( 0, pushAmt - 1 );
                    }
                }
            }

            Console.ForegroundColor = oldColor;
        }

        internal static List<ConsoleLog> logList = new List<ConsoleLog>();
        public const int MAX_LOGS_PER_PUSH = 10;

        internal class ConsoleLog
        {
            internal ConsoleLog( string msg, ConsoleColor color )
            {
                this.msg = msg;
                this.color = color;
            }

            string msg;
            ConsoleColor color;

            public ConsoleColor GetColor()
            {
                return color;
            }
            public string GetMessage()
            {
                return msg;
            }
        }
    }
}

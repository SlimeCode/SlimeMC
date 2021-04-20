using System;
using System.Collections.Generic;
using System.Text;

namespace SlimeMC.API.Slime
{
    public enum ServerStates
    {
        STOPPED = -10,
        STOPPING = -1,
        INITIALIZING = 0,
        STARTING = 1,
        READY = 10
    }
}

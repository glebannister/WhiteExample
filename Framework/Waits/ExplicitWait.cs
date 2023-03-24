using Framework.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Utility;

namespace Framework.Waits
{
    public static class ExplicitWait
    {
        public static bool WaitUntil(Func<bool> condition, int timeoutMilliseconds)
        {
            FrameworkLogger.GetInstance().Debug($"Waiting for some conditions with timeout: [{timeoutMilliseconds}]");
            return Retry.For(condition, TimeSpan.FromMilliseconds(timeoutMilliseconds));
        }
    }
}

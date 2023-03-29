using Framework.Logging;
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

#if UNITY_WEBGL && WEIXINMINIGAME
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace R4P0.UnityUMWXSDK
{
    public class UMADebug
    {
        public static ILogger logger { get; set; } = Debug.unityLogger;

        public static void Log(object message, Object context)
        {
            logger?.Log(LogType.Log, message, context);
        }

        public static void Log(object message)
        {
            logger?.Log(LogType.Log, message);
        }

        public static void LogError(object message, Object context)
        {
            logger?.Log(LogType.Error, message, context);
        }

        public static void LogError(object message)
        {
            logger?.Log(LogType.Error, message);
        }

        public static void LogException(Exception exception)
        {
            logger?.LogException(exception);
        }
        public static void LogException(Exception exception, Object context)
        {
            logger?.LogException(exception, context);
        }

        public static void LogWarning(object message, Object context)
        {
            logger?.Log(LogType.Warning, message, context);
        }

        public static void LogWarning(object message)
        {
            logger?.Log(LogType.Warning, message);
        }
    }
}
#endif
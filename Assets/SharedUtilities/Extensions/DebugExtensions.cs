using System;
using System.Collections.Generic;
using UnityEngine;

namespace Psyfer.Utilities
{
    public static class DebugExtensionMethods
    {
        public static void Log<T>(this T local, string message, Color color) where T : IFormattable
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local} : {message}</color>");
        }

        public static void Log<T>(this T local, Color color) where T : IFormattable
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local}</color>");
        }

        public static void Log<T>(this T local) where T : IFormattable
        {
            Debug.Log(local);
        }

        public static void Log(this UnityEngine.Object local, string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local} : {message}</color>");
        }

        public static void Log(this UnityEngine.Object local, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local}</color>");
        }

        public static void Log(this UnityEngine.Object local)
        {
            Debug.Log(local);
        }

        public static void Log(this string local, string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local} : {message}</color>");
        }

        public static void Log(this string local, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{local}</color>");
        }

        public static void Log(this string local)
        {
            Debug.Log(local);
        }

        public static void Log<T>(this IList<T> list, string message, Color color)
        {
            string elements = string.Join(", ", list);
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{elements} : {message}</color>");
        }

        public static void Log<T>(this IList<T> list, Color color)
        {
            string elements = string.Join(", ", list);
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{elements}</color>");
        }

        public static void Log<T>(this IList<T> list)
        {
            string elements = string.Join(", ", list);
            Debug.Log(elements);
        }
    }
}
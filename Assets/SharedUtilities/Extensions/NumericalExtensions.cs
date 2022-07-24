using System;
using UnityEngine;

namespace Psyfer.Utilities
{
    public static class NumericalExtensionMethods
    {
        /// <summary> 
        /// Remaps from an existing range to a new range.
        /// </summary>
        public static float Remap(this float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            return (value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;
        }

        /// <summary>
        /// Clamp values between two bounds.
        /// </summary>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            if (val.CompareTo(max) > 0) return max;
            return val;
        }

        /// <summary>
        /// Clamp01 values between 0 and 1.
        /// </summary>
        public static float Clamp01(this float val)
        {
            if (val < 0) return 0;
            if (val > 1) return 1;
            return val;
        }

        // Lerp functionality ---------------------------------------------------------------------------------
        /// <summary>
        /// Sin range from 0-1 based on time, used for interpolating between two values.
        /// </summary>
        public static float SinLerpTime(float time) => Mathf.Sin(Mathf.Clamp01(time) * Mathf.PI * 0.5f);
        /// <summary>
        /// Cos range from 0-1 based on time, used for interpolating between two values.
        /// </summary>
        public static float CosLerpTime(float time) => 1.0f - Mathf.Cos(Mathf.Clamp01(time) * Mathf.PI * 0.5f);
        /// <summary>
        /// Smooth polynomial range from 0-1 based on time, used for interpolating between two values.
        /// </summary>
        public static float SmoothStepLerpTime(float time)
        {
            float t = Mathf.Clamp01(time);
            return t * t * t * (t * (6.0f * t - 15.0f) + 10.0f);
        }

        /// <summary>
        /// Calculate the pow value for an int without using floats / doubles  
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pow"></param>
        /// <returns></returns>
        public static int Pow(this int value, int pow)
        {
            if (pow <= 0) return 1;

            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= value;
                value *= value;
                pow >>= 1;
            }
            return ret;
        }

        // Begin from the values initial value and lerp towards the end value.
        public static float SinLerp(this float start, float end, float time) => start + (end - start) * SinLerpTime(time);
        public static float CosLerp(this float start, float end, float time) => start + (end - start) * CosLerpTime(time);
        public static float SmoothStepLerp(this float start, float end, float time) => start + (end - start) * SmoothStepLerpTime(time);
        public static float CurveLerp(this float start, float end, float time, AnimationCurve curve) => start + (end - start) * curve.Evaluate(time);

        // Begin from the start value and lerp towards the end value.
        public static float SinLerp(this float _, float start, float end, float time) => start + (end - start) * SinLerpTime(time);
        public static float CosLerp(this float _, float start, float end, float time) => start + (end - start) * CosLerpTime(time);
        public static float SmoothStepLerp(this float _, float start, float end, float time) => start + (end - start) * SmoothStepLerpTime(time);
        public static float CurveLerp(this float _, float start, float end, float time, AnimationCurve curve) => start + (end - start) * curve.Evaluate(time);
        // -----------------------------------------------------------------------------------------------------
    }
}
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class GradientLibrary
    {
        public static Gradient InterpolateGradients(Gradient gradientA, Gradient gradientB, float t)
        {
            Gradient result = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[gradientA.colorKeys.Length];
            for (int i = 0; i < gradientA.colorKeys.Length; i++)
            {
                Color color = Color.Lerp(gradientA.colorKeys[i].color, gradientB.colorKeys[i].color, t);
                float time = Mathf.Lerp(gradientA.colorKeys[i].time, gradientB.colorKeys[i].time, t);
                colorKeys[i] = new GradientColorKey(color, time);
            }

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[gradientA.alphaKeys.Length];
            for (int i = 0; i < gradientA.alphaKeys.Length; i++)
            {
                float alpha = Mathf.Lerp(gradientA.alphaKeys[i].alpha, gradientB.alphaKeys[i].alpha, t);
                float time = Mathf.Lerp(gradientA.alphaKeys[i].time, gradientB.alphaKeys[i].time, t);
                alphaKeys[i] = new GradientAlphaKey(alpha, time);
            }

            result.SetKeys(colorKeys, alphaKeys);
            return result;
        }
    }
}
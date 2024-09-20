using System.Collections;
using UI;
using UnityEngine;
using Utils;

public enum GameColor
{
    None,
    Blue,
    Red
}

namespace Player
{
    public class PlayerColorSwap : MonoBehaviour
    {
        public GameColor CurrentColor => currentColor;
        
        [SerializeField] private ScrollingBackground scrollingBackground;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TrailRenderer firstTrailRenderer;
        [SerializeField] private TrailRenderer secondTrailRenderer;
        [SerializeField] private Color blueColor;
        [SerializeField] private Gradient blueGradient;
        [SerializeField] private Color redColor;
        [SerializeField] private Gradient redGradient;
        [SerializeField] private float tweenDuration;
        [SerializeField] private GameColor gameStartColor = GameColor.Blue;
    
        private Material meshMatInstance;
        private GameColor currentColor;
        private Coroutine crossFadeCoroutine;

        private void Start()
        {
            currentColor = gameStartColor;
            Color startColor = gameStartColor == GameColor.Blue ? blueColor : redColor;
        
            meshMatInstance = meshRenderer.materials[1];
            meshMatInstance.color = startColor;
            scrollingBackground.ChangeColor(startColor);
            firstTrailRenderer.colorGradient = gameStartColor == GameColor.Blue ? blueGradient : redGradient;
            secondTrailRenderer.colorGradient = gameStartColor == GameColor.Blue ? blueGradient : redGradient;
        }

        public void SetColor(GameColor gameColor)
        {
            currentColor = gameColor;
            Color newColor = currentColor == GameColor.Blue ? blueColor : redColor;
            Gradient newGradient = currentColor == GameColor.Blue ? blueGradient : redGradient;
            meshMatInstance.color = newColor;
            scrollingBackground.ChangeColor(newColor);
            firstTrailRenderer.colorGradient = newGradient;
            secondTrailRenderer.colorGradient = newGradient;
        }

        public void ChangeColor()
        {
            if (crossFadeCoroutine != null) StopCoroutine(crossFadeCoroutine);
            StartCoroutine(CrossFadeCoroutine());
            currentColor = currentColor == GameColor.Blue ? GameColor.Red : GameColor.Blue;
        }

        private IEnumerator CrossFadeCoroutine()
        {
            float timeElapsed = 0;
            Color baseColor = currentColor == GameColor.Blue ? blueColor : redColor;
            Color targetColor = currentColor == GameColor.Blue ? redColor : blueColor;
            Gradient baseGradient = currentColor == GameColor.Blue ? blueGradient : redGradient;
            Gradient targetGradient = currentColor == GameColor.Blue ? redGradient : blueGradient;

            while (timeElapsed < tweenDuration)
            {
                Color newColor = Color.Lerp(baseColor, targetColor, timeElapsed / tweenDuration); 
                meshMatInstance.color = newColor;
                scrollingBackground.ChangeColor(newColor);
                firstTrailRenderer.colorGradient = GradientLibrary.InterpolateGradients(baseGradient, targetGradient, timeElapsed / tweenDuration);
                secondTrailRenderer.colorGradient = GradientLibrary.InterpolateGradients(baseGradient, targetGradient, timeElapsed / tweenDuration);
            
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_BlackFade : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float fadeTime;

        public IEnumerator ShowCoroutine()
        {
            image.gameObject.SetActive(true);
            Tween tween = image.DOFade(1, fadeTime);
            yield return new WaitUntil(() => !tween.IsActive());
        }

        public IEnumerator HideCoroutine()
        {
            Tween tween = image.DOFade(0, fadeTime);
        
            tween.onComplete += () =>
            {
                image.gameObject.SetActive(false);
            };
        
            yield return new WaitUntil(() => image.gameObject.activeSelf == false);
        }
    }
}
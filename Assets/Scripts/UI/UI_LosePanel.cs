using System;
using System.Collections;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_LosePanel : MonoBehaviour
    {
        public static Action OnGameReset;
        
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UI_StartPanel startPanel;
        [SerializeField] private UI_BlackFade blackFade;
        [SerializeField] private Image background;
        [SerializeField] private Image panel;

        private bool isResetting = false;

        public void Show()
        {
            background.gameObject.SetActive(true);
            background.DOFade(192/255f, 0.5f);
            panel.transform.localScale = Vector3.zero;
            panel.transform.DOScale(Vector3.one, 0.5f);
        }
    
        public void OnClickRetry()
        {
            if (isResetting) return;
        
            StartCoroutine(ResetCoroutine());
            isResetting = true;
        }

        private IEnumerator ResetCoroutine()
        {
            yield return blackFade.ShowCoroutine();
            OnGameReset?.Invoke();
            background.gameObject.SetActive(false);
        
            yield return blackFade.HideCoroutine();
            startPanel.StartLevel();
            isResetting = false;
        }
    }
}

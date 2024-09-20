using System;
using System.Collections;
using DG.Tweening;
using GameElements;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_WinPanel : MonoBehaviour
    {
        public static Action OnGameNext;
        
        [SerializeField] private UI_BlackFade blackFade;
        [SerializeField] private UI_StartPanel startPanel;
        [SerializeField] private Image background;
        [SerializeField] private Image panel;
        [SerializeField] private GameObject[] starsOff;
        [SerializeField] private GameObject[] starsOn;
        [SerializeField] private TMP_Text txtResult;
        [SerializeField] private Button btnNext;
        
        private bool isResetting = false;

        private void Start()
        {
            FinishLine.OnCrossFinish += Show;
        }

        private void Show()
        {
            float score = ScoreManager.Instance.GetScore();
            
            if (score >= 0.9f) txtResult.text = "Perfect!";
            else if (score >= 0.7f) txtResult.text = "Great!";
            else if (score >= 0.4f) txtResult.text = "Good!";
            else txtResult.text = "Try again!";
            
            starsOn[0].SetActive(score >= 0.4f);
            starsOn[1].SetActive(score >= 0.7f);
            starsOn[2].SetActive(score >= 0.9f);

            btnNext.interactable = score >= 0.4f;
            
            background.gameObject.SetActive(true);
            background.DOFade(192/255f, 0.5f);
            panel.transform.localScale = Vector3.zero;
            panel.transform.DOScale(Vector3.one, 0.5f);
        }

        public void OnClickNext()
        {
            if (isResetting) return;
        
            StartCoroutine(NextCoroutine());
            isResetting = true;
        }
        
        private IEnumerator NextCoroutine()
        {
            yield return blackFade.ShowCoroutine();
            OnGameNext?.Invoke();
            background.gameObject.SetActive(false);
        
            yield return blackFade.HideCoroutine();
            startPanel.StartLevel();
            isResetting = false;
        }
    }
}

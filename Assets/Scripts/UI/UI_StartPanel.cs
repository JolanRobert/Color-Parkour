using System.Collections;
using DG.Tweening;
using Managers;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_StartPanel : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Image backgroundCountdown;
        [SerializeField] private TMP_Text txtCountdown;

        private int countdown = 3;
    
        private void Start()
        {
            StartLevel();
            UI_LosePanel.OnGameReset += Reset;
            UI_WinPanel.OnGameNext += Reset;
        }

        public void StartLevel()
        {
            backgroundCountdown.gameObject.SetActive(true);
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            countdown--;

            if (countdown == 0)
            {
                txtCountdown.text = "GO";
                backgroundCountdown.DOFade(0, 0.3f).onComplete += () =>
                {
                    gameObject.SetActive(false);
                    playerController.InitMovement();
                };
            }
            else
            {
                txtCountdown.text = countdown.ToString();
                StartCoroutine(CountdownCoroutine());
            }
        }

        private void Reset()
        {
            gameObject.SetActive(true);
            countdown = 3;
            txtCountdown.text = countdown.ToString();
        }
    }
}

using DG.Tweening;
using GameElements;
using Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        [SerializeField] private Image fillImage;
        [SerializeField] private GameObject firstStar;
        [SerializeField] private GameObject secondStar;
        [SerializeField] private GameObject thirdStar;

        private float currentCoins = 0;
        private float maxCoins = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayerCollision.OnCoinCollect += UpdateBar;
            UI_LosePanel.OnGameReset += Reset;
            UI_WinPanel.OnGameNext += Reset;
        }

        public void SetMaxCoins(int value)
        {
            maxCoins = value;
        }

        public float GetScore()
        {
            return currentCoins / maxCoins;
        }

        private void UpdateBar(Coin coin)
        {
            currentCoins++;
            float newFillAmount = currentCoins / maxCoins;
            fillImage.DOFillAmount(newFillAmount, 0.3f);
            
            if (newFillAmount >= 0.4f) UnlockStar(firstStar);
            if (newFillAmount >= 0.7f) UnlockStar(secondStar);
            if (newFillAmount >= 0.9f) UnlockStar(thirdStar);
        }

        private void UnlockStar(GameObject star)
        {
            if (star.activeSelf) return;
            
            star.SetActive(true);
            star.transform.DOScale(new Vector3(2f,2f,2f), 0.5f).SetLoops(2, LoopType.Yoyo);
        }

        public void Reset()
        {
            currentCoins = 0;
            
            fillImage.fillAmount = 0;
            firstStar.SetActive(false);
            secondStar.SetActive(false);
            thirdStar.SetActive(false);
        }
    }
}

using System;
using GameElements;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UI_LosePanel losePanel;

        [SerializeField] private ParticleSystem coinFX;
        [SerializeField] private ParticleSystem coinStarFX;

        public static Action<Coin> OnCoinCollect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                OnCoinCollect?.Invoke(coin);
                coinFX.Play();
                coinStarFX.Play();
            }
            
            else if (other.TryGetComponent(out Wall wall))
            {
                if (playerController.ColorSwap.CurrentColor == wall.CurrentColor) return;
                
                playerController.StopMovement();
                losePanel.Show();
            }
        }
    }
}

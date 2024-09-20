using System;
using Player;
using UnityEngine;

namespace GameElements
{
    public class FinishLine : MonoBehaviour
    {
        public static Action OnCrossFinish;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                playerController.StopMovement();
                OnCrossFinish?.Invoke();
            }
        }
    }
}

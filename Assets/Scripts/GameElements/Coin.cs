using DG.Tweening;
using UnityEngine;

namespace GameElements
{
    public class Coin : MonoBehaviour
    {
        private void Start()
        {
            //transform.DOMoveY(transform.position.y + 0.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
            transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private void OnTriggerEnter(Collider other)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}

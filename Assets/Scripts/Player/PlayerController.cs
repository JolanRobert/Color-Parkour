using DG.Tweening;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerCollision Collision => playerCollision;
        public PlayerColorSwap ColorSwap => playerColorSwap;
        
        [SerializeField] private PlayerCollision playerCollision;
        [SerializeField] private PlayerColorSwap playerColorSwap;
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private TrailRenderer firstTrail;
        [SerializeField] private TrailRenderer secondTrail;
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float moveAmount = 0.95f;

        private Vector3 startPosition;
        private float currentX = 0;
        private float currentForwardVelocity;

        private void Awake()
        {
            startPosition = transform.position;
        }

        private void Start()
        {
            UI_LosePanel.OnGameReset += Reset;
            UI_WinPanel.OnGameNext += Reset;
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector3(0, 0, currentForwardVelocity);
        }

        public void InitMovement()
        {
            currentForwardVelocity = forwardSpeed;
        }

        public void StopMovement()
        {
            currentForwardVelocity = 0;
            transform.DOKill();
        }
    
        public void MoveLeft()
        {
           if (currentX < -0.1f || currentForwardVelocity == 0) return;

            currentX -= moveAmount;
            transform.DOKill();
            transform.DOMoveX(currentX, 0.2f);
        }

        public void MoveRight()
        {
            if (currentX > 0.1f || currentForwardVelocity == 0) return;
        
            currentX += moveAmount;
            transform.DOKill();
            transform.DOMoveX(currentX, 0.2f);
        }
    
        private void Reset()
        {
            transform.position = startPosition;
            firstTrail.Clear();
            secondTrail.Clear();
            currentX = 0;
            ColorSwap.SetColor(GameColor.Blue);
        }
    }
}

using Player;
using UnityEngine;

namespace UI
{
    public class UI_PlayerInputs : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
    
        public void OnClickLeft()
        {
            playerController.MoveLeft();
        }
    
        public void OnClickChangeColor()
        {
            playerController.ColorSwap.ChangeColor();
        }

        public void OnClickRight()
        {
            playerController.MoveRight();
        }
    }
}

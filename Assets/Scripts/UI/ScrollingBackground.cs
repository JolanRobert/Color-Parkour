using Player;
using UnityEngine;

namespace UI
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private float offsetZ;

        private Material matInstance;

        private void Awake()
        {
            matInstance = meshRenderer.material;
        }
    
        private void Update()
        {
            Vector3 playerPos = playerController.transform.position;
            transform.position = new Vector3(0, playerPos.y, playerPos.z + offsetZ);
        }

        public void ChangeColor(Color newColor)
        {
            matInstance.SetColor("_Color", newColor);
        }
    }
}

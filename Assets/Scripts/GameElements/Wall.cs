using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace GameElements
{
    public class Wall : MonoBehaviour
    {
        public GameColor CurrentColor => gameColor;
        
        [SerializeField] private MeshRenderer wallRenderer;
        [SerializeField] private MeshRenderer firstPillarRenderer;
        [SerializeField] private MeshRenderer secondPillarRenderer;
        [SerializeField] private GameColor gameColor;
        [SerializeField] private SerializedDictionary<GameColor, Material> wallMaterials;
        [SerializeField] private SerializedDictionary<GameColor, Material> pillarMaterials;

        private void OnValidate()
        {
            wallRenderer.material = wallMaterials[gameColor];
            firstPillarRenderer.material = pillarMaterials[gameColor];
            secondPillarRenderer.material = pillarMaterials[gameColor];
        }
    }
}

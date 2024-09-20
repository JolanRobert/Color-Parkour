using System;
using Data;
using UI;
using UnityEngine;

namespace Managers
{
    public class LayoutManager : MonoBehaviour
    {
        [SerializeField] private LayoutData[] allLayouts;

        private int currentIndex = 0;

        private void Start()
        {
            UI_LosePanel.OnGameReset += Reset;
            UI_WinPanel.OnGameNext += NextLevel;
            ScoreManager.Instance.SetMaxCoins(allLayouts[currentIndex].MaxCoins);
        }

        public void LoadLayout()
        {
            LayoutData layout = allLayouts[currentIndex];
            if (layout == null)
            {
                Debug.LogError("No layout to load");
                return;
            }
        
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        
            for (int i = 0; i < layout.LayoutElements.Count; i++)
            {
                GameObject newObject = Instantiate(layout.LayoutElements[i], new Vector3(0,0, i * 10), Quaternion.identity, transform);
            }
        }

        private void NextLevel()
        {
            currentIndex++;
            if (currentIndex >= allLayouts.Length) currentIndex = 0;
            ScoreManager.Instance.SetMaxCoins(allLayouts[currentIndex].MaxCoins);
            LoadLayout();
        }

        private void Reset()
        {
            LoadLayout();
        }
    }
}

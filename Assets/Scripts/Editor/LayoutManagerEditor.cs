using Managers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LayoutManager))]
    public class LayoutManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LayoutManager layoutManager = (LayoutManager)target;

            if (GUILayout.Button("Load Layout"))
            {
                layoutManager.LoadLayout();
            }
        }
    }
}

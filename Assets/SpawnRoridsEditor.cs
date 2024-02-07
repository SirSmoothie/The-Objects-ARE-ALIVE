using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rory
{
    [CustomEditor(typeof(SpawnRorids))]
    public class SpawnRoridsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Spawn Boids"))
            {
                (target as SpawnRorids)?.Spawn();
            }
        }
    }
}

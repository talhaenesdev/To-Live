using UnityEditor;
using UnityEngine;

namespace EnemySystem.Scripts.Data.Config
{
    [CustomEditor(typeof(CD_Enemy))]
    public class InspectorButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CD_Enemy test = (CD_Enemy)target;

            if (GUILayout.Button("Spawn Enemy"))
            {
                test.AddEnemy();
            }
        }
    }

}

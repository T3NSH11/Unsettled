using UnityEditor;
using UnityEngine;

public class SpawnPath : EditorWindow
{
    GameObject nodeObject;
    bool Spawning = false;
    [MenuItem("Tools/Create Path")]
    public static void ShowWindow()
    {
        GetWindow(typeof(SpawnPath));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn Path", EditorStyles.boldLabel);
        nodeObject = EditorGUILayout.ObjectField("Node Object", nodeObject, typeof(GameObject), false) as GameObject;
        if (GUILayout.Button("Start Creating Path"))
        {
            Spawning = true;
        }

        if (GUILayout.Button("Stop Creating Path"))
        {
            Spawning = false;
        }

        if (Spawning)
        {
            SpawnNode();
        }
    }

    private void SpawnNode()
    {
        GameObject NewNode;

        if (Input.GetMouseButtonDown(0))
        {
            Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(worldRay, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.gameObject != null)
                {
                    NewNode = Instantiate(nodeObject) as GameObject;
                    NewNode.transform.position = hitInfo.point;
                }
            }
        }
    }
}

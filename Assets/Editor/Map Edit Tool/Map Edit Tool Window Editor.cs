/*using UnityEngine;
using UnityEditor;

public class MapEditToolWindowEditor : EditorWindow
{
    string[] MapEditorType = { "Create", "Delete", "Setting Change" };
    int MapEditorTypeIndex = 0;

    string[] BlockType = { "Block", "Block Entity", "Slab", "Stairs" };
    int BlockTypeIndex = 0;

    [MenuItem("Window/Map Edit Tool")]
    public static void ShowWindow() => GetWindow<MapEditToolWindowEditor>().titleContent = new GUIContent("Map Edit Tool");

    Rect buttonRect;
    void OnGUI()
    {
        GUILayout.Label("Map Editor", EditorStyles.boldLabel);

        MapEditorTypeIndex = GUILayout.Toolbar(MapEditorTypeIndex, MapEditorType);

        if (MapEditorTypeIndex == 0)
        {
            GUILayout.Label("Block Type");
            BlockTypeIndex = EditorGUILayout.Popup(BlockTypeIndex, BlockType);
        }
    }
}*/
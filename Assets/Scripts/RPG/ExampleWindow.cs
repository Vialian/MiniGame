using UnityEditor;
using UnityEngine;

public class ExampleWindow : EditorWindow {

    Color color;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }

    private void OnGUI()
    {
        //window code
        GUILayout.Label("Color the selected objecets!", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("COLORIZE!"))
        {
            Colorize();
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}

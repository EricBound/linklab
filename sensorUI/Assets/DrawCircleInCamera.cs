using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircleInCamera : MonoBehaviour
{
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIContent content;
    GUIStyle style = new GUIStyle();

    void Start()
    {
        content = new GUIContent("X", BoxTexture, "This is a tooltip");

        // Position the Text and Texture in the center of the box
        style.alignment = TextAnchor.MiddleCenter;

        // Position the Text below the Texture (rather than to the right of it)
        style.imagePosition = ImagePosition.ImageAbove;
    }

    void OnGUI()
    {
        if (gameObject.GetComponent<Camera>() == Camera.main) 
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content, style);
    }
}

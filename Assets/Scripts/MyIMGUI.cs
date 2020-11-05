using UnityEngine;
using System.Collections;

public class MyIMGUI : MonoBehaviour
{
    [SerializeField] private HealthController _playerHealthController;
    [SerializeField] Vector2 pos = new Vector2(20,40);
    [SerializeField] Vector2 size = new Vector2(60,20);
    [SerializeField] private Texture2D progressBarFull;

    private Texture2D progressBarEmpty;

    void OnGUI()
    {
        DrawHealthBar();
    }


    private void DrawHealthBar()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * _playerHealthController.RelativeHealthValue, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();
    }
}











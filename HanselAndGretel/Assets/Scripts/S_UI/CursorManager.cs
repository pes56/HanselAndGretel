using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultCursor;     // The default cursor sprite
    public Texture2D clickCursor;       // The cursor sprite when clicking

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}

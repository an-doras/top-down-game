using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hotpos = new Vector2(16, 48); // chinh vi tri con tro chuot
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hotpos, CursorMode.Auto);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotpos, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hotpos, CursorMode.Auto);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorReload, hotpos, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(cursorNormal, hotpos, CursorMode.Auto);
        }
    }
}

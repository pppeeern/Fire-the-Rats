using UnityEngine;

public class HideCursorOnHover : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true; // Ensure cursor is initially visible
    }

    private void OnMouseEnter()
    {
        Cursor.visible = false; // Hide cursor when mouse enters the GameObject's area
    }

    private void OnMouseExit()
    {
        Cursor.visible = true; // Show cursor when mouse exits the GameObject's area
    }
}

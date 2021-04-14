

using UnityEngine;

public class Cursor : Cube
{
    [SerializeField] private bool isActive;

    public void Toggle()
    {
        isActive = !isActive;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
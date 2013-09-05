using UnityEngine;

public class CenterOnObject : MonoBehaviour
{
    public UIDraggablePanel dragPanel;

    void Start ()
    {
        Vector3 newPos = dragPanel.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position);
		newPos.y = 512.0f;
        SpringPanel.Begin(dragPanel.gameObject, -newPos, 4f);
    }
}



using UnityEngine;

    /// <summary>
    /// Manual version of NGUI's UICenterOnChild -stripped down and adapted for compatibility with NGUI free
    /// </summary>
public class UICenterOnChildManual : MonoBehaviour
{
    UIDraggablePanel mDrag;
    GameObject mCenteredObject;
    UIPanel mDragPanel;

    /// <summary>
    /// Recenter the draggable list on targetTrans.
    /// </summary>

    public void CenterOnChild( Transform targetTrans )
    {
        if (mDrag == null)
        {
            mDrag = NGUITools.FindInParents<UIDraggablePanel>(gameObject);
            
            mDragPanel = gameObject.GetComponent ( typeof ( UIPanel ) ) as UIPanel;

            if (mDrag == null)
            {
                Debug.LogWarning(GetType() + " requires " + typeof(UIDraggablePanel) + " on a parent object in order to work", this);
                enabled = false;
                return;
            }
        }
        if (mDragPanel == null) return;

        // Calculate the panel's center in world coordinates
        Vector4 clip = mDragPanel.clipRange;
        Transform dt = mDragPanel.cachedTransform;
        Vector3 center = dt.localPosition;
        center.x += clip.x;
        center.y += clip.y;
        center = dt.parent.TransformPoint(center);

        // Offset this value by the momentum
        mDrag.currentMomentum = Vector3.zero;

        // Figure out the difference between the chosen child and the panel's center in local coordinates
        Vector3 cp = dt.InverseTransformPoint(targetTrans.position);
        Vector3 cc = dt.InverseTransformPoint(center);
        Vector3 offset = cp - cc;

        // Offset shouldn't occur if blocked by a zeroed-out scale
        if (mDrag.scale.x == 0f) offset.x = 0f;
        if (mDrag.scale.y == 0f) offset.y = 0f;
        if (mDrag.scale.z == 0f) offset.z = 0f;

        // Spring the panel to this calculated position
        SpringPanel.Begin(mDrag.gameObject, dt.localPosition - offset, 8f);
    }
}
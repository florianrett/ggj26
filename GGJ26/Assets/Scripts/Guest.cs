using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Guest : MonoBehaviour
{
    // The location this guest's mask has to be attached to
    [SerializeField] private GameObject maskLocation;
    
    // The mask script associated with this guest
    private Mask mask;
    
    private void OnMouseDown()
    {
        // ignore mouse when it is hovering UI
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        Debug.Log("Clicked on guest");
        
        FindAnyObjectByType<GameMode>().OpenDialogMenu(mask.GetVariant());
    }

    public void SetMask(GameObject maskObject)
    {
        maskObject.transform.SetParent(maskLocation.transform, false);
        mask = maskObject.GetComponent<Mask>();
    }

    public MaskVariant GetMaskVariant()
    {
        return mask.GetVariant();
    }
}

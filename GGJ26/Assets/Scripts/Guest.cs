using System;
using UnityEngine;

public class Guest : MonoBehaviour
{
    // The location this guest's mask has to be attached to
    [SerializeField] private GameObject maskLocation;
    
    // The mask script associated with this guest
    private Mask mask;
    
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    public void SetMask(GameObject maskObject)
    {
        maskObject.transform.SetParent(maskLocation.transform, false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    
    [SerializeField] private DialogOptions dialogOption;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    public void OnButtonPressed()
    {
        FindFirstObjectByType<DialogMenu>().DialogButtonPressed(dialogOption);
    }
}

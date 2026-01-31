using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    
    [SerializeField] private DialogOptions dialogOption;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private String content;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textMesh.text = content + " (" + FindFirstObjectByType<GameMode>().GetPenaltyForDialogOptions(dialogOption) + "%)";
    }

    public void OnButtonPressed()
    {
        FindFirstObjectByType<DialogMenu>().DialogButtonPressed(dialogOption);
    }
}

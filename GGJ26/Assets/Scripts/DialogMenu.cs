using TMPro;
using UnityEngine;

public enum DialogOptions
{
    Eyes,
    Ears,
    Nose,
    Mouth,
    Any1,
    Any2,
    Any3,
    All,
    Exit
}

public class DialogMenu : MonoBehaviour
{
    [SerializeField] private Mask mask;

    [SerializeField] private GameObject responsePanel;
    [SerializeField] private TextMeshProUGUI responseText;
    
    private GameMode gameMode;
    
    void Start()
    {
        gameMode = FindFirstObjectByType<GameMode>();
    }
    
    public void Open(MaskVariant maskVariant)
    {
        mask.SetVariant (maskVariant);
        responsePanel.SetActive(false);
        gameObject.SetActive (true);
    }

    public void DialogButtonPressed(DialogOptions dialogOption)
    {
        if (gameMode.EvaluateDialogOption(dialogOption, mask.GetVariant()))
        {
            ShowResponse("That was correct.");
        }
        else
        {
            ShowResponse("You are talking nonsense!");
        }
    }

    private void ShowResponse(string response)
    {
        responsePanel.SetActive(true);
        responseText.text = response;
    }
}

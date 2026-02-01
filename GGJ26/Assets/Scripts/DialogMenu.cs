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

    [SerializeField] private string[] correctResponses;
    [SerializeField] private string[] incorrectResponses;
    
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
            ShowResponse(correctResponses[Random.Range(0, correctResponses.Length)]);
            AudioManager.Instance.playaudioGood();
        }
        else
        {
            ShowResponse(incorrectResponses[Random.Range(0, incorrectResponses.Length)]);
            AudioManager.Instance.playaudioBad();
        }
    }

    private void ShowResponse(string response)
    {
        responsePanel.SetActive(true);
        responseText.text = response;
    }
}

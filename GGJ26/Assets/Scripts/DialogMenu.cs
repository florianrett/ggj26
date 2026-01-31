using UnityEngine;

public enum DialogOptions
{
    Hair,
    Eyes,
    Ears,
    Nose,
    Mouth,
    Any1,
    Any2,
    Any3,
    Any4,
    All
}

public class DialogMenu : MonoBehaviour
{
    [SerializeField] private Mask mask;

    private GameMode gameMode;
    
    void Start()
    {
        gameMode = FindFirstObjectByType<GameMode>();
    }
    
    public void Open(MaskVariant maskVariant)
    {
        mask.SetVariant (maskVariant);
        gameObject.SetActive (true);
    }

    public void DialogButtonPressed(DialogOptions dialogOption)
    {
        if (gameMode.EvaluateDialogOption(dialogOption, mask.GetVariant()))
        {
            // TODO: actual answer menu
            Debug.Log("That was correct.");
        }
        else
        {
            Debug.Log("You are talking nonsense!");
        }
    }
}

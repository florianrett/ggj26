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
    [SerializeField] private GameObject audiomanager;

    private AudioManager audioManger;
    private AudioSource responseaudiogood;
    private AudioSource responseaudiobad;
    private GameMode gameMode;
    
    void Start()
    {
        audioManger = audiomanager.GetComponent<AudioManager>();
        responseaudiogood = audiomanager.GetComponentInChildren<AudioSource>();
        responseaudiobad = audiomanager.GetComponent<AudioSource>();
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
            
            AudioManager.Instance.playaudioGood();
            
        }
        else
        {
            Debug.Log("You are talking nonsense!");
            audioManger.SetMusicVolume(20);
            AudioManager.Instance.playaudioBad();
            audioManger.SetMusicVolume(95);
        }
    }
}

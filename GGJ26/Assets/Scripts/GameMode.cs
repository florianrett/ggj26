using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject roomLeft;
    [SerializeField] private GameObject roomMiddle;
    [SerializeField] private GameObject roomRight;
    [SerializeField] private DialogMenu dialogMenu;
    [SerializeField] private ScoreBoard scoreBoard;
    [SerializeField] private Button roomButtonRight; 
    [SerializeField] private Button roomButtonLeft;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gameOverScreen;
    
    [SerializeField] private MaskManager maskManager;

    [SerializeField] private MaskVariant playerMask;

    [SerializeField] private int suspicionAny1 = 5;
    [SerializeField] private int suspicionAny2 = 10;
    [SerializeField] private int suspicionAny3 = 40;
    [SerializeField] private int suspicionAllMatch = 50;
    [SerializeField] private int suspicionDirect = 30;

    private int currentRoom = 1;
    private int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Enable all rooms so all guest objects are active for initialization
        roomLeft.SetActive(true);
        roomMiddle.SetActive(true);
        roomRight.SetActive(true);

        Guest[] guests = FindObjectsByType<Guest>(FindObjectsSortMode.None);

        foreach (Guest guest in guests)
        {
            Debug.Log(guest.name);
            guest.SetMask(maskManager.GetRandomMask());
        }
        
        int targetGuestIndex = UnityEngine.Random.Range(0, guests.Length);
        playerMask = guests[targetGuestIndex].GetMaskVariant();
        
        roomButtonLeft.onClick.AddListener(delegate { ShowRoom(currentRoom - 1); });
        roomButtonRight.onClick.AddListener(delegate { ShowRoom(currentRoom + 1); });
        ShowRoom(1);
        dialogMenu.gameObject.SetActive(false);
        scoreBoard.gameObject.SetActive(true);
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        tutorial.SetActive(true);
    }

    public void ShowRoom(int room)
    {
        if (room is < 0 or > 2)
            return;
        currentRoom = room;
        
        roomLeft.SetActive(room == 0);
        roomMiddle.SetActive(room == 1);
        roomRight.SetActive(room == 2);
        
        roomButtonLeft.gameObject.SetActive(room != 0);
        roomButtonRight.gameObject.SetActive(room != 2);
    }

    public void OpenDialogMenu(MaskVariant variant)
    {
        dialogMenu.gameObject.SetActive(true);
        dialogMenu.Open(variant);
    }

    public bool EvaluateDialogOption(DialogOptions option, MaskVariant npcMask)
    {
        bool result = ComparePlayerMask(npcMask, option);
        if (result)
        {
            HandleReward(option);
        }
        else
        {
            HandlePunishment(option);
        }

        return result;
    }

    public int GetPenaltyForDialogOptions(DialogOptions option)
    {
        switch (option)
        {
            case DialogOptions.Ears:
                return suspicionDirect;
            case DialogOptions.Eyes:
                return suspicionDirect;
            case DialogOptions.Nose:
                return suspicionDirect;
            case DialogOptions.Mouth:
                return suspicionDirect;
            case DialogOptions.Any1:
                return suspicionAny1;
            case DialogOptions.Any2:
                return suspicionAny2;
            case DialogOptions.Any3:
                return suspicionAny3;
            case DialogOptions.All:
                return suspicionAllMatch;
            case DialogOptions.Exit:
                return 0;
        }

        return 0;
    }
    
    // Compare player mask with a specific NPC mask for a given dialog optiion
    private bool ComparePlayerMask(MaskVariant npcMask, DialogOptions option)
    {
        switch (option)
        {
            case DialogOptions.Ears:
                return npcMask.ears == playerMask.ears;
            case DialogOptions.Eyes:
                return npcMask.eyes == playerMask.eyes;
            case DialogOptions.Nose:
                return npcMask.nose == playerMask.nose;
            case DialogOptions.Mouth:
                return playerMask.mouth == npcMask.mouth;
            case DialogOptions.Any1:
                return playerMask.CountMatchingFeatures(npcMask) >= 1;
            case DialogOptions.Any2:
                return playerMask.CountMatchingFeatures(npcMask) >= 2;
            case DialogOptions.Any3:
                return playerMask.CountMatchingFeatures(npcMask) >= 3;
            case DialogOptions.All:
                if (playerMask.CountMatchingFeatures(npcMask) >= 4)
                {
                    victoryScreen.SetActive(true);
                    return true;
                }

                return false;
        }
        
        Debug.LogError("Should be unreachable");
        return false;
    }

    private void HandleReward(DialogOptions option)
    {
        
    }

    private void HandlePunishment(DialogOptions option)
    {
        AddScore(GetPenaltyForDialogOptions(option));
    }

    private void AddScore(int value)
    {
        score += value;
        scoreBoard.SetScore(score, value, true);

        if (score >= 100)
        {
            gameOverScreen.SetActive(true);
        }
    }
}

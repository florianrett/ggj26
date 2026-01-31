using UnityEngine;
using System.Collections.Generic;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject room1;
    [SerializeField] private GameObject room2;
    [SerializeField] private DialogMenu dialogMenu;
    [SerializeField] private MaskManager maskManager;

    private MaskVariant playerMask;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        room1.SetActive(true);
        room2.SetActive(true);

        Guest[] guests = FindObjectsByType<Guest>(FindObjectsSortMode.None);

        foreach (Guest guest in guests)
        {
            Debug.Log(guest.name);
            guest.SetMask(maskManager.GetRandomMask());
        }
        
        int targetGuestIndex = UnityEngine.Random.Range(0, guests.Length);
        playerMask = guests[targetGuestIndex].GetMaskVariant();
        
        room1.SetActive(true);
        room2.SetActive(false);
        dialogMenu.gameObject.SetActive(false);
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
            case DialogOptions.Hair:
                return npcMask.hair == playerMask.hair;
            case DialogOptions.Any1:
                return playerMask.CountMatchingFeatures(npcMask) >= 1;
            case DialogOptions.Any2:
                return playerMask.CountMatchingFeatures(npcMask) >= 2;
            case DialogOptions.Any3:
                return playerMask.CountMatchingFeatures(npcMask) >= 3;
            case DialogOptions.Any4:
                return playerMask.CountMatchingFeatures(npcMask) >= 4;
            case DialogOptions.All:
                return playerMask.CountMatchingFeatures(npcMask) >= 4;
        }
        
        Debug.LogError("Should be unreachable");
        return false;
    }

    private void HandleReward(DialogOptions option)
    {
        
    }

    private void HandlePunishment(DialogOptions option)
    {
        
    }
}

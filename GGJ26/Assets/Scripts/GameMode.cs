using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject room1;
    [SerializeField] private GameObject room2;
    [SerializeField] private MaskManager maskManager;
    
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
        
        room1.SetActive(true);
        room2.SetActive(false);
    }
}

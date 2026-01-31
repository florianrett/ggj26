using UnityEngine;

public class MaskView : MonoBehaviour
{
    [SerializeField] Sprite[] eyeVariations;
    [SerializeField] Sprite[] hairVariations;
    [SerializeField] Sprite[] noseVariations;
    [SerializeField] Sprite[] mouthVariations;
    [SerializeField] Sprite[] earVariations;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView(MaskVariant variant)
    {
        // TODO: update sprites
    }
}

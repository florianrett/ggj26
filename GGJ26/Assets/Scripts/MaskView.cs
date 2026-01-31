using UnityEngine;

public class MaskView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hairSprite;
    [SerializeField] private SpriteRenderer eyesSprite;
    [SerializeField] private SpriteRenderer earsSprite;
    [SerializeField] private SpriteRenderer noseSprite;
    [SerializeField] private SpriteRenderer mouthSprite;
    
    // [SerializeField] private Sprite[] hairVariations;
    // [SerializeField] private Sprite[] eyeVariations;
    // [SerializeField] private Sprite[] earVariations;
    // [SerializeField] private Sprite[] noseVariations;
    // [SerializeField] private Sprite[] mouthVariations;
    
    [SerializeField] private Color[] hairVariations;
    [SerializeField] private Color[] eyeVariations;
    [SerializeField] private Color[] earVariations;
    [SerializeField] private Color[] noseVariations;
    [SerializeField] private Color[] mouthVariations;
    
    
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
        hairSprite.color = hairVariations[(int)variant.hair];
        eyesSprite.color = eyeVariations[(int)variant.eyes];
        earsSprite.color = earVariations[(int)variant.ears];
        noseSprite.color = noseVariations[(int)variant.nose];
        mouthSprite.color = mouthVariations[(int)variant.mouth];
    }
}

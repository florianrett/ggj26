using UnityEngine;

public class MaskView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer earsSprite;
    [SerializeField] private SpriteRenderer eyesSprite;
    [SerializeField] private SpriteRenderer mouthSprite;
    [SerializeField] private SpriteRenderer noseSprite;
    
    [SerializeField] private Sprite[] earVariations;
    [SerializeField] private Sprite[] eyeVariations;
    [SerializeField] private Sprite[] mouthVariations;
    [SerializeField] private Sprite[] noseVariations;
    
    // [SerializeField] private Color[] eyeVariations;
    // [SerializeField] private Color[] earVariations;
    // [SerializeField] private Color[] noseVariations;
    // [SerializeField] private Color[] mouthVariations;
    
    
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
        eyesSprite.sprite = eyeVariations[(int)variant.eyes];
        earsSprite.sprite = earVariations[(int)variant.ears];
        noseSprite.sprite = noseVariations[(int)variant.nose];
        mouthSprite.sprite = mouthVariations[(int)variant.mouth];
    }
}

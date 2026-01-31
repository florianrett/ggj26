using System;
using UnityEngine;

public enum HairVariants
{
    Variant1,
    Variant2,
    Variant3,
    [InspectorName(null)]
    MAX_VALUE
}

public enum EyeVariants
{
    Variant1,
    Variant2,
    Variant3,
    [InspectorName(null)]
    MAX_VALUE
}

public enum EarVariants
{
    Variant1,
    Variant2,
    Variant3,
    [InspectorName(null)]
    MAX_VALUE
}

public enum NoseVariants
{
    Variant1,
    Variant2,
    Variant3,
    [InspectorName(null)]
    MAX_VALUE
}

public enum MouthVariants
{
    Variant1,
    Variant2,
    Variant3,
    [InspectorName(null)]
    MAX_VALUE
}

[Serializable]
public struct MaskVariant
{
    public HairVariants hair;
    public EyeVariants eyes;
    public EarVariants ears;
    public NoseVariants nose;
    public MouthVariants mouth;
}

public class Mask : MonoBehaviour
{

    [SerializeField]
    MaskVariant _variant;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateView()
    {
        gameObject.GetComponent<MaskView>().UpdateView(_variant);
    }

    public void SetVariant(MaskVariant inVariant)
    {
        _variant = inVariant;
        
        UpdateView();
    }

    public MaskVariant GetVariant()
    {
        return _variant;
    }
}

using System;
using UnityEngine;

public enum HairVariants
{
    Variant1,
    [InspectorName(null)]
    MAX_VALUE
}

public enum EyeVariants
{
    Variant1,
    Variant2,
    Variant3,
    Variant4,
    [InspectorName(null)]
    MAX_VALUE
}

public enum EarVariants
{
    Variant1,
    Variant2,
    Variant3,
    Variant4,
    [InspectorName(null)]
    MAX_VALUE
}

public enum NoseVariants
{
    Variant1,
    Variant2,
    Variant3,
    Variant4,
    [InspectorName(null)]
    MAX_VALUE
}

public enum MouthVariants
{
    Variant1,
    Variant2,
    Variant3,
    Variant4,
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

    public int CountMatchingFeatures(MaskVariant otherMask)
    {
        int count = 0;
        // if (otherMask.hair == hair)
        //     count++;
        if (otherMask.eyes == eyes)
            count++;
        if (otherMask.ears == ears)
            count++;
        if (otherMask.nose == nose)
            count++;
        if (otherMask.mouth == mouth)
            count++;

        return count;
    }
}

public class Mask : MonoBehaviour
{
    [SerializeField]
    private MaskVariant variant;
    
    [SerializeField]
    private MaskView maskView;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateView();
    }

    void UpdateView()
    {
        maskView.UpdateView(variant);
    }

    public void SetVariant(MaskVariant inVariant)
    {
        variant = inVariant;
        
        UpdateView();
    }

    public MaskVariant GetVariant()
    {
        return variant;
    }
}

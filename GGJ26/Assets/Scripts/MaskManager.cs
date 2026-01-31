using System;
using System.Collections.Generic;
using UnityEngine;

public class MaskManager : MonoBehaviour
{
    [SerializeField] private GameObject maskPrefab;

    // Remaining available mask variants
    [SerializeField] private List<MaskVariant> remainingVariants;

    void Awake()
    {
        ResetMaskPool();
    }

    public void ResetMaskPool()
    {
        remainingVariants.Clear();

        EyeVariants eyes = EyeVariants.Variant1;
        while (eyes != EyeVariants.MAX_VALUE)
        {
            EarVariants ears = EarVariants.Variant1;
            while (ears != EarVariants.MAX_VALUE)
            {
                NoseVariants nose = NoseVariants.Variant1;
                while (nose != NoseVariants.MAX_VALUE)
                {
                    MouthVariants mouth = MouthVariants.Variant1;
                    while (mouth != MouthVariants.MAX_VALUE)
                    {
                        MaskVariant currentVariant = new MaskVariant
                        {
                            eyes = eyes,
                            ears = ears,
                            nose = nose,
                            mouth = mouth
                        };

                        remainingVariants.Add(currentVariant);
                        // Debug.Log("Adding mask variant" + hair + eyes + ears + nose + mouth);

                        mouth += 1;
                    }

                    nose += 1;
                }

                ears += 1;
            }

            eyes += 1;
        }
    }

    // Create a random unique mask
    public GameObject GetRandomMask()
    {
        if (remainingVariants.Count == 0)
        {
            Debug.LogError("No mask available!");
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, remainingVariants.Count);
        MaskVariant variant = remainingVariants[randomIndex];
        remainingVariants.RemoveAt(randomIndex);

        GameObject mask = Instantiate(maskPrefab);
        maskPrefab.GetComponent<Mask>().SetVariant(variant);

        return mask;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullTile : MonoBehaviour
{
    [SerializeField] private Renderer[] rend;
    [SerializeField] private Material dull;

    public void SetDull()
    {
        foreach (Renderer r in rend)
        {
            r.material = dull;
        }
    }
}

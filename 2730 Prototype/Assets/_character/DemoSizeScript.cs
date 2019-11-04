using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSizeScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [Range(0, 1)]
    [SerializeField] private float size;

    private void Update()
    {
        anim.SetFloat("size", size);
    }
}

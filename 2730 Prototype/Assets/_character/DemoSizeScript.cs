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

        size += Input.GetAxis("Horizontal") * Time.deltaTime;
        size = Mathf.Clamp01(size);

        anim.SetFloat("size", size);
        anim.SetBool("crouching", Input.GetKey(KeyCode.Space));
    }
}

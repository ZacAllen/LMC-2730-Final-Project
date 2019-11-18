using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpikeAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float[] rates;

    private Vector2[] values;

    private void Awake()
    {
        values = new Vector2[rates.Length];
    }
    private void Update()
    {
        for (int i = 0; i < rates.Length; i++)
        {
            values[i] += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * rates[i] * Time.deltaTime;
            values[i] = new Vector2(Mathf.Clamp01(values[i].x), Mathf.Clamp01(values[i].y));
        }

        anim.SetFloat("l0", values[0].x);
        anim.SetFloat("r0", values[0].y);

        anim.SetFloat("l1", values[1].x);
        anim.SetFloat("r1", values[1].y);

        anim.SetFloat("l2", values[2].x);
        anim.SetFloat("r2", values[2].y);

    }
}

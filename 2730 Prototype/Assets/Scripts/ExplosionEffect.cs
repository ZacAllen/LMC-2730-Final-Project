using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private Transform r;

    Vector3 refVel;


    public void Explode()
    {
        Debug.Log("exploding");
        system.Play();
        StartCoroutine(KillMe());
    }

    private IEnumerator KillMe()
    {
        float time = 0f;
        while (time < 0.8f)
        {
            r.localScale = Vector3.SmoothDamp(
                r.localScale,
                Vector3.zero,
                ref refVel,
                0.1f);




            time += Time.deltaTime;
            yield return null;
        }

        Destroy(r.gameObject);

    }
}

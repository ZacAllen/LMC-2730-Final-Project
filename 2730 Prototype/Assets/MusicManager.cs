using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;

    private void Start()
    {
        foreach (MusicManager m in FindObjectsOfType<MusicManager>())
        {
            if (m != this)
            {
                Destroy(this);
            }
        }
        source.clip = clips[0];
        source.Play();
        SceneManager.sceneLoaded += SetClip;
        DontDestroyOnLoad(this);
    }

    private void SetClip(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Instructions":
                trySet(0);
                break;
            case "Level 0":
                trySet(1);

                break;
            case "Level 1":
                trySet(2);

                break;
            case "Level 2":
                trySet(3);

                break;
            case "Level Select":
                trySet(0);
                break;
            case "Main Menu":
                trySet(0);
                break;
        }
    }

    private void trySet(int index)
    {
        if (source.clip != clips[index])
        {
            source.clip = clips[index];
            source.Play();
        }
    }
}

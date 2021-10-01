using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    public static SongController Instance;

    private void Awake()
    {
        if(Instance != null) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect { GOLD, CRATE, NOTIF }

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    public List<AudioClip> clipList;

    public Dictionary<SoundEffect, AudioClip> ClipDictionary = new Dictionary<SoundEffect, AudioClip>();

    [SerializeField] private GameObject audioSourcePrefab;
    public List<GameObject> audioSourceList;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        ClipDictionary[SoundEffect.GOLD] = clipList[0];
        ClipDictionary[SoundEffect.CRATE] = clipList[1];
        ClipDictionary[SoundEffect.NOTIF] = clipList[2];

    }

    void Update()
    {
        if (audioSourceList == null || audioSourceList.Count == 0) return;

        foreach (var audio in audioSourceList)
        {
            if (audio != null)
            {
                if (!audio.GetComponent<AudioSource>().isPlaying)
                {
                    Destroy(audio);
                }
            }
            else
            {
                audioSourceList.Remove(audio);
                break;
            }
        }
    }


    public void PlayAudio(SoundEffect sfx)
    {
        GameObject obj = Instantiate(audioSourcePrefab, transform);
        obj.GetComponent<AudioSource>().clip = ClipDictionary[sfx];
        obj.GetComponent<AudioSource>().Play();
        audioSourceList.Add(obj);
    }

}


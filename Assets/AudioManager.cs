using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameManager tempAudioPrefab;

    private void PlayAudioEffect(AudioClip clip)
    {
        GameObject obj = Instantiate(tempAudioPrefab).gameObject;
        tempAudioPrefab.GetComponent<AudioSource>().clip = clip;
    }
}

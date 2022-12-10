using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject tempAudioPrefab;
    [SerializeField] AudioClip audioPickup;
    [SerializeField] AudioClip audioDrop;
    [SerializeField] AudioClip audioCollectStar;
    [SerializeField] AudioClip levelCompleted;
    [SerializeField] AudioClip buttonKickoff;
    [SerializeField] AudioClip earthKicked;
    [SerializeField] AudioClip earthExplosion;

    private void PlayAudioEffect(AudioClip clip)
    {
        if (clip == null)
            return;

        GameObject obj = Instantiate(tempAudioPrefab).gameObject;
        tempAudioPrefab.GetComponent<AudioSource>().clip = clip;
    }

    private void OnEnable()
    {
        SpawnEarthButton.Clicked += PlayButtonKickoff;
        Star.Collected += PlayCollectedStar;
        KopernikMgr.KickedEarth += PlayEarthKicked;
        Planet.LevelCompleted += PlayLevelCompleted;
        Planet.Exploded += PlayEarthExplosion;
        Draggable.PickedUp += PlayPickedUp;
        Draggable.Dropped += PlayDropped;
    }

    private void OnDisable()
    {
        SpawnEarthButton.Clicked -= PlayButtonKickoff;
        Star.Collected -= PlayCollectedStar;
        KopernikMgr.KickedEarth -= PlayEarthKicked;
        Planet.LevelCompleted -= PlayLevelCompleted;
        Planet.Exploded -= PlayEarthExplosion;
        Draggable.PickedUp -= PlayPickedUp;
        Draggable.Dropped -= PlayDropped;
    }

    private void PlayButtonKickoff()
    {
        PlayAudioEffect(buttonKickoff);
    }

    private void PlayCollectedStar()
    {
        PlayAudioEffect(audioCollectStar);
    }

    private void PlayEarthKicked()
    {
        print("kicked audio");
        PlayAudioEffect(earthKicked);
    }

    private void PlayLevelCompleted()
    {
        PlayAudioEffect(levelCompleted);
    }

    private void PlayEarthExplosion()
    {
        PlayAudioEffect(earthExplosion);
    }

    private void PlayPickedUp()
    {
        print("pickedup");
        PlayAudioEffect(audioPickup);
    }
    private void PlayDropped()
    {
        PlayAudioEffect(audioDrop);
    }
}

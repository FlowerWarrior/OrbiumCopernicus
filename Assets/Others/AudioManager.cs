using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject tempAudioPrefab;
    [SerializeField] AudioField audioPickup;
    [SerializeField] AudioField audioDrop;
    [SerializeField] AudioField audioCollectStar;
    [SerializeField] AudioField levelCompleted;
    [SerializeField] AudioField buttonKickoff;
    [SerializeField] AudioField earthKicked;
    [SerializeField] AudioField earthExplosion;
    [SerializeField] AudioField ufoIn;
    [SerializeField] AudioField ufoOut;

    [System.Serializable]
    public struct AudioField
    {
        public AudioClip clip;
        public float volume;
    }

    private void PlayAudioEffect(AudioField audioField)
    {
        if (audioField.clip == null)
            return;

        GameObject obj = Instantiate(tempAudioPrefab).gameObject;
        obj.GetComponent<AudioSource>().clip = audioField.clip;
        obj.GetComponent<AudioSource>().volume = audioField.volume;
        obj.GetComponent<AudioSource>().Play();
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
        UFO.UfoIn += PlayUfoIn;
        UFO.UfoOut += PlayUfoOut;
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
        UFO.UfoIn -= PlayUfoIn;
        UFO.UfoOut -= PlayUfoOut;
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

    private void PlayUfoIn()
    {
        PlayAudioEffect(ufoIn);
    }

    private void PlayUfoOut()
    {
        PlayAudioEffect(ufoOut);
    }
}

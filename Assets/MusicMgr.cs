using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMgr : MonoBehaviour
{
    public static MusicMgr instance;
    [SerializeField] AudioSource audioMenu;
    [SerializeField] AudioSource audioGameplay;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioMenu.enabled = true;
        audioGameplay.enabled = false;
    }

    public void SetGameplayMusic()
    {
        audioMenu.enabled = false;
        audioGameplay.enabled = true;
    }
}

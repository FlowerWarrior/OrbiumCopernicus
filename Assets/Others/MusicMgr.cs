using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMgr : MonoBehaviour
{
    public static MusicMgr instance = null;
    [SerializeField] AudioSource audioMenu;
    [SerializeField] AudioSource audioGameplay;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
           Destroy(gameObject);
        }
        else
        {
            instance = this;

        }
    }

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

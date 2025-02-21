using UnityEngine;
using System;
using UnityEngine.Rendering;

public class SoundPlayer : MonoBehaviour
{    
    [SerializeField] private AudioSource audiosource; 
    public delegate void ListenerEvent(Casette.GENRE genre);
    public static event ListenerEvent OnSoundUpdated;

    public void PlayMusic(AudioClip clip, Casette.GENRE genre)
    {
        audiosource.Stop();
        audiosource.loop = true; 
        audiosource.clip = clip; 
        audiosource.Play();
        SendSoundUpdate(genre); 
    }

    public void StopPlaying()
    {
        audiosource.Stop();
        SendSoundUpdate(Casette.GENRE.IDLE);
    }

    private void SendSoundUpdate(Casette.GENRE genre)
    {
        if(OnSoundUpdated != null)
        {
            OnSoundUpdated(genre);
        }
    }

    #region singletonstuff
    private static SoundPlayer instance; 
    public static SoundPlayer Instance
    {
        get 
        {
            if (instance == null)
            {
                //SetupInstance(); 
            }
            return instance; 
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}

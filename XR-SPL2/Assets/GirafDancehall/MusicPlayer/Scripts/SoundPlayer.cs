using UnityEngine;
using System;
using UnityEngine.Rendering;

public class SoundPlayer : MonoBehaviour
{    
    [SerializeField] private AudioSource audiosource; 

    private AudioClip loadedclip = null; 
    private Casette.GENRE currentgenre = Casette.GENRE.IDLE; 
    public delegate void ListenerEvent(Casette.GENRE genre);
    public static event ListenerEvent OnSoundUpdated;

    public void PlayMusic()
    {
        audiosource.Stop();
        audiosource.loop = true; 
        audiosource.clip = loadedclip; 
        audiosource.Play();
        SendSoundUpdate(currentgenre); 
    }
    
    public void LoadClip(AudioClip clip, Casette.GENRE newgenre)
    {
        loadedclip = clip; 
        currentgenre = newgenre;
        //SendSoundUpdate(currentgenre);
    }

    public void StartPlaying()
    {
        audiosource.clip = loadedclip; 
        if(audiosource.clip && !audiosource.isPlaying)
        {
            audiosource.Play();
            SendSoundUpdate(currentgenre);
        }
    }

    public void StopPlaying()
    {
        if(audiosource.isPlaying)
        {
            audiosource.Stop();
            SendSoundUpdate(Casette.GENRE.IDLE);
        }
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

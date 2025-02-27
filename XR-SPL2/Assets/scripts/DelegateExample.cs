using UnityEngine;

public class DelegateExample : MonoBehaviour
{

    public AudioSource audiosource; 
    public delegate void SoundEvent(AudioClip clip);
    SoundEvent soundDelegate;

    private void Awake()
    {
        soundDelegate = PlaySound;    
    }

    private void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip); 
    }

    private void PlayLooped(AudioClip clip)
    {
        audiosource.loop = true;
        audiosource.PlayOneShot(clip);
    }
}

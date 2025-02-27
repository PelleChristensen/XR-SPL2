using UnityEngine;

public class PlaybackUI : MonoBehaviour
{
    public CanvasGroup canvas; 

    void Start()
    {
        canvas.alpha = 0; 
        canvas.interactable = false; 

        SoundPlayer.OnSoundUpdated += OnSoundUpdated; 
    }

    private void OnSoundUpdated(Casette.GENRE genre)
    {
        if(genre != Casette.GENRE.IDLE)
        {
            canvas.alpha = 1; 
            canvas.interactable = true; 
        }
        else
        {
            canvas.alpha = 0; 
            canvas.interactable = false; 
        }
    }

    public void StopPlayback()
    {
        SoundPlayer.Instance.StopPlaying(); 
    }
}

using UnityEngine;

public class Playbutton : MonoBehaviour, IPressable
{
    public void PlaySound()
    {
        SoundPlayer.Instance.StartPlaying(); 
    }

    public void OnPressed()
    {
        Debug.Log("[AR-DEBUG] PlaySound button pressed");
        PlaySound();
    }

}

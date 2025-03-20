using UnityEngine;

public class PauseButton : MonoBehaviour, IPressable
{

    public void PauseSound()
    {
        SoundPlayer.Instance.StopPlaying();
    }

    public void OnPressed()
    {
        Debug.Log("[AR-DEBUG] Pause sound pressed");
        PauseSound();
    }


}

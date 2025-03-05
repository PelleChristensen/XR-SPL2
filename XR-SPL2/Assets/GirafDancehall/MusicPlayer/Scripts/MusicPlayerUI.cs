using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MusicPlayerUI : MonoBehaviour
{
    [SerializeField]TMPro.TMP_Text descriptionlabel; 
    [SerializeField]CanvasGroup canvas; 

    [SerializeField]private PauseButton pausebutton; 

    [SerializeField]private Playbutton playbutton; 

    void Start()
    {
        canvas.interactable = false; 
        canvas.alpha = 0; 
        //we would like for the UI to listen for music starting
        SoundPlayer.OnSoundUpdated += OnSoundUpdated; 
    }

    private void OnSoundUpdated(Casette.GENRE genre)
    {
        if(genre == Casette.GENRE.IDLE) 
        {
            descriptionlabel.text = ""; 
            canvas.alpha = 0; 
            canvas.interactable = false;
            return;             
        }

        descriptionlabel.text = genre.ToString(); 
        canvas.alpha = 1; 
        canvas.interactable = true; 
    }

}

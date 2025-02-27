using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MusicPlayerUI : MonoBehaviour
{
    [SerializeField]TMPro.TMP_Text descriptionlabel; 
    [SerializeField]CanvasGroup canvas; 
    XRInteractionGroup m_InteractionGroup;
    public XRInteractionGroup interactionGroup
    {
        get => m_InteractionGroup;
        set => m_InteractionGroup = value;
    }

    [SerializeField]
    XRInputValueReader<Vector2> m_TapStartPositionInput = new XRInputValueReader<Vector2>("Tap Start Position");

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
            //canvas.alpha = 0; 
            //canvas.interactable = false;
            return;             
        }

        descriptionlabel.text = genre.ToString(); 
        canvas.alpha = 1; 
        canvas.interactable = true; 
    }

    public void StopPlaying()
    {
        SoundPlayer.Instance.StopPlaying();
    }




}

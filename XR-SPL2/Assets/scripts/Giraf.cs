using UnityEngine;

public class Giraf : MonoBehaviour
{
    [SerializeField]Animator animator; 
    void  OnEnable()
    {
        SoundPlayer.OnSoundUpdated += SetMood; 
    }
    void  OnDisable()
    {
        SoundPlayer.OnSoundUpdated -= SetMood; 
    }

    void Start()
    {
        SetMood(Casette.GENRE.IDLE);
    }

    private void SetMood(Casette.GENRE genre)
    {
        switch(genre)
        {
            case Casette.GENRE.JUNGLE: 
                animator.SetTrigger("JUNGLE");
            break; 
            case Casette.GENRE.METAL: 
                animator.SetTrigger("METAL");
            break;
            default : 
                animator.SetTrigger("IDLE");
            break; 
        }
    }
}

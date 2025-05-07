using UnityEngine;

public class ScoreView : MonoBehaviour
{ 
    [SerializeField]private TMPro.TMP_Text initials; 
    [SerializeField]private TMPro.TMP_Text score; 

    public void SetScore(string initials, string score)
    {
        this.initials.text = initials; 
        this.score.text = score; 
    }
}

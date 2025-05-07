using UnityEngine;

public class SubmitScorePanel : MonoBehaviour
{
    [SerializeField]private TMPro.TMP_InputField initials; 
    [SerializeField]private TMPro.TMP_InputField score;

    public AddScore addscorescript; 

    void Awake()
    {
        score.contentType = TMPro.TMP_InputField.ContentType.IntegerNumber; 
        initials.contentType = TMPro.TMP_InputField.ContentType.Name; 

        score.onValueChanged.AddListener(ValidateInput);
    }

    private void ValidateInput(string value)
    {
        string digitsOnly = System.Text.RegularExpressions.Regex.Replace(value, @"[^0-9-]", "");
        if (digitsOnly != value)
        {
            score.text = digitsOnly;
        }
    }

    public void Submitscore ()
    {
        int result; 
        if(int.TryParse(score.text, out result))
        {
            addscorescript.SubmitScore(initials.text, result);
            Debug.Log("Sending initials " + initials.text);
        }
        {
            Debug.LogWarning("Invalid integer");
        } 
    }
}

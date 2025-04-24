using UnityEngine;

public class Counter : MonoBehaviour
{
    public TMPro.TMP_Text textfield; 

    private int count = 0; 
    void Start()
    {
        textfield.text = count.ToString(); 
    }

    void OnEnable()
    {
        Messenger.OnObjectDestroyed += UpdateValue; 
    }

    void OnDisable()
    {
        Messenger.OnObjectDestroyed -= UpdateValue; 
    }

    private void UpdateValue(int value)
    {
        count += value; 
    }

    void Update()
    {
        textfield.text = count.ToString(); 
        Debug.Log("Dead count is: " + count); 
    }
}

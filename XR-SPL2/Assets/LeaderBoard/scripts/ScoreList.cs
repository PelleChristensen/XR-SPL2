using System.Collections.Generic;
using UnityEngine;

public class ScoreList : MonoBehaviour
{
    //the transform that is used for the score items
    [SerializeField] private Transform list; 
    [SerializeField] private Leaderboard leaderboard; 
    [SerializeField] private ScoreView prefab; 
    
    void Start()
    {
        ClearList();
    }

    void OnEnable()
    {
        leaderboard.OnHighscoreUpdated += OnNewLeaderBoard; 
    }

    void OnDisable()
    {
        leaderboard.OnHighscoreUpdated -= OnNewLeaderBoard; 
    }

    private void OnNewLeaderBoard(List<ScoreEntry> newlist)
    {
        Debug.Log("New leaderboard");
        ClearList(); 

        foreach(ScoreEntry item in newlist)
        {
            ScoreView sw = Instantiate(prefab); 
            sw.SetScore(item.initials,item.score.ToString());
            sw.transform.SetParent(list);
        }
    }
    //use this to clear old score items
    private void ClearList()
    {
        while (list.childCount > 0) 
        {
            DestroyImmediate(list.GetChild(0).gameObject);
        }
    }

    //add score item to the list transform. 
    public void AddScore(ScoreView item)
    {
        item.transform.SetParent(list);
    }
}

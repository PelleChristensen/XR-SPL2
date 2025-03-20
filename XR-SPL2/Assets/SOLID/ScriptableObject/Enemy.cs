using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]private EnemyStats stats; 
    private int health = 0; 
    private float speed = 0; 
    void Start()
    {
        health = stats.health; 
        speed = stats.speed; 
    }

}

using System.Collections.Generic;
using UnityEngine;

public class Casette : MonoBehaviour, IPressable
{
    public enum GENRE { METAL, JUNGLE, IDLE }
    public GENRE genre; 
    [SerializeField] AudioClip audioclip; 
    public List<GenreMaterials> coverart = new List<GenreMaterials>(); 
    [SerializeField] MeshRenderer renderer;

    void Start()
    {
        Debug.Log("[AR-DEBUG] Casette ready: " + genre);
        foreach(GenreMaterials mat in coverart)
        {
            if(mat.genre == genre)
            {
                renderer.material = mat.material;
            }
        }
    }

    public void OnPressed()
    {
        //Debug.Log("[AR-DEBUG] Casette pressed: " + genre);
        SoundPlayer.Instance.LoadClip(audioclip, genre);
    }

    [System.Serializable]
    public struct GenreMaterials
    {
        public GENRE genre; 
        public Material material;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Casette : MonoBehaviour
{
    public enum GENRE { METAL, JUNGLE, IDLE }

    public GENRE genre; 

    [SerializeField] AudioClip audioclip; 

    public List<GenreMaterials> coverart = new List<GenreMaterials>(); 

    [SerializeField] MeshRenderer renderer;

    void Start()
    {
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
        print("Tape pressed: " + genre);
        SoundPlayer.Instance.PlayMusic(audioclip, genre);
    }

    [System.Serializable]
    public struct GenreMaterials
    {
        public GENRE genre; 
        public Material material;
    }
}

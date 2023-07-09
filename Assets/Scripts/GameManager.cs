using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public Dictionary<Collectable, int> Collectacles = new Dictionary<Collectable, int>() { };

    [SerializeField] private GameObject EndGameCanvas;
     void Start()
    {
        Instance = this;
    }

    public void Lose()
    {
        Debug.Log("Lose");
        var a = FindObjectOfType<Player>();

        CameraController.instance.Lose();  

    }
    public void AddCollectables(Collectable collectable)
    {
        if(Collectacles.ContainsKey(collectable))
        {
            Collectacles[collectable] += 1;
        }
        else
        {
            Collectacles.Add(collectable, 1);
        }
        
        Debug.Log(Collectacles[collectable]);

    }

    public void Win()
    {
        EndGameCanvas.SetActive(true);
    }

}

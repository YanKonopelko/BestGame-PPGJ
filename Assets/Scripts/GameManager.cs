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
        StartCoroutine(BackScreen());

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
    IEnumerator BackScreen()
    {
        yield return new WaitForSeconds(0.7F);
        EndGameCanvas.SetActive(true);
        yield return new WaitForSeconds(2.2F);
        EndGameCanvas.SetActive(false);


    }
    public void Win()
    {
        EndGameCanvas.SetActive(true);
    }

}

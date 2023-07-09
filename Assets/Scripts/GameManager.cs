using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<Collectable, int> Collectacles = new Dictionary<Collectable, int>(){};

    [SerializeField] private GameObject EndGameCanvas;
    
    [SerializeField] private PostProcessVolume postProcess;
    [SerializeField] private Color[] postProsCollors;
    private const float collectableCount = 6;
    private float curCount;
    [SerializeField] private float startIntensity; 
    
     void Start()
     { 
         
        curCount = collectableCount;
        Instance = this;
        postProcess.sharedProfile.GetSetting<Vignette>().color.value = postProsCollors[0];
        postProcess.sharedProfile.GetSetting<Grain>().intensity.value = startIntensity;

    }

    public void Lose()
    {
        Debug.Log("Lose");
        var a = FindObjectOfType<Player>();

        CameraController.instance.Lose();
        SoundManager.Instance.PlaySound(SoundManager.SoundType.LoseSound);
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
    }

    public void UpgradeEffects()
    {
        curCount -= 1;
        postProcess.sharedProfile.GetSetting<Vignette>().color.value +=(postProsCollors[1] - postProsCollors[0]) / collectableCount;
        postProcess.sharedProfile.GetSetting<Grain>().intensity.value = (curCount / collectableCount)*startIntensity;
        if (curCount == 0)
        {
            Win();
        }
    }
    public void Win()
    {
        EndGameCanvas.SetActive(true);
    }

}

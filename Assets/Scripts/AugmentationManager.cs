using UnityEngine;

public class AugmentationManager : MonoBehaviour
{
    public GameObject[] representations;

    private string currentTarget = null;

    void Awake()
    {
        foreach (var rep in representations)
            rep.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        if(currentTarget == targetName) return;

        currentTarget = targetName;

        foreach (var rep in representations)
            rep.SetActive(rep.name.Contains(targetName));
    }

    public void ClearActiveTarget(string targetName)
    {
        if(currentTarget == targetName){
            currentTarget = null;

            foreach(var rep in representations)
                rep.SetActive(false);
        }
    }
}
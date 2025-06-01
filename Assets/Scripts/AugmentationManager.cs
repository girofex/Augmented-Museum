using UnityEngine;

public class AugmentationManager : MonoBehaviour
{
    public GameObject[] representations;
    private GameObject currentRep = null;
    private string currentTarget = null;

    void Awake()
    {
        foreach (var rep in representations)
            rep.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
            return;

        currentTarget = targetName;

        if(currentRep != null)
            currentRep.SetActive(false);

        foreach (var rep in representations)
        {
            if (rep.name.Contains(targetName))
            {
                rep.SetActive(true);
                currentRep = rep;
                break;
            }
        }
    }

    public void ClearActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
        {
            currentTarget = null;

            if (currentRep != null)
            {
                currentRep.SetActive(false);
                currentRep = null;
            }
        }
    }
}
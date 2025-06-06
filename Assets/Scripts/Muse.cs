using UnityEngine;

public class Muse : MonoBehaviour
{
    public GameObject[] muses;
    private GameObject currentMuse = null;
    private string currentTarget = null;

    void Awake()
    {
        foreach (var muse in muses)
            muse.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
            return;

        currentTarget = targetName;

        if(currentMuse != null)
            currentMuse.SetActive(false);

        foreach (var muse in muses)
        {
            if (muse.name.Contains(targetName))
            {
                muse.SetActive(true);
                currentMuse = muse;
                break;
            }
        }
    }

    public void ClearActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
        {
            currentTarget = null;

            if (currentMuse != null)
            {
                currentMuse.SetActive(false);
                currentMuse = null;
            }
        }
    }
}
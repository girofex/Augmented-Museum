using UnityEngine;

public class Thalia : MonoBehaviour
{
    private string currentTarget = null;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        currentTarget = targetName;
        gameObject.SetActive(true);
    }

    public void ClearActiveTarget(string targetName)
    {
        if(currentTarget == targetName){
            currentTarget = null;
            gameObject.SetActive(false);
        }
    }
}
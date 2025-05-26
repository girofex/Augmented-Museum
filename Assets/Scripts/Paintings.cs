using UnityEngine;
using Vuforia;

public class Paintings : MonoBehaviour
{
    public GameObject daliPrefab, friedrichPrefab, gentileschiPrefab, kahloPrefab, warholPrefab;

    void Start()
    {
        var targets = FindObjectsOfType<ImageTargetBehaviour>();

        foreach (var target in targets)
            target.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            Debug.Log("Detected: " + behaviour.TargetName);
            SpawnPainting(behaviour.TargetName, behaviour.transform);
        }
    }

    void SpawnPainting(string targetName, Transform parent)
    {
        GameObject go = null;
        
        switch(targetName){
            case "dali":
                go = Instantiate(daliPrefab);
                break;
            case "friedrich":
                go = Instantiate(friedrichPrefab);
                break;
            case "gentileschi":
                go = Instantiate(gentileschiPrefab);
                break;
            case "kahlo":
                go = Instantiate(kahloPrefab);
                break;
            case "warhol":
                go = Instantiate(warholPrefab);
                break;
        }

        if(go != null){
            go.transform.SetParent(parent);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
        }
    }
}

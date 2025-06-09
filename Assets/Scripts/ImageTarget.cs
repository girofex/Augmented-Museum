using UnityEngine;
using Vuforia;

public class ImageTarget : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    public AugmentationManager manager;
    public Dialogue dialogue;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
            observerBehaviour.OnTargetStatusChanged += StatusChanged;
    }

    void OnDestroy()
    {
        if (observerBehaviour != null)
            observerBehaviour.OnTargetStatusChanged -= StatusChanged;
    }

    private void StatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        string targetName = behaviour.TargetName;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            manager.SetActiveTarget(targetName);
            dialogue.SetActiveTarget(targetName);
        }

        else if (status.Status == Status.NO_POSE)
        {
            manager.ClearActiveTarget(targetName);
            dialogue.ClearActiveTarget(targetName);
        }
    }
}
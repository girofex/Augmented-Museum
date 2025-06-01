using UnityEngine;
using Vuforia;

public class ImageTarget : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    public AugmentationManager manager;
    public Thalia thalia;
    public Dialogue dialogue;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
            observerBehaviour.OnTargetStatusChanged += HandleTargetStatusChanged;
    }

    void OnDestroy()
    {
        if (observerBehaviour != null)
            observerBehaviour.OnTargetStatusChanged -= HandleTargetStatusChanged;
    }

    private void HandleTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        string targetName = behaviour.TargetName;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            manager.SetActiveTarget(targetName);
            thalia.SetActiveTarget(targetName);
            dialogue.SetActiveTarget(targetName);
        }

        else if (status.Status == Status.NO_POSE)
        {
            manager.ClearActiveTarget(targetName);
            thalia.ClearActiveTarget(targetName);
            dialogue.ClearActiveTarget(targetName);
        }
    }
}
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
        if (observerBehaviour)
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnDestroy()
    {
        if (observerBehaviour)
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        string targetName = behaviour.TargetName;

        if (manager == null) return;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            manager.SetActiveTarget(behaviour.TargetName);
            thalia.SetActiveTarget(targetName);
            dialogue.SetActiveTarget(targetName);
        }

        else if (status.Status == Status.NO_POSE)
        {
            manager.ClearActiveTarget(behaviour.TargetName);
            thalia.ClearActiveTarget(targetName);
            dialogue.ClearActiveTarget(targetName);
        }
    }
}
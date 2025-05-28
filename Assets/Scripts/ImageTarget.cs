using UnityEngine;
using Vuforia;

public class ImageTarget : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    public AugmentationManager manager;
    public Thalia thalia;

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
        if (manager == null) return;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            string targetName = behaviour.TargetName;
            manager.SetActiveTarget(behaviour.TargetName);
            thalia.SetActiveTarget(targetName);
        }

        else if (status.Status == Status.NO_POSE)
        {
            string targetName = behaviour.TargetName;
            manager.ClearActiveTarget(behaviour.TargetName);
            thalia.ClearActiveTarget(targetName);
        }
    }
}
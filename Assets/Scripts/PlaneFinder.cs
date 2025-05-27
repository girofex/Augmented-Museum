using UnityEngine;
using Vuforia;

public class PlaneFinder : MonoBehaviour
{
    private PlaneFinderBehaviour planeFinder;
    private ContentPositioningBehaviour contentPositioning;

    void Start()
    {
        planeFinder = GetComponent<PlaneFinderBehaviour>();
        contentPositioning = GetComponent<ContentPositioningBehaviour>();

        if (planeFinder != null)
            planeFinder.OnInteractiveHitTest.AddListener(OnHitTest);
    }

    void OnHitTest(HitTestResult result)
    {
        if (contentPositioning != null)
            contentPositioning.PositionContentAtPlaneAnchor(result);
    }
}
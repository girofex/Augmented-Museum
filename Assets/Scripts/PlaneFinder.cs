using UnityEngine;
using Vuforia;

public class PlaneFinder : MonoBehaviour
{
    public GameObject museum;
    public static bool placed { get; private set; } = false;

    private PlaneFinderBehaviour planeFinder;
    private ContentPositioningBehaviour contentPositioning;

    void Start()
    {
        planeFinder = GetComponent<PlaneFinderBehaviour>();
        contentPositioning = GetComponent<ContentPositioningBehaviour>();
        museum.SetActive(false);

        if (planeFinder != null)
            planeFinder.OnAutomaticHitTest.AddListener(OnHitTest);
    }

    void OnHitTest(HitTestResult result)
    {
        if (placed || contentPositioning == null)
            return;

        contentPositioning.PositionContentAtPlaneAnchor(result);

        museum.SetActive(true);
        placed = true;
    }
}
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public TextMeshProUGUI dialogueText;

    private string currentTarget = null;

    void Awake()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        currentTarget = targetName;
        dialogueCanvas.gameObject.SetActive(true);
        dialogueText.text = $"Detected: {targetName}";
    }

    public void ClearActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
        {
            currentTarget = null;
            dialogueCanvas.gameObject.SetActive(false);
        }
    }
}
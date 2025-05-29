using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public Canvas dialogue;
    public TextMeshProUGUI text;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private string lastPlayed, currentTarget = null;

    void Awake()
    {
        new WaitForSeconds(1.5f);
        dialogue.gameObject.SetActive(true);
        text.text = "Hello there, I'm the muse Thalia.\nFrame a painting and I will appear to tell you more about its story.";
        StartCoroutine(PlayAudio(0));
    }

    private IEnumerator PlayAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();

        yield return new WaitWhile(() => audioSource.isPlaying);

        if (index == 0)
            dialogue.gameObject.SetActive(false);
    }

    public void SetActiveTarget(string targetName)
    {
        if (targetName == lastPlayed) 
            return;

        currentTarget = targetName;
        lastPlayed = targetName;

        dialogue.gameObject.SetActive(true);

        switch (currentTarget)
        {
            case "dali":
                text.text = "The Persistence of Memory by Salvador Dalì: as said by the author, the watches are inspired by the surrealist perception of a Camembert melting in the sun.\nIn the middle, we have a self-portrait.\nThe ants on the orange watch are a symbol of decay.\nWe also have a reference to his homeland, Catalonia.";
                StartCoroutine(PlayAudio(1));
                break;
            case "friedrich":
                text.text = "Wanderer above the Sea of Fog by Caspar David Friedrich: the painting is an emblem of self-reflection and contemplation of life's path, as the landscape is considered to evoke the sublime.\nIt has also been interpreted as an expression of Friedrich's German liberal and nationalist feeling.";
                StartCoroutine(PlayAudio(2));
                break;
            case "gentileschi":
                text.text = "Corisca and the Satyr by Artemisia Gentileschi: the satyr attemps to rape Corisca, but he can only clutch to her hairpiece.\nMany interpretations link this content to Gentileschi's own rape by her art teacher, which changed her life and artistic process.";
                StartCoroutine(PlayAudio(3));
                break;
            case "kahlo":
                text.text = "Self Portrait with Thorn Necklace and Hummingbird by Frida Kahlo: Frida spent most of her life in physical pain after a bus accident, which led to about thirty-five operations and inability to have children.\nThis painting accurately depicts her suffering.";
                StartCoroutine(PlayAudio(4));
                break;
            case "warhol":
                text.text = "The Last Supper by Andy Warhol: one of the 100 variations of the original painting by Leonardo, which indicates Warhol's profound religious faith.\nWarhol used a black and white photograph and an encyclopedic illustration of the original work.\nThe former served as model for the silkscreens, the latter for the handdrawn tracing paintings.";
                StartCoroutine(PlayAudio(5));
                break;
        }
    }

    public void ClearActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
        {
            currentTarget = null;
            dialogue.gameObject.SetActive(false);
            lastPlayed = null;
        }
    }
}
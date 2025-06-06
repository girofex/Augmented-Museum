using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public Canvas dialogue;
    public TextMeshProUGUI text;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Muse muse;
    private string lastPlayed, currentTarget, currentMuse = null;

    private IEnumerator PlayAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();

        yield return new WaitWhile(() => audioSource.isPlaying);

        if (index == 0)
            dialogue.gameObject.SetActive(false);
    }

    private IEnumerator Delay()
    {
        yield return new WaitUntil(() => PlaneFinder.placed);

        text.text = "Frame a painting and the muses will appear to tell you more about its story.";
    }
    
    void Start()
    {
        text.text = "Look at the floor to start";
        StartCoroutine(Delay());
    }

    public void SetActiveTarget(string targetName)
    {
        if (targetName == lastPlayed) 
            return;

        currentTarget = lastPlayed = targetName;
        dialogue.gameObject.SetActive(true);

        switch (currentTarget)
        {
            case "dali":
                text.text = "The Persistence of Memory by Salvador Dalì: as said by the author, the watches are inspired by the surrealist perception of a Camembert melting in the sun.\nIn the middle, we have a self-portrait.\nThe ants on the orange watch are a symbol of decay.\nWe also have a reference to his homeland, Catalonia.";
                currentMuse = "Euterpe";
                muse.SetActiveTarget(currentMuse);
                StartCoroutine(PlayAudio(0));
                break;
            case "gentileschi":
                text.text = "Corisca and the Satyr by Artemisia Gentileschi: the satyr attemps to rape Corisca, but he can only clutch to her hairpiece.\nMany interpretations link this content to Gentileschi's own rape by her art teacher, which changed her life and artistic process.";
                currentMuse = "Melpomene";
                muse.SetActiveTarget(currentMuse);
                StartCoroutine(PlayAudio(1));
                break;
            case "monet":
                text.text = "Water Lilies by Claude Monet: part of a series of approximately 250 oil paintings.\nIt depicts his flower garden at his home in Giverny, main focus of his artistic production during the last 31 years of his life.\nAs said by the author “One instant, one aspect of nature contains it all”.";
                currentMuse = "Thalia";
                muse.SetActiveTarget(currentMuse);
                StartCoroutine(PlayAudio(2));
                break;
            case "mucha":
                text.text = "The Four Seasons by Alphonse Mucha: this was his first set of decorative panels.\nThe nymph-like women against the seasonal views of the countryside breathed new life into the classic theme.\nMucha captures the moods of the seasons - innocent Spring, sultry Summer, fruitful Autumn and frosty Winter.";
                currentMuse = "Terpsichore";
                muse.SetActiveTarget(currentMuse);
                StartCoroutine(PlayAudio(3));
                break;
            case "warhol":
                text.text = "The Last Supper by Andy Warhol: one of the 100 variations of the original painting by Leonardo, which indicates Warhol's profound religious faith.\nWarhol used a black and white photograph and an encyclopedic illustration of the original work.\nThe former served as model for the silkscreens, the latter for the handdrawn tracing paintings.";
                currentMuse = "Urania";
                muse.SetActiveTarget(currentMuse);
                StartCoroutine(PlayAudio(4));
                break;
        }
    }

    public void ClearActiveTarget(string targetName)
    {
        if (currentTarget == targetName)
        {
            currentTarget = lastPlayed = null;
            dialogue.gameObject.SetActive(false);

            if (currentMuse != null)
            {
                muse.ClearActiveTarget(currentMuse);
                currentMuse = null;
            }
        }
    }
}
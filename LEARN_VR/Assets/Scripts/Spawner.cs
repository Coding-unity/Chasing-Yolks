using UnityEngine;
using System.Collections;
using TMPro;
public class Spawner : MonoBehaviour
{
    public Transform[] dropPosition;
    public GameObject[] eggs;
    public AudioClip[] clip;
    public AudioSource audioSource;


    public TextMeshProUGUI waitText;


    private IEnumerator Start()
    {
        audioSource.PlayOneShot(clip[0]);

        yield return new WaitForSeconds(4F);

        waitText.text = null;
        InvokeRepeating(nameof(InitiateDrop), 2, 2);

        yield break;
    }

    private void InitiateDrop()
    {
        int randLocation = Random.Range(0, dropPosition.Length);
        int randEggs = Random.Range(0, eggs.Length);

        Instantiate(eggs[randEggs], dropPosition[randLocation], default);

        audioSource.Play();
    }

}
using UnityEngine;
using System.Collections;
using TMPro;
public class Spawner : MonoBehaviour
{
    public Transform[] dropPosition;
    public GameObject[] eggs;
    public AudioClip[] clip;
    public AudioSource audioSource;

    public Timer timer;

    public TextMeshProUGUI waitText;
    public bool fall;

    /*  private IEnumerator Start()
      {
          audioSource.PlayOneShot(clip[0]);

          yield return new WaitForSeconds(4F);

          waitText.text = null;
          InvokeRepeating(nameof(InitiateDrop), 2, 2);

          yield break;
      } */

    private IEnumerator Start()
    {
        audioSource.PlayOneShot(clip[0]);

        yield return new WaitForSeconds(4F);

        waitText.text = null;
        fall = true;
    }

    private void Update()
    {

        if (timer.Duration > 1)
        {
            InitiateDrop();
        } 
            
    }

    private void InitiateDrop()
    {
        int randLocation = Random.Range(0, dropPosition.Length);
        int randEggs = Random.Range(0, eggs.Length);

        if(fall)
        {
            Instantiate(eggs[randEggs], dropPosition[randLocation], default);
            fall = false;
            StartCoroutine(Delay(2));
        }
        
        audioSource.Play();
    }

    private IEnumerator Delay(byte time)
    {
        yield return new WaitForSeconds(time);
        fall = true;
    }

}
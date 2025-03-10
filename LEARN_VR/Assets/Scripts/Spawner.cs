//using UnityEngine;
//using System.Collections;
//using TMPro;
//public class Spawner : MonoBehaviour
//{
//    public Transform[] dropPosition;
//    public GameObject[] eggs;
//    public AudioClip[] clip;

//    public Timer timer;
//    public AudioSource audioSource;

//    public bool release;
//    public bool wait;
//    public TextMeshProUGUI waitText;

//    private void Awake()
//    {
//        wait = false;
//        audioSource.PlayOneShot(clip[0]);
//    }
//    private void Start()
//    {
//        StartCoroutine(Delay(4));
//        waitText.gameObject.SetActive(false);
//    }

//    private void Update()
//    {
//        if (waitText.gameObject.activeSelf) return;
//        if (timer.Duration > 0 && wait)
//        {
//            InitiateDrop();
//        }
//    }

//    private void InitiateDrop()
//    {

//        int randLocation = Random.Range(0, dropPosition.Length);
//        int randEggs = Random.Range(0, eggs.Length);

//        if (release)
//        {
//            Instantiate(eggs[randEggs], dropPosition[randLocation], default);
//            release = false;
//            StartCoroutine(Delay(2));
//            release = true;
//            audioSource.Play();
//        }
//    }

//    private IEnumerator Delay(byte time)
//    {
//        yield return new WaitForSeconds(time);
//        release = true;
//    }
//    private IEnumerator AudioDelay(byte time)
//    {
//        yield return new WaitForSeconds(time);
//        wait = true;
//    }
//}



// 

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
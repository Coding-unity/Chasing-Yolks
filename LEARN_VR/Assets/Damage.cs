using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject Basket, Spawner;
    public Spawner spawner;
    public Timer timer;

    public Image[] Heart = new Image[5];

    private byte health = 5;

    public TextMeshProUGUI ScoreText;
    public AudioSource audioSource;

    int i;

    public Slider Slider, RestartSlider;

    private void Awake()
    {
        RestartSlider.gameObject.SetActive(false);
    }

    private void Start()
    {
        i = 0;
    }

    private void Update()
    {
        if (health < 1 || timer.Duration == 0)
        {
            ScoreText.text = "Game Over";
            timer.wait = false;
            Basket.SetActive(false);
            Spawner.SetActive(false);
            Slider.gameObject.SetActive(false);
            RestartSlider.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eggs"))
        {
            other.gameObject.SetActive(true);
            audioSource.Play();
            Destroy(other);
            Heart[i].gameObject.SetActive(false);
            i++;
            health--;
            Debug.Log(i);
        }
    }


}

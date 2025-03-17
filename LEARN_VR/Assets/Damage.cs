using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject Basket, Spawner;
    public Spawner spawner;
    public Timer timer;

    public Image[] Heart = new Image[5];

    public byte health = 5;

    public TextMeshProUGUI ScoreText;
    public AudioSource audioSource;
    public Button RetryButton,PokeRetryButton;

    int i;

    public Slider Slider;

    private void Awake()
    {
        RetryButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        i = 0;
        RetryButton.onClick.AddListener(ResetSetup);
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
            RetryButton.gameObject.SetActive(true);
            if (RetryButton && !RetryButton.gameObject.activeInHierarchy)
            {
                RetryButton.gameObject.SetActive(true);
            }

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
        }
    }

    public void ResetSetup()
    {
        i = 0;
        health = 5;
        timer.ResetTime(90);
        Basket.SetActive(false);
        Spawner.SetActive(false);
        Slider.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);
    }

}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Timer timer;
    public byte health = 5;
    public byte Points;
    public TextMeshProUGUI ScoreHolder;
    public AudioSource audioSource;

    private void Start()
    {
        Points = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        audioSource.Play();
        Points += 1;
        ScoreHolder.text = Points.ToString();
    }
    private void Update()
    {
        if(timer.Duration != 0) return;

        Points = 0;
        timer.Duration = 90f;
    }
}

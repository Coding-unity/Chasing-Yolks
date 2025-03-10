using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI LevelTimer;
    public float Duration;

    public bool wait;

    private void Start()
    {
        wait = false;
        StartCoroutine(Delay(4));
    }

    private void Update()
    {
        if(!wait) return;

        if (Duration > 0)
        {
            Duration -= Time.deltaTime;
        }
        else if(Duration < 0)
        {
            Duration = 0;
            LevelTimer.color = Color.black;
            enabled = false;
        }

        int minutes = Mathf.FloorToInt(Duration / 60);
        int seconds = Mathf.FloorToInt(Duration % 60);

        LevelTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator Delay(byte time)
    {
        yield return new WaitForSeconds(time);
        wait = true;
    }
}

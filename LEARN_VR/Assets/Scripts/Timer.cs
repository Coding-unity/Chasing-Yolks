using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI LevelTimer;
    public float Duration;
    public Health health;
    public Damage damage;

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

    public void ResetTime(int time)
    {
        Duration = time;
        Duration -= Time.deltaTime;
        LevelTimer.color = Color.white;
        LevelTimer.text = time.ToString();
        health.Points = 0;
        damage.Heart = new Image[5];
    }
}

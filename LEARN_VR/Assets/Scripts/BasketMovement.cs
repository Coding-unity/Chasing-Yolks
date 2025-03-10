using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasketMovement : MonoBehaviour
{
    public Timer timer;
    public Slider Slider;
    public GameObject Basket;
    public byte Rate;
    public float Value;


    private void Start()
    {
        Slider.value = 0.5f;
    }

    private void MoveRight()
    {
        Basket.transform.Translate(0, 0, Rate * Time.deltaTime);
    }

    private void MoveLeft()
    {
        Basket.transform.Translate(0, 0, -Rate * Time.deltaTime);
    }

    private void Update()
    {
        Value = Slider.value;
        if (Value > 0.5f) MoveRight();

        if (Value < 0.5f)

            MoveLeft();

        if (timer.Duration == 0)
        {
            Rate = 0; Value = 0.5F;
            Slider.interactable = false;    
            this.enabled = false;
        }

    }
}

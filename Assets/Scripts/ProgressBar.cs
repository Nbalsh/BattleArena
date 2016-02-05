using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour{
    Image image;
    public float timeToFill = 8.0f;
    private bool fillBar = false;
    private float timeUntilFillAgain = 0.0f;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (fillBar)
        {
            image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1f, Time.deltaTime / timeToFill);
        } else if (timeUntilFillAgain < Time.deltaTime)
        {
            fillBar = false;
        }
    }

    public void ActivateProgressBar()
    {
        if (timeUntilFillAgain < Time.fixedTime)
        {
            timeUntilFillAgain = Time.fixedTime + timeToFill;
            image.fillAmount = 0;
            fillBar = true;
        }
    }
}

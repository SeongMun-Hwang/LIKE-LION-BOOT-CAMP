using UnityEngine;
using UnityEngine.UI;

public class HealthBarColor : MonoBehaviour
{
    private void Update()
    {
        Image image = GetComponent<Image>();
        image.color = Color.HSVToRGB(image.fillAmount/3, 1.0f, 1.0f);
    }
}

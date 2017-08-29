using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HologramManager : MonoBehaviour {
    [Header("Customization")]
	public Image Placeholder;
	private Color PlaceholderColor = new Color (1f, 1f, 1f, 1f);
    private bool HidePlaceholder = false;
    public GameObject TapButton;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void TapToHide()
    {
        print("Hide it");
        HidePlaceholder = true;
        TapButton.SetActive(false);
    }

    void Update()
    {
        if (HidePlaceholder)
        {
            if (PlaceholderColor.a != 0f)
            {
                PlaceholderColor.a = PlaceholderColor.a - 0.002f;
                Placeholder.color = new Color(1f, 1f, 1f, PlaceholderColor.a);
            }
        }
    }
}

using UnityEngine;
using TMPro;


public class TimeButtonText : MonoBehaviour {

    private TextMeshProUGUI timeText;

    void Awake () {
        timeText = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            timeText.text = "1x";
        }
        if (Time.timeScale == 2)
        {
            timeText.text = "2x";
        }
    }
}

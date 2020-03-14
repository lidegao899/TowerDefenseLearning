using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text LivesText;

    // Update is called once per frame
    private void Update()
    {
        LivesText.text = PlayerStats.Lives + " Lives";
    }
}
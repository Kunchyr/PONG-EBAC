using TMPro;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();
        if (lastWinner != "")
            uiWinner.text = "Último Vencedor: " + lastWinner;
        else
            uiWinner.text = "";
    }
}

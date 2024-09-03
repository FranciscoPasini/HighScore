using UnityEngine;
using TMPro;

public class UiScoreItem : MonoBehaviour
{
    [SerializeField] TMP_Text numberText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scoreText;

   
    public void Set(string number, string name, string score)
    {
        numberText.text = number;
        nameText.text = name;
        scoreText.text = score;
    }
}

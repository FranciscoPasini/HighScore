using UnityEngine;
using TMPro;

public class UiScoreItem : MonoBehaviour
{
    public string Score { get; private set; }
    public string Name { get; private set; }

    [SerializeField] private TMP_Text numberText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text scoreText;

    public void Set(string number, string playerName, string playerScore)
    {
        numberText.text = number;
        nameText.text = playerName;
        scoreText.text = playerScore;

        Name = playerName;
        Score = playerScore;
    }
}

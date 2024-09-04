using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiScore : MonoBehaviour
{
    [SerializeField] private List<UiScoreItem> items = new List<UiScoreItem>();
    [SerializeField] private UiScoreItem scoreItemPrefab;
    [SerializeField] private Transform content;

    private int maxElements = 10;

    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField scoreInput;
    [SerializeField] private Button confirmButton;

    private void Awake()
    {
        confirmButton.onClick.AddListener(OnConfirmClicked);
    }

    private void OnDestroy()
    {
        confirmButton.onClick.RemoveAllListeners();
    }

    private void OnConfirmClicked()
    {
        if (items.Count >= maxElements)
        {
            Debug.LogWarning("Cannot add more than 10 players.");
            return;
        }

        string playerName = nameInput.text;
        string playerScore = scoreInput.text;

        AddPlayer(items.Count + 1, playerName, playerScore);

        nameInput.text = "";
        scoreInput.text = "";

        Sort();
    }

    private void Sort()
    {
        items.Sort((x, y) => int.Parse(y.Score).CompareTo(int.Parse(x.Score)));

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
            items[i].Set((i + 1).ToString(), items[i].Name, items[i].Score);
        }
    }

    private void AddPlayer(int number, string name, string score)
    {
        UiScoreItem item = Instantiate(scoreItemPrefab, content);
        item.Set(number.ToString(), name, score);
        items.Add(item);
    }
}

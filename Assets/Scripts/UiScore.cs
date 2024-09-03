using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiScore : MonoBehaviour
{
    [SerializeField] private List<UiScoreItem> items = new List<UiScoreItem> ();
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
    private void Start()
    {
        for (int i = 0; i < maxElements; i++)
        {
            AddPlayer(i.ToString(), "Player " + i + 1, Random.Range(0, 1000).ToString());
        }
        Sort();
    }

    private void OnDestroy() 
    {
        confirmButton.onClick.RemoveAllListeners();
    }

    private void OnConfirmClicked()
    {
        string playerName = nameInput.text;
        string playerScore = scoreInput.text;

        AddPlayer("xx", playerName, playerScore);

        nameInput.text = "";
        scoreInput.text = "";
    }

    private void Sort()
    {
        items[3].transform.SetSiblingIndex(0);
    }

    private void AddPlayer(string number, string name, string score)
    {
        UiScoreItem item = Instantiate(scoreItemPrefab, transform);
        item.Set(number, name, score);
        items.Add(item);
    }
}

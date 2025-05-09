using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class display_24info : MonoBehaviour
{
    public TextMeshProUGUI season;
    public string seasonName;
    public SeasonInfoPanel infoPanel; // 인스펙터에서 연결
    // Start is called before the first frame update
    void Start()
    {
        seasonName = season.text;
        infoPanel = FindObjectOfType<SeasonInfoPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        seasonName = season.text;
    }

    public void OnClickButton()
    {
        string seasonName = season.text;
        infoPanel.ShowSeasonInfo(seasonName);
    }
}

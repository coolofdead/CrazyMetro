using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TramInformation : MonoBehaviour
{
    public TMP_Text[] tramsText;

    private void Awake()
    {
        MapManager.onStationArrive += UpdateInfo;
    }

    private void UpdateInfo(Station station)
    {
        print("update tram info");
        var connections = MapManager.Instance.GetTramLinesAtStation(station);
        
        for (int i = 0; i < tramsText.Length; i++)
        {
            tramsText[i].gameObject.SetActive(i < connections.Count());

            if (i >= connections.Count()) continue;

            tramsText[i].text = $"{connections[i].tramLine} in {Random.Range(2, 8)}min";
        }
    }

    private void OnDestroy()
    {
        MapManager.onStationArrive -= UpdateInfo;
    }
}

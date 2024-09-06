using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour, ICodeReadable
{
    public static MapManager Instance;
    public static Action<Station> onStationArrive;

    public List<TramLineConnection> tramLines;

    public Station currentStation;

    public List<Code> touchesReadable;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //currentStation = (Station)UnityEngine.Random.Range(0, 18);
        onStationArrive?.Invoke(currentStation);
    }

    public bool CanReadCode(Code code)
    {
        return touchesReadable.Any(toucheReadable => toucheReadable.Equals(code));
    }

    public void ReceiveCode(Code code)
    {
        for (int i = 0; i < touchesReadable.Count; i++)
        {
            if (touchesReadable[i].Equals(code))
            {
                var direction = (Direction)i;
                if (direction == Direction.ChangeDirection)
                {
                    ConsoleManager.Instance.PrintLog("Change direction");
                    print("change direction");
                }
                else
                {
                    print("take tram " + (TramLine)i);
                    TakeTram((TramLine)i, Random.Range(0f, 1f) > 0.5f);
                }
            }
        }
    }

    public void TakeTram(TramLine tramLine, bool goesForward)
    {
        var tramLineConnections = GetTramLinesAtStation(currentStation);

        if (!tramLineConnections.Any(tramLineConnection => tramLineConnection.tramLine == tramLine))
        {
            ConsoleManager.Instance.PrintLog($"Nothing happened");
            return;
        }

        var connections = tramLineConnections.First(tramLineConnection => tramLineConnection.tramLine == tramLine)
                                             .stations.First(connection => connection.station == currentStation)
                                             .connections.Where(connection => connection != currentStation);

        currentStation = Random.Range(0f, 1f) > 0.5f ? connections.First() : connections.Last();
        print("go to station " + currentStation);
        onStationArrive?.Invoke(currentStation);
    }

    public TramLineConnection[] GetTramLinesAtStation(Station station)
    {
        return tramLines.Where(tramLine => tramLine.stations.Any(connection => connection.station == currentStation)).ToArray();
    }

    public string GetDescForCode(Code code)
    {
        for (int i = 0; i < touchesReadable.Count; i++)
        {
            if (touchesReadable.Equals(code))
            {
                return $"Take tram {(TramLine)i}";
            }
        }

        return "";
    }

    public IEnumerable<Code> GetAllCodes()
    {
        return touchesReadable;
    }

    public enum Direction
    {
        FirstTram,
        SecondTram,
        ThirdTram,
        ChangeDirection,
    }
}

[Serializable]
public struct TramLineConnection
{
    public TramLine tramLine;
    public List<LineConnection> stations;

    public readonly List<LineConnection> Connections(Station station) => stations.Where(lineConnection => lineConnection.station == station).ToList();
}

[Serializable]
public struct LineConnection
{
    public Station station;
    public List<Station> connections;
}

public enum TramLine
{
    RedLine,
    BlueLine,
    GreenLine,
}

public enum Station
{
    CastleClifBeach,
    CastleClifStation,
    GonvilleJunction,
    HospitalCorner,
    Racecourse,
    TownCentre,
    CpoCook,
    WhanganuiBridge,
    RailwayStation,
    TaupoQuayDepot,
    Glasgow,
    CalverCorner,
    DublinBridge,
    AramohoJunction,
    Aramoho,
    AramohoPark,
    MoanaStreet,
    WhanganuiEast,
    EastTownRailwayStation,
}
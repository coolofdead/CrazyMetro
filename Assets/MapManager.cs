using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<TramLineConnection> tramLines;

    public Station currentStation;

    public void 
}

[System.Serializable]
public struct TramLineConnection
{
    public TramLine tramLine;
    public List<LineConnection> stations;
}

[System.Serializable]
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
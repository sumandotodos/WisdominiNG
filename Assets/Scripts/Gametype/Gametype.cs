using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType { Kids, Teens_es, Teens_en };

public class Gametype : MonoBehaviour
{
    public static string GetGameTypeKey()
    {
        return "gametype";
    }

    public static string GameTypeToString(GameType type)
    {
        switch(type)
        {
            case GameType.Kids:
                return "kids";
            case GameType.Teens_en:
                return "teens_en";
            case GameType.Teens_es:
                return "teens_es";
            default:
                return "kids";
        }
    }

    public static GameType GameTypeFromString(string Type)
    {
        switch(Type)
        {
            case "kids":
                return GameType.Kids;
            case "teens_en":
                return GameType.Teens_en;
            case "teens_es":
                return GameType.Teens_es;
            default:
                return GameType.Kids;
        }
    }

    public static void StoreGameType(GameType type)
    {
        PlayerPrefs.SetString(Gametype.GetGameTypeKey(), Gametype.GameTypeToString(type));
    }

    public GameType RetrieveGameType(string type)
    {
        return GameTypeFromString(PlayerPrefs.GetString(Gametype.GetGameTypeKey()));
    }
}

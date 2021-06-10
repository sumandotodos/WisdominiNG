using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WisdominiVersions { Kids, Teens, TeensEN };

public class WisdominiVersionSelector : MonoBehaviour
{
    public ObjectSwitch objectSwitch;

    public WisdominiVersions version;

    private void Start()
    {
        GameType type = Gametype.GameTypeFromString(PlayerPrefs.GetString(Gametype.GetGameTypeKey()));
        switch (type)
        {
            case GameType.Kids:
                objectSwitch.SetChannel(0);
                break;
            case GameType.Teens_es:
                objectSwitch.SetChannel(1);
                break;
            case GameType.Teens_en:
                objectSwitch.SetChannel(2);
                break;
        }

        /*switch (version)
        {
            case WisdominiVersions.Kids:
                objectSwitch.SetChannel(0);
                break;
            case WisdominiVersions.Teens:
                objectSwitch.SetChannel(1);
                break;
            case WisdominiVersions.TeensEN:
                objectSwitch.SetChannel(2);
                break;
        }*/
    }
}

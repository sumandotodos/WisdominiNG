using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TitleController : MonoBehaviour
{
    public Fader fader;
    public Fader titleFader;
    public Fader universeFader;
    public VideoPlayer videoPlayer;

    public Fader kidsFader;
    public Fader teensESFader;
    public Fader teensENFader;

    public Fader copyrightFader;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        fader.Start();
        titleFader.Start();
        yield return fader.FadeToTransparent();
        yield return new WaitForSeconds(0.25f);
        titleFader.FadeToOpaque();
        yield return new WaitForSeconds(1.05f);
        kidsFader.FadeToOpaque();
        yield return new WaitForSeconds(0.5f);
        teensESFader.FadeToOpaque();
        yield return new WaitForSeconds(0.5f);
        teensENFader.FadeToOpaque();
        yield return new WaitForSeconds(1.0f);
        copyrightFader.FadeToOpaque();

    }

    IEnumerator LoadMainScreen()
    {
        //videoPlayer.Play();
        yield return new WaitForSeconds(0.25f);
        yield return universeFader.FadeToOpaque();
        yield return SceneManager.LoadSceneAsync("Main");
    }

    public void TouchKidsIcon()
    {
        Gametype.StoreGameType(GameType.Kids);
        StartCoroutine(LoadMainScreen());
    }

    public void TouchTeensESIcon()
    {
        Gametype.StoreGameType(GameType.Teens_es);
        StartCoroutine(LoadMainScreen());
    }

    public void TouchTeensENIcon()
    {
        Gametype.StoreGameType(GameType.Teens_en);
        StartCoroutine(LoadMainScreen());
    }
        
}

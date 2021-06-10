using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Heroes { Warrior, Explorer, Philosopher, Sage, Master, Wizard, Yogi }

public class MainController : MonoBehaviour
{
    public Animator eyeAnimator;
    public Animator heroesAnimator;
    [SerializeField] GameObject FlashPrefab;
    [SerializeField] GameObject FlashParent;

    protected delegate void TouchScreenDelegate();

    TouchScreenDelegate TouchScreenCallback;

    void Start()
    {
        TouchScreenCallback = TouchScreenShowHeroes;
        FindObjectOfType<QuestionRouletteController>().OnSpinStopped += Flash;
    }

    public static Heroes HeroFromIndex(int index)
    {
        switch(index)
        {
            case 0:
                return Heroes.Warrior;
            case 1:
                return Heroes.Explorer;
            case 2:
                return Heroes.Philosopher;
            case 3:
                return Heroes.Sage;
            case 4:
                return Heroes.Master;
            case 5:
                return Heroes.Wizard;
            case 6:
                return Heroes.Yogi;
            default:
                return Heroes.Warrior;
        }
    }

    IEnumerator ShowHeroes()
    {
        eyeAnimator.SetTrigger("ScaleOut");
        yield return new WaitForSeconds(0.15f);
        heroesAnimator.SetTrigger("ScaleIn");
        HeroTouched = false;
    }

    private void TouchScreenShowHeroes()
    {
        StartCoroutine(ShowHeroes());
        TouchScreenCallback = TouchScreenDoNothing; 
    }

    private void TouchScreenStopRoulette()
    {
        FindObjectOfType<QuestionRouletteController>().StopRoulette();
        TouchScreenCallback = TouchScreenDoNothing;
        StartCoroutine(ExecuteOnTimeout(2.0f, () =>
        {
            TouchScreenCallback = TouchScreenRepeat;
        }));
        }

    IEnumerator ExecuteOnTimeout(float Timeout, System.Action action)
    {
        yield return new WaitForSeconds(Timeout);
        action();
    }

    private void TouchScreenRepeat()
    { 
        StartCoroutine(ShowHeroes());
        TouchScreenCallback = TouchScreenDoNothing;
        FindObjectOfType<QuestionRouletteController>().HideAll();

    }
    private void TouchScreenDoNothing()
    {
        // do nothing
    }

    public void TouchScreen()
    {
        TouchScreenCallback();
    }

    IEnumerator HideHeroes()
    {
        yield return new WaitForSeconds(0.15f);
        heroesAnimator.SetTrigger("ScaleOut");
        yield return new WaitForSeconds(1.00f);
        Flash();
        FindObjectOfType<QuestionRouletteController>().SpinRoulette();
    }

    private void Flash()
    {
        GameObject newGO = (GameObject)Instantiate(FlashPrefab);
        newGO.transform.SetParent(FlashParent.transform);
        newGO.transform.localScale = Vector3.one;
        newGO.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    bool HeroTouched = false;
    public void TouchOnHero(int hero)
    {
        if (HeroTouched) return;
        HeroTouched = true;
        TouchScreenCallback = TouchScreenDoNothing;
        StartCoroutine(ExecuteOnTimeout(2.0f, () =>
        {
            TouchScreenCallback = TouchScreenStopRoulette;
        }));
        FindObjectOfType<ObjectSwitch>().GetGameObject<TableSelector>().SetChannel(hero);
        TouchOnHero(HeroFromIndex(hero));
    }

    public void TouchOnHero(Heroes hero)
    {
        StartCoroutine(HideHeroes());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviour
{
	public Fader fader;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        fader.Start();
        yield return new WaitForSeconds(0.25f);
        yield return fader.FadeToTransparent();
        yield return Helpers.CancellableWait(2.0f);
        yield return fader.FadeToOpaque();
        SceneManager.LoadScene("Title");
    }

}

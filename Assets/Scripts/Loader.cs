using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Loader : MonoBehaviour
{
    public GameObject Player;
    public GameObject Fader;
    public GameObject MoveInstructions;
    public GameObject tcc;
    public float FadeTime;

    private bool showControls;

    private void Start()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.GetComponent<FirstPersonController>().enabled = false;
    }

    public void StartButtonPressed()
    {
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        var wait = new WaitForSeconds(0.01f);
        var endWait = new WaitForSeconds(0.75f);

        for (int i = 0; i <= 100; i++)
        {
            Fader.GetComponent<Image>().color = Color.Lerp(Fader.GetComponent<Image>().color, Color.black, FadeTime * Time.deltaTime);
            yield return wait;
        }

        GetComponent<Animator>().SetBool("fly", true);
        GetComponent<CursorScript>().enabled = true;

        yield return endWait;

        StartCoroutine(FadeToClear());
    }

    private IEnumerator FadeToClear()
    {
        StopCoroutine(FadeToBlack());

        var wait = new WaitForSeconds(0.05f);

        yield return wait;

        tcc.GetComponent<AudioSource>().enabled = true;

        for (int i = 0; i <= 100; i++)
        {
            Fader.GetComponent<Image>().color = Color.Lerp(Fader.GetComponent<Image>().color, Color.clear, FadeTime * Time.deltaTime);
            yield return wait;
        }
    }
    
    public void Landed() {
        Player.GetComponent<CharacterController>().enabled = true;
        Player.GetComponent<FirstPersonController>().enabled = true;
        GetComponent<Animator>().SetBool("fly", false);

        showControls = true;
        StartCoroutine(ControlsFade());
    }

    private void Update()
    {
        if (MoveInstructions.GetComponent<Image>().color.a >= 0.8f)
        {
            showControls = false;
        }
    }

    private IEnumerator ControlsFade()
    {
        var wait = new WaitForSeconds(0.1f);

        if (showControls)
        {
            while (MoveInstructions.GetComponent<Image>().color != Color.white)
            {
                MoveInstructions.GetComponent<Image>().color = Color.Lerp(MoveInstructions.GetComponent<Image>().color,
                    Color.white, FadeTime*Time.deltaTime);
                yield return wait;
            }
        }

        if (!showControls)
        {
            while (MoveInstructions.GetComponent<Image>().color != Color.clear)
            {
                MoveInstructions.GetComponent<Image>().color = Color.Lerp(MoveInstructions.GetComponent<Image>().color,
                    Color.clear, FadeTime * Time.deltaTime);
                yield return wait;
            }
        }

        
    }
}
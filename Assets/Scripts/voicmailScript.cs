using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voicmailScript : MonoBehaviour
{
    public AudioSource voicemailAudio;

    public GameObject interactText;
    public GameObject subtitleText;

    private Ray ray;
    private RaycastHit hit;

    private bool voicemailPlaying = false;
    private bool voicemailInteractAllow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "VoiceMailCube" && !voicemailPlaying)
        {
            voicemailInteractAllow = true;
            interactText.GetComponent<Text>().text = "Press 'E' to listen to voicemail message.";

        }else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "VoiceMailCube" && voicemailPlaying)
        {
            voicemailInteractAllow = true;
            interactText.GetComponent<Text>().text = "Press 'E' to turn off voicemail machine.";

        }
        else
        {
            voicemailInteractAllow = false;

        }

        if (voicemailInteractAllow && Input.GetKeyDown(KeyCode.E) && !voicemailPlaying)
        {
            playVoicemail();
        }else if (voicemailInteractAllow && Input.GetKeyDown(KeyCode.E) && voicemailPlaying)
        {
            stopVoicemail();
        }

        //Turn off voicemail after it plays
        if (!voicemailAudio.isPlaying && voicemailPlaying)
        {
            stopVoicemail();
        }
    }

    private void playVoicemail()
    {
        voicemailPlaying = true;
        voicemailAudio.Play();
        StartCoroutine(TheSequence());
    }
    private void stopVoicemail()
    {
        voicemailPlaying = false;
        voicemailAudio.Stop();
    }

    IEnumerator TheSequence()
    {
        subtitleText.GetComponent<Text>().text = "Voicemail: Click. Beep!";
        yield return new WaitForSeconds(1.5f);// 1.5
        subtitleText.GetComponent<Text>().text = "Foster Reed: Billy!";
        yield return new WaitForSeconds(1f);//2.5
        subtitleText.GetComponent<Text>().text = "This is Foster.";
        yield return new WaitForSeconds(1.3f);//3.8
        subtitleText.GetComponent<Text>().text = "For the love of Abaddon, man, don't go after it.";
        yield return new WaitForSeconds(2.9f);//6.7
        subtitleText.GetComponent<Text>().text = "Don't try to catch it or stop it.";
        yield return new WaitForSeconds(2.2f);//8.9
        subtitleText.GetComponent<Text>().text = "Y-you can't. Alright?";
        yield return new WaitForSeconds(1.5f);//10.4
        subtitleText.GetComponent<Text>().text = "Going outside to do anything in those woods right now would just be meshuga.";
        yield return new WaitForSeconds(4.4f);//14.8
        subtitleText.GetComponent<Text>().text = "Just let it do what it needs to do.";
        yield return new WaitForSeconds(4f);//18.8
        subtitleText.GetComponent<Text>().text = "Just stay in and...hopefully it'll just leave you alone.";
        yield return new WaitForSeconds(4.2f);//23
        subtitleText.GetComponent<Text>().text = "I've done all I can do for the people of this town, but they just don't listen to reason.";
        yield return new WaitForSeconds(5.6f);//28.6
        subtitleText.GetComponent<Text>().text = "...or...men with ponytails.";
        yield return new WaitForSeconds(2.4f);//31
        subtitleText.GetComponent<Text>().text = "I'll keep you in my dark prayers. Shalom.";
        yield return new WaitForSeconds(3.4f);//34.4
        subtitleText.GetComponent<Text>().text = "Voicemail: Click. Beep!";
        yield return new WaitForSeconds(1.5f);//35.9
        subtitleText.GetComponent<Text>().text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioScript : MonoBehaviour
{
    public AudioSource radioMusic;
    public AudioSource radioReportSound;
    public AudioSource staticLoopSound;
    public AudioSource radioOffSound;


    public GameObject interactText;
    public GameObject subtitleText;

    private Ray ray;
    private RaycastHit hit;

    private bool radioOn = true;
    private bool radioReportPlaying = false;
    private bool radioInteractAllow = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "RadioCube" && radioOn && !radioReportPlaying)
        {
            radioInteractAllow = true;
            interactText.GetComponent<Text>().text = "Press 'E' to change stations.";

        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "RadioCube" && radioOn && radioReportPlaying)
        {
            radioInteractAllow = true;
            interactText.GetComponent<Text>().text = "Press 'E' to turn off radio.";
        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "RadioCube" && !radioOn)
        {
            radioInteractAllow = true;
            interactText.GetComponent<Text>().text = "Press 'E' to turn on radio.";
        }
        else
        {
            radioInteractAllow = false;
        }


        if (radioInteractAllow && Input.GetKeyDown(KeyCode.E) && !radioReportPlaying)
        {
            changeToReport();
        }
        else if (radioInteractAllow && Input.GetKeyDown(KeyCode.E) && radioReportPlaying)
        {
            turnOffRadio();
        }
        else if (radioInteractAllow && Input.GetKeyDown(KeyCode.E) && !radioOn)
        {
            changeToReport();
        }

        //Switch to static loop after report plays
        if (!radioReportSound.isPlaying && radioReportPlaying)
        {
            staticLoopSound.Play();
        }
    }

    private void changeToReport()
    {
        radioOn = true;
        radioReportPlaying = true;
        radioMusic.Stop();
        radioReportSound.Play();
        StartCoroutine(TheSequence());
    }

    private void turnOffRadio()
    {
        radioOn = false;
        radioReportPlaying = false;
        radioReportSound.Stop();
        staticLoopSound.Stop();
        radioOffSound.Play();
    }

    IEnumerator TheSequence()
    {
        subtitleText.GetComponent<Text>().text = "Radio Report: ...without periling U.S. security.";
        yield return new WaitForSeconds(2f);// 2
        subtitleText.GetComponent<Text>().text = "In local news, reports of unidentified animal attacks are springing up all over Riverton - so many, in fact, that authorities are beginning to wonder if the attacks are indeed carried out by a simple beast.";
        yield return new WaitForSeconds(10.2f);// 12.2
        subtitleText.GetComponent<Text>().text = "At this time we can't be sure the perpetrator of these horrific attacks is a wild animal, or some wild man.";
        yield return new WaitForSeconds(7.1f);// 19.3
        subtitleText.GetComponent<Text>().text = "What we do know is these violent events, and ultimate deaths, are shocking and absolutely brutal.";
        yield return new WaitForSeconds(6.9f);// 26.2
        subtitleText.GetComponent<Text>().text = "Sherrif Layland Meeks spoke on the matter yesterday evening at Riverton town hall, addressing the now 4 deaths and 2 disappearances.";
        yield return new WaitForSeconds(6.9f);// 33.1
        subtitleText.GetComponent<Text>().text = "The three women, and one young man who lost their lives to this creature will not be forgotten - nor will the nature of their deaths.";
        yield return new WaitForSeconds(8.6f);// 41.7
        subtitleText.GetComponent<Text>().text = "And for the two that have gone missing, on behalf of my department, we will not give up the search.";
        yield return new WaitForSeconds(7.5f);// 49.2
        subtitleText.GetComponent<Text>().text = "67 year old Marnie Simmons, a Riverton citizen, disappeared 9 days ago. Her husband, Opal Simmons, last spoke to her over a telephone call, just minutes before a quick trip to the supermarket.";
        yield return new WaitForSeconds(10.2f);// 59.4
        subtitleText.GetComponent<Text>().text = "She, uh, called me at work, asked if I needed anything from the grocery store- said she was headed that way, just a 15 - 20 minute walk. She does it all the time. Got home later that night, wasn't home. Called Randy up at the supermarket - said Marn hadn't been in. That's when I got worried.";
        yield return new WaitForSeconds(22.1f);// 81.5
        subtitleText.GetComponent<Text>().text = "9 year old Lloyd Berkin, a student of Riverton Elementary, went missing just two days later- a mere 6 miles from Walgin's Market. His mother, Wendy, is devastated.";
        yield return new WaitForSeconds(9f);// 90.5
        subtitleText.GetComponent<Text>().text = "I just want my little boy back.";
        yield return new WaitForSeconds(3.6f);// 94.1
        subtitleText.GetComponent<Text>().text = "John Berkin, Lloyd's father, said he doesn't think his disappearance is a coincidence.";
        yield return new WaitForSeconds(5.1f);// 99.2
        subtitleText.GetComponent<Text>().text = "I heard what sounded like someone hummin' a song out by the treeline. Hadn't seen Lloyd since 7 or so.First I thought it was him.";
        yield return new WaitForSeconds(11.6f);// 110.8
        subtitleText.GetComponent<Text>().text = "I-I heard that hummin', I went out with the flashlight and found a bunch of Lloyd's green marbles layin' out, scattered all over the place.The hummin' went away, but I chased after it. It was gone quick.";
        yield return new WaitForSeconds(15.9f);// 126.7
        subtitleText.GetComponent<Text>().text = "But whatever that noise was, it was playful. I think Lloyd followed it. I think whatever it was was luring him-probably others too.";
        yield return new WaitForSeconds(9f);// 135.7
        subtitleText.GetComponent<Text>().text = "Though the town has been supportive, tragic events offer more than just sympathy from others. Some individuals believe these deaths and disappearances could deal directly with something supernatural.";
        yield return new WaitForSeconds(9.1f);// 144.8
        subtitleText.GetComponent<Text>().text = "My name is Foster Reed, and I'm a demonologist. I believe that these killings, these attacks, *munch* are certainly premeditated.";
        yield return new WaitForSeconds(11.4f);// 156.2
        subtitleText.GetComponent<Text>().text = "But if you look at the details, at the way these killings took place, you'd see a direct link to lycanthropy. The way the bodies have been dismembered - the fact that they have been separated into several pieces, and then the way they are hidden – buried, even! This is part ritual, part instinct for this creature. ";
        yield return new WaitForSeconds(26.4f);// 182.6
        subtitleText.GetComponent<Text>().text = "The fact that we are continuously interrupting this sacred practice, only means these killings are destined to continue.";
        yield return new WaitForSeconds(9.7f);// 192.3
        subtitleText.GetComponent<Text>().text = "We either have to let it do what it needs and go back to sleep, or we have to kill it. And one is much harder to do.";
        yield return new WaitForSeconds(8.8f);// 201.1
        subtitleText.GetComponent<Text>().text = "We don't need any characters making this situation more difficult than it already is. People like *static* Reed aren't *static* Riverton *static* greater *static*";
        yield return new WaitForSeconds(16.9f);// 218
        subtitleText.GetComponent<Text>().text = "";

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class identityParadeScript : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMSelectable hairLeft;
    public KMSelectable hairRight;
    public KMSelectable buildLeft;
    public KMSelectable buildRight;
    public KMSelectable attireLeft;
    public KMSelectable attireRight;
    public KMSelectable suspectLeft;
    public KMSelectable suspectRight;
    public KMSelectable convictBut;

    public KMAudio Audio;

    //Text for lists
    public TextMesh hairText;
    public TextMesh buildText;
    public TextMesh attireText;
    public TextMesh suspectText;

    //List data
    private int hairIndex;
    private List<string> hairEntries = new List<string>();
    private int buildIndex;
    private List<string> buildEntries = new List<string>();
    private int attireIndex;
    private List<string> attireEntries = new List<string>();
    private int suspectIndex;
    private List<string> suspectEntries = new List<string>();

    //Correct answers
    string hairAnswer;
    string buildAnswer;
    string attireAnswer;
    string suspectAnswer;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        hairLeft.OnInteract += delegate () { OnhairLeft(); return false; };
        hairRight.OnInteract += delegate () { OnhairRight(); return false; };
        buildLeft.OnInteract += delegate () { OnbuildLeft(); return false; };
        buildRight.OnInteract += delegate () { OnbuildRight(); return false; };
        attireLeft.OnInteract += delegate () { OnattireLeft(); return false; };
        attireRight.OnInteract += delegate () { OnattireRight(); return false; };
        suspectLeft.OnInteract += delegate () { OnsuspectLeft(); return false; };
        suspectRight.OnInteract += delegate () { OnsuspectRight(); return false; };
        convictBut.OnInteract += delegate () { OnconvictBut(); return false; };
    }

    void Start()
    {
        int correctSuspect = UnityEngine.Random.Range(0, 18);

        switch (correctSuspect)
        {
            case 0:
                andy();
                break;
            case 1:
                ben();
                break;
            case 2:
                chrissie();
                break;
            case 3:
                dylan();
                break;
            case 4:
                eddie();
                break;
            case 5:
                fiona();
                break;
            case 6:
                gemma();
                break;
            case 7:
                harriet();
                break;
            case 8:
                ian();
                break;
            case 9:
                james();
                break;
            case 10:
                kayleigh();
                break;
            case 11:
                louise();
                break;
            case 12:
                megan();
                break;
            case 13:
                nate();
                break;
            case 14:
                oscar();
                break;
            case 15:
                penny();
                break;
            case 16:
                quentin();
                break;
            case 17:
                rhiannon();
                break;
        }

        //Compile traits and character lists
        while (hairEntries.Count < 3)
        {
            getHair();
        }
        while (buildEntries.Count < 3)
        {
            getBuild();
        }
        while (attireEntries.Count < 3)
        {
            getAttire();
        }

        while (suspectEntries.Count < 9)
        {
            getSuspect();
        }

        hairIndex = UnityEngine.Random.Range(0, hairEntries.Count);
        buildIndex = UnityEngine.Random.Range(0, buildEntries.Count);
        attireIndex = UnityEngine.Random.Range(0, attireEntries.Count);
        suspectIndex = UnityEngine.Random.Range(0, suspectEntries.Count);
        hairText.text = hairEntries[hairIndex];
        buildText.text = buildEntries[buildIndex];
        attireText.text = attireEntries[attireIndex];
        suspectText.text = suspectEntries[suspectIndex];
        Debug.LogFormat("[Identity Parade #{0}] The displayed hair options are {1}, {2} & {3}.", moduleId, hairEntries[0], hairEntries[1], hairEntries[2]);
        Debug.LogFormat("[Identity Parade #{0}] The displayed build options are {1}, {2} & {3}.", moduleId, buildEntries[0], buildEntries[1], buildEntries[2]);
        Debug.LogFormat("[Identity Parade #{0}] The displayed attire options are {1}, {2} & {3}.", moduleId, attireEntries[0], attireEntries[1], attireEntries[2]);
        Debug.LogFormat("[Identity Parade #{0}] The displayed suspects are {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} & {9}.", moduleId, suspectEntries[0], suspectEntries[1], suspectEntries[2], suspectEntries[3], suspectEntries[4], suspectEntries[5], suspectEntries[6], suspectEntries[7], suspectEntries[8]);
        Debug.LogFormat("[Identity Parade #{0}] The correct suspect is {1} who is {2}, has {3} hair and is wearing a {4}.", moduleId, suspectAnswer, buildAnswer, hairAnswer, attireAnswer);
    }

    //Buttons
    public void OnhairLeft()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, hairLeft.transform);
        hairLeft.AddInteractionPunch(.5f);
        hairIndex = ((hairIndex + hairEntries.Count) - 1) % hairEntries.Count;
        hairText.text = hairEntries[hairIndex];
    }
    public void OnhairRight()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, hairRight.transform);
        hairRight.AddInteractionPunch(.5f);
        hairIndex = (hairIndex + 1) % hairEntries.Count;
        hairText.text = hairEntries[hairIndex];
    }
    public void OnbuildLeft()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, buildLeft.transform);
        buildLeft.AddInteractionPunch(.5f);
        buildIndex = ((buildIndex + buildEntries.Count) - 1) % buildEntries.Count;
        buildText.text = buildEntries[buildIndex];
    }
    public void OnbuildRight()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, buildRight.transform);
        buildRight.AddInteractionPunch(.5f);
        buildIndex = (buildIndex + 1) % buildEntries.Count;
        buildText.text = buildEntries[buildIndex];
    }
    public void OnattireLeft()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, attireLeft.transform);
        attireLeft.AddInteractionPunch(.5f);
        attireIndex = ((attireIndex + attireEntries.Count) - 1) % attireEntries.Count;
        attireText.text = attireEntries[attireIndex];
    }
    public void OnattireRight()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, attireRight.transform);
        attireRight.AddInteractionPunch(.5f);
        attireIndex = (attireIndex + 1) % attireEntries.Count;
        attireText.text = attireEntries[attireIndex];
    }
    public void OnsuspectLeft()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, suspectLeft.transform);
        suspectLeft.AddInteractionPunch(.5f);
        suspectIndex = ((suspectIndex + suspectEntries.Count) - 1) % suspectEntries.Count;
        suspectText.text = suspectEntries[suspectIndex];
    }
    public void OnsuspectRight()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, suspectRight.transform);
        suspectRight.AddInteractionPunch(.5f);
        suspectIndex = (suspectIndex + 1) % suspectEntries.Count;
        suspectText.text = suspectEntries[suspectIndex];
    }
    public void OnconvictBut()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, convictBut.transform);
        convictBut.AddInteractionPunch();
        if (hairText.text == hairAnswer && buildText.text == buildAnswer && attireText.text == attireAnswer && suspectText.text == suspectAnswer)
        {
            GetComponent<KMBombModule>().HandlePass();
            Debug.LogFormat("[Identity Parade #{0}] You convicted {1}, the {2}, {3}-haired person wearing a {4}. Congratulations, they are going to prison and the module has been disarmed.", moduleId, suspectAnswer, buildAnswer, hairAnswer, attireAnswer);
        }
        else
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Identity Parade #{0}] Strike! You convicted {1}, the {2}-haired {3} person wearing a {4}. That is not the correct combination.", moduleId, suspectText.text, hairText.text, buildText.text, attireText.text);
        }
    }

#pragma warning disable 414
    private string TwitchHelpMessage = "Cycle with “!{0} cycle hair/build/attire/suspect”. Use “!{0} convict H B A S” to submit a solution, where H B A S must be a valid hair, build, attire, and suspect. Unambiguous abbreviations are allowed (e.g. use “tank” instead of “tank top”). Invalid submissions incur a penalty.";
#pragma warning restore 414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        var split = command.ToLowerInvariant().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (split.Length == 1 && new[] { "convict", "submit" }.Contains(split[0]))
        {
            yield return new WaitForSeconds(.1f);
            convictBut.OnInteract();
            yield return new WaitForSeconds(.1f);
            yield break;
        }

        if (split.Length == 2 && split[0] == "cycle")
        {
            int numCycles;
            KMSelectable rightButton;
            switch (split[1])
            {
                case "hair": case "hairs": numCycles = hairEntries.Count; rightButton = hairRight; break;
                case "build": case "builds": numCycles = buildEntries.Count; rightButton = buildRight; break;
                case "attire": case "attires": numCycles = attireEntries.Count; rightButton = attireRight; break;
                case "suspect": case "suspects": case "people": numCycles = suspectEntries.Count; rightButton = suspectRight; break;
                default: yield break;
            }
            for (int i = 0; i < numCycles; i++)
            {
                yield return "trycancel";
                yield return new WaitForSeconds(1f);
                rightButton.OnInteract();
            }
            yield break;
        }

        if (split.Length == 5 && new[] { "convict", "submit" }.Contains(split[0]))
        {
            for (int i = 0; i < hairEntries.Count; i++)
            {
                if (hairEntries[hairIndex].IndexOf(split[1], StringComparison.InvariantCultureIgnoreCase) != -1)
                    goto hairFound;
                yield return new WaitForSeconds(.1f);
                hairRight.OnInteract();
            }
            yield return string.Format("sendtochat I don’t recognise {0} as a hair colour.", split[1]);
            yield return "unsubmittablepenalty";
            yield break;

            hairFound:
            for (int i = 0; i < buildEntries.Count; i++)
            {
                if (buildEntries[buildIndex].IndexOf(split[2], StringComparison.InvariantCultureIgnoreCase) != -1)
                    goto buildFound;
                yield return new WaitForSeconds(.1f);
                buildRight.OnInteract();
            }
            yield return string.Format("sendtochat I don’t recognise {0} as a build.", split[2]);
            yield return "unsubmittablepenalty";
            yield break;

            buildFound:
            for (int i = 0; i < attireEntries.Count; i++)
            {
                if (attireEntries[attireIndex].IndexOf(split[3], StringComparison.InvariantCultureIgnoreCase) != -1)
                    goto attireFound;
                yield return new WaitForSeconds(.1f);
                attireRight.OnInteract();
            }
            yield return string.Format("sendtochat I don’t recognise {0} as an attire.", split[3]);
            yield return "unsubmittablepenalty";
            yield break;

            attireFound:
            for (int i = 0; i < suspectEntries.Count; i++)
            {
                if (suspectEntries[suspectIndex].IndexOf(split[4], StringComparison.InvariantCultureIgnoreCase) != -1)
                    goto suspectFound;
                yield return new WaitForSeconds(.1f);
                suspectRight.OnInteract();
            }
            yield return string.Format("sendtochat I don’t recognise {0} as a suspect.", split[4]);
            yield return "unsubmittablepenalty";
            yield break;

            suspectFound:
            yield return new WaitForSeconds(.1f);
            convictBut.OnInteract();
        }
    }

    //Hair method
    void getHair()
    {
        int hairOptions = UnityEngine.Random.Range(0, 6);
        if (hairOptions == 0 && !hairEntries.Contains("Blonde"))
        {
            hairEntries.Add("Blonde");
        }
        else if (hairOptions == 1 && !hairEntries.Contains("Red"))
        {
            hairEntries.Add("Red");
        }
        else if (hairOptions == 2 && !hairEntries.Contains("Black"))
        {
            hairEntries.Add("Black");
        }
        else if (hairOptions == 3 && !hairEntries.Contains("White"))
        {
            hairEntries.Add("White");
        }
        else if (hairOptions == 4 && !hairEntries.Contains("Grey"))
        {
            hairEntries.Add("Grey");
        }
        else if (hairOptions == 5 && !hairEntries.Contains("Brown"))
        {
            hairEntries.Add("Brown");
        }
    }

    //Build method
    void getBuild()
    {
        int buildOptions = UnityEngine.Random.Range(0, 6);
        if (buildOptions == 0 && !buildEntries.Contains("Fat"))
        {
            buildEntries.Add("Fat");
        }
        else if (buildOptions == 1 && !buildEntries.Contains("Slim"))
        {
            buildEntries.Add("Slim");
        }
        else if (buildOptions == 2 && !buildEntries.Contains("Tall"))
        {
            buildEntries.Add("Tall");
        }
        else if (buildOptions == 3 && !buildEntries.Contains("Short"))
        {
            buildEntries.Add("Short");
        }
        else if (buildOptions == 4 && !buildEntries.Contains("Hunched"))
        {
            buildEntries.Add("Hunched");
        }
        else if (buildOptions == 5 && !buildEntries.Contains("Muscular"))
        {
            buildEntries.Add("Muscular");
        }
    }

    //Attire method
    void getAttire()
    {
        int attireOptions = UnityEngine.Random.Range(0, 6);
        if (attireOptions == 0 && !attireEntries.Contains("Suit"))
        {
            attireEntries.Add("Suit");
        }
        else if (attireOptions == 1 && !attireEntries.Contains("Blazer"))
        {
            attireEntries.Add("Blazer");
        }
        else if (attireOptions == 2 && !attireEntries.Contains("Tank top"))
        {
            attireEntries.Add("Tank top");
        }
        else if (attireOptions == 3 && !attireEntries.Contains("T-shirt"))
        {
            attireEntries.Add("T-shirt");
        }
        else if (attireOptions == 4 && !attireEntries.Contains("Hoodie"))
        {
            attireEntries.Add("Hoodie");
        }
        else if (attireOptions == 5 && !attireEntries.Contains("Jumper"))
        {
            attireEntries.Add("Jumper");
        }
    }

    //Suspect method
    void getSuspect()
    {
        int suspectOptions = UnityEngine.Random.Range(0, 18);
        if (suspectOptions == 0 && !suspectEntries.Contains("Andy") && (!hairEntries.Contains("Brown") || !buildEntries.Contains("Hunched") || !attireEntries.Contains("Suit")))
        {
            suspectEntries.Add("Andy");
        }
        else if (suspectOptions == 1 && !suspectEntries.Contains("Ben") && (!hairEntries.Contains("Grey") || !buildEntries.Contains("Tall") || !attireEntries.Contains("T-shirt")))
        {
            suspectEntries.Add("Ben");
        }
        else if (suspectOptions == 2 && !suspectEntries.Contains("Chrissie") && (!hairEntries.Contains("Red") || !buildEntries.Contains("Hunched") || !attireEntries.Contains("Hoodie")))
        {
            suspectEntries.Add("Chrissie");
        }
        else if (suspectOptions == 3 && !suspectEntries.Contains("Dylan") && (!hairEntries.Contains("Blonde") || !buildEntries.Contains("Short") || !attireEntries.Contains("Tank top")))
        {
            suspectEntries.Add("Dylan");
        }
        else if (suspectOptions == 4 && !suspectEntries.Contains("Eddie") && (!hairEntries.Contains("Grey") || !buildEntries.Contains("Slim") || !attireEntries.Contains("Suit")))
        {
            suspectEntries.Add("Eddie");
        }
        else if (suspectOptions == 5 && !suspectEntries.Contains("Fiona") && (!hairEntries.Contains("Brown") || !buildEntries.Contains("Tall") || !attireEntries.Contains("Hoodie")))
        {
            suspectEntries.Add("Fiona");
        }
        else if (suspectOptions == 6 && !suspectEntries.Contains("Gemma") && (!hairEntries.Contains("Grey") || !buildEntries.Contains("Short") || !attireEntries.Contains("Blazer")))
        {
            suspectEntries.Add("Gemma");
        }
        else if (suspectOptions == 7 && !suspectEntries.Contains("Harriet") && (!hairEntries.Contains("Black") || !buildEntries.Contains("Fat") || !attireEntries.Contains("T-shirt")))
        {
            suspectEntries.Add("Harriet");
        }
        else if (suspectOptions == 8 && !suspectEntries.Contains("Ian") && (!hairEntries.Contains("White") || !buildEntries.Contains("Tall") || !attireEntries.Contains("Jumper")))
        {
            suspectEntries.Add("Ian");
        }
        else if (suspectOptions == 9 && !suspectEntries.Contains("James") && (!hairEntries.Contains("Red") || !buildEntries.Contains("Muscular") || !attireEntries.Contains("Tank top")))
        {
            suspectEntries.Add("James");
        }
        else if (suspectOptions == 10 && !suspectEntries.Contains("Kayleigh") && (!hairEntries.Contains("White") || !buildEntries.Contains("Short") || !attireEntries.Contains("Tank top")))
        {
            suspectEntries.Add("Kayleigh");
        }
        else if (suspectOptions == 11 && !suspectEntries.Contains("Louise") && (!hairEntries.Contains("Blonde") || !buildEntries.Contains("Fat") || !attireEntries.Contains("Suit")))
        {
            suspectEntries.Add("Louise");
        }
        else if (suspectOptions == 12 && !suspectEntries.Contains("Megan") && (!hairEntries.Contains("Brown") || !buildEntries.Contains("Slim") || !attireEntries.Contains("Blazer")))
        {
            suspectEntries.Add("Megan");
        }
        else if (suspectOptions == 13 && !suspectEntries.Contains("Nate") && (!hairEntries.Contains("Red") || !buildEntries.Contains("Fat") || !attireEntries.Contains("Jumper")))
        {
            suspectEntries.Add("Nate");
        }
        else if (suspectOptions == 14 && !suspectEntries.Contains("Oscar") && (!hairEntries.Contains("Black") || !buildEntries.Contains("Slim") || !attireEntries.Contains("Hoodie")))
        {
            suspectEntries.Add("Oscar");
        }
        else if (suspectOptions == 15 && !suspectEntries.Contains("Penny") && (!hairEntries.Contains("Blonde") || !buildEntries.Contains("Muscular") || !attireEntries.Contains("T-shirt")))
        {
            suspectEntries.Add("Penny");
        }
        else if (suspectOptions == 16 && !suspectEntries.Contains("Quentin") && (!hairEntries.Contains("White") || !buildEntries.Contains("Hunched") || !attireEntries.Contains("Blazer")))
        {
            suspectEntries.Add("Quentin");
        }
        else if (suspectOptions == 17 && !suspectEntries.Contains("Rhiannon") && (!hairEntries.Contains("Black") || !buildEntries.Contains("Muscular") || !attireEntries.Contains("Jumper")))
        {
            suspectEntries.Add("Rhiannon");
        }
    }

    //Suspect database
    void andy()
    {
        hairEntries.Add("Brown");
        buildEntries.Add("Hunched");
        attireEntries.Add("Suit");
        suspectEntries.Add("Andy");
        hairAnswer = "Brown";
        buildAnswer = "Hunched";
        attireAnswer = "Suit";
        suspectAnswer = "Andy";
    }
    void ben()
    {
        hairEntries.Add("Grey");
        buildEntries.Add("Tall");
        attireEntries.Add("T-shirt");
        suspectEntries.Add("Ben");
        hairAnswer = "Grey";
        buildAnswer = "Tall";
        attireAnswer = "T-shirt";
        suspectAnswer = "Ben";
    }
    void chrissie()
    {
        hairEntries.Add("Red");
        buildEntries.Add("Hunched");
        attireEntries.Add("Hoodie");
        suspectEntries.Add("Chrissie");
        hairAnswer = "Red";
        buildAnswer = "Hunched";
        attireAnswer = "Hoodie";
        suspectAnswer = "Chrissie";
    }
    void dylan()
    {
        hairEntries.Add("Blonde");
        buildEntries.Add("Short");
        attireEntries.Add("Tank top");
        suspectEntries.Add("Dylan");
        hairAnswer = "Blonde";
        buildAnswer = "Short";
        attireAnswer = "Tank top";
        suspectAnswer = "Dylan";
    }
    void eddie()
    {
        hairEntries.Add("Grey");
        buildEntries.Add("Slim");
        attireEntries.Add("Suit");
        suspectEntries.Add("Eddie");
        hairAnswer = "Grey";
        buildAnswer = "Slim";
        attireAnswer = "Suit";
        suspectAnswer = "Eddie";
    }
    void fiona()
    {
        hairEntries.Add("Brown");
        buildEntries.Add("Tall");
        attireEntries.Add("Hoodie");
        suspectEntries.Add("Fiona");
        hairAnswer = "Brown";
        buildAnswer = "Tall";
        attireAnswer = "Hoodie";
        suspectAnswer = "Fiona";
    }
    void gemma()
    {
        hairEntries.Add("Grey");
        buildEntries.Add("Short");
        attireEntries.Add("Blazer");
        suspectEntries.Add("Gemma");
        hairAnswer = "Grey";
        buildAnswer = "Short";
        attireAnswer = "Blazer";
        suspectAnswer = "Gemma";
    }
    void harriet()
    {
        hairEntries.Add("Black");
        buildEntries.Add("Fat");
        attireEntries.Add("T-shirt");
        suspectEntries.Add("Harriet");
        hairAnswer = "Black";
        buildAnswer = "Fat";
        attireAnswer = "T-shirt";
        suspectAnswer = "Harriet";
    }
    void ian()
    {
        hairEntries.Add("White");
        buildEntries.Add("Tall");
        attireEntries.Add("Jumper");
        suspectEntries.Add("Ian");
        hairAnswer = "White";
        buildAnswer = "Tall";
        attireAnswer = "Jumper";
        suspectAnswer = "Ian";
    }
    void james()
    {
        hairEntries.Add("Red");
        buildEntries.Add("Muscular");
        attireEntries.Add("Tank top");
        suspectEntries.Add("James");
        hairAnswer = "Red";
        buildAnswer = "Muscular";
        attireAnswer = "Tank top";
        suspectAnswer = "James";
    }
    void kayleigh()
    {
        hairEntries.Add("White");
        buildEntries.Add("Short");
        attireEntries.Add("Tank top");
        suspectEntries.Add("Kayleigh");
        hairAnswer = "White";
        buildAnswer = "Short";
        attireAnswer = "Tank top";
        suspectAnswer = "Kayleigh";
    }
    void louise()
    {
        hairEntries.Add("Blonde");
        buildEntries.Add("Fat");
        attireEntries.Add("Suit");
        suspectEntries.Add("Louise");
        hairAnswer = "Blonde";
        buildAnswer = "Fat";
        attireAnswer = "Suit";
        suspectAnswer = "Louise";
    }
    void megan()
    {
        hairEntries.Add("Brown");
        buildEntries.Add("Slim");
        attireEntries.Add("Blazer");
        suspectEntries.Add("Megan");
        hairAnswer = "Brown";
        buildAnswer = "Slim";
        attireAnswer = "Blazer";
        suspectAnswer = "Megan";
    }
    void nate()
    {
        hairEntries.Add("Red");
        buildEntries.Add("Fat");
        attireEntries.Add("Jumper");
        suspectEntries.Add("Nate");
        hairAnswer = "Red";
        buildAnswer = "Fat";
        attireAnswer = "Jumper";
        suspectAnswer = "Nate";
    }
    void oscar()
    {
        hairEntries.Add("Black");
        buildEntries.Add("Slim");
        attireEntries.Add("Hoodie");
        suspectEntries.Add("Oscar");
        hairAnswer = "Black";
        buildAnswer = "Slim";
        attireAnswer = "Hoodie";
        suspectAnswer = "Oscar";
    }
    void penny()
    {
        hairEntries.Add("Blonde");
        buildEntries.Add("Muscular");
        attireEntries.Add("T-shirt");
        suspectEntries.Add("Penny");
        hairAnswer = "Blonde";
        buildAnswer = "Muscular";
        attireAnswer = "T-shirt";
        suspectAnswer = "Penny";
    }
    void quentin()
    {
        hairEntries.Add("White");
        buildEntries.Add("Hunched");
        attireEntries.Add("Blazer");
        suspectEntries.Add("Quentin");
        hairAnswer = "White";
        buildAnswer = "Hunched";
        attireAnswer = "Blazer";
        suspectAnswer = "Quentin";
    }
    void rhiannon()
    {
        hairEntries.Add("Black");
        buildEntries.Add("Muscular");
        attireEntries.Add("Jumper");
        suspectEntries.Add("Rhiannon");
        hairAnswer = "Black";
        buildAnswer = "Muscular";
        attireAnswer = "Jumper";
        suspectAnswer = "Rhiannon";
    }

}

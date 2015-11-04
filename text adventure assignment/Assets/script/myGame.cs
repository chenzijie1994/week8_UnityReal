using UnityEngine;
using System.Collections;

public class myGame : MonoBehaviour {

    private string currentPlace = "start";

    [Header("audio staff")]
    public AudioSource bgm;
    public AudioClip bgmWin;
    public AudioClip bgmLose;
    public AudioSource sfx;
    public AudioClip sfxGetKey;
    public AudioClip sfxOpenDoor;

    private bool bgmChanged = false;

    [Header("places")]
    public string place_north;
    public string place_south;
    public string place_east;
    public string place_west;

    private bool hasMagicKey = false;
    private bool hasRustyKey = false;
    private bool hasAncientKey = false;
    private bool hasCrusedKey = false;

    private bool hasMagicDoorOpen = false;
    private bool hasHeavyDoorOpen = false;
    private bool hasRustyDoorOpen = false;
    private bool hasCrusedDoorOpen = false;

    private bool hasDragonSpear = false;
    private bool hasCrystalBall = false;
    private bool hasMagicArmor = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        string textBuffer = "";
        place_north = "";
        place_south = "";
        place_west = "";
        place_east = "";

        switch (currentPlace)
        {
            case "start":
                textBuffer = "The Great Battle\n" +
                    "\n by James Chen" +
                    "\nPress 'A' to start the game";

                if (Input.GetKeyDown(KeyCode.A))
                    {
                        currentPlace = "starting point";
                    }

                break;
            case "starting point":
                textBuffer = "you are currently at the starting point.\n";

                place_east = "road junction";

                break;
            case "road junction":
                textBuffer = "you are currently at the road junction.\n";

                place_east = "extinct volcano";
                place_west = "starting point";
                place_south = "dark corridor";

                break;
            case "extinct volcano":

                textBuffer = "you are currently at the extinct volcano.\n";

                place_north = "cursed door";
                place_east = "warrior's treasure room";
                place_west = "road junction";

                break;
            case "warrior's treasure room":

                textBuffer = "you are currently at the warrior's treasure room.\n";

                textBuffer += "you search around this area \n" +
                "and find a Dragon Spear.";

                hasDragonSpear = true;

                place_west = "extinct volcano";

                break;
            case "dark corridor":

                textBuffer = "you are currently at the dark corridor.\n";

                textBuffer += "you find a broken box.\n" +
                        "press 'o' to open the box.";

                if (Input.GetKeyDown(KeyCode.O))
                {
                    hasMagicKey = true;
                    currentPlace = "get magic key";
                    sfx.PlayOneShot(sfxGetKey);
                }

                place_south = "habour";
                place_north = "road junction";

                break;
            case "get magic key":
                textBuffer = "you got the magic key.\n" +
                    "press any key to get back.";

                if (Input.anyKeyDown)
                {
                    currentPlace = "dark corridor";
                }

                break;
            case "habour":

                textBuffer = "you are currently at the habour.\n";

                place_west = "mysterious island";
                place_east = "mystic forest";
                place_north = "dark corridor";

                break;
            case "mysterious island" :

                textBuffer = "you are currently at the mysterious island.\n";

                place_east = "habour";
                place_south = "deep sea";

                break;
            case "deep sea":

                textBuffer = "you are currently at the deep sea.\n";

                place_west = "wreckage";
                place_south = "ruins";
                place_north = "mysterious island";

                break;
            case "wreckage":

                textBuffer = "you are currently at the wreckage.\n";

                textBuffer += "you find a broken box.\n" +
                        "press 'o' to open the box.";

                if (Input.GetKeyDown(KeyCode.O))
                {
                    hasRustyKey = true;
                    currentPlace = "get rusty key";
                    sfx.PlayOneShot(sfxGetKey);
                }

                place_east = "deep sea";

                break;
            case "get rusty key":
                textBuffer = "you got the rusty key.\n" +
                    "press any key to get back.";

                if (Input.anyKeyDown)
                {
                    currentPlace = "wreckage";
                }

                break;
            case "ruins":

                textBuffer = "you are currently at the ruins.\n" +
                    "you search around strenuously but find nothing.\n" +
                    "'why is there a empty room here, it's mreaningless!'you whine";

                place_north = "deep sea";

                break;
            case "mystic forest":

                textBuffer = "you are currently in the mystic forest.\n";

                place_west = "habour";
                place_east = "slient road";
                place_south = "sacred mountain";

                break;
            case "sacred mountain":

                textBuffer = "you are currently in the sacred mountain.\n";

                place_north = "mystic forest";
                place_south = "teleportation circle";

                break;
            case "teleportation circle":

                textBuffer = "after you pass the mountain, the mountain disappears.\n" +
                    "but after search around, you find a teleportation circle.\n" +
                    "press 't' to activate it.";

                if (Input.GetKeyDown(KeyCode.T))
                {
                    currentPlace = "starting point";
                }

                break;
            case "slient road":
                textBuffer = "you are currently at the slient road.\n";

                    textBuffer += "you find a broken box.\n" +
                        "press 'o' to open the box.";

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        hasAncientKey = true;
                        currentPlace = "get ancient key";
                        sfx.PlayOneShot(sfxGetKey);
                    }

                place_east = "cross road";
                place_west = "mystic forest";

                break;
            case "get ancient key":
                textBuffer = "you got the ancient key.\n" +
                    "press any key to get back.";

                if (Input.anyKeyDown)
                {
                    currentPlace = "slient road";
                }

                break;
            case "cross road":

                textBuffer = "you are currently at the cross road";

                place_west = "slient road";
                place_east = "magic door";
                place_north = "rusty door";
                place_south = "heavy door";

                break;
            case "magic door":

                if (hasMagicKey)
                {
                    textBuffer = "you use the key to open the door";
                    
                    place_east = "prophet's house";

                    if (!hasMagicDoorOpen)
                    {
                        hasMagicDoorOpen = true;
                        sfx.PlayOneShot(sfxOpenDoor);

                    }
                }
                else
                {
                    textBuffer = "the door is locked. Press any key to return to the cross road";

                    if (Input.anyKeyDown)
                    {
                        currentPlace = "cross road";
                    }
                }

                break;
            case "prophet's house":
                textBuffer = "you enter the prophet's house.\n" +
                    "you try hard to seaarch around.\n" +
                    "but only manage to dins some empty box.\n" +
                    "'Damn, someone comes before me!'you whine";

                place_east = "prophet's garden";
                place_west = "cross road";

                break;
            case "prophet's garden":

                textBuffer = "you are currently at the prophet's garden.\n";

                textBuffer += "you find a broken box.\n" +
                        "press 'o' to open the box.";

                if (Input.GetKeyDown(KeyCode.O))
                {
                    hasCrusedKey = true;
                    currentPlace = "get crused key";
                    sfx.PlayOneShot(sfxGetKey);
                }

                place_west = "prophet's house";

                break;
            case "get crused key":
                textBuffer = "you got the crused key.\n" +
                    "press any key to get back.";

                if (Input.anyKeyDown)
                {
                    currentPlace = "prophet's garden";
                }

                break;

            case "heavy door":

                if (hasAncientKey)
                {
                    textBuffer = "you use the key to open the door";

                    place_east = "nameless hero's tomb";

                    if (!hasHeavyDoorOpen)
                    {
                        hasHeavyDoorOpen = true;
                        sfx.PlayOneShot(sfxOpenDoor);

                    }
                }
                else
                {
                    textBuffer = "the door is locked. Press any key to return to the cross road";

                    if (Input.anyKeyDown)
                    {
                        currentPlace = "cross road";
                    }
                }

                break;
            case "nameless hero's tomb":

                textBuffer = "you are currently at the nameless hero's tomb.\n";

                    textBuffer += "you search around this area \n" +
                    "and find the magic armor.";

                    hasMagicArmor = true;

                place_north = "cross road";

                break;
            case "rusty door":

                if (hasRustyKey)
                {
                    textBuffer = "you use the key to open the door";

                    place_east = "magician's library";

                    if (!hasRustyDoorOpen)
                    {
                        hasRustyDoorOpen = true;
                        sfx.PlayOneShot(sfxOpenDoor);

                    }
                }
                else
                {
                    textBuffer = "the door is locked. Press any key to return to the cross road";

                    if (Input.anyKeyDown)
                    {
                        currentPlace = "cross road";
                    }
                }

                break;
            case "magician's library":

                textBuffer = "you are currently at the magician's library.\n";

                    textBuffer += "you search around this area \n" +
                    "and find the crystal ball.";

                    hasCrystalBall = true;

                place_north = "cross road";

                break;                                                                                                                                          
            case "cursed door":

                if (hasCrusedKey)
                {
                    textBuffer = "you use the key to open the door";

                    place_east = "place of decisive battle";

                    if (!hasCrusedDoorOpen)
                    {
                        hasCrusedDoorOpen = true;
                        sfx.PlayOneShot(sfxOpenDoor);

                    }
                }
                else
                {
                    textBuffer = "the door is locked. Press any key to return to the extinct volcano";

                    if (Input.anyKeyDown)
                    {
                        currentPlace = "extinct volcano";
                    }
                }

                break;
            case "place of decisive battle":
                textBuffer = "you are in the place of decisive battle.\n" +
                    "you meet the evil game designer James Chen";
                if (hasDragonSpear && hasCrystalBall && hasMagicArmor)
                {
                    textBuffer += "\n After the great fight, you finally beat James Chen.\n" +
                        "Your name has been written into the history book.\n" +
                        "\n congratulations! you win!";
                    if (!bgmChanged)
                    {
                        bgm.clip = bgmWin;
                        bgm.PlayOneShot(bgmWin);
                        bgmChanged = true;
                    }
                }
                else
                {
                    textBuffer = "\n you finally beaten by James Chen due to lack of energy.\n" +
                        "'you are too weak to beat me, hahahaha' James Chen laughs arrogantly.\n" +
                        "\n Game Over.";
                    if (!bgmChanged)
                    {
                        bgm.clip = bgmLose;
                        bgm.PlayOneShot(bgmLose);
                        bgmChanged = true;
                    }
                }
                break;
            default:
                break;

        }


        if (place_north != "")
        {
            textBuffer += "\n Press 'n' to go to the " + place_north + ".";

            if (Input.GetKeyDown(KeyCode.N))
            {
                currentPlace = place_north;
            }
        }

        if (place_south != "")
        {
            textBuffer += "\n Press 's' to go to the " + place_south + ".";

            if (Input.GetKeyDown(KeyCode.S))
            {
                currentPlace = place_south;
            }
        }

        if (place_east != "")
        {
            textBuffer += "\n Press 'e' to go to the " + place_east + ".";

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentPlace = place_east;
            }
        }


        if (place_west != "")
        {
            textBuffer += "\n Press 'w' to go to the " + place_west + ".";

            if (Input.GetKeyDown(KeyCode.W))
            {
                currentPlace = place_west;
            }
        }

        GetComponent<TextMesh>().text = textBuffer;
    }
}
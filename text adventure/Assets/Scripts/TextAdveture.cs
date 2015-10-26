using UnityEngine;
using System.Collections;

public class TextAdveture : MonoBehaviour {

    public string currentRoom = "entryway";

    public string room_north;
    public string room_south;
    public string room_east;
    public string room_west;

    private bool hasKey = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        string textBuffer = "";
        room_north = "";
        room_south = "";
        room_west = "";
        room_east = "";

        switch (currentRoom) {
            case "entryway":
                textBuffer = "you are in the entryway.\n";

                room_north = "magicRoom";
                room_south = "privateRoom";

                break;
            case "magicRoom":
                textBuffer = "you are in the magic room.\n";

                room_south = "entryway";
                room_west = "key room";
                
                break;
            case "key room":
                textBuffer = "you are in the key room.\n" +
                    "there is a box.\n" +
                    "press 'o' to open the box";

                if (Input.GetKeyDown(KeyCode.O))
                {
                    hasKey = true;
                    currentRoom = "gotKey";
                }

                room_east = "magicRoom";
                break;
            case "gotKey":
                textBuffer = "you got the key.\n" +
                    "press any key";

                if (Input.anyKeyDown)
                {
                    currentRoom = "key room";
                }
                break;
            case "privateRoom":
                textBuffer = "you are in the private room.\n";

                room_north = "entryway";
                room_south = "private room door";

                break;
            case "private room door":
                if (hasKey)
                {
                    textBuffer = "you use the key to open the door";

                    room_east = "partyRoom";
                }
                else {
                    textBuffer = "the door is locked. Press any key to return to the private room";

                    if (Input.anyKeyDown) {
                        currentRoom = "privateRoom";
                    }
                }
                break;
            case "partyRoom":
                textBuffer = "you are in the party room.\n" +
                    "you win.";
                break;
            default:
                break;
            
        }


        if (room_north != "") {
            textBuffer += "\n Press 'n' to go to the " + room_north + ".";

            if (Input.GetKeyDown(KeyCode.N)) {
                currentRoom = room_north;
            }
        }

        if (room_south != "")
        {
            textBuffer += "\n Press 's' to go to the " + room_south + ".";

            if (Input.GetKeyDown(KeyCode.S))
            {
                currentRoom = room_south;
            }
        }

        if (room_east != "")
        {
            textBuffer += "\n Press 'e' to go to the " + room_east + ".";

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentRoom = room_east;
            }
        }


        if (room_west != "")
        {
            textBuffer += "\n Press 'w' to go to the " + room_west + ".";

            if (Input.GetKeyDown(KeyCode.W))
            {
                currentRoom = room_west;
            }
        }

        GetComponent<TextMesh>().text = textBuffer;
    }
}

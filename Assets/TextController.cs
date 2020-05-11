using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextController : MonoBehaviour
{

    public Text text;
    
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, stairs_1,
		stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3,closet_door, in_closet
	};

	private States myState;
    
    // Use this for initialization
    public void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    public void Update() {
        switch (myState) {
            case States.cell:
                cell();
                break;
            case States.sheets_0:
                sheets_0();
                break;
            case States.mirror:
                mirror();
                break;
            case States.lock_0:
                lock_0();
                break;
            case States.cell_mirror:
                cell_mirror();
                break;
            case States.sheets_1:
                sheets_1();
                break;
            case States.lock_1:
                lock_1();
                break;
            case States.corridor_0:
                corridor_0();
                break;
            case States.stairs_0:
                stairs_0();
                break;
            case States.stairs_1:
                stairs_1();
                break;
            case States.stairs_2:
                stairs_2();
                break;
            case States.courtyard:
                courtyard();
                break;
            case States.floor:
                floor();
                break;
            case States.corridor_1:
                corridor_1();
                break;
            case States.corridor_2:
                corridor_2();
                break;
            case States.corridor_3:
                corridor_3();
                break;
            case States.closet_door:
                closet_door();
                break;
            case States.in_closet:
                in_closet();
                break;
        }
    }

    #region state handlers
    private void cell() {
        /*
        string history = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque ";
        history += "penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis,";
        history += "sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut,";
        history += "imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum ";
        */
        string history = "You are in a prison cell, and you want to escape. There are ";
        history += "some dirty sheets on the bed, a mirror on the wall, and the door ";
        history += "is locked from the outside.\n\n\r";
        history += "Press S to view Sheets, or M to view Mirror, or L to view Lock";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.M)) {
            myState = States.mirror;
        } else  if (Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_0;
        }
    }

    public void sheets_0() {
        string history = "You cant believe you sleep in these things. Surely its ";
        history += "time somebody changed them. The pleasures of prison life ";
        history += "I guess!\n\n\r";
        history += "Press R to Return to roaming your cell";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }

    public void mirror() {
        string history = "The dirty old mirror on the wall seems loose.";
        history += "\n\n\r";
        history += "Press T to take the mirror, or R to return to cell";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        } else if (Input.GetKeyDown(KeyCode.T)) {
            myState = States.cell_mirror;
        }
    }

    public void lock_0() {
        string history = "This is one of those button locks. You have no idea what the ";
        history += "combination is. You wish you could somehow see where the dirty ";
        history += "fingerprints were, maybe that would help.\n\n\r";
        history += "Press R to Return to roaming your cell";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }

    public void cell_mirror() {
        string history = "You are in your cell, and you STILL want to escape! There are ";
        history += "some dirty sheets on the bed, a mark where there mirror was, ";
        history += "and the pesky door is still there, and firmly locked!\n\n\r";
        history += "Press S to view Sheets, or L to view Lock";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_1;
        } else if (Input.GetKeyDown(KeyCode.T)) {
            myState = States.mirror;
        } else if (Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_1;
        }
    }

    public void sheets_1() {
        string history = "Holding a mirror in your hand doesn't make the sheets look ";
        history += "any better\n\n\r";
        history += "Press R to Return to your cell";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        }
    }

    public void lock_1() {
        string history = "You carefully put the mirror through the bars, and turn it round ";
        history += "so you can see the lock. You can just make out fingerprints around ";
        history += "the buttons. You press the dirty buttons, and hear a click\n\n\r";
        history += "Press O to Open, or R to Return to your cell";

        text.text = history;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        } else if (Input.GetKeyDown(KeyCode.O)) {
            myState = States.corridor_0;
        }
    }

    public void corridor_0() {
        text.text = "You're out of your cell, but not out of trouble." +
                    "You are in the corridor, there's a closet and some stairs leading to " +
                    "the courtyard. There's also various detritus on the floor.\n\n" +
                    "C to view the Closet, F to inspect the Floor, and S to climb the stairs";

        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.stairs_0;
        } else if (Input.GetKeyDown(KeyCode.F)) {
            myState = States.floor;
        } else if (Input.GetKeyDown(KeyCode.C)) {
            myState = States.closet_door;
        }
    }

    private void in_closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
                    "Seems like your day is looking-up.\n\n" +
                    "Press D to Dress up, or R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_2;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            myState = States.corridor_3;
        }
    }

    void closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_0;
        }
	}
	
	void corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";

        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.courtyard;
        } else if (Input.GetKeyDown(KeyCode.U))	{
            myState = States.in_closet;
        }
	}
	
	void corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, and S to climb the stairs";

        if (Input.GetKeyDown(KeyCode.C)) {
            myState = States.in_closet;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.stairs_2;
        }
	}
	
	void corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"P to Pick the lock, and S to climb the stairs";

        if (Input.GetKeyDown(KeyCode.P)) {
            myState = States.in_closet;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.stairs_1;
        }
	}
	
	void floor () {
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press R to Return to the standing, or H to take the Hairclip." ;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_0;
        } else if (Input.GetKeyDown(KeyCode.H)) {
            myState = States.corridor_1;
        }
	}	
	
	void courtyard () {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P to Play again." ;

        if (Input.GetKeyDown(KeyCode.P)) {
            myState = States.cell;
        }
	}	
	
	void stairs_0 () {
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor." ;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_0;
        }
	}
	
	void stairs_1 () {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_1;
        }
	}
	
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.corridor_2;
        }
	}

    #endregion

}
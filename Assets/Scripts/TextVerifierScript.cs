using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextVerifierScript : MonoBehaviour {
    Text saviorLast, savior1, savior2, toSave1, toSave2;
    TextTyperScript scriptSaviorLast, scriptSavior1, scriptSavior2, scriptToSave1, scriptToSave2;
    bool saviorText1Done = false;
    bool saviorText2Done = false;
    bool saviorLastTextDone = false;
    bool toSaveText1Done = false;
    bool toSaveText2Done = false;
    GameObject savior, toSave;
    // Use this for initialization
    void Start() {
        savior = GameObject.Find("Savior");
        toSave = GameObject.Find("ToSave");

        foreach (Text texto in GetComponentsInChildren<Text>())
        {

            Debug.Log("start");
            switch (texto.name)
            {
                case "SaviorLastText":
                    scriptSaviorLast = texto.GetComponent<Text>().GetComponent<TextTyperScript>();
                    saviorLast = texto;
                    break;
                case "SaviorText1":
                    scriptSavior1 = texto.GetComponent<Text>().GetComponent<TextTyperScript>();
                    savior1 = texto;
                    break;
                case "SaviorText2":
                    scriptSavior2 = texto.GetComponent<Text>().GetComponent<TextTyperScript>();
                    savior2 = texto;
                    break;
                case "ToSaveText1":
                    scriptToSave1 = texto.GetComponent<Text>().GetComponent<TextTyperScript>();
                    toSave1 = texto;
                    break;
                case "ToSaveText2":
                    scriptToSave2 = texto.GetComponent<Text>().GetComponent<TextTyperScript>();
                    toSave2 = texto;
                    break;                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!toSaveText1Done)
        {
            verifyToSaveText1();
        }
        if (!toSaveText2Done)
        {
            verifyToSaveText2();
        }
        if (!saviorText1Done)
        {
            verifySaviorText1();
        }
        if (!saviorText2Done)
        {
            verifySaviorText2();
        }
        if (!saviorLastTextDone)
        {
            verifySaviorLastText();
        }
    }

    void verifyToSaveText1()
    {

        if (scriptToSave1.endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                toSave1.enabled = false;
                savior1.enabled = true;
                scriptSavior1.enabled = true;

                savior.GetComponentInChildren<Player>().CurrentHp = 100;

                savior.GetComponentInChildren<Animator>().Play("Idle");



                savior.GetComponentInChildren<MovementIntroAI>().enabled = true;
                savior.GetComponentInChildren<MovementIntroAI>().target = toSave.transform;
                savior.GetComponentInChildren<MovementIntroAI>().enabled = false;
                Vector3 theScale = savior.transform.localScale;
                theScale.x *= -1;
                savior.transform.localScale = theScale;
                toSaveText1Done = true;

            }

        }
    }

    

    

    void verifySaviorText1()
    {

        if (scriptSavior1.endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                savior1.enabled = false;
                toSave2.enabled = true;
                scriptToSave2.enabled = true;
            }


        }
    }

    void verifyToSaveText2()
    {


        if (scriptToSave2.endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                toSave2.gameObject.SetActive(false);
                savior2.enabled = true;
                scriptSavior2.enabled = true;

                toSave.GetComponentInChildren<Player>().CurrentHp = 0;


            }


        }
    }

    void verifySaviorText2()
    {

        if (scriptSavior2.endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject character = GameObject.Find("ToSave");
                GameObject player = GameObject.Find("Savior");
                player.tag = "Player";
                character.tag = "Untagged";


                

                savior2.gameObject.SetActive(false);
                saviorLast.enabled = true;
                scriptSaviorLast.enabled = true;
            }

        }
    }

    void verifySaviorLastText(){
        if (scriptSaviorLast.endText) {
            if (Input.GetButtonDown("Fire1")){

                GameObject.Find("Speech2").SetActive(false);
                MovementIntroAI mv = savior.GetComponentInChildren<MovementIntroAI>();
                mv.animator = savior.GetComponentInChildren<Animator>();
                mv.enabled = true;
                mv.target = GameObject.Find("DoorSprite").transform;
                Vector3 theScale = savior.transform.localScale;
                theScale.x *= -1;
                savior.transform.localScale = theScale;
                GameObject.Find("PlayerCamera").GetComponentInChildren<SmoothFollow>().enabled = false;
            }

        }
    }
}

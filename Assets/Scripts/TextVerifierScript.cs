using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextVerifierScript : MonoBehaviour {
    Text saviorLast, savior1, savior2, toSave1, toSave2;
    TextTyperScript scriptSaviorLast, scriptSavior1, scriptSavior2, scriptToSave1, scriptToSave2;
    // Use this for initialization
    void Start() {
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
        verifyToSaveText1();
        verifyToSaveText2();
        verifySaviorText1();
        verifySaviorText2();
        verifySaviorLastText();
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


            }


        }
    }

    void verifySaviorText2()
    {

        if (scriptSavior2.endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject character = GameObject.FindGameObjectWithTag("Player");
                GameObject player = GameObject.Find("Savior");
                character.GetComponent<Player>().CurrentHp = 0f;
                character.tag = "Untagged";
                savior2.enabled = false;
                saviorLast.enabled = true;
                scriptSaviorLast.enabled = true;
            }

        }
    }

    void verifySaviorLastText(){
        if (scriptSaviorLast.endText) {
            if (Input.GetButtonDown("Fire1")){
                GameObject character = GameObject.FindGameObjectWithTag("Player");
                MovementIntroAI mv = character.GetComponentInChildren<MovementIntroAI>();
                mv.enabled = true;
                mv.SendMessage("Flip");
                GameObject.Find("PlayerCamera").GetComponentInChildren<SmoothFollow>().enabled = false;
            }

        }
    }
}

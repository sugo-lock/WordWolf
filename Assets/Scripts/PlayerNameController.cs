using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name;
        InputField inputField;

        name = PlayerPrefs.GetString(this.name);
        inputField = this.GetComponent<InputField>();
        inputField.text = name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StorePlayerName()
    {
        InputField inputField;
        inputField = this.GetComponent<InputField>();

        PlayerPrefs.SetString(this.name, inputField.text);
        PlayerPrefs.Save();

    }
}

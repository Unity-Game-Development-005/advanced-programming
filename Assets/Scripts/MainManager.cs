
using System.Configuration;
using UnityEngine;

// for data input/output
using System.IO;


public class MainManager : MonoBehaviour
{
    // *** CREATE A SINGLETON PATTERN OF MAIN MANAGER ***

    // create a static instance of main manager to make it persistent
    // allow the instance to be read from other scripts                       - get
    // but do not allow other scripts to be able to change the instance value - private set
    public static MainManager Instance { get; private set; }

    // reference to unit colour
    public Color unitColour;




    private void Awake()
    {
        // if an instance of this class already exists
        if (Instance != null)
        {
            // then destroy the instance
            Destroy(gameObject);
        }

        // otherwise
        // create an instance of this class
        Instance = this;

        // then make the instance of this class persistent
        DontDestroyOnLoad(gameObject);


        // load the selected colour
        LoadColour();
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    // saves selected colour
    public void SaveColour()
    {
        // create a new save data object
        SaveData dataToSave = new SaveData();

        // assign the object unit colour to the main unit colour
        dataToSave._unitColour = unitColour;

        // create a json byte string file
        string jsonByteFile = JsonUtility.ToJson(dataToSave);

        // then save the file to the devices' persistent data storage area
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonByteFile);
    }


    // loads selected colour
    public void LoadColour()
    {
        // data path to the devices' persistent storage area
        string dataPath = Application.persistentDataPath + "/savefile.json";

        // first check to see if the data file exists at the specified location
        if (File.Exists(dataPath))
        {
            // if the file exists
            // read the byte file
            string jsonByteFile = File.ReadAllText(dataPath);

            // and store it in the save data class object
            SaveData dataToLoad = JsonUtility.FromJson<SaveData>(jsonByteFile);

            // then assign main unit colour to the value read into the save data class object
            unitColour = dataToLoad._unitColour;
        }
    }







    // internal class for saving json data
    [System.Serializable]
    class SaveData
    {
        // reference to unit colour
        public Color _unitColour;
    }


} // end of class

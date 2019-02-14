using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct SaveGame
//{
//    public string name;
//}
[System.Serializable]
public struct Token
{
    public int tokenID;
    public float x;
    public float y;
    public bool isCollected;
}

[System.Serializable]
public struct TokenCollection
{
    public List<Token> listTokens;
}

public class FileTest : MonoBehaviour 
{
    //public SaveGame saveData;

    Dictionary<int, Token> dictionaryTokens;

	// Use this for initialization
	void Start () 
    {
        //to get json
        //saveData = JsonUtility.FromJson<SaveGame>(JsonFileUtility.LoadJsonFromFile("Save.json", false));	

        //to post json
        //string saveDataString = JsonUtility.ToJson(saveData);
        //JsonFileUtility.WriteJsonToExternalResource("Save.json", saveDataString);

        dictionaryTokens = new Dictionary<int, Token>();

        //dictionaryTokens.Add(0, new Token() { tokenID = 0, x = 0, y = 0, isCollected = false });
        //dictionaryTokens.Add(1, new Token() { tokenID = 1, x = 10, y = 10, isCollected = false });
        //dictionaryTokens.Add(2, new Token() { tokenID = 2, x = 20, y = 20, isCollected = false });
        //dictionaryTokens.Add(3, new Token() { tokenID = 3, x = 30, y = 30, isCollected = false });

        //SaveTokens();

        LoadTokens();
        List<int> tokenKeys = new List<int>(dictionaryTokens.Keys);
        foreach (int key in tokenKeys)
        {
            Debug.Log("Token ID: " + dictionaryTokens[key].tokenID + "isColected: " + dictionaryTokens[key].isCollected);
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void LoadTokens() //GET
    {
        TokenCollection tempCollection = JsonUtility.FromJson<TokenCollection>(JsonFileUtility.LoadJsonFromFile("TokenCollection.json", false));

        foreach(Token toke in tempCollection.listTokens )
        {
            dictionaryTokens.Add(toke.tokenID, toke);
        }
    }

    public void SaveTokens() //POST
    {
        List<int> tokenKeys = new List<int>(dictionaryTokens.Keys);
        List<Token> toSaveCollection = new List<Token>();
        foreach(int key in tokenKeys)
        {
            toSaveCollection.Add(dictionaryTokens[key]);
        }
        TokenCollection saveCollection = new TokenCollection() { listTokens = toSaveCollection };

        string jsonString = JsonUtility.ToJson(saveCollection);

        JsonFileUtility.WriteJsonToExternalResource("TokenCollection.json", jsonString);
    }
}

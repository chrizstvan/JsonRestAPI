using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;

public class Countries : MonoBehaviour 
{
    public Dropdown ddlCountries;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(GetCountries());
        ddlCountries.ClearOptions();
	}
	
    IEnumerator GetCountries()
    {
        string getCountriesUrl = "https://restcountries.eu/rest/v2/all";
        using (UnityWebRequest www = UnityWebRequest.Get (getCountriesUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult);

                    Helpers.RootObject[] entities = Helpers.GetJsonArray<Helpers.RootObject>(jsonResult);
                    ddlCountries.options.AddRange(entities.Select(x => new Dropdown.OptionData()
                    {
                        text = x.name
                    }).ToList());
                    ddlCountries.value = 0; //0 value for deselect or clear option
                }
            }
        }
    }
}

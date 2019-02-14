﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    public static T[] GetJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    [System.Serializable]
	public class Currency
    {
        public string code;
        public string name;
        public string symbol;
    }

    [System.Serializable]
    public class Language
    {
        public string iso639_1;
        public string iso639_2;
        public string name;
        public string nativeName;
    }

    [System.Serializable]
    public class Translations
    {
        public string de;
        public string es;
        public string fr;
        public string ja;
        public string it;
        public string br;
        public string pt;
    }

    [System.Serializable]
    public class RootObject
    {
        public string name;
        public List<string> topLevelDomain;
        public string alpha2Code;
        public string alpha3Code;
        public List<Object> callingCodes;
        public string capital;
        public List<Object> atSpellings;
        public string region;
        public string subregion;
        public int population;
        public List<Object> latlng;
        public string demonym;
        public double? area;
        public double? gini;
        public List<string> timezone;
        public List<Object> borders;
        public string nativeName;
        public string numericCode;
        public List<Currency> currencies;
        public List<Language> languages;
        public Translations translations;
        public string flag;
        public List<Object> regionalBlocs;
    }

    [System.Serializable]
    public class CountriesList
    {
        public List<RootObject> Countries;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings {
    private static Dictionary<string, object> settings = new Dictionary<string, object>();
    
    static Settings()
    {
        settings.Add("DeformTerrain", true);
        settings.Add("DeformTexture", true);
    }

    public static object GetValue(string key)
    {
        return settings[key];
    }

    public static E GetValue<E> (string key)
    {
        return (E)settings[key];
    }

    public static void SetValue(string key, object value)
    {
        settings[key] = value;
    }
}

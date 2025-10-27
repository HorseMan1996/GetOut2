using UnityEngine;
using UnityEditor;

public class AutoLocalizationScanner
{
    [MenuItem("Tools/Localization/Scan _loc_ Objects")]
    public static void ScanSceneForLocalization()
    {
        int added = 0;

        // Sahnedeki tüm aktif GameObject'leri al
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>(true);

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.ToLower().Contains("_loc_"))
            {
                if (obj.GetComponent<LocalizationEntity>() == null)
                {
                    obj.AddComponent<LocalizationEntity>();
                    added++;
                }
            }
        }

        Debug.Log($" {added} objeye LocalizationEntity eklendi (isimde '_loc_' bulunanlar).");
    }
}
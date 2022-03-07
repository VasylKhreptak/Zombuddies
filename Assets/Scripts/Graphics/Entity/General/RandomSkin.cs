using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomSkin : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BodyParts[] _skinElements;

    #region MonoBehaviour

    private void OnEnable()
    {
        SetRandomSkin();
    }

    #endregion

    public void SetRandomSkin()
    {
        DisableSkins();
        
        foreach (var skinElement in _skinElements)
        {
            skinElement.bodyParts.Random().SetActive(true);
        }
    }

    public void DisableSkins()
    {
        foreach (var skinElement in _skinElements)
        {
            foreach (var bodyPart in skinElement.bodyParts)
            {
                bodyPart.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class BodyParts
    {
        public GameObject[] bodyParts;
    }

    #region Editor

    #if UNITY_EDITOR

    [CustomEditor(typeof(RandomSkin))]
    public class RandomSkinEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RandomSkin targetScript = (RandomSkin)target;
            
            if(targetScript == null) return;

            if (GUILayout.Button("Set Radnom Skin"))
            {
                targetScript.SetRandomSkin();
            }
        }
    }
    #endif

    #endregion
}

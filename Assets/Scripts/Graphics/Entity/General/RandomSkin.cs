using UnityEditor;
using UnityEngine;

public class RandomSkin : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Skin[] _skins;

    #region MonoBehaviour

    private void OnEnable()
    {
        SetRandomSkin();
    }

    #endregion

    public void SetRandomSkin()
    {
        SetSkin(_skins.Random());
    }

    private void DisableSkins()
    {
        foreach (var skin in _skins)
        {
            foreach (var skinPart in skin.parts)
            {
                skinPart.SetActive(false);
            }
        }
    }

    private void SetSkin(Skin skin)
    {
        DisableSkins();

        foreach (var skinPart in skin.parts)
        {
            skinPart.SetActive(true);
        }
    }

    [System.Serializable]
    public class Skin
    {
        public GameObject[] parts;
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

            if (targetScript == null) return;

            SetRandomSkinButton(targetScript);
        }

        private void SetRandomSkinButton(RandomSkin targetScript)
        {
            if (GUILayout.Button("Set Random Skin"))
            {
                targetScript.SetRandomSkin();
            }
        }
    }

    #endif

    #endregion
}

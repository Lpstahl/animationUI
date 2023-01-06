using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info,
        Shop,
        Inventory
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listObjects;
        public List<Typper> listOfPhrases;

        public Image uiBackground;

        public bool startHided = false;

        [Header("Animation")]
        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            Debug.Log("Show");
            HideObjects();
        }

        private void HideObjects()
        {
            listObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for (var i = 0; i < listObjects.Count; i++)
            {
                var obj = listObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listObjects.Count);
            uiBackground.enabled = true;
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void forceShowObjects()
        {
            listObjects.ForEach(i => i.gameObject.SetActive(true));
            uiBackground.enabled = true;
        }

    }
}

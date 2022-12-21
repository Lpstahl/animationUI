using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listObjects;
        public List<Typper> listOfPhrases;

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
        protected virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Show");
            HideObjects();
        }

        private void HideObjects()
        {
            listObjects.ForEach(i => i.gameObject.SetActive(false));
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
        }

    }
}

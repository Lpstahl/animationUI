using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        {
            ScreenManager.instance.ShowByType(screenType);
        }
    }
}

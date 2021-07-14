using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Cook
{
    public class Timer : MonoBehaviour
    {
        public Action<float> timer;
        [SerializeField]
        private Text uiChrono;

        private void Start()
        {
            timer = UpdateChrono;
        }

        private void UpdateChrono(float timer)
        {
            var textTimer = timer.ToString("F", CultureInfo.CreateSpecificCulture("fr-FR"));
            uiChrono.text = textTimer;
        }
    }
}

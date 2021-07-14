using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cook
{
    public class GameManager : MonoBehaviour
    {
        [Header("Placeholder for 3D env")]
        [SerializeField]
        private GameObject placeholderFry;
        [SerializeField]
        private TransformContainer placeholderCook;
        [SerializeField]
        private GameObject placeholderCut;
        [SerializeField]
        private GameObject placeholderChopCut;
        [SerializeField]
        private GameObject placeholderFood;

        [Header("Placeholder for UI")]
        [SerializeField]
        private GameObject instruction;
        [SerializeField]
        private Timer uiTimer;
        [SerializeField]
        private GameObject gameOverSuccess;
        [SerializeField]
        private GameObject gameOverFail;

        [SerializeField] 
        private Recipe recipe;

        private float timer = 10;
        private bool isRecipeFinish = false;

        private void Start()
        {
            
        }

        private void Update()
        {

            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (isRecipeFinish)
            {
                gameOverSuccess.SetActive(true);
                return;
            }

            if(timer < 0)
            {
                gameOverFail.SetActive(true);
                return;
            }

            timer -= Time.deltaTime;

            uiTimer.timer?.Invoke(timer);
        }
    }
}

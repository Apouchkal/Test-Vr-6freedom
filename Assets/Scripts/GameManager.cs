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
        private List<GameObject> placeholderFood = new List<GameObject>();

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

        private float timer;
        private bool isRecipeFinish = false;

        private void Start()
        {
            placeholderCook.OnContainerFull = GameWin;
            placeholderCook.DefineNumberOfSocket(recipe.NumberOfTransformFood());

            CreateFood();

            timer = recipe.timer;
        }

        private void Update()
        {
            if (isRecipeFinish)
            {
                gameOverSuccess.SetActive(true);
                return;
            }

            ProcessTimer();
        }

        private void CreateFood()
        {
            var Foods = recipe.Foods;

            for (int i = 0; i < Foods.Count; i++)
            {
                var placeHolder = placeholderFood[i];

                Instantiate(Foods[i], placeHolder.transform.position, placeHolder.transform.rotation);
            }
        }

        private void ProcessTimer()
        {
            if(timer < 0)
            {
                uiTimer.gameObject.SetActive(false);
                instruction.gameObject.SetActive(false);
                gameOverFail.SetActive(true);
                return;
            }

            timer -= Time.deltaTime;

            uiTimer.timer?.Invoke(timer);
        }

        private void GameWin()
        {
            isRecipeFinish = true;
        }
    }
}

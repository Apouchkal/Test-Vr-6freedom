using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

namespace Cook
{
    public class TransformContainer : MonoBehaviour
    {
        public Action OnContainerFull;

        [SerializeField]
        private GameObject Result;
        [SerializeField]
        private List<XRSocketInteractor> socketInteractors = new List<XRSocketInteractor>();
        
        [SerializeField]
        private List<GameObject> gameObjetStockInSocket = new List<GameObject>();
        private int numberOfSocketFull;

        private void Awake()
        {
            GetSocketsInChildren();

            InitialiseSockets();
        }

        public void DefineNumberOfSocket(int numberOfSocket)
        {
            int numberOfSocketAvailable = socketInteractors.Count;

            UninitialiseSockets();

            socketInteractors.RemoveAt(numberOfSocket - 1);
        }

        private void GetSocketsInChildren()
        {
            var sockets = this.GetComponentsInChildren<XRSocketInteractor>();

            sockets.ToList().ForEach((socket) => socketInteractors.Add(socket));
        }

        private void InitialiseSockets()
        {
            socketInteractors.ForEach((socket) =>
            {
                socket.onSelectEntered.AddListener(AddToSocket);
                socket.onSelectExited.AddListener(RemoveToSocket);
            });
        }

        private void UninitialiseSockets()
        {
            socketInteractors.ForEach((socket) =>
            {
                socket.onSelectEntered.RemoveListener(AddToSocket);
                socket.onSelectExited.RemoveListener(RemoveToSocket);
            });
        }

        private void AddToSocket(XRBaseInteractable obj)
        {
            //add systeme to filter the food you need for the recipe

            numberOfSocketFull++;
            gameObjetStockInSocket.Add(obj.gameObject);

            if (numberOfSocketFull == socketInteractors.Count)
            {
                Instantiate(Result, transform.position, transform.rotation);

                Destroy(this.gameObject);
                DeleteObjStockInSocket();

                OnContainerFull?.Invoke();
            }
        }
 
        private void RemoveToSocket(XRBaseInteractable obj)
        {
            gameObjetStockInSocket.Remove(obj.gameObject);
            numberOfSocketFull--;
        }

        private void DeleteObjStockInSocket()
        {
            var ObjectsStocked = new List<GameObject>();
            gameObjetStockInSocket.ForEach((obj) => ObjectsStocked.Add(obj));

            ObjectsStocked.ForEach((obj => 
            {
                Destroy(obj);
                gameObjetStockInSocket.Remove(obj);
            }));
        }
    }
}

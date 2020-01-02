using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class buttonControl : MonoBehaviour
    {
        public SteamVR_Action_Boolean putAction;
        public Hand hand;

        public GameObject leftHand;
        public GameObject rightHand;
        public GameObject buttons;

        public GameObject[] models;

        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (putAction == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
                return;
            }

            putAction.AddOnChangeListener(OnPutActionChange, hand.handType);
        }

        private void OnDisable()
        {
            if (putAction != null)
                putAction.RemoveOnChangeListener(OnPutActionChange, hand.handType);
        }

        private void OnPutActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                Show();
            }
        }

        public void Show()
        {
            buttons.SetActive(false);
        }

            public void chooseModel(int i)
        {
            leftHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
            leftHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
        }
    }
}

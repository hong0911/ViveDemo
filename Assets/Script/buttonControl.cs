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

        public int which = 0;

        private void OnEnable()
        {
            //buttons.transform.GetChild(which).gameObject.SetActive(true);
            chooseModel(which);

            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (putAction == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
                return;
            }

            putAction.AddOnChangeListener(ShowActionChange, hand.handType);
        }

        private void OnDisable()
        {
            if (putAction != null)
                putAction.RemoveOnChangeListener(ShowActionChange, hand.handType);
        }

        private void ShowActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                Show();
            }
        }

        public void Show()
        {
            //buttons.transform.GetChild(which).gameObject.SetActive(false);
            which++;
            which = which % models.Length;
            buttons.transform.GetChild(which).gameObject.SetActive(true);
            chooseModel(which);
            Invoke("NotShow", 0.25f);
        }

        void NotShow()
        {
            buttons.transform.GetChild(which).gameObject.SetActive(false);
        }

        public void chooseModel(int i)
        {
            leftHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
            rightHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
        }
    }
}

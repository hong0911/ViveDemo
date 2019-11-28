//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Putting : MonoBehaviour
    {
        public SteamVR_Action_Boolean putAction;

        public Hand hand;

        public GameObject prefabToPut;


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
                Put();
            }
        }

        public void Put()
        {
            StartCoroutine(DoPut());
        }

        private IEnumerator DoPut()
        {
            Vector3 putPosition;

            RaycastHit hitInfo;
            bool hit = Physics.Raycast(hand.transform.position, Vector3.down, out hitInfo);
            if (hit)
            {
                putPosition = hitInfo.point + (Vector3.up * 0.35f);
            }
            else
            {
                putPosition = hand.transform.position;
                putPosition.y = Player.instance.transform.position.y;
            }

            GameObject model = GameObject.Instantiate<GameObject>(prefabToPut);
            model.transform.position = putPosition;
            model.transform.rotation = Quaternion.Euler(0, hand.transform.eulerAngles.y, 180);

            //model.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

            Rigidbody rigidbody = model.GetComponent<Rigidbody>();
            if (rigidbody != null)
                rigidbody.isKinematic = true;



            Vector3 initialScale = Vector3.one * 0.01f;
            Vector3 targetScale = Vector3.one * (1 + (Random.value * 0.25f));

            float startTime = Time.time;
            float overTime = 0.5f;
            float endTime = startTime + overTime;

            while (Time.time < endTime)
            {
                model.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
                yield return null;
            }


            if (rigidbody != null)
                rigidbody.isKinematic = false;
        }
    }
}
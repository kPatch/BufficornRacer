﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TS.Generics;

namespace TS.Generics
{
    [RequireComponent(typeof(ScrollRect))]
    public class UpDown : MonoBehaviour
    {
        private ScrollRect _ScrollView;
        private float _ScrollViewHeight;
        private RectTransform _content;

        public RectTransform _RefPos;

        public float ScrollMovement = .4f;

        void Awake()
        {
            _ScrollView = GetComponent<ScrollRect>();
            _ScrollViewHeight = _ScrollView.GetComponent<RectTransform>().rect.height;
            _content = _ScrollView.content;
        }

        void Update()
        {
            if (ControlFreak2.CF2Input.mouseScrollDelta.y != 0)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
              else if (EventSystem.current.currentSelectedGameObject == null)
            {
                return;
            }  
            else if (EventSystem.current.currentSelectedGameObject.transform.parent.parent.parent != _content.transform)
            {
                return;
            }
            else
            {
                float distanceUp =
                    _RefPos.localPosition.y -
                   EventSystem.current.currentSelectedGameObject.transform.parent.parent.GetComponent<RectTransform>().localPosition.y -
                   _content.localPosition.y;

                //Debug.Log("Distance Up: " + distanceUp + " : " + _RefPos.localPosition.y + " : " + EventSystem.current.currentSelectedGameObject.transform.parent.parent.GetComponent<RectTransform>().localPosition.y);
                if (distanceUp < 15)
                {
                    //Debug.Log("< 15");
                    _ScrollView.normalizedPosition = new Vector2(_ScrollView.normalizedPosition.x , _ScrollView.normalizedPosition.y + ScrollMovement);
                }
                if (distanceUp > _ScrollViewHeight)
                {
                    //Debug.Log("> 15");
                    _ScrollView.normalizedPosition = new Vector2(_ScrollView.normalizedPosition.x, _ScrollView.normalizedPosition.y - ScrollMovement);
                }
            }     
        }
    }
}

using System;
using System.Linq;
using UniRx;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    [RequireComponent(typeof(BodySourceManager))]
    public class ReactiveKinectSkeltonSensor : MonoBehaviour
    {
        private BodySourceManager _bodySource;

        private ReactiveProperty<KinectSkeltonData> _skelton;

        public ReactiveProperty<KinectSkeltonData> Skelton => _skelton;

        private void Start()
        {
            _bodySource = GetComponent<BodySourceManager>();
        }

        private void Update()
        {
            Kinect.Body body = _bodySource.GetData().FirstOrDefault(b => b.IsTracked);
            if (body != null)
            {
                _skelton = new ReactiveProperty<KinectSkeltonData>(new KinectSkeltonData(body));
            }
        }
    }
}
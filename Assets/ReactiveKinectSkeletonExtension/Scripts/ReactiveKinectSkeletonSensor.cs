﻿using System.Linq;
using UniRx;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectSkeletonExtension
{
    [RequireComponent(typeof(BodySourceManager))]
    public class ReactiveKinectSkeletonSensor : MonoBehaviour
    {
        
        private BodySourceManager _bodySource;

        private ReactiveProperty<KinectSkeletonData> _skeleton;
        public IReadOnlyReactiveProperty<KinectSkeletonData> Skeleton => _skeleton;
        [SerializeField] private bool _isMirror;
        

        private void Awake()
        {
            _bodySource = GetComponent<BodySourceManager>();
            _skeleton = new ReactiveProperty<KinectSkeletonData>();

        }

        private void Update()
        {
            Kinect.Body body = _bodySource.GetData().FirstOrDefault(b => b.IsTracked);
            if (body != null)
            {
                _skeleton.Value = !_isMirror ? new KinectSkeletonData(body) : new KinectSkeletonData(body).ToMirror();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HBFrameWork
{
    public abstract class BaseUI : MonoBehaviour
    {
        #region Cache gameObject & transform
        private GameObject _cacheGameObject;
        public GameObject CacheGameObject
        {
            get
            {
                if (null == _cacheGameObject)
                    _cacheGameObject = this.gameObject;
                return _cacheGameObject;
            }
        }
        private Transform _cacheTransform;
        public Transform CacheTransform
        {
            get
            {
                if (null == _cacheTransform)
                    _cacheTransform = this.transform;
                return _cacheTransform;
            }
        }
        #endregion

        #region Enum ObjState & UI Type
        protected EnumObjectState _state = EnumObjectState.None;
        public event StateChangeEvent StateChanged;
        public EnumObjectState State
        {
            protected get
            {
                return this._state;
            }
            set
            {
                EnumObjectState oldState = this._state;
                this._state = value;
                if (null != StateChanged)
                    StateChanged(this, this._state, oldState);
            }
        }

        public abstract EnumUIType GetUIType();

        #endregion

        private void Awake()
        {
            this.State = EnumObjectState.Initial;
            OnAwake();
        }
        void Start()
        {
            OnStart();
        }

        void Update()
        {
            if (this.State == EnumObjectState.Ready)
                OnUpdate(Time.deltaTime);
        }
        void Release()
        {
            this.State = EnumObjectState.Closing;
            GameObject.Destroy(this.CacheGameObject);
            OnRelease();
        }
        private void OnDestroy()
        {
            this.State = EnumObjectState.None;
        }
        protected virtual void OnAwake()
        {
            this.State = EnumObjectState.Loading;

            this.OnPlayOpenUIAudio();
        }
        protected virtual void OnStart()
        { }
        protected virtual void OnUpdate(float deltaTime)
        { }
        protected virtual void OnRelease()
        {
            this.State = EnumObjectState.None;

            this.OnPlayCloseUIAudio();
        }
        protected virtual void OnLoadData()
        { }

        /// <summary>
        /// 播放打开界面音乐
        /// </summary>
        protected virtual void OnPlayOpenUIAudio()
        { }
        /// <summary>
        /// 播放关闭界面音乐
        /// </summary>
        protected virtual void OnPlayCloseUIAudio()
        { }


        public void SetUIWhenOpening(params object[] uiParams)
        {
            SetUI(uiParams);
            StartCoroutine(LoadDataAsyn());
        }

        protected virtual void SetUI(params object[] uiParams)
        {
            this.State = EnumObjectState.Loading;
        }
        private IEnumerator LoadDataAsyn()
        {
            yield return new WaitForSeconds(0f);
            if (this.State == EnumObjectState.Loading)
            {
                this.OnLoadData();
                this.State = EnumObjectState.Ready;
            }
        }
    }
}
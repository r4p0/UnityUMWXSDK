using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;
using AOT;

namespace R4P0.UnityUMWXSDK.Sample
{
    public class SampleController : UIBehaviour
    {
        [SerializeField] InputField m_EventID;
        [SerializeField] InputField m_Params;
        [SerializeField] Button m_TrackEvent;

        protected override void Awake()
        {
            base.Awake();
            if (m_TrackEvent)
            {
                m_TrackEvent.onClick.AddListener(this.TrackEvent);
            }
        }

        public void TrackEvent()
        {
            UMADebug.Log($"UMA.Init");
            UMA.Init("testID", true, true, true, true);

            UMADebug.Log($"UMA.OnShareAppMessage");
            UMA.OnShareAppMessage(OnShareAppMessageCallback);

            UMADebug.Log($"UMA.SetOpenid");
            UMA.SetOpenid("openid");

            UMADebug.Log($"UMA.SetOpenid");
            UMA.SetUnionid("Unionid");

            UMADebug.Log($"UMA.SetOpenid");
            UMA.SetUserid("Userid", "provider");

            var eventId = m_EventID ? m_EventID.text : null;
            var _params = m_Params ? m_Params.text : null;
            UMADebug.Log($"UMA.TrackEvent({eventId},{_params})");
            UMA.TrackEvent(eventId, _params);
        }

        [MonoPInvokeCallback(typeof(OnShareAppMessageCallback))]
        public static string OnShareAppMessageCallback()
        {
            var share = new JsonData();
            share["title"] = new JsonData("代码调用分享");
            share["imageUrl"] = new JsonData("图片 URL");
            share["query"] = new JsonData("key1=val1&key2=val2");

            UMADebug.Log($"UMA.TrackShare:{share.ToJson()}");
            var data = UMA.TrackShare(share);
            UMADebug.Log($"UMA.TrackShare:{share.ToJson()}=>{data.ToJson()}");

            UMADebug.Log($"UMA.ShareAppMessage:{data.ToJson()}");
            UMA.ShareAppMessage(data);
            return data.ToJson();
        }
    }
}

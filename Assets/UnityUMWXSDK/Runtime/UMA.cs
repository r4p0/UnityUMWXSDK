#if UNITY_WEBGL && WEIXINMINIGAME

using LitJson;

namespace R4P0.UnityUMWXSDK
{
    public sealed class UMA
    {
        public static void OnShareAppMessage(OnShareAppMessageCallback callback)
        {
            UMAProxy.OnShareAppMessage(callback);
        }

        public static void ShareAppMessage(JsonData json)
        {
            ShareAppMessage(json.ToJson());
        }

        public static void ShareAppMessage(string json)
        {
            UMAProxy.ShareAppMessage(json);
        }

        public static JsonData TrackShare(JsonData json)
        {
            return TrackShare(json.ToJson());
        }

        public static JsonData TrackShare(string json)
        {
            UMADebug.Log($"{nameof(TrackShare)}({json})");
            var ret = UMAProxy.TrackShare(json);
            UMADebug.Log($"{nameof(TrackShare)}({json})=>{ret}");
            return JsonMapper.ToObject(ret);
        }

        public static void TrackEvent(string eventId, JsonData json)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                UMADebug.LogException(new System.ArgumentNullException(nameof(eventId)));
                return;
            }
            const int MAX_KEY_LENGTH = 128;
            if (eventId.Length > MAX_KEY_LENGTH)
            {
                UMADebug.LogException(new System.ArgumentException("length of " + nameof(eventId) + " can not be larger than " + MAX_KEY_LENGTH, nameof(eventId)));
                return;
            }

            var _params = json?.ToJson();

            const int MAX_PARAM_LENGTH = 256;
            if (!string.IsNullOrEmpty(_params) && _params.Length > MAX_PARAM_LENGTH)
            {
                UMADebug.LogException(new System.ArgumentException("length of " + nameof(_params) + " can not be larger than " + MAX_PARAM_LENGTH, nameof(_params)));
                return;
            }

            UMAProxy.TrackEvent(eventId, _params);
        }

        public static void TrackEvent(string eventId, string _params)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                UMADebug.LogException(new System.ArgumentNullException(nameof(eventId)));
                return;
            }
            const int MAX_KEY_LENGTH = 128;
            if (eventId.Length > MAX_KEY_LENGTH)
            {
                UMADebug.LogException(new System.ArgumentException("length of " + nameof(eventId) + " can not be larger than " + MAX_KEY_LENGTH, nameof(eventId)));
                return;
            }

            const int MAX_PARAM_LENGTH = 256;
            if (!string.IsNullOrEmpty(_params) && _params.Length > MAX_PARAM_LENGTH)
            {
                UMADebug.LogException(new System.ArgumentException("length of " + nameof(_params) + " can not be larger than " + MAX_PARAM_LENGTH, nameof(_params)));
                return;
            }

            UMAProxy.TrackEvent(eventId, _params);
        }

        public static void SetOpenid(string openid)
        {
            UMAProxy.SetOpenid(openid);
        }

        public static void SetUnionid(string id)
        {
            UMAProxy.SetUnionid(id);
        }

        public static void SetUserid(string userId, string provider = null)
        {
            UMAProxy.SetUserid(userId, provider);
        }

        public static void Init(string appKey, bool useOpenid, bool autoGetOpenid, bool debug, bool uploadUserInfo)
        {
            UMAProxy.Init(appKey, useOpenid, autoGetOpenid, debug, uploadUserInfo);
        }
    }
}
#endif
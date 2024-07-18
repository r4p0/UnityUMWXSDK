#if UNITY_WEBGL && WEIXINMINIGAME
using System.Runtime.InteropServices;

namespace R4P0.UnityUMWXSDK
{
    /// <summary>
    /// 分享参数获取回调
    /// </summary>
    /// <returns>json对象</returns>
    public delegate string OnShareAppMessageCallback();

    /// <summary>
    /// -  `uma.onShareAppMessage()`替代wx.onShareAppMessage
    /// -  `uma.shareAppMessage()`替代wx.shareAppMessage
    /// -  `uma.trackShare`见下方《关于分享事件和方法》
    /// -  `uma.trackEvent`同微信小程序统计sdk
    /// -  `uma.setOpenid`同微信小程序统计sdk
    /// -  `uma.setUnionid`同微信小程序统计sdk
    /// -  `uma.setUserid`同微信小程序统计sdk
    /// -  `uma.init`同微信小程序统计sdk
    /// </summary>
    internal sealed class UMAProxy
    {
        [DllImport("__Internal")]
        public static extern void OnShareAppMessage(OnShareAppMessageCallback callback);

        [DllImport("__Internal")]
        public static extern void ShareAppMessage(string json);

        [DllImport("__Internal")]
        public static extern string TrackShare(string json);

        /// <summary>
        /// trackEvent('事件ID',{ '属性1':'属性值1','属性2':'属性值2'});
        /// // 字符型属性值
        /// trackEvent('ViewProductDetails',{ 'Category':'家电','ItemName':'西门子冰箱'});
        /// // 数值型属性值
        /// trackEvent('Pay',{ 'PayAmount':6999});
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="_params">json对象字符串</param>
        [DllImport("__Internal")]
        public static extern void TrackEvent(string eventId, string _params);

        [DllImport("__Internal")]
        public static extern void SetOpenid(string openid);

        [DllImport("__Internal")]
        public static extern void SetUnionid(string id);

        [DllImport("__Internal")]
        public static extern void SetUserid(string userId, string provider);

        /// <summary>
        /// uma.init({
        ///   appKey:'xxxx',
        ///   useOpenid:true,// default true
        ///   autoGetOpenid:true,
        ///   debug:true,
        ///   uploadUserInfo:true// 上传用户信息，上传后可以看到有用户头像和昵称的分享信息
        /// });
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="useOpenid"></param>
        /// <param name=""></param>
        [DllImport("__Internal")]
        public static extern void Init(string appKey, bool useOpenid, bool autoGetOpenid, bool debug, bool uploadUserInfo);
    }
}
#endif
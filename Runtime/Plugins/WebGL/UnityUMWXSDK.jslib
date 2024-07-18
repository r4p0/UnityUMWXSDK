var UnityUMWXSDKLibrary = {
    //C#string => js string
    $ParseUnityString: function (ptr) {
        return UTF8ToString(ptr);
    },
    //js string => C#string
    $ReturnUnityString: function (returnStr) {
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    OnShareAppMessage: function (callback) {
        wx.uma.onShareAppMessage(() => {
            return JSON.parse(ParseUnityString(Module.dynCall_i(callback)));
        });
    },
    ShareAppMessage: function (dataPtr) {
        wx.uma.shareAppMessage(JSON.parse(ParseUnityString(dataPtr)));
    },
    TrackShare: function (dataPtr) {
        return ReturnUnityString(JSON.stringify(wx.uma.trackShare(JSON.parse(ParseUnityString(dataPtr)))));
    },
    TrackEvent: function (idPtr, paramsPtr) {
        wx.uma.trackEvent(ParseUnityString(idPtr), paramsPtr ? ParseUnityString(paramsPtr) : undefined);
    },
    SetOpenid: function (openidPtr) {
        wx.uma.setOpenid(ParseUnityString(openidPtr));
    },
    SetUnionid: function (idPtr) {
        wx.uma.setUnionid(ParseUnityString(idPtr));
    },
    SetUserid: function (userIdPtr, providerPtr) {
        wx.uma.setUserid(ParseUnityString(userIdPtr), providerPtr ? ParseUnityString(providerPtr) : undefined);
    },
    Init: function (appKeyPtr, useOpenid, autoGetOpenid, debug, uploadUserInfo) {
        wx.uma.init({ appKey: ParseUnityString(appKeyPtr), useOpenid, autoGetOpenid, debug, uploadUserInfo });
    }
};

autoAddDeps(UnityUMWXSDKLibrary, "$ParseUnityString");
autoAddDeps(UnityUMWXSDKLibrary, "$ReturnUnityString");
mergeInto(LibraryManager.library, UnityUMWXSDKLibrary);

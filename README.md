# UnityUMWXSDK
Unity 友盟 微信小游戏 SDK

## 添加友盟依赖库（TODO自动化添加）

1. 使用Unity微信小游戏插件/团结引擎，导出微信小游戏工程
1. 将友盟SDK的`uma.min.js`导入至小游戏工程内，e.g.`'./utils/umtrack-wxgame/uma.min.js';`
1. 在微信小游戏工程内找到`game.js`文件，在`import './webgl.wasm.framework.unityweb';`前添加SDK import代码`import './utils/umtrack-wxgame/uma.min.js';`

game.js：
```js
// @ts-nocheck
/* eslint-disable no-prototype-builtins */
/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
import './weapp-adapter';
import './events';
import 'texture-config.js';
import unityNamespace from './unity-namespace';
import './utils/umtrack-wxgame/uma.min.js';
import './webgl.wasm.framework.unityweb';
import './unity-sdk/index.js';
import checkVersion from './check-version';
import { launchEventType, scaleMode } from './plugin-config';
import { preloadWxCommonFont } from './unity-sdk/font/index';

.......
```

## Unity层调用API
C#层开放以下接口，其中标`json`的参数需要传递json对象，可以使用`LitJson`库生成json
```csharp
namespace R4P0.UnityUMWXSDK
{
    public delegate string OnShareAppMessageCallback();
    public sealed class UMA
    {
        public static void OnShareAppMessage(OnShareAppMessageCallback callback);
        public static void ShareAppMessage(JsonData json);
        public static void ShareAppMessage(string json);
        public static JsonData TrackShare(JsonData json);
        public static JsonData TrackShare(string json);
        public static void TrackEvent(string eventId, JsonData json);
        public static void TrackEvent(string eventId, string _params);
        public static void SetOpenid(string openid);
        public static void SetUnionid(string id);
        public static void SetUserid(string userId, string provider = null);
        public static void Init(string appKey, bool useOpenid, bool autoGetOpenid, bool debug, bool uploadUserInfo);
    }
}

```

其中`OnShareAppMessage`参数必须是public静态方法并且添加`[MonoPInvokeCallback(typeof(OnShareAppMessageCallback))]`特性


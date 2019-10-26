mergeInto(LibraryManager.library, {
  GetUrlParams: function() {
    searchParams = new URLSearchParams(location.search);
    return searchParams.getAll();
  },

  TestJs2: function(data) {
    console.log("TestJs2");
    return data;
  },

  TestJs: function() {
    console.log("hoge");
    var ws = new WebSocket("ws://localhost:3001");
    console.log(ws);
    ws.onopen = event => {
      console.log("open: " + event);
    };

    ws.onclose = event => {
      console.log("close: " + event);
    };

    ws.onmessage = event => {
      console.log("msg: " + event);
      _TestJs2(event);
    };
  },

  InjectionJs: function(url, id) {
    url = Pointer_stringify(url);
    id = Pointer_stringify(id);

    // idを渡して、同じidだった場合は要素を生成しないようにしておく
    if (!document.getElementById(id)) {
      var s = document.createElement("script");
      s.setAttribute("src", url);
      s.setAttribute("id", id);
      document.head.appendChild(s);
    }
  },
  // 指定したメソッドを実行するための関数例(~.jslib内)
  ExecuteJs: function(id, methodName, jsonData, callbackGameObjectName) {
    id = Pointer_stringify(id);
    methodName = Pointer_stringify(methodName);
    jsonData = Pointer_stringify(jsonData);
    callbackGameObjectName = Pointer_stringify(callbackGameObjectName);

    var jsonObj = JSON.parse(jsonData);
    jsonObj.Id = id;
    jsonObj.MethodName = methodName; // メッセージを返してもらうためのGameObject名を渡しておく
    jsonObj.CallbackGameObjectName = callbackGameObjectName;

    // PostMessage
    var messageString = JSON.stringify(jsonObj);
    window.postMessage(messageString, "*");
  }
});

//'use strict';
/// <reference path="../lib/jquery/jquery-2.1.4.min.js" />
/// <reference path="base.js" />
/// <reference path="../lib/angular/angular.js" />
//var sxapp = angular.module('appindex', ['infinite-scroll']);
var sxapp = angular.module('appindex', []);
//var app = angular.module('shopControllers',[]);
sxapp.controller('appindexCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.test = 223;
    $scope.checked = true;
    $scope.items = {
        cusmenu: { show: false },//自定义菜单
        msg: { show: false },//图文消息
    }
    $scope.itemClick = function (item) {
        item.show = !item.show;
        console.log(333);
    }
}]);
sxapp.controller('cusMenuCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.types = {
        view: { val: "view", url: "" },
        click: { val: "click", key: "" },
    }
    $scope.menunameover = false;//标记菜单长度是否溢出16字节
    $scope.menuOldname = "";//当前正在编辑的菜单的名称;
    $scope.menuName = "";//菜单正在被编辑的值
    $scope.menuType = "view";//菜单类型单选框值//view click
    $scope.btn = null;//当前编辑子菜单所在的父菜单对象
    $scope.btnIndex = 0;//当前编辑的菜单对应的一级菜单索引
    $scope.subbtnIndex = 0;//当前编辑的子菜单索引
    $scope.isSubbutton = false;//标记当前编辑的菜单是否是子菜间;true是子菜单;
    $http.get("/home/getmenu2", {}).success(function (data) {
        if (data.is_menu_open != 1) {
            //$scope.menu = data.selfmenu_info;
            //$scope.menu=""
            var tmp = JSON.parse('{     "is_menu_open": 1,     "selfmenu_info": {         "button": [             {                 "type": "click",                 "name": "今日歌曲",                 "key": "V1001_TODAY_MUSIC"            },             {                 "name": "菜单",                 "sub_button": {                     "list": [                         {                             "type": "view",                             "name": "搜索",                             "url": "http://www.soso.com/"                        },                         {                             "type": "view",                             "name": "视频",                             "url": "http://v.qq.com/"                        },                         {                             "type": "click",                             "name": "赞一下我们",                             "key": "V1001_GOOD"                        }                    ]                }            }        ]    } }');
            $scope.menu = tmp.selfmenu_info;
            if ($scope.menu.button && $scope.menu.button.length > 0) {
                $scope.btn = $scope.menu.button[0];
                $scope.btnIndex = 0;
                $scope.subbtnIndex = 0;
            } else {
                $scope.btn = null;
            }
            showEditMenu();//第一次调用
            $scope.menuSize = {//自定义菜单宽度
                w100: false,
                w050: false,
                w033: false
            }
            //var ff = $scope.menu.button.pop();

            //#region 当子菜单数小于5时，显示添加按钮
            for (var i = 0; i < $scope.menu.button.length; i++) {
                var subbtns = $scope.menu.button[i];
                if (!subbtns.hasOwnProperty("sub_button")) {
                    subbtns.sub_button = {};
                    subbtns.sub_button.list = [];
                }
                if (!subbtns.sub_button.list || subbtns.sub_button.list.length < 5) {
                    subbtns.sub_button.end = true;
                }
            }

            //#endregion 

            setMenuWidth();
            //#region  判断一级菜单组数量,小于3个时，显示添加按钮，并设置宽度
            function setMenuWidth() {
                $scope.menu.end = true;
                $scope.menuSize.w100 = false;
                $scope.menuSize.w050 = false;
                $scope.menuSize.w033 = false;
                switch ($scope.menu.button.length) {
                    case 0:
                        $scope.menuSize.w100 = true;
                        break;
                    case 1:
                        $scope.menuSize.w050 = true;
                        break;
                    case 2:
                        $scope.menuSize.w033 = true;
                        break;
                    default:
                }
            }
            //#endregion

            //添加子菜单
            $scope.addSubbtn = function ($event, $index, btn) {
                $event.stopPropagation();
                $scope.isSubbutton = true;
                //btn.sub_button.list
                $scope.menuOldname = "新建子菜单";
                $scope.menuName = "新建子菜单";
                if (btn.sub_button.list.length < 5) {
                    btn.sub_button.list.push({ name: "新建子菜单" });
                }
                if (btn.sub_button.list.length >= 5) {
                    delete btn.sub_button.end;
                } else {
                    btn.sub_button.end = true;
                }
                $scope.btn = btn;
                $scope.btnIndex = $index;
                $scope.subbtnIndex = btn.sub_button.list.length - 1;
            }
            //添加一级菜单
            $scope.addButton = function () {
                $scope.isSubbutton = false;
                $scope.menuOldname = "新建一级菜单";
                $scope.menuName = "新建一级菜单";
                var menu = $scope.menu;
                if (menu.button.length < 3) {
                    var newmenu = { name: "新建一级菜单", sub_button: { list: [], end: true } };
                    menu.button.push(newmenu);
                }
                if (menu.button.length >= 3) {
                    delete menu.end;
                } else {
                    menu.end = true;
                }
                $scope.btn = menu.button[menu.button.length - 1];
                $scope.btnIndex = menu.button.length - 1;
                $scope.subbtnIndex = 0;
                $scope.btn.type = "view";//默认设置为跳转网页;
                setMenuWidth();
            }

            //删除当前正在编辑的菜单
            $scope.delmenubtn = function () {
                var subbtn = $scope.btn.sub_button;
                if ($scope.isSubbutton && subbtn.list.length > 0) {
                    subbtn.list.splice($scope.subbtnIndex, 1);
                } else if ($scope.menu.button.length > 0) {
                    if ($scope.btnIndex >= $scope.menu.button.length) {
                        $scope.btnIndex = 0;
                    }
                    $scope.menu.button.splice($scope.btnIndex, 1);
                }
                if ($scope.btn.sub_button.list.length <= 5) {
                    subbtn.end = true;
                }
                if ($scope.menu.button.length < 3) {
                    $scope.menu.end = true;
                }
                $scope.subbtnIndex = 0;//删除一个子菜单后从0开始
                showEditMenu();
                setMenuWidth();
            }

            //在右侧显示当前编辑的菜单
            function showEditMenu() {
                var name = '', type = '';
                var btn = $scope.btn;
                var menu = $scope.menu;
                var subbtnindex = $scope.subbtnIndex;
                var btnindex = $scope.btnIndex;
                var isSubbtn = $scope.isSubbutton;
                if (btn && isSubbtn && btn.sub_button.list.length > 0) {
                    if (subbtnindex >= btn.sub_button.list.length) {
                        subbtnindex = 0;
                    }
                    name = btn.sub_button.list[subbtnindex].name;
                    type = btn.sub_button.list[subbtnindex].type
                } else {
                    if (menu.button.length > 0) {
                        if (btnindex >= menu.button.length) {
                            btnindex = 0;
                        }
                        name = menu.button[btnindex].name;
                        type = menu.button[btnindex].type;
                        if (!type) {
                            type = 'view';
                        }
                    } else {
                        alert('没有菜单了');
                    }
                }
                $scope.menuOldname = name;
                $scope.menuName = name;
                $scope.menuType = type;
            }

            ///子菜单点击事件
            //parame> $event
            //parame>$index 当前子菜单在父菜单中的索引
            //parame>btn当前子菜单的父菜单对象
            ///
            $scope.submenuClick = function ($event, $index, pIndex, btn) {
                $event.stopPropagation();
                $scope.isSubbutton = true;
                $scope.btn = btn;
                $scope.subbtnIndex = $index;
                $scope.btnIndex = pIndex;
                showEditMenu();
            }

            //一级菜单点击事件
            $scope.menuClick = function ($event, $index) {
                $event.stopPropagation();
                $scope.isSubbutton = false;
                $scope.btnIndex = $index;
                showEditMenu();
            }

            //获取字符串的字节长度;
            function getByteLen(val) {
                var len = 0;
                for (var i = 0; i < val.length; i++) {
                    var a = val.charAt(i);
                    if (a.match(/[^\x00-\xff]/ig) != null) {
                        len += 2;
                    }
                    else {
                        len += 1;
                    }
                }
                return len;
            }
            $scope.$watch('menuName', function (newValue, oldValue, scope) {
                if (newValue) {
                    $scope.menunameover = getByteLen(newValue) > 16 ? true : false;
                }
            });
        }
    });
    $scope.save = function () {
        $scope.btn.type = $scope.menuType;
        var types = $scope.types;
        var btn = $scope.btn;
        switch (btn.type) {
            case types.view.val:
                btn.url = types.view.url;
                break;
            case types.click.val:
                break;
            default:
                break;
        }
        console.log({ menu: $scope.menu });
        //$http.post('/shop/qssearch', {key:$scope.key}).success(function (data) {
        var menu = JSON.stringify($scope.menu);
        menu = JSON.parse(menu);
        for (var i = 0; i < menu.button.length; i++) {
            var list=menu.button[i].sub_button.list;;
            menu.button[i].sub_button = list;
            delete list;
        }
        console.log(menu);
        $http.post('/home/savemenu', {menu:JSON.stringify(menu)}).success(function (data) {
            console.log(data);
        });
    }
}]);
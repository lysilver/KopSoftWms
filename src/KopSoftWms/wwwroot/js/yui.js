; (function (undefined) {
    "use strict"
    var _global;
    function result(args, fn) {
        var argsArr = Array.prototype.slice.call(args);
        if (argsArr.length > 0) {
            return argsArr.reduce(fn);
        } else {
            return 0;
        }
    }
    var yui = {
        //dom
        ready: function (func) {
            (function () {
                func && func();
            })();
        },
        add: function () {
            return result(arguments, function (pre, cur) {
                return pre + cur;
            });
        },
        extend: function () {
            var length = arguments.length;
            var target = arguments[0] || {};
            if (typeof target !== "object" && typeof target !== "function") {
                target = {};
            }
            if (length === 1) {
                target = this;
                i--;
            }
            for (var i = 1; i < length; i++) {
                var source = arguments[i];
                for (var key in source) {
                    if (Object.prototype.hasOwnProperty.call(source, key)) {
                        target[key] = source[key];
                    }
                }
            }
            return target;
        },
        onkeydown: function (func) {
            document.onkeydown = function (e) {
                var ev = document.all ? window.event : e;
                if (ev.keyCode === 13) // Enter
                {
                    func && func();
                }
            };
        },
        getWidth: function () {
            var w = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            return w;
        },
        getHeight: function () {
            var h = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            return h;
        },
        getLength: function (str) {
            return str.length;
        },
        getDomById: function (id) {
            return document.getElementById(id);
        },
        getDomByClass: function (obj) {
            return document.getElementsByClassName(obj);
        },
        getAttribute: function (id, key) {
            return document.getElementById(id).getAttribute(key);
        },
        setAttribute: function (id, key, value) {
            document.getElementById(id).setAttribute(key, value);
        },
        getDataSetById: function (id) {
            return document.getElementById(id).dataset;
        },
        print: function (str) {
            console.info(str);
        },
        toJson: function (str) {
            return JSON.stringify(str);
        },
        toObj: function (str) {
            return JSON.parse(str);
        },
        isRealNum: function (val) {
            if (val === "" || val === null) {
                return false;
            }
            if (!isNaN(val)) {
                return true;
            } else {
                return false;
            }
        },
        signlessInteger: function (num) {
            if (!(/(^[1-9]\d*$)/.test(num))) {
                return false;
            }
            return true;
        },
        isRealNum2: function (val) {
            if (val === "" || val === null) {
                return false;
            }
            if (val.length > 0) {
                var first = val.indexOf("0");
                if (first === 0) {
                    return false;
                }
            }
            if (!isNaN(val)) {
                return true;
            } else {
                return false;
            }
        },
        GetPercent: function (num, total) {
            num = parseFloat(num);
            total = parseFloat(total);
            if (isNaN(num) || isNaN(total)) {
                return "-";
            }
            return total <= 0 ? "0%" : (Math.round(num / total * 10000) / 100.00) + "%";
        },
        //string
        strLength: function (s, bUnicode255For1) {
            if (bUnicode255For1) { return s.length; }
            return [].reduce.call(s, function (sum, value) {
                return value.charCodeAt(0) > 255 ? sum + 2 : sum + 1;
            }, 0);
        },
        //time
        getNow: function () {
            var date = new Date();
            var seperator1 = "-";
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = year + seperator1 + month + seperator1 + strDate;
            return currentdate;
        },
        getYearMonth: function () {
            var date = new Date();
            var seperator1 = "-";
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            var currentdate = year + seperator1 + month;
            return currentdate;
        },
        getCurrentMonthFirst: function () {
            var date = new Date();
            //date.setDate(1);
            var seperator1 = "-";
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            strDate = 1;
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = year + seperator1 + month + seperator1 + strDate;
            return currentdate;
        },
        getCurrentMonthLast: function () {
            var seperator1 = "-";
            var date1 = new Date();
            var year1 = date1.getFullYear() + "";
            var month1 = (date1.getMonth() + 1) + "";
            if (month1 >= 1 && month1 <= 9) {
                month1 = "0" + month1;
            }
            var lastDateOfCurrentMonth = new Date(year1, month1, 0);
            var strDate = lastDateOfCurrentMonth.getDate();
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var end1 = year1 + seperator1 + month1 + seperator1 + strDate;
            return end1;
        },
        jsonDateFormat: function (jsonDate) {
            //json日期格式转换为正常格式
            if (jsonDate === null || jsonDate.length <= 0) {
                return "";
            }
            var jsonDateStr = jsonDate.toString();//此处用到toString（）是为了让传入的值为字符串类型，目的是为了避免传入的数据类型不支持.replace（）方法
            try {
                var k = parseInt(jsonDateStr.replace("/Date(", "").replace(")/", ""), 10);
                if (k < 0)
                    return null;

                var date = new Date(parseInt(jsonDateStr.replace("/Date(", "").replace(")/", ""), 10));
                var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
                var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
                var milliseconds = date.getMilliseconds();
                return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;
            }
            catch (ex) {
                return "时间格式转换错误";
            }
        },
        getDateDiff: function (startTime, endTime, diffType) {
            //将xxxx-xx-xx的时间格式，转换为 xxxx/xx/xx的格式
            startTime = startTime.replace(/\-/g, "/");
            endTime = endTime.replace(/\-/g, "/");
            //将计算间隔类性字符转换为小写
            diffType = diffType.toLowerCase();
            var sTime = new Date(startTime); //开始时间
            var eTime = new Date(endTime); //结束时间
            //作为除数的数字
            var timeType = 1;
            switch (diffType) {
                case "second":
                    timeType = 1000;
                    break;
                case "minute":
                    timeType = 1000 * 60;
                    break;
                case "hour":
                    timeType = 1000 * 3600;
                    break;
                case "day":
                    timeType = 1000 * 3600 * 24;
                    break;
                default:
                    break;
            }
            return parseFloat((eTime.getTime() - sTime.getTime()) / parseInt(timeType)).toFixed(2);
        },
        //axios
        $axiospostform: function (url, data) {
            return new Promise(function (resolve, reject) {
                axios.post(url, Qs.stringify(data), {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
                        'promise': 'promise'
                    }
                }).then(function (response) {
                    resolve(response);
                }).catch(function (error) {
                    reject(error);
                });
            });
        },
        $axiospostjson: function (url, data) {
            return new Promise(function (resolve, reject) {
                axios.post(url, data, {
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8',
                        'promise': 'promise'
                    }
                }).then(function (response) {
                    resolve(response);
                }).catch(function (error) {
                    reject(error);
                });
            });
        },
        $axiospost: function (url, data) {
            return new Promise(function (resolve, reject) {
                axios.post(url, data, {
                    headers: {
                        'promise': 'promise'
                    }
                }).then(function (response) {
                    resolve(response);
                }).catch(function (error) {
                    reject(error);
                });
            });
        },
        $axiosget: function (url, data) {
            return new Promise(function (resolve, reject) {
                axios.get(url, data, {
                    headers: {
                        'promise': 'promise'
                    }
                }).then(function (response) {
                    resolve(response);
                }).catch(function (error) {
                    reject(error);
                });
            });
        },
        //layer
        layershow: function (title, url, w, h) {
            if (title === null || title === '') {
                title = false;
            };
            if (url === null || url === '') {
                url = "404.html";
            };
            if (w === null || w === '') {
                w = 800;
            };
            if (h === null || h === '') {
                h = ($(window).height() - 50);
            };
            layer.open({
                type: 2,
                area: [w + 'px', h + 'px'],
                fix: false, //不固定
                maxmin: true,
                shade: 0.4,
                title: title,
                content: url
            });
        },
        layershowId: function (title, id, w, h) {
            if (title === null || title === '') {
                title = false;
            };
            if (w === null || w === '') {
                w = 800;
            };
            if (h === null || h === '') {
                h = ($(window).height() - 50);
            };
            layer.open({
                type: 1,
                area: [w + 'px', h + 'px'],
                fix: false, //不固定
                maxmin: true,
                shade: 0.4,
                title: title,
                content: '#' + id
            });
        },
        layer_close: function () {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        },
        layer_close2: function () {
            var index = parent.layer.getFrameIndex(window.name);
            parent.$("button[name='refresh']").click();
            parent.layer.close(index);
        },
        layer_close3: function () {
            var index = parent.layer.getFrameIndex(window.name);
            parent.$("button[name='search']").click();
            parent.layer.close(index);
        },
        //bootstrap table
        table: function (id, url, obj, method, key, singleSelect, qParams, sortName, sortOrder, isShowDate) {
            if (typeof singleSelect === "undefined") {
                singleSelect = true;
            }
            if (typeof isShowDate === "undefined") {
                isShowDate = true;
            }
            $("#" + id).bootstrapTable({
                url: url,
                method: method || "GET",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                toolbar: '#toolbar', //工具按钮用哪个容器
                striped: true, //是否显示行间隔色
                cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                sortable: true, //是否启用排序
                sortOrder: sortOrder || "desc", //排序方式
                sortName: sortName || "CreateDate",
                pagination: true, //是否显示分页（*）
                paginationLoop: true,
                onlyInfoPagination: false,
                sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
                pageNumber: 1, //初始化加载第一页，默认第一页,并记录
                pageSize: 10, //每页的记录行数（*）
                pageList: [10, 25, 50, 100, 'All'], //可供选择的每页的行数（*）
                search: true, //是否显示表格搜索
                strictSearch: false, //设置为 true启用全匹配搜索，否则为模糊搜索。
                trimOnSearch: true, //设置为 true 将自动去掉搜索字符的前后空格。
                smartDisplay: true,
                showPaginationSwitch: false,
                showColumns: true, //是否显示所有的列（选择显示的列）
                showHeader: true, //是否显示列头。
                showFooter: false, //是否显示列脚。
                showRefresh: true, //是否显示刷新按钮
                showExport: false, //是否显示导出按钮
                exportDataType: "all",
                buttonsAlign: "right", //按钮位置
                exportTypes: ['csv', 'txt', 'sql', 'doc', 'excel', 'xlsx', 'pdf'], //导出文件类型
                Icons: 'glyphicon-export',
                singleSelect: singleSelect, //设置 true 将禁止多选。
                minimumCountColumns: 1, //最少允许的列数
                clickToSelect: true, //是否启用点击选中行
                //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
                //idField: "Name",
                uniqueId: key, //每一行的唯一标识，一般为主键列
                showToggle: true, //是否显示详细视图和列表视图的切换按钮
                showFullscreen: false,
                cardView: false, //是否显示详细视图
                detailView: false, //是否显示父子表
                queryParams: function (params) {
                    var temp = {
                        limit: params.limit,     //页面大小
                        offset: params.offset,   //页码
                        sort: params.sort,      //排序列名
                        order: params.order, //排序命令（desc，asc）
                        _: params._,
                        search: params.search
                    };
                    if (isShowDate) {
                        temp.datemin = _self.$refs.datemin.value;
                        temp.datemax = _self.$refs.datemax.value;
                    }
                    return yui.extend(temp, qParams);
                    //return $.extend(temp, qParams);
                },
                queryParamsType: 'limit',
                columns: obj
            });
        },
        table2: function (id, url, urlSub, obj, objSub, method, key, keySub, singleSelect, qParams, sortName, sortOrder, isShowDate) {
            if (typeof singleSelect === "undefined") {
                singleSelect = true;
            }
            if (typeof isShowDate === "undefined") {
                isShowDate = true;
            }
            $("#" + id).bootstrapTable({
                url: url,
                method: method || "GET",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                toolbar: '#toolbar', //工具按钮用哪个容器
                striped: true, //是否显示行间隔色
                cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                sortable: true, //是否启用排序
                sortOrder: sortOrder || "desc", //排序方式
                sortName: sortName || "CreateDate",
                pagination: true, //是否显示分页（*）
                paginationLoop: true,
                onlyInfoPagination: false,
                sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
                pageNumber: 1, //初始化加载第一页，默认第一页,并记录
                pageSize: 10, //每页的记录行数（*）
                pageList: [10, 25, 50, 100, 'All'], //可供选择的每页的行数（*）
                search: true, //是否显示表格搜索
                strictSearch: false, //设置为 true启用全匹配搜索，否则为模糊搜索。
                trimOnSearch: true, //设置为 true 将自动去掉搜索字符的前后空格。
                smartDisplay: true,
                showPaginationSwitch: false,
                showColumns: true, //是否显示所有的列（选择显示的列）
                showHeader: true, //是否显示列头。
                showFooter: false, //是否显示列脚。
                showRefresh: true, //是否显示刷新按钮
                showExport: false, //是否显示导出按钮
                exportDataType: "all",
                buttonsAlign: "right", //按钮位置
                exportTypes: ['csv', 'txt', 'sql', 'doc', 'excel', 'xlsx', 'pdf'], //导出文件类型
                Icons: 'glyphicon-export',
                singleSelect: singleSelect, //设置 true 将禁止多选。
                minimumCountColumns: 1, //最少允许的列数
                clickToSelect: true, //是否启用点击选中行
                //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
                //idField: "Name",
                uniqueId: key, //每一行的唯一标识，一般为主键列
                showToggle: true, //是否显示详细视图和列表视图的切换按钮
                showFullscreen: false,
                cardView: false, //是否显示详细视图
                detailView: true, //是否显示父子表
                queryParams: function (params) {
                    var temp = {
                        limit: params.limit,     //页面大小
                        offset: params.offset,   //页码
                        sort: params.sort,      //排序列名
                        order: params.order, //排序命令（desc，asc）
                        _: params._,
                        search: params.search
                    };
                    if (isShowDate) {
                        temp.datemin = _self.$refs.datemin.value;
                        temp.datemax = _self.$refs.datemax.value;
                    }
                    return yui.extend(temp, qParams);
                    //return $.extend(temp, qParams);
                },
                //queryParams: function (params) {
                //    //这里的键的名字和控制器的变量名必须一致，这边改动，控制器也需要改成一样的
                //    var temp = {
                //        rows: params.limit,                         //页面大小
                //        page: (params.offset / params.limit) + 1,   //页码
                //        sort: params.sort,      //排序列名
                //        sortOrder: params.order //排位命令（desc，asc）
                //    };
                //    return temp;
                //},
                queryParamsType: 'limit',
                columns: obj,
                onExpandRow: function (index, row, $detail) {
                    yui.InitSubTable(index, row, $detail, urlSub, objSub, keySub, method, singleSelect);
                }
            });
        },
        table3: function (id, url, urlSub, obj, objSub, method, key, keySub, singleSelect, qParams, sortName, sortOrder, isShowDate) {
            if (typeof singleSelect === "undefined") {
                singleSelect = true;
            }
            if (typeof isShowDate === "undefined") {
                isShowDate = true;
            }
            $("#" + id).bootstrapTable({
                url: url,
                method: method || "GET",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                toolbar: '#toolbar', //工具按钮用哪个容器
                striped: true, //是否显示行间隔色
                cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                sortable: true, //是否启用排序
                sortOrder: sortOrder || "desc", //排序方式
                sortName: sortName || "CreateDate",
                pagination: true, //是否显示分页（*）
                paginationLoop: true,
                onlyInfoPagination: false,
                sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
                pageNumber: 1, //初始化加载第一页，默认第一页,并记录
                pageSize: 10, //每页的记录行数（*）
                pageList: [10, 25, 50, 100, 'All'], //可供选择的每页的行数（*）
                search: true, //是否显示表格搜索
                strictSearch: false, //设置为 true启用全匹配搜索，否则为模糊搜索。
                trimOnSearch: true, //设置为 true 将自动去掉搜索字符的前后空格。
                smartDisplay: true,
                showPaginationSwitch: false,
                showColumns: true, //是否显示所有的列（选择显示的列）
                showHeader: true, //是否显示列头。
                showFooter: false, //是否显示列脚。
                showRefresh: true, //是否显示刷新按钮
                showExport: false, //是否显示导出按钮
                exportDataType: "all",
                buttonsAlign: "right", //按钮位置
                exportTypes: ['csv', 'txt', 'sql', 'doc', 'excel', 'xlsx', 'pdf'], //导出文件类型
                Icons: 'glyphicon-export',
                singleSelect: singleSelect, //设置 true 将禁止多选。
                minimumCountColumns: 1, //最少允许的列数
                clickToSelect: true, //是否启用点击选中行
                //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
                //idField: "Name",
                uniqueId: key, //每一行的唯一标识，一般为主键列
                showToggle: true, //是否显示详细视图和列表视图的切换按钮
                showFullscreen: false,
                cardView: false, //是否显示详细视图
                detailView: true, //是否显示父子表
                queryParams: function (params) {
                    var temp = {
                        limit: params.limit,     //页面大小
                        offset: params.offset,   //页码
                        sort: params.sort,      //排序列名
                        order: params.order, //排序命令（desc，asc）
                        _: params._,
                        search: params.search
                    };
                    if (isShowDate) {
                        temp.datemin = _self.$refs.datemin.value;
                        temp.datemax = _self.$refs.datemax.value;
                    }
                    return yui.extend(temp, qParams);
                    //return $.extend(temp, qParams);
                },
                //queryParams: function (params) {
                //    //这里的键的名字和控制器的变量名必须一致，这边改动，控制器也需要改成一样的
                //    var temp = {
                //        rows: params.limit,                         //页面大小
                //        page: (params.offset / params.limit) + 1,   //页码
                //        sort: params.sort,      //排序列名
                //        sortOrder: params.order //排位命令（desc，asc）
                //    };
                //    return temp;
                //},
                queryParamsType: 'limit',
                columns: obj,
                onExpandRow: function (index, row, $detail) {
                    yui.InitSubTable(index, row, $detail, urlSub, objSub, keySub, method, singleSelect);
                }
            });
        },
        InitSubTable: function (index, row, $detail, urlSub, objSub, keySub, method, singleSelect) {
            var parentid = row[keySub];
            var cur_table = $detail.html('<table></table>').find('table');
            $(cur_table).bootstrapTable({
                url: urlSub,
                method: method || "GET",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                queryParams: { pid: parentid },
                sidePagination: "server",
                clickToSelect: true, //是否启用点击选中行
                singleSelect: singleSelect,
                detailView: false,//父子表
                uniqueId: keySub,
                pagination: true, //是否显示分页（*）
                pageNumber: 1,
                pageSize: 10,
                pageList: [10, 25, 50, 100, 'All'],
                columns: objSub,
                onExpandRow: function (index, row, $detail) {
                    yui.InitSubTable(index, row, $detail);
                }
            });
        },
        InitSubTable3: function (index, row, $detail, urlSub, objSub, keySub, method, singleSelect) {
            var parentid = row[keySub];
            var cur_table = $detail.html('<table></table>').find('table');
            $(cur_table).bootstrapTable({
                url: urlSub,
                method: method || "GET",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                queryParams: { pid: parentid },
                sidePagination: "server",
                clickToSelect: true, //是否启用点击选中行
                singleSelect: singleSelect,
                detailView: true,//父子表
                uniqueId: keySub,
                pagination: true, //是否显示分页（*）
                pageNumber: 1,
                pageSize: 10,
                pageList: [10, 25, 50, 100, 'All'],
                columns: objSub,
                onExpandRow: function (index, row, $detail) {
                    yui.InitSubTable(index, row, $detail);
                }
            });
        }
    };
    // 最后将插件对象暴露给全局对象
    _global = (function () { return this || (0, eval)('this'); }());
    if (typeof module !== "undefined" && module.exports) {
        module.exports = yui;
    } else if (typeof define === "function" && define.amd) {
        define(function () { return yui; });
    } else {
        !('yui' in _global) && (_global.yui = yui);
    }
    //---const---
    const errorMsg = "异常";

    //-----vue-----
    Vue.directive('focus', {
        inserted: function (el) {
            el.focus();
        }
    });
    //---vue---component---
    Vue.component('yl-input', {
        props: {
            value: String,
            id: String,
            lable: String,
            placeholder: '',
            autofocus: { type: Boolean, default: false },
            readonly: { type: Boolean, default: false },
            disabled: { type: Boolean, default: false }
        },
        //['value', 'id', 'lable'],
        template: `
     <div class="form-group">
            <label class="form-label col-sm-2">{{lable}}</label>
            <div class="col-sm-10">
                <input  :focus="focus" :placeholder="placeholder" :disabled="disabled" :readonly="readonly" :autofocus="autofocus"
                        :id="id" class="form-control" type="text"
                     v-bind="$attrs"  v-bind:value="value" v-on="inputListeners">
            </div>
        </div>
    `,
        data: function () {
            return {
            };
        },
        methods: {
            focus: function () {
                this.$emit(this.$refs.input.focus());
            }
        },
        computed: {
            inputListeners: function () {
                var vm = this;
                return Object.assign({},
                    this.$listeners,
                    {
                        input: function (event) {
                            vm.$emit('input', event.target.value);
                        }
                    }
                );
            }
        }
    });
    Vue.component('yl-select', {
        props: ["lable", "option", "value", "list"],
        //template: '#yl-select',
        template: `
    <div class="form-group">
            <label class="form-label col-sm-2">{{lable}}</label>
            <div class="col-sm-10">
                <select class="form-control"  size="1">
                    <option value="">{{option}}</option>
                    <template v-for="item in list">
                        <option :value="item.value">{{item.name}}</option>
                    </template>
                </select>
            </div>
        </div>
    `,
    });
    Vue.prototype.strLength = function (s, bUnicode255For1) {
        return yui.strLength(s, bUnicode255For1);
    };
    Vue.prototype.getDateDiff = function (startTime, endTime, diffType) {
        return yui.getDateDiff(startTime, endTime, diffType);
    };
    Vue.prototype.jsonDateFormat = function (jsonDate) {
        return yui.jsonDateFormat(jsonDate);
    };
    Vue.prototype.getNow = function () {
        return yui.getNow();
    };
    Vue.prototype.getCurrentMonthFirst = function () {
        return yui.getCurrentMonthFirst();
    };
    Vue.prototype.getCurrentMonthLast = function () {
        return yui.getCurrentMonthLast();
    };
}());
var yui = {
    ready: function (func) {
        (function () {
            func && func();
        })();
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
    get: function (func) {
        func && func();
    },
    post: function (url, data) {
    },
    getDomById: function (id) {
        return document.getElementById(id);
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
    GetPercent: function (num, total) {
        num = parseFloat(num);
        total = parseFloat(total);
        if (isNaN(num) || isNaN(total)) {
            return "-";
        }
        return total <= 0 ? "0%" : (Math.round(num / total * 10000) / 100.00) + "%";
    },
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
    $axiospostform: function (url, data) {
        return new Promise(function (resolve, reject) {
            axios.post(url, Qs.stringify(data), {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
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
                    'Content-Type': 'application/json; charset=UTF-8'
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
            axios.post(url, data).then(function (response) {
                resolve(response);
            }).catch(function (error) {
                reject(error);
            });
        });
    },
    $axiosget: function (url, data) {
        return new Promise(function (resolve, reject) {
            axios.get(url, data).then(function (response) {
                resolve(response);
            }).catch(function (error) {
                reject(error);
            });
        });
    }
};
var yl = {
    table: function (id, url, obj, method, key, singleSelect, DeptId, sortName, sortOrder) {
        method = method || "GET";
        sortName = sortName || "CreateDate";
        sortOrder = sortOrder || "desc";
        if (typeof singleSelect === "undefined") {
            singleSelect = true;
        }
        $("#" + id).bootstrapTable({
            url: url,
            method: method,
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            toolbar: '#toolbar', //工具按钮用哪个容器
            striped: true, //是否显示行间隔色
            cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            sortable: true, //是否启用排序
            sortOrder: sortOrder, //排序方式
            sortName: sortName,
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
                    search: params.search,
                    datemin: _self.$refs.datemin.value,
                    datemax: _self.$refs.datemax.value,
                    //datemin: $("#datemin").val(),
                    //datemax: $("#datemax").val() || "",
                    //keyword: $("#keyword").val() || ""
                };
                if (DeptId) {
                    temp.DeptId = _self.$refs.DeptId.value;
                }
                return temp;
            },
            queryParamsType: 'limit',
            columns: obj
        });
    },
    table2: function (id, url, obj, key, method, sortName, sortOrder, singleSelect) {
        method = method || "GET";
        $("#" + id).bootstrapTable({
            url: url,
            method: method,
            toolbar: '#toolbar', //工具按钮用哪个容器
            striped: true, //是否显示行间隔色
            cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            sortable: true, //是否启用排序
            sortOrder: sortOrder, //排序方式
            sortName: sortName,
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
            singleSelect: true, //设置 true 将禁止多选。
            minimumCountColumns: 1, //最少允许的列数
            clickToSelect: true, //是否启用点击选中行
            //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            //idField: "Name",
            uniqueId: key, //每一行的唯一标识，一般为主键列
            showToggle: true, //是否显示详细视图和列表视图的切换按钮
            showFullscreen: false,
            cardView: false, //是否显示详细视图
            detailView: true, //是否显示父子表
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
            columns: obj
        });
    },
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
    }
};

const errorMsg = "异常";
//-----vue-----
Vue.directive('focus', {
    inserted: function (el) {
        el.focus();
    }
});

Vue.prototype.strLength = function (s, bUnicode255For1) {
    if (bUnicode255For1) { return s.length; }
    return [].reduce.call(s, function (sum, value) {
        return value.charCodeAt(0) > 255 ? sum + 2 : sum + 1;
    }, 0);
};
Vue.prototype.GetDateDiff = function (startTime, endTime, diffType) {
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
    console.info(eTime.getTime() - sTime.getTime());
    return parseFloat((eTime.getTime() - sTime.getTime()) / parseInt(timeType)).toFixed(2);
};
Vue.prototype.jsonDateFormat = function (jsonDate) {
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
};
Vue.prototype.getNow = function () {
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
};
Vue.prototype.getCurrentMonthFirst = function () {
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
};
Vue.prototype.getCurrentMonthLast = function () {
    //var date = new Date();
    //var seperator1 = "-";
    //var currentMonth = date.getMonth()+2;
    //var lastDateOfCurrentMonth = new Date(date.getFullYear(), currentMonth,0);
    //var month = lastDateOfCurrentMonth.getMonth();
    //if (month >= 1 && month <= 9) {
    //    month = "0" + month;
    //}
    //strDate = lastDateOfCurrentMonth.getDate();
    //if (strDate >= 0 && strDate <= 9) {
    //    strDate = "0" + strDate;
    //}
    //var currentdate = lastDateOfCurrentMonth.getFullYear() + seperator1 + month + seperator1 + strDate;
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
};

//layer
function layer_close() {
    var index = parent.layer.getFrameIndex(window.name);
    parent.layer.close(index);
}
function layer_close2() {
    var index = parent.layer.getFrameIndex(window.name);
    parent.$("button[name='refresh']").click();
    parent.layer.close(index);
}

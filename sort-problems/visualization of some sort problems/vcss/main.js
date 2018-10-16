(
  function () {
    var queue = document.getElementById("queue"),
      state = [], //保存排序的中间状态
      msg = "请输入 10～100 的数字";
      mseg="请输入 100~10000 的数字";
    init();
    //------------------------------->
    var LFT = [];
    var RGT = [];
    var BASE=[];
    // var BST=[];
    var timespeed;
    // var psp=0;
    //------------------------------->
    var 
      input = document.getElementById("in-number"),
      leftIn = document.getElementById("left-in"),
      rightIn = document.getElementById("right-in"),
      leftOut = document.getElementById("left-out"),
      rightOut = document.getElementById("right-out"),
      inspeed=document.getElementById("speed-controller"),
      btnspeed=document.getElementById("time-controler"),
    btnBubble = document.getElementById("bubble-sort");
    btnqSort = document.getElementById("quick-sort");
    //------------------------------->
    btnspeed.onclick = function () {
      var speed = parseInt(inspeed.value);
      if (!(speed >= 100 && speed <= 10000))
        alert(mseg);
      else timespeed = speed;
    }
    //------------------------------->
    leftIn.onclick = function () {
      var number = parseInt(input.value);
      if (!isNaN(number) && isBetween(number)) {
        queue.insertBefore(createLabel(number), queue.firstElementChild);
        if (queue.children.length > 60) {
          alert(number);
        }
      } else {
        alert(msg);
      }
    };
    //------------------------------->
    rightIn.onclick = function () {
      var number = parseInt(input.value);
      if (!isNaN(number) && isBetween(number)) {
        queue.appendChild(createLabel(number));
        if (queue.children.length > 60) {
          alert(number);
        }
      } else {
        alert(msg);
      }
    };
    //------------------------------->
    leftOut.onclick = function () {
      var first = queue.firstElementChild;
      queue.removeChild(first);
      alert(first.itemValue);
    };
    rightOut.onclick = function () {
      var last = queue.lastElementChild;
      queue.removeChild(last);
      alert(last.itemValue);
    };
    btnBubble.onclick = function () {
      processSort(bubbleSort);
    }
    btnqSort.onclick = function () {
      processSort(quickSort);
    }
    //--------------functions---------------------------
    /*
    初始化队列
    */
    function init() {
      var initArr = //[];
        [30, 10, 21, 67, 82, 44, 100, 77, 63, 42, 55, 12]; //测试数据
      initArr.forEach(function (item) {
        var label = createLabel(item);
        queue.appendChild(label);
      });
    }
    /*
    执行排序
    */
    function processSort(callback) {
      var arr = [];
      var children = queue.children;
      for (var i = 0; i < children.length; i++) {
        arr.push(children[i].itemValue);
      }
      callback.call(this, arr);
      draw();
    }
    /*
    画出某一步时的状态
    参考：https://www.zhihu.com/question/41642706
    */
   var psp=-100;
    function draw() {
      var bars = queue.children;
      var current = state.shift() || [];
      var data1=LFT.shift();
      var data2=RGT.shift();
      var temp_data=BASE.shift();
      if(temp_data!=-1)
      psp=temp_data;
      for(var i=0;i<bars.length;i++)
      {
        if(current[i]==psp)
        {
            setItem(bars[i],current[i],"blue");
            break;
        }
      }
      for (var i = 0; i < bars.length; i++) 
      {
        // if(i==LFT.first()||i==RGT.first())
        // {
        //   setItem(bars[i], current[i],"red");
        // }
        // else 
        if(current[i]==psp) continue;
        if(current[i]==data1||current[i]==data2)
        setItem(bars[i], current[i],"red");
        else  setItem(bars[i], current[i]);
      }
      // LFT.pop();
      // RGT.pop();
      console.log(current);
      if (state.length > 0) 
      {
        // 关于延时函数：
        //https://www.haorooms.com/post/js_setTimeout
        setTimeout(draw, timespeed);
      }
    }
    /*
    冒泡排序
    */
    function bubbleSort(arr) 
    {
      var step = function (j) 
      {
        //console.log(j);
        if (arr[j] > arr[j + 1]) 
        {
          swap(arr, j, j + 1);

        }
      };
      for (var i = 0; i < arr.length; i++) {
        for (var j = 0; j < arr.length - 1 - i; j++) 
        {
          step(j);
          LFT.push(arr[j]);
          RGT.push(arr[j+1]);
          // sessionStorage.setItem('first','77');
          // sessionStorage.setItem('second','j+1');
          state.push(JSON.parse(JSON.stringify(arr)));
        }
      }
    }

    function swap(arr, i, j) {
      var tmp = arr[i];
      arr[i] = arr[j];
      arr[j] = tmp;
    }

    /*
    快速排序 
    */

    function quickSort(arr) {
      function Qsort(l, r) {
        if (l > r) return;
        var temp = arr[l];
        // BST.push(psp);
        BASE.push(temp);
        var i = l;
        var j = r;
        while (i < j) {
          while (arr[j] >= temp && i < j)
            {
              LFT.push(arr[j]);
              j--;
            }
          while (arr[i] <= temp && i < j)
            {
              RGT.push(arr[i]);
              i++;
            }

          if (i < j) {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
            LFT.push(arr[j]);
            RGT.push(arr[i]);
            BASE.push(-1);
            state.push(JSON.parse(JSON.stringify(arr)));
          }
        }
        arr[l] = arr[i];
         LFT.push(arr[l]);
        BASE.push(-1);
        state.push(JSON.parse(JSON.stringify(arr)));
        arr[i] = temp;
        RGT.push(arr[i]);
        BASE.push(-1);
        state.push(JSON.parse(JSON.stringify(arr)));
        // psp++;
        Qsort(l, i - 1);
        Qsort(i + 1, r);
      }
      Qsort(0, arr.length - 1);
    }
    /*
    新建 label
    */
    function createLabel(item) {
      var label = document.createElement("label");
      setItem(label, item);
      label.onclick = function () {
        queue.removeChild(label);
      };
      return label;
    }
    /*
    设置 label 的数值和高度
    */
    function setItem(label, item,lbcolor="green") 
    {
      label.style.backgroundColor=lbcolor;
      label.itemValue = item;
      label.style.height = item * 3 + 'px';
    }
    /*
    判断是否满足范围
    */
    function isBetween(number, low = 10, high = 100) {
      return number >= low && number <= high;
    }
  }
)();
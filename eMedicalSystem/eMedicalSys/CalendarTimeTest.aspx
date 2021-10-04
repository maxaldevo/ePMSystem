<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CalendarTimeTest.aspx.cs" Inherits="eMedicalSys.CalendarTimeTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<style>
.grid-header {
    background-color:#aaa;
    background-size: 34px;
    border-bottom: 1px solid #ddd;
    overflow: hidden;
    box-shadow: 0 0 3px 0;
    position: fixed;
    top:43px;
    display:block;
    z-index:1035;
}


.grid-header-labels {
    padding-left: 60px;
}
.grid-header-label {
    width:120px;
    float: left;
    padding: 10px 5px;
    height: 40px;
    text-align: center;
    background: #009d97;
    color: #fff;
    cursor: pointer;
    position: relative;
}



.grid-header-label-divider{
    border-right: 1px solid #cbcbcb;
    position: static ;
    right:0;
    bottom:0;
    height:22px;
}

.grid-header-Clock {
       text-align:left;
  background-color:#aaa;
    width: 60px;
    height: 60px;
    position: fixed;
    left: 0;
    top: 0;
    font-size:40px;
}

.grid-body {

    position: absolute;
    top: 40px !important;
    background: #f7f7f7;
}
.ui-block {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
}

.grid-times-holder {
    position: absolute;
    overflow: hidden;
    width: 60px;
    top: 0;
    display:block;
    z-index: 200;
    border-right: 1px solid #ddd;
    background: #eee;
    text-align: center;
}
.grid-date-holder {
    position: absolute;
    overflow: hidden;
    left:60px;
    top:0px;
    display:block;
    z-index: 200;
    border-right: 1px solid #ddd;
    background: #eee;
    text-align: center;
}

.day-label{
    height: 24px;
    line-height: 25px;
  
    border-bottom: 1px solid #a6a8ab;
    color: #57585a;
    background-color: #CBCBCB;
}
.grid-time-label {
     height: 50px; 
    top:10px;
    line-height: 20px;
    border-bottom: 1px solid #ddd;
    padding-left: 0;
}
.grid-times {
  }
.grid-body-labels {
    padding-left: 0px;
}
.grid-body-cell {
    width:110px;
    float: left;
    padding: 10px 5px;
    height: 50px; 
    line-height: 49px;
    border-bottom: 1px solid #ddd;
    padding-left: 0;

    text-align: center;
    color: #fff;
    background-color:#fff;
    cursor: pointer;
    position: relative;
    border: 1px solid #ddd;
}
.grid-sessions {
    position: relative;
    min-width:100%;
}
.grid-sessions-day {
    position: relative;
    height: 1525px;
    background: url(https://farm9.staticflickr.com/8617/16121120332_0c7b48b7c4_o.png) 60px 25px;
    min-width: 100%;
}

.grid-session-cell {
    position: absolute;
    width: 118px;
    overflow: hidden;
    border: 1px solid #bbb;
    font-size: 12px;
    cursor: pointer;
    background: rgba(0,157,151,.85);
    color: #fff;
    font-family: sans-serif;
}

.grid-session-icon {
    position: absolute;
    right: 10px;
    bottom: 10px;
    font-size:24px;
}
.grid-session-title{
    padding:9px;
    padding-right:10px;
    font-weight:bold;
}
.grid-session-time{
    padding:9px;
    }

</style>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
        <link href="//code.ionicframework.com/nightly/css/ionic.css" rel="stylesheet">
    <script src="//code.ionicframework.com/nightly/js/ionic.bundle.js"></script>
     <ion-pane>
        <ion-header-bar class="bar-dark" style="background-color:#009d97">
            <h1 class="title">Beautiful Agenda</h1>
        </ion-header-bar>


        <div id="gridHeader" class="grid-header"  ng-style="{'overflow': 'false', 'width' : (200 * rooms.length + 60) + 'px', 'left':'-'+timerleft}">
           <div class="grid-header-clock" style="left: 0px;">
        
            </div>
            <div class="grid-header-labels" ng-repeat="room in rooms">
                <div class="grid-header-label">{{room.name}}
                    <div class="grid-header-label-divider"></div>
                </div>

            </div>
            
        </div>
        <ion-content scroll="true" direction="xy"  has-bouncing="false"  on-scroll="gotScrolled()">
            <div id="gridBody" class="grid-body ui-block"  >
                <div style="position:relative" ng-repeat="day in days">
                    <div id="gridTimesHolder" class="grid-times-holder" ng-style="{'left':timerleft}" >
                        <div class="day-label">{{day.day.substr(0, 3)}}</div>  
                        <div class="grid-times" ng-repeat="hour in hours">
                            <div class="grid-time-label">{{hour}}</div> 
                        </div>
                    </div>
                    <div class="grid-sessions" ng-style="{'height' : (50 * hours.length + 24) + 'px'}">
                        <div class="grid-sessions-day" ng-style="{'overflow': 'true', 'width' : (130 * rooms.length + 60) + 'px'}"
                             >
                            <div ng-repeat="event in events| filter:{ dateformat: day.dateformat}">
                                <div class="grid-session-cell" ng-style="{'top':event.top, 'left':event.left, 'height':event.height, 'background-color':event.color}">
                                    <i class="icon  grid-session-icon" ng-class="event.eventtype"></i>
                                    <div class="grid-session-title">{{event.eventname}}</div>
                                    <div class="grid-session-time">{{event.starthour}}-{{event.endhour}}</div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="grid-date-holder" ng-style="{'overflow': 'true', 'width' : (200 * rooms.length) + 'px'}">
                        <div class="day-label">{{day.longdate}}</div> 

                    </div>

                </div>

            </div>



        </ion-content>
    </ion-pane>

    <script>
    
angular.module('starter', ['ionic'])

        .run(function ($ionicPlatform) {
            $ionicPlatform.ready(function () {
               
                if (window.cordova && window.cordova.plugins.Keyboard) {
                    cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
                }
                if (window.StatusBar) {
                    StatusBar.styleDefault();
                }
            });
        })

        .controller('MyCtrl', function ($scope, $ionicScrollDelegate) {

            var startHour = 7;
            var endHour = 21;
            var usehalfhour = true;

            $scope.timerleft = '0px';

            $scope.hours = getHours();
            $scope.rooms = getRooms();
            $scope.days = getDays();
            $scope.events = getEvents();

            function getHours()
            {
                var tmp = [];
                for (i = startHour; i <= endHour; i++)
                {
                    tmp.push(('0' + i).slice(-2) + ':00');
                    if (usehalfhour && i < endHour)
                    {
                        tmp.push(('0' + i).slice(-2) + ':30');
                    }
                }

                return tmp;
            }
            ;


            function getRooms()
            {
                var tmp = [];
                tmp.push({id: 1, name: 'Morpheues'});
                tmp.push({id: 2, name: 'Neo'});
                tmp.push({id: 3, name: 'Trinity'});
                tmp.push({id: 4, name: 'Mouse'});

                return tmp;
            }
            ;
            function getDays()
            {
                var tmp = [];
                var date1 = new Date();
                var date2 = new Date();
                date2.setDate(date2.getDate() + 1);
                var weekday = new Array(7);
                weekday[0] = "Sunday";
                weekday[1] = "Monday";
                weekday[2] = "Tuesday";
                weekday[3] = "Wednesday";
                weekday[4] = "Thursday";
                weekday[5] = "Friday";
                weekday[6] = "Saturday";

                var monthname = new Array(12);
                monthname[0] = "January";
                monthname[1] = "February";
                monthname[2] = "March";
                monthname[3] = "April";
                monthname[4] = "May";
                monthname[5] = "June";
                monthname[6] = "July";
                monthname[7] = "August";
                monthname[8] = "September";
                monthname[9] = "October";
                monthname[10] = "November";
                monthname[11] = "December";


                tmp.push({day: weekday[date1.getDay()], longdate: weekday[date1.getDay()] + ', ' + monthname[date1.getMonth()] + ' ' + date1.getDate() + ', ' + date1.getFullYear(), datevalue: date1, dateformat: date1.toLocaleDateString()});
                tmp.push({day: weekday[date2.getDay()], longdate: weekday[date2.getDay()] + ', ' + monthname[date2.getMonth()] + ' ' + date2.getDate() + ', ' + date2.getFullYear(), datevalue: date2, dateformat: date2.toLocaleDateString()});
                console.log(tmp);
                return tmp;
            }

            $scope.gotScrolled = function () {

                $scope.timerleft = $ionicScrollDelegate.getScrollPosition().left + 'px';
                $scope.$apply();

            };

            function getEvents() {
                var tmp = [];
                var date1 = new Date();
                tmp.push({eventname: 'Presentation 1', starthour: '08:00', endhour: '09:30', eventtype: 'ion-mic-c', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 1 * 100) + 'px', height: (1.5 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Coffee Break', starthour: '09:30', endhour: '10:00', eventtype: 'ion-coffee', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 2.5 * 100) + 'px', height: (0.5 * 100) + 'px', color: 'rgba(255,169,0,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Presentation 2', starthour: '10:00', endhour: '11:45', eventtype: 'ion-mic-c', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 3 * 100) + 'px', height: (1.75 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Networking + Coffee', starthour: '12:00', endhour: '14:00', eventtype: 'ion-chatbubbles', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 5 * 100) + 'px', height: (1.75 * 100) + 'px', color: 'rgba(18,67,172,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Presentation 3', starthour: '14:30', endhour: '18:00', eventtype: 'ion-mic-c', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 7.5 * 100) + 'px', height: (2.5 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Dinner', starthour: '19:00', endhour: '21:00', eventtype: 'ion-wineglass', room: 'Morpheus', left: (60 + 0 * 120) + 'px', top: (23 + 12 * 100) + 'px', height: (2 * 100) + 'px', color: 'rgba(255,113,0,0.75)', dateformat: date1.toLocaleDateString()});

                tmp.push({eventname: 'Presentation 4', starthour: '08:00', endhour: '11:00', eventtype: 'ion-mic-c', room: 'Trinity', left: (60 + 2 * 120) + 'px', top: (23 + 1 * 100) + 'px', height: (3 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Presentation 5', starthour: '11:00', endhour: '12:00', eventtype: 'ion-mic-c', room: 'Trinity', left: (60 + 2 * 120) + 'px', top: (23 + 4 * 100) + 'px', height: (1 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Networking + Coffee', starthour: '12:00', endhour: '14:00', eventtype: 'ion-chatbubbles', room: 'Trinity', left: (60 + 2 * 120) + 'px', top: (23 + 5 * 100) + 'px', height: (1.75 * 100) + 'px', color: 'rgba(18,67,172,0.75)', dateformat: date1.toLocaleDateString()});
                tmp.push({eventname: 'Presentation 6', starthour: '14:30', endhour: '16:00', eventtype: 'ion-mic-c', room: 'Trinity', left: (60 + 2 * 120) + 'px', top: (23 + 7.5 * 100) + 'px', height: (1.5 * 100) + 'px', color: 'rgba(0,157,151,0.75)', dateformat: date1.toLocaleDateString()});
                //
                //
                //Presentation - 0,157,151 -- ion-mic-c
                //Networking 18,67,172 -- ion-chatbubbles
                //Coffee Break 255,169,0, --ion-coffee
                //Dinner 255,113,0 --ion-wineglass
                return tmp;
            }
            ;

        });

</script>
</asp:Content>

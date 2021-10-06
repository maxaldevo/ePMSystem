using System;
using System.Web.UI.WebControls;
using DevExpress.Web.Internal;
using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;

namespace DevExpress.Web.Demos.ASPxScheduler {
    #region ASPxTimeZoneEditEx
    public class ASPxTimeZoneEditEx : ASPxTimeZoneEdit {
        const string ScriptFileName = "ASPxTimeZoneEditEx.js";
        TimeRuler timeRuler = null;
        public DevExpress.XtraScheduler.TimeRuler TimeRuler { get { return timeRuler; } set { timeRuler = value; } }

        protected override void InitializeComboBox(ASPxComboBox combo) {
            base.InitializeComboBox(combo);
            combo.DropDownButton.Visible = false;
            combo.Font.Size = FontUnit.Point(8);
            combo.Cursor = "pointer";
        }
        public override string GetActualTimeZone() {
            if(TimeRuler == null)
                return "Hawaiian Standard Time";
            return TimeRuler.TimeZoneId;
        }

        #region Client scripts support
        protected override string GetClientObjectClassName() {
            return "ASPxClientTimeZoneEditEx";
        }
        protected override string GetComboOnChange() {
            if(TimeRuler != null) {
                DevExpress.Web.ASPxScheduler.ASPxScheduler control = (DevExpress.Web.ASPxScheduler.ASPxScheduler)this.MasterControl;
                TimeRulerCollection rulers = control.DayView.TimeRulers;
                int indx = rulers.IndexOf(TimeRuler);
                return String.Format("function(s, e) {{ aspxTimeZoneEditComboSelectedIndexChangedEx('{0}', s.GetValue(), {1}); }}", ClientID, indx);
            }
            return String.Empty;
        }
        #endregion
    }
    #endregion
    #region ChangeTimeZoneCallbackCommand
    public class ChangeTimeZoneCallbackCommand : SchedulerCallbackCommand {
        public const string CommandId = "UTZCH";
        #region Fields
        string timeZoneId;
        int index;
        #endregion

        public ChangeTimeZoneCallbackCommand(DevExpress.Web.ASPxScheduler.ASPxScheduler control)
            : base(control) {
        }

        #region Properties
        public string TimeZoneId { get { return timeZoneId; } }
        public int Index { get { return index; } }
        public override string Id { get { return CommandId; } }
        #endregion

        protected override void ParseParameters(string parameters) {
            string[] args = parameters.Split(new char[] { ',' });
            this.timeZoneId = args[0];
            this.index = Int32.Parse(args[1]);
        }

        protected override void ExecuteCore() {
            Control.DayView.TimeRulers[Index].TimeZoneId = TimeZoneId;
        }
    }
    #endregion
}

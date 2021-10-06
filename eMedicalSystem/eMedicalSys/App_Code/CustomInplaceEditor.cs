using System;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;

public class MyInplaceEditorSaveCallbackCommand : AppointmentInplaceEditorSaveCallbackCommand {
    public MyInplaceEditorSaveCallbackCommand(ASPxScheduler control)
        : base(control) {
    }
    protected override void AssignControllerValues() {
        TextBox txSubject = (TextBox)FindControlByID("txSubject");
        if(txSubject != null) Controller.Subject = txSubject.Text;
    }
}

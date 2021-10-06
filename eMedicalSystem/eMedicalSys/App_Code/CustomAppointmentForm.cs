using System;
using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;

public class CustomFieldNames {
    public const string ContactInfo = "ContactInfo";
}


public class MyAppointmentFormTemplateContainer : AppointmentFormTemplateContainer {
    public MyAppointmentFormTemplateContainer(ASPxScheduler control)
        : base(control) {
    }
    public string ContactInfo { get { return Convert.ToString(Appointment.CustomFields[CustomFieldNames.ContactInfo]); } }
}
public class MyAppointmentSaveCallbackCommand : AppointmentFormSaveCallbackCommand {
    public MyAppointmentSaveCallbackCommand(ASPxScheduler control)
        : base(control) {
    }
    protected internal new MyAppointmentFormController Controller { get { return (MyAppointmentFormController)base.Controller; } }

    protected override void AssignControllerValues() {
        ASPxTextBox tbSubject = (ASPxTextBox)FindControlByID("tbSubject");
        ASPxTextBox tbLocation = (ASPxTextBox)FindControlByID("tbLocation");
        ASPxDateEdit edtStartDate = (ASPxDateEdit)FindControlByID("edtStartDate");
        ASPxDateEdit edtEndDate = (ASPxDateEdit)FindControlByID("edtEndDate");
        ASPxMemo memDescription = (ASPxMemo)FindControlByID("memDescription");
        ASPxMemo memContacts = (ASPxMemo)FindControlByID("memContacts");

        Controller.Subject = tbSubject.Text;
        Controller.Location = tbLocation.Text;
        Controller.Description = memDescription.Text;

        Controller.Start = edtStartDate.Date;
        Controller.End = edtEndDate.Date;
        // custom field 
        Controller.ContactInfo = memContacts.Text;

        DateTime clientStart = FromClientTime(Controller.Start);
        AssignControllerRecurrenceValues(clientStart);
    }
    protected override AppointmentFormController CreateAppointmentFormController(Appointment apt) {
        return new MyAppointmentFormController(Control, apt);
    }
}

public class MyAppointmentFormController : AppointmentFormController {
    private const string ContactInfoFieldName = "ContactInfo";

    public MyAppointmentFormController(ASPxScheduler control, Appointment apt)
        : base(control, apt) {
    }
    public string ContactInfo { get { return (string)EditedAppointmentCopy.CustomFields[ContactInfoFieldName]; } set { EditedAppointmentCopy.CustomFields[ContactInfoFieldName] = value; } }

    string SourceContactInfo { get { return (string)SourceAppointment.CustomFields[ContactInfoFieldName]; } set { SourceAppointment.CustomFields[ContactInfoFieldName] = value; } }

    public override bool IsAppointmentChanged() {
        if(base.IsAppointmentChanged())
            return true;
        return SourceContactInfo != ContactInfo;
    }
    protected override void ApplyCustomFieldsValues() {
        SourceContactInfo = ContactInfo;
    }
}

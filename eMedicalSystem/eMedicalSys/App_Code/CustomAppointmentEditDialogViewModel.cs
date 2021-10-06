using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Dialogs;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;
using System.Linq;
using System.Collections.Generic;

public class CustomAppointmentEditDialogViewModel : AppointmentEditDialogViewModel {
    public CustomAppointmentEditDialogViewModel(ASPxScheduler scheduler) : base() {
        Scheduler = scheduler;
    }

    [DialogFieldViewSettings(Caption = "Phone")]
    public string Phone { get; set; }

    [DialogFieldViewSettings(Caption = "Doctor", EditorType = DialogFieldEditorType.ComboBox)]
    public override List<object> ResourceIds { get { return base.ResourceIds; } }

    [DialogFieldViewSettings(Caption = "Department", EditorType = DialogFieldEditorType.ComboBox)]
    public override string Location {
        get { return base.Location; }
        set { base.Location = value; }
    }

    protected ASPxScheduler Scheduler { get; private set; }

    public override void Load(AppointmentFormController appointmentController) {
        base.Load(appointmentController);

        SetDataItemsFor(m => m.Location, PopulateLocations);

        UpdateResourceRelatedProperties();
        TrackPropertyChangeFor((CustomAppointmentEditDialogViewModel m) => m.ResourceIds, UpdateResourceRelatedProperties);
    }
    void PopulateLocations(AddDataItemMethod<string> addDataItemDelegate) {
        addDataItemDelegate("Hospital", "Hospital");
        addDataItemDelegate("Surgery", "Surgery");
        addDataItemDelegate("Urgent Care", "Urgent Care");
        addDataItemDelegate("Pharmacy", "Pharmacy");
    }
    void UpdateResourceRelatedProperties() {
        if(ResourceIds.Any()) {
            Resource resource = Scheduler.Storage.Resources.GetResourceById(ResourceIds.First());
            Phone = resource.CustomFields["Phone"] as string;
        }
    }
    public override void SetDialogElementStateConditions() {
        base.SetDialogElementStateConditions();
        SetItemVisibilityCondition(m => m.Description, false);
    }
}

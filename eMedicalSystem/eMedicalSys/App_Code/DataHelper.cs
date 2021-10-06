using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Demos;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNet.EntityDataSource;
using System.Drawing;

public static class DataHelper {
    public static void SetupDefaultMappings(ASPxScheduler control) {
        SetupDefaultMappings(control.Storage, false);
    }
    public static void SetupDefaultMappings(ASPxSchedulerStorage storage) {
        SetupDefaultMappings(storage, false);
    }
    public static void SetupDefaultMappings(ASPxSchedulerStorage storage, bool useImageResourceMapping) {
        storage.BeginUpdate();
        try {
            ASPxResourceMappingInfo resourceMappings = storage.Resources.Mappings;
            resourceMappings.ResourceId = "ID";
            resourceMappings.Caption = "DisplayName";
            if(useImageResourceMapping)
                resourceMappings.Image = "PhotoBytes";

            ASPxAppointmentMappingInfo appointmentMappings = storage.Appointments.Mappings;
            appointmentMappings.AppointmentId = "ID";
            appointmentMappings.Start = "StartTime";
            appointmentMappings.End = "EndTime";
            appointmentMappings.Subject = "Subject";
            appointmentMappings.Description = "Description";
            appointmentMappings.Location = "Location";
            appointmentMappings.AllDay = "AllDay";
            appointmentMappings.Type = "EventType";
            appointmentMappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentMappings.ReminderInfo = "ReminderInfo";
            appointmentMappings.Label = "Label";
            appointmentMappings.Status = "Status";
            appointmentMappings.ResourceId = "MedicId";
        }
        finally {
            storage.EndUpdate();
        }
    }
    public static void SetupCustomEventsMappings(ASPxScheduler control) {
        SetupCustomEventsMappings(control.Storage);
    }
    public static void SetupCustomEventsMappings(ASPxSchedulerStorage storage) {
        storage.BeginUpdate();
        try {
            ASPxResourceMappingInfo resourceMappings = storage.Resources.Mappings;
            resourceMappings.ResourceId = "ID";
            resourceMappings.Caption = "Caption";

            ASPxAppointmentMappingInfo appointmentMappings = storage.Appointments.Mappings;
            appointmentMappings.AppointmentId = "ID";
            appointmentMappings.Start = "StartTime";
            appointmentMappings.End = "EndTime";
            appointmentMappings.Subject = "Subject";
            appointmentMappings.AllDay = "AllDay";
            appointmentMappings.Description = "Description";
            appointmentMappings.Label = "Label";
            appointmentMappings.Location = "Location";
            appointmentMappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentMappings.ReminderInfo = "ReminderInfo";
            appointmentMappings.ResourceId = "OwnerId";
            appointmentMappings.Status = "Status";
            appointmentMappings.Type = "EventType";
        }
        finally {
            storage.EndUpdate();
        }
    }
    public static void SetupLabels(ASPxScheduler control) {
        SetupLabels(control.Storage);
    }
    public static void SetupLabels(ASPxSchedulerStorage storage) {
        DevExpress.Web.ASPxScheduler.AppointmentLabelCollection labels = storage.Appointments.Labels;
        labels.Clear();
        labels.Add(1, "Routine", "Routine", Color.FromArgb(255, 75, 194, 80));
        labels.Add(2, "Follow-Up", "Follow-Up", Color.FromArgb(255, 58, 159, 254));
        labels.Add(3, "Urgent", "Urgent", Color.FromArgb(255, 255, 89, 50));
        labels.Add(4, "Lab Testing", "Lab Testing", Color.FromArgb(255, 92, 107, 192));
        labels.Add(5, "Service", "Service", Color.FromArgb(255, 159, 159, 159));
    }
    public static void SetupStatuses(ASPxScheduler control) {
        SetupStatuses(control.Storage);
    }
    public static void SetupStatuses(ASPxSchedulerStorage storage) {
        DevExpress.Web.ASPxScheduler.AppointmentStatusCollection statuses = storage.Appointments.Statuses;
        statuses.Clear();
        statuses.Add(1, AppointmentStatusType.Custom, "Confirmed", "Confirmed", Color.FromArgb(255, 0, 171, 71));
        statuses.Add(2, AppointmentStatusType.Custom, "Awaiting Confirmation", "Awaiting Confirmation", Color.FromArgb(255, 94, 53, 177));
        statuses.Add(3, AppointmentStatusType.Custom, "Cancelled", "Cancelled", Color.FromArgb(255, 255, 255, 255));
    }
    public static void ProvideRowInsertion(ASPxScheduler control, DataSourceControl dataSource) {

        bool isDbDataSource = dataSource is EntityDataSource || dataSource is AccessDataSource;
        if(isDbDataSource) {
            DbRowInsertionProvider provider = new DbRowInsertionProvider();
            provider.ProvideRowInsertion(control, dataSource);
            return;
        }

        ObjectDataSource objectDataSource = dataSource as ObjectDataSource;
        if(objectDataSource != null) {
            ObjectDataSourceRowInsertionProvider provider = new ObjectDataSourceRowInsertionProvider();
            provider.ProvideRowInsertion(control, objectDataSource);
        }
    }
    public static void ProvideRowInsertion(ASPxScheduler control, DevExpress.Web.DemoUtils.SchedulerDemoDataSource dataSource) {
        if(dataSource.IsSiteMode.Equals(DevExpress.Utils.DefaultBoolean.True)) {
            DataSourceControlRowInsertionProvider provider = new DataSourceControlRowInsertionProvider();
            provider.ProvideRowInsertion(control, dataSource);
        }
        else
            control.Storage.Appointments.AutoRetrieveId = true;
    }
    public static void EnsureOnlineVersionModificationLock(ASPxScheduler control) {
        if(Utils.IsSiteMode) {
            DemoOnlineRowModificationProvider provider = new DemoOnlineRowModificationProvider();
            provider.ProvideModification(control);

            control.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            control.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
            control.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;
            control.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            control.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None;
            control.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.None;
        }
    }
    public static void EnsureOnlineVersionModificationLock(ASPxScheduler control, SqlDataSource dataSource) {
        if(Utils.IsSiteMode) {
            DemoOnlineRowModificationProvider provider = new DemoOnlineRowModificationProvider();
            provider.ProvideModification(control, dataSource);
        }
    }
    public static CustomEventList GenerateCustomEventList(ASPxSchedulerStorage Storage) {
        CustomEventList eventList = new CustomEventList();
        int count = Storage.Resources.Count;
        for(int i = 0; i < count; i++) {
            Resource resource = Storage.Resources[i];
            string subjPrefix = resource.Caption + "'s ";

            eventList.Add(CreateEvent(resource.Id, subjPrefix + "meeting", 2, 5));
            eventList.Add(CreateEvent(resource.Id, subjPrefix + "travel", 3, 6));
            eventList.Add(CreateEvent(resource.Id, subjPrefix + "phone call", 0, 10));
        }
        return eventList;
    }
    public static CustomEventList GenerateCustomEventListByInterval(ASPxSchedulerStorage Storage, TimeOfDayInterval[] workTimes) {
        CustomEventList eventList = GenerateCustomEventList(Storage);
        foreach(CustomEvent evt in eventList) {
            TimeOfDayInterval workTime = workTimes[Int32.Parse(evt.OwnerId.ToString()) % workTimes.Length];
            int StartHour = workTime != null ? workTime.Start.Hours : 0;
            int EndHour = workTime != null ? workTime.End.Hours : 24;
            Random rnd = SchedulerDemoUtils.RandomInstance;
            evt.StartTime = SchedulerDemoUtils.BaseDate + TimeSpan.FromHours(rnd.Next(StartHour, EndHour - 2));
            evt.EndTime = evt.StartTime + TimeSpan.FromHours(rnd.Next(1, EndHour - evt.StartTime.Hour));
        }
        return eventList;
    }
    public static CustomEvent CreateEvent(object resourceId, string subject, int status, int label) {
        CustomEvent customEvent = new CustomEvent();
        customEvent.Subject = subject;
        customEvent.OwnerId = resourceId;
        Random rnd = SchedulerDemoUtils.RandomInstance;
        int rangeInHours = 48;
        customEvent.StartTime = SchedulerDemoUtils.BaseDate + TimeSpan.FromHours(rnd.Next(0, rangeInHours));
        customEvent.EndTime = customEvent.StartTime + TimeSpan.FromHours(rnd.Next(0, rangeInHours / 8));
        customEvent.Status = status;
        customEvent.Label = label;
        customEvent.ID = "ev" + customEvent.GetHashCode();
        return customEvent;
    }
}
public class DemoOnlineRowModificationProvider {
    public void ProvideModification(ASPxScheduler control, SqlDataSource dataSource) {
        dataSource.Updating += OnSqlDataSourceModifying;
        dataSource.Inserting += OnSqlDataSourceModifying;
        dataSource.Deleting += OnSqlDataSourceModifying;
    }
    void OnSqlDataSourceModifying(object sender, SqlDataSourceCommandEventArgs e) {
        Utils.AssertNotReadOnlyText();
    }
    public void ProvideModification(ASPxScheduler control) {
        control.AppointmentRowInserting += AppointmentRowChanging;
        control.AppointmentRowUpdating += AppointmentRowChanging;
        control.AppointmentRowDeleting += AppointmentRowChanging;
    }
    void AppointmentRowChanging(object sender, CancelEventArgs e) {
        Utils.AssertNotReadOnlyText();
    }
}

public class DbRowInsertionProvider {
    List<int> lastInsertedIdList = new List<int>();

    void ProvideRowInsertionCore(ASPxScheduler control) {
        control.AppointmentRowInserting += new ASPxSchedulerDataInsertingEventHandler(ControlOnAppointmentRowInserting);
        control.AppointmentRowInserted += new ASPxSchedulerDataInsertedEventHandler(ControlOnAppointmentRowInserted);
        control.AppointmentsInserted += new PersistentObjectsEventHandler(ControlOnAppointmentsInserted);
        control.AppointmentCollectionCleared += new EventHandler(OnControlAppointmentCollectionCleared);
    }

    public void ProvideRowInsertion(ASPxScheduler control, DataSourceControl dataSource) {
        if(dataSource is AccessDataSource)
            (dataSource as AccessDataSource).Inserted += AppointmentsAccessDataSource_Inserted;
        if(dataSource is EntityDataSource)
            (dataSource as EntityDataSource).Inserted += AppointmentsEntityDataSource_Inserted;
        ProvideRowInsertionCore(control);
    }
    public void ProvideRowInsertion(ASPxScheduler control, DevExpress.Web.DemoUtils.DemoDataSource dataSource) {
        dataSource.Inserted += AppointmentsAccessDataSource_Inserted;
        ProvideRowInsertionCore(control);
    }

    void OnControlAppointmentCollectionCleared(object sender, EventArgs e) {
        this.lastInsertedIdList.Clear();
    }

    void ControlOnAppointmentRowInserting(object sender, ASPxSchedulerDataInsertingEventArgs e) {
        // Autoincremented primary key case
        e.NewValues.Remove("ID");
    }
    void ControlOnAppointmentRowInserted(object sender, ASPxSchedulerDataInsertedEventArgs e) {
        // Autoincremented primary key case
        int count = this.lastInsertedIdList.Count;
        System.Diagnostics.Debug.Assert(count > 0);
        e.KeyFieldValue = this.lastInsertedIdList[count - 1];
    }
    void AppointmentsAccessDataSource_Inserted(object sender, SqlDataSourceStatusEventArgs e) {
        // Autoincremented primary key case
        OleDbConnection connection = (OleDbConnection)e.Command.Connection;
        using(OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", connection)) {
            this.lastInsertedIdList.Add((int)cmd.ExecuteScalar());
        }
    }
    void AppointmentsEntityDataSource_Inserted(object sender, EntityDataSourceChangedEventArgs e) {
        this.lastInsertedIdList.Add((e.Entity as DevExpress.Web.Demos.MedicsSchedulingDb_MedicalAppointments).ID);
    }
    void ControlOnAppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
        // Autoincremented primary key case
        int count = e.Objects.Count;
        System.Diagnostics.Debug.Assert(count == this.lastInsertedIdList.Count);        
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        for(int i = 0; i < count; i++) {
            Appointment apt = (Appointment)e.Objects[i];
            int appointmentId = this.lastInsertedIdList[i];
            storage.SetAppointmentId(apt, appointmentId);
        }

        this.lastInsertedIdList.Clear();
    }
}
public class ObjectDataSourceRowInsertionProvider {
    List<Object> lastInsertedIdList = new List<object>();

    public void ProvideRowInsertion(ASPxScheduler control, ObjectDataSource dataSource) {
        control.AppointmentsInserted += new PersistentObjectsEventHandler(control_AppointmentsInserted);
        control.AppointmentCollectionCleared += new EventHandler(control_AppointmentCollectionCleared);
        dataSource.Inserted += new ObjectDataSourceStatusEventHandler(dataSource_Inserted);
    }

    void control_AppointmentCollectionCleared(object sender, EventArgs e) {
        this.lastInsertedIdList.Clear();
    }
    void dataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
        this.lastInsertedIdList.Add(e.ReturnValue);
    }
    void control_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        int count = e.Objects.Count;
        System.Diagnostics.Debug.Assert(count == this.lastInsertedIdList.Count);
        for(int i = 0; i < count; i++) { //B184873
            Appointment apt = (Appointment)e.Objects[i];
            storage.SetAppointmentId(apt, this.lastInsertedIdList[i]);    
        }
        this.lastInsertedIdList.Clear();
    }
}
public class DataSourceControlRowInsertionProvider {
    List<Object> lastInsertedIdList = new List<object>();

    public void ProvideRowInsertion(ASPxScheduler control, DevExpress.Web.DemoUtils.SchedulerDemoDataSource dataSource) {
        control.AppointmentRowInserting += new ASPxSchedulerDataInsertingEventHandler(ControlOnAppointmentRowInserting);
        control.AppointmentRowInserted += new ASPxSchedulerDataInsertedEventHandler(ControlOnAppointmentRowInserted);
        control.AppointmentsInserted += new PersistentObjectsEventHandler(control_AppointmentsInserted);
        control.AppointmentCollectionCleared += new EventHandler(control_AppointmentCollectionCleared);
    }

    void control_AppointmentCollectionCleared(object sender, EventArgs e) {
        this.lastInsertedIdList.Clear();
    }
    void ControlOnAppointmentRowInserting(object sender, ASPxSchedulerDataInsertingEventArgs e) {
        this.lastInsertedIdList.Add(e.GetHashCode());
    }
    void ControlOnAppointmentRowInserted(object sender, ASPxSchedulerDataInsertedEventArgs e) {
        e.KeyFieldValue = this.lastInsertedIdList[this.lastInsertedIdList.Count - 1];
    }
    void control_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        int count = e.Objects.Count;
        System.Diagnostics.Debug.Assert(count == this.lastInsertedIdList.Count);
        for(int i = 0; i < count; i++) {
            Appointment apt = (Appointment)e.Objects[i];
            storage.SetAppointmentId(apt, this.lastInsertedIdList[i]);
        }
        this.lastInsertedIdList.Clear();
    }
}

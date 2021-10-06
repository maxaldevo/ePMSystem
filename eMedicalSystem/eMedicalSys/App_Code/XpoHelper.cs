using System;
using System.Threading;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;


public static class XpoHelper {
    public static Session GetNewSession() {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork() {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object _lockObject = new object();

    static object _dataLayer;
    static IDataLayer DataLayer {
        get {
            if(_dataLayer == null) {
                lock(_lockObject) {
                    if(Thread.VolatileRead(ref _dataLayer) == null) {
                        Thread.VolatileWrite(ref _dataLayer, CreateDataLayer());
                    }
                }
            }
            return (IDataLayer)_dataLayer;
        }
    }

    static IDataLayer CreateDataLayer() {
        XpoDefault.Session = null;
        XPDictionary dict = new ReflectionDictionary();
        // Note: in a real application, use the AutoCreateOption.SchemaAlreadyExists option
        IDataStore store = XpoDefault.GetConnectionProvider(GetConnectionString(), AutoCreateOption.DatabaseAndSchema);
        dict.GetDataStoreSchema(typeof(XPOData.Task), typeof(XPOData.Employee));
        IDataLayer dl = new ThreadSafeDataLayer(dict, store);
        return dl;
    }

    static string GetConnectionString() {
        return AccessConnectionProviderMultiUserThreadSafe.GetConnectionString(HttpContext.Current.Server.MapPath("~\\App_Data\\XPOBoundMode.mdb"), String.Empty, String.Empty);
    }
}

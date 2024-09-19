//using SQLite;

//namespace ModernUO_API.Helpers;

//public static class DatabaseHelper
//{
//    private static readonly string _localAppPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//    private static readonly string _appPath = Path.Combine(_localAppPath, "ModernUO", "ServerAccounts");

//    private static readonly string _accounts = Path.Combine(_appPath, "Accounts.db");

//    public static void InitializeFolder()
//    {
//        if (!Directory.Exists(_appPath)) Directory.CreateDirectory(_appPath);
//    }

//    #region Database CRUD

//    #region Create

//    public static void Insert<T>(T item)
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.CreateTable<T>();
//        connection.Insert(item);
//    }

//    public static void Insert<T>(List<T> items)
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.CreateTable<T>();
//        connection.InsertAll(items);
//    }

//    #endregion Create

//    #region Read

//    public static List<T> Read<T>() where T : new()
//    {
//        SQLiteConnectionString connectionString = new(_accounts, openFlags: SQLiteOpenFlags.ReadOnly | SQLiteOpenFlags.SharedCache, storeDateTimeAsTicks: true);
//        using SQLiteConnection connection = new(connectionString);
//        return [.. connection.Table<T>()];
//    }

//    #endregion Read

//    #region Update

//    public static void Update<T>(T item)
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.CreateTable<T>();
//        connection.Update(item);
//    }

//    public static void Update<T>(List<T> items)
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.CreateTable<T>();
//        connection.UpdateAll(items);
//    }

//    #endregion Update

//    #region Delete

//    public static void Delete<T>(T item)
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.CreateTable<T>();
//        connection.Delete(item);
//    }

//    public static void DropTable<T>() where T : new()
//    {
//        using SQLiteConnection connection = new(_accounts);
//        connection.DropTable<T>();
//    }

//    #endregion Delete

//    #endregion Database CRUD
//}
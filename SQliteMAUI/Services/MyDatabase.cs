using System;
using SQLite;
using SQliteMAUI.Models;

namespace SQliteMAUI.Services
{
    public sealed class MyDatabase
    {
        /// <summary>
        /// nombre de la base de datos
        /// y su extension debe ser .db3
        /// </summary>
        private const string DbName = "contacts.db3";
        public SQLiteConnection? Database { get; private set; }
        private static object lockObj = new object();

        private MyDatabase()
		{
		}

        private static MyDatabase? _instance = null;

        public static MyDatabase Instance
        {
            get
            {
                //usamos lock para volver
                //nuestro singleton thread-safe
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new MyDatabase();
                        _instance.Initialize();
                    }

                    return _instance;
                }
            }
        }

        public void Initialize()
        {
            //creamos la base de datos solo una vez
            //verificamos que este nula
            if (Database == null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, DbName);

                //creamos la base de datos
                //No asincrona
                Database = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

                //tenemos que agregar las tablas que
                //que vayamos a utilizar
                var tables = new List<Type>
                {
                    typeof(MyContact)
                };

                //creamos las tablas sino existen
                Database.CreateTables(CreateFlags.None, tables.ToArray());
            }
        } 
    }
}


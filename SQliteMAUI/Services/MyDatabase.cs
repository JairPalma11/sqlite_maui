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
        private static object lockObject = new object();

        private MyDatabase()
		{
		}

        private static MyDatabase? _instance = null;


        public static MyDatabase GetInstance()
        {
            //usamos lock para volver
            //nuestro singleton thread-safe
            lock (lockObject)
            {
                if (_instance == null)
                {
                    _instance = new MyDatabase();
                }

                return _instance;
            }
        }

        public async Task Initialize()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, DbName);

            var database = new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            //tenemos que agregar las tablas que
            //que vayamos a utilizar
            var tables = new List<Type>
            {
                typeof(MyContact)
            };
            await database.CreateTablesAsync(CreateFlags.None, tables.ToArray());
        } 
    }
}

